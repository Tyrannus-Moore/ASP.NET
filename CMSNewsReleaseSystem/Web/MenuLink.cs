using System;
using System.Collections.Generic;
using System.Web;

namespace Maticsoft.Web
{
    public class MenuLink
    {
        private string title;

        private string code;

        private string href;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public string Href
        {
            get { return href; }
            set { href = value; }
        }

    }
}