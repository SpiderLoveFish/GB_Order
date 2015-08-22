using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBERP.Model
{
    public class MenuItem
    {
        public MenuItem()
        {
            ChildNodes = new List<MenuItem>();
        }
        public string MenuID { get; set; }
        public string MenuName { get; set; }
        public string ModuleID { get; set; }
        public string SupMenuID { get; set; }
        public string Url { get; set; }
        public List<MenuItem> ChildNodes { get; set; }

    }
}
