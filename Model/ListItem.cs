using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ListItem
    {
        public ListItem(string text, string value)
        {
            this.Text = text;
            this.Value = value;
        }

        public string Text { get; set; }
        public string Value { get; set; }
    }
}
