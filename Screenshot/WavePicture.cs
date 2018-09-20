using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Screenshot
{
    class WavePicture : PictureBox
    {
        private Wave wave;

        public new Image Image
        {
            get { return base.Image; }
            set
            {
                base.Image = value;
                wave = new Wave(this.Image, this);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.X > 0 && e.X < this.Width && e.Y > 0 && e.Y < this.Height)
                wave.DropWater(e.X, e.Y, 1, 100);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (e.X > 0 && e.X < this.Width && e.Y > 0 && e.Y < this.Height)
                wave.DropWater(e.X, e.Y, 5, 750);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (wave != null && wave.Image != null)
            {
                wave.Image.Release();
                pe.Graphics.DrawImage(wave.Image.Bitmap, 0, 0, wave.Image.Width(), wave.Image.Height());
            }
        }
    }

    class Wave
    {
        public Wave(Image img, Control ctl)
        {
            this.img = img;
            this.ctl = ctl;
            this.tmr = new Timer();
            this.tmr.Interval = 15;
            this.tmr.Tick += new EventHandler(tmr_Tick);

            this.width = this.img.Width;
            this.height = this.img.Height;
            this.waveWeight = new int[width, height, 2];

            this.CreateBitmap();
            this.tmr.Start();
        }

        void tmr_Tick(object sender, EventArgs e)
        {
            if (_image.IsLocked()) return;
            tmr.Stop();
            PaintWater();
            tmr.Start();
        }

        private int width = 0;

        private int height = 0;

        private int bits = 4;
        private int[, ,] waveWeight;

        private FastBitmap _image = null;

        public int currentWeightBuffer = 0;
        public int newWeightBuffer = 0;
        private byte[] _bitmapOriginalBytes;
        private Random _r = new Random();
        private Timer tmr;

        public FastBitmap Image
        {
            get { return _image; }
        }

        private Image img;
        private Control ctl;

        public void CreateBitmap()
        {
            _image = new FastBitmap((Bitmap)(this.img).Clone(), bits);
            _bitmapOriginalBytes = new byte[bits * _image.Width() * _image.Height()];
            _image.LockBits();
            Marshal.Copy(_image.Data().Scan0, _bitmapOriginalBytes, 0, _bitmapOriginalBytes.Length);
            _image.Release();
        }

        public void DropWater(int x, int y, int radius, int weight)
        {
            long _distance;
            int _x;
            int _y;
            Single _ratio;

            _ratio = (Single)((Math.PI / (Single)radius));

            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    _x = x + i;
                    _y = y + j;
                    if ((_x >= 0) && (_x <= width - 1) && (_y >= 0) && (_y <= height - 1))
                    {
                        _distance = (long)Math.Sqrt(i * i + j * j);
                        if (_distance <= radius)
                        {
                            waveWeight[_x, _y, currentWeightBuffer] = (int)(weight * Math.Cos((Single)_distance * _ratio));
                        }
                    }
                }
            }
        }

        private void PaintWater()
        {
            newWeightBuffer = (currentWeightBuffer + 1) % 2;
            _image.LockBits();
            byte[] _bufferBits = new byte[bits * _image.Width() * _image.Height()];
            Marshal.Copy(_image.Data().Scan0, _bufferBits, 0, _bufferBits.Length);

            int _offX, _offY;

            for (int _x = 0; _x < width; _x++)
            {
                for (int _y = 0; _y < height; _y++)
                {
                    unchecked
                    {
                        waveWeight[_x, _y, newWeightBuffer] = ((
                            (_x > 0 ? waveWeight[_x - 1, _y, currentWeightBuffer] : 0) +
                            (_x > 0 && _y > 0 ? waveWeight[_x - 1, _y - 1, currentWeightBuffer] : 0) +
                            (_y > 0 ? waveWeight[_x, _y - 1, currentWeightBuffer] : 0) +
                            (_x < width - 1 && _y > 0 ? waveWeight[_x + 1, _y - 1, currentWeightBuffer] : 0) +
                            (_x < width - 1 ? waveWeight[_x + 1, _y, currentWeightBuffer] : 0) +
                            (_x < width - 1 && _y < height - 1 ? waveWeight[_x + 1, _y + 1, currentWeightBuffer] : 0) +
                            (_y < height - 1 ? waveWeight[_x, _y + 1, currentWeightBuffer] : 0) +
                            (_x > 0 && _y < height - 1 ? waveWeight[_x - 1, _y + 1, currentWeightBuffer] : 0)) >> 2)
                            - waveWeight[_x, _y, newWeightBuffer];
                    }

                    waveWeight[_x, _y, newWeightBuffer] -= (waveWeight[_x, _y, newWeightBuffer] >> 4);

                    _offX = ((_x > 0 ? waveWeight[_x - 1, _y, newWeightBuffer] : 0) - (_x < width - 1 ? waveWeight[_x + 1, _y, newWeightBuffer] : 0)) >> 3;
                    _offY = ((_y > 0 ? waveWeight[_x, _y - 1, newWeightBuffer] : 0) - (_y < height - 1 ? waveWeight[_x, _y + 1, newWeightBuffer] : 0)) >> 3;

                    if ((_offX != 0) || (_offY != 0))
                    {
                        if (_x + _offX <= 1) _offX = -_x;
                        if (_x + _offX >= width - 1) _offX = width - _x - 1;
                        if (_y + _offY <= 1) _offY = -_y;
                        if (_y + _offY >= height - 1) _offY = height - _y - 1;
                    }
                    _bufferBits[bits * (_x + _y * width) + 0] = _bitmapOriginalBytes[bits * (_x + _offX + (_y + _offY) * width) + 0];
                    _bufferBits[bits * (_x + _y * width) + 1] = _bitmapOriginalBytes[bits * (_x + _offX + (_y + _offY) * width) + 1];
                    _bufferBits[bits * (_x + _y * width) + 2] = _bitmapOriginalBytes[bits * (_x + _offX + (_y + _offY) * width) + 2];
                    _bufferBits[bits * (_x + _y * width) + 3] = _bitmapOriginalBytes[bits * (_x + _offX + (_y + _offY) * width) + 3];
                }
            }
            Marshal.Copy(_bufferBits, 0, _image.Data().Scan0, _bufferBits.Length);
            currentWeightBuffer = newWeightBuffer;
            ctl.Invalidate();
        }
    }

    public unsafe class FastBitmap
    {

        public struct PixelData
        {
            public byte blue;
            public byte green;
            public byte red;
            public byte alpha;
        }

        Bitmap Subject;
        int SubjectWidth;
        BitmapData bitmapData = null;
        Byte* pBase = null;
        bool isLocked = false;
        int _bits = 0;

        public FastBitmap(Bitmap SubjectBitmap, int bits)
        {
            this.Subject = SubjectBitmap;
            _bits = bits;
            try
            {
                //LockBits();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Release()
        {
            try
            {
                UnlockBits();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Bitmap Bitmap
        {
            get
            {
                return Subject;
            }
        }

        public void SetPixel(int X, int Y, Color Colour)
        {
            try
            {
                PixelData* p = PixelAt(X, Y);
                p->red = Colour.R;
                p->green = Colour.G;
                p->blue = Colour.B;
            }
            catch (AccessViolationException ave)
            {
                throw (ave);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Color GetPixel(int X, int Y)
        {
            try
            {
                PixelData* p = PixelAt(X, Y);
                return Color.FromArgb((int)p->red, (int)p->green, (int)p->blue);
            }
            catch (AccessViolationException ave)
            {
                throw (ave);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Width() { return Subject.Width; }
        public int Height() { return Subject.Height; }
        public bool IsLocked() { return isLocked; }
        public BitmapData Data() { return bitmapData; }

        public void LockBits()
        {
            if (isLocked) return;
            try
            {
                GraphicsUnit unit = GraphicsUnit.Pixel;
                RectangleF boundsF = Subject.GetBounds(ref unit);
                Rectangle bounds = new Rectangle((int)boundsF.X,
                    (int)boundsF.Y,
                    (int)boundsF.Width,
                    (int)boundsF.Height);

                SubjectWidth = (int)boundsF.Width * sizeof(PixelData);
                if (SubjectWidth % _bits != 0)
                {
                    SubjectWidth = _bits * (SubjectWidth / _bits + 1);
                }
                if (_bits == 3)
                    bitmapData = Subject.LockBits(bounds, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                else
                    bitmapData = Subject.LockBits(bounds, ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
                pBase = (Byte*)bitmapData.Scan0.ToPointer();
            }
            finally
            {
                isLocked = true;
            }
        }

        private PixelData* PixelAt(int x, int y)
        {
            return (PixelData*)(pBase + y * SubjectWidth + x * sizeof(PixelData));
        }

        private void UnlockBits()
        {
            if (bitmapData == null) return;
            Subject.UnlockBits(bitmapData);
            bitmapData = null;
            pBase = null;
            isLocked = false;
        }
    }
}
