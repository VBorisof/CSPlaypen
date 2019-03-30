using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace CSPlaypen.IniFiles
{
    public class IniFile
    {
        private string _path;
        private string _exeName = Assembly.GetExecutingAssembly().GetName().Name;

        public IniFile(string IniPath = null)
        {
            _path = $"{AppDomain.CurrentDomain.BaseDirectory}{ IniPath ?? _exeName + ".ini" }";
            //new FileInfo($"{Path.GetFullPath(".")}\\{ IniPath ?? _exeName + ".ini" }").FullName.ToString();
        }


        public string Read(string Key, string Section = null)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? "CSPlaypen", Key, "", RetVal, 255, _path);
            return RetVal.ToString();
        }

        public void Write(string Key, string Value, string Section = null)
        {
            WritePrivateProfileString(Section ?? _exeName, Key, Value, _path);
        }

        public void DeleteKey(string Key, string Section = null)
        {
            Write(Key, null, Section ?? _exeName);
        }

        public void DeleteSection(string Section = null)
        {
            Write(null, null, Section ?? _exeName);
        }

        public bool KeyExists(string Key, string Section = null)
        {
            return Read(Key, Section).Length > 0;
        }


        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);
    }
}
