using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UIApp
{
    /// <summary>
    /// 系统环境变量
    /// </summary>
    public class ConfigData
    {
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private string srcsafeIni;

        public string SrcsafeIni
        {
            get { return srcsafeIni; }
            set { srcsafeIni = value; }
        }
        private string docsafeIni;

        public string DocsafeIni
        {
            get { return docsafeIni; }
            set { docsafeIni = value; }
        }


    }
}
