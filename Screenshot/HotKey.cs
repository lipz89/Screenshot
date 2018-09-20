using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Screenshot
{
    public delegate void HotkeyEventHandler(int HotKeyID);
    public class Hotkey : IMessageFilter
    {
        Hashtable keyIDs = new Hashtable();
        IntPtr hWnd;

        public event HotkeyEventHandler OnHotkey;
        [DllImport("user32.dll")]
        public static extern UInt32 RegisterHotKey(IntPtr hWnd, UInt32 id, UInt32 fsModifiers, UInt32 vk);

        [DllImport("user32.dll")]
        public static extern UInt32 UnregisterHotKey(IntPtr hWnd, UInt32 id);

        [DllImport("kernel32.dll")]
        public static extern UInt32 GlobalAddAtom(String lpString);

        [DllImport("kernel32.dll")]
        public static extern UInt32 GlobalDeleteAtom(UInt32 nAtom);

        public Hotkey(IntPtr hWnd)
        {
            this.hWnd = hWnd;
            Application.AddMessageFilter(this);
        }

        public int RegisterHotkey(Keys key)
        {
            KeyFlags keyFlags = KeyFlags.MOD_NONE;
            if ((key & Keys.Shift) == Keys.Shift)
            {
                keyFlags = keyFlags | KeyFlags.MOD_SHIFT;
            }
            if ((key & Keys.Control) == Keys.Control)
            {
                keyFlags = keyFlags | KeyFlags.MOD_CONTROL;
            }
            if ((key & Keys.Alt) == Keys.Alt)
            {
                keyFlags = keyFlags | KeyFlags.MOD_ALT;
            }
            key = key & Keys.KeyCode;
            UInt32 hotkeyid = GlobalAddAtom(System.Guid.NewGuid().ToString());
            RegisterHotKey((IntPtr)hWnd, hotkeyid, (UInt32)keyFlags, (UInt32)key);
            keyIDs.Add(hotkeyid, hotkeyid);
            return (int)hotkeyid;
        }

        public void UnregisterHotkeys()
        {
            //Application.RemoveMessageFilter(this);
            foreach (UInt32 key in keyIDs.Values)
            {
                UnregisterHotKey(hWnd, key);
                GlobalDeleteAtom(key);
            }
            keyIDs.Clear();
        }

        public bool PreFilterMessage(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == 0x312)
            {
                if (OnHotkey != null)
                {
                    foreach (UInt32 key in keyIDs.Values)
                    {
                        if ((UInt32)m.WParam == key)
                        {
                            OnHotkey((int)m.WParam);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }

    public enum KeyFlags
    {
        MOD_NONE = 0x0,
        MOD_ALT = 0x1,
        MOD_CONTROL = 0x2,
        MOD_SHIFT = 0x4,
        MOD_WIN = 0x8
    }

    public class HotKeyInfo
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private Keys oldKeys;

        public Keys OldKeys
        {
            get { return oldKeys; }
            set { oldKeys = value; }
        }
        private Keys newKeys;

        public Keys NewKeys
        {
            get { return newKeys; }
            set { newKeys = value; }
        }
        private string mark;

        public string Mark
        {
            get { return mark; }
            set { mark = value; }
        }
    }
}
