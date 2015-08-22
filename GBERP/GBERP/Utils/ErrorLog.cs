using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GBERP.Utils
{
    public class ErrorLog
    {
        private static ErrorLog _current;
        public static ErrorLog Current
        {
            get
            {
                if (_current == null)
                    _current = new ErrorLog();
                return _current;
            }
        }

        private const string _fileName = "errorlog.xml";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg">Time stamp will be added automatically</param>
        public void AppendLog(string msg)
        {
            var root = GetRoot();
            root.Add(new XElement("i",
                new XAttribute("time", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")),
                msg));
            root.Save(_fileName);
        }

        private XElement GetRoot()
        {
            XElement root;
            if (System.IO.File.Exists(_fileName))
                root = XDocument.Load(_fileName).Root;
            else
                root = new XElement("ErrorLog");
            return root;
        }
    }
}
    