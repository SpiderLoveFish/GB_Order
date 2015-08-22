using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBERP.Model
{
    public class TextValuePair
    {
        public TextValuePair()
        {

        }
        public TextValuePair(string text, string value)
        {
            Text = text;
            Value = value;
        }
        public TextValuePair(string text, string value, string tag)
        {
            Text = text;
            Value = value;
            Tag = tag;
        }
        public string Text { get; set; }
        public string Value { get; set; }
        public string Tag { get; set; }


    }
}
