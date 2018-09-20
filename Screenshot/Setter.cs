using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace Screenshot
{
    class Setter
    {
        private static Setter useSet;

        public static Setter UseSet
        {
            get
            {
                return Setter.useSet;
            }
        }

        private Setter() { }

        private string baseFolder = AppDomain.CurrentDomain.BaseDirectory;
        private bool saveToCliboard = true;
        private bool saveToDisk = true;
        private bool sendToApp = false;
        private bool stopScreen = false;
        private Keys keysScreenshot = Keys.Alt | Keys.Shift | Keys.A;
        private string sendAppName = "mspaint.exe";

        public bool SendToApp
        {
            get { return sendToApp; }
            set { sendToApp = value; }
        }

        public string SendAppName
        {
            get { return sendAppName; }
            set { sendAppName = value; }
        }

        public bool StopScreen
        {
            get { return stopScreen; }
            set { stopScreen = value; }
        }

        public string BaseFolder
        {
            get
            {
                if (Directory.Exists(baseFolder))
                    return baseFolder;
                else
                    return AppDomain.CurrentDomain.BaseDirectory;
            }
            set { baseFolder = value; }
        }

        public bool SaveToCliboard
        {
            get { return saveToCliboard; }
            set { saveToCliboard = value; }
        }

        public bool SaveToDisk
        {
            get { return saveToDisk; }
            set { saveToDisk = value; }
        }

        public Keys KeysScreenshot
        {
            get { return keysScreenshot; }
            set { keysScreenshot = value; }
        }

        public static void LoadSet()
        {
            FileStream fs = File.Open(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\screenshot.ini", FileMode.OpenOrCreate, FileAccess.Read);
            if (fs.Length == 0)
            {
                fs.Close();
                Setter.useSet = new Setter();

                useSet.SaveSet();
            }
            else
            {
                StreamReader sr = new StreamReader(fs);
                Hashtable ht = new Hashtable();

                string s = sr.ReadToEnd();
                if (!string.IsNullOrEmpty(s))
                {
                    string[] ss = s.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string str in ss)
                    {
                        string[] sstr = str.Split('=');
                        if (sstr.Length == 2)
                            ht.Add(sstr[0], sstr[1]);
                    }
                }
                sr.Close();
                fs.Close();

                Setter.useSet = new Setter();
                if (ht.ContainsKey("basefolder"))
                {
                    Setter.useSet.BaseFolder = ht["basefolder"].ToString();
                }
                if (ht.ContainsKey("sendapp"))
                {
                    Setter.useSet.sendAppName = ht["sendapp"].ToString();
                }
                if (ht.ContainsKey("savetocliboard"))
                {
                    Setter.useSet.saveToCliboard = Convert.ToBoolean(ht["savetocliboard"].ToString());
                }
                if (ht.ContainsKey("savetodisk"))
                {
                    Setter.useSet.saveToDisk = Convert.ToBoolean(ht["savetodisk"].ToString());
                }
                if (ht.ContainsKey("sendtoapp"))
                {
                    Setter.useSet.sendToApp = Convert.ToBoolean(ht["sendtoapp"].ToString());
                }
                if (ht.ContainsKey("stopScreen"))
                {
                    Setter.useSet.stopScreen = Convert.ToBoolean(ht["stopScreen"].ToString());
                }
                if (ht.ContainsKey("keysscreenshot"))
                {
                    string k = ht["keysscreenshot"].ToString();
                    string[] ks = k.Split('+');
                    Setter.useSet.keysScreenshot = Keys.None;
                    foreach (string key in ks)
                    {
                        Keys nk = (Keys)Enum.Parse(typeof(Keys), key.Trim());
                        Setter.useSet.keysScreenshot = Setter.useSet.keysScreenshot | nk;
                    }
                }
            }
        }

        public void SaveSet()
        {
            FileStream fs = File.Open(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\screenshot.ini", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("{0}={1}", "basefolder", this.baseFolder.ToString());
            sw.WriteLine("{0}={1}", "sendapp", this.sendAppName.ToString());
            sw.WriteLine("{0}={1}", "savetocliboard", this.saveToCliboard.ToString());
            sw.WriteLine("{0}={1}", "savetodisk", this.saveToDisk.ToString());
            sw.WriteLine("{0}={1}", "sendtoapp", this.sendToApp.ToString());
            sw.WriteLine("{0}={1}", "stopScreen", this.stopScreen.ToString());
            sw.WriteLine("{0}={1}", "keysscreenshot", this.keysScreenshot.ToString().Replace(',', '+'));
            sw.Close();
            fs.Close();
        }

        public static string GetKeyString(Keys key)
        {
            string s = "";
            if ((key & Keys.Shift) == Keys.Shift)
            {
                s += "SHIFT + ";
            }
            if ((key & Keys.Control) == Keys.Control)
            {
                s += "CTRL + ";
            }
            if ((key & Keys.Alt) == Keys.Alt)
            {
                s += "ALT + ";
            }
            s += (key & Keys.KeyCode).ToString();
            return s.Trim(' ', '+');
        }
    }
}
