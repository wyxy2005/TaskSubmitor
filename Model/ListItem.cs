using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ListItem
    {
        public ListItem()
        { }

        public ListItem(string text, string value)
        {
            this.Text = text;
            this.Value = value;
        }

        public ListItem(string text, string value, string code)
        {
            this.Text = text;
            this.Value = value;
            this.Code = code;
        }

        public string Text { get; set; }
        public string Value { get; set; }
        public string Code { get; set; }
    }
}
