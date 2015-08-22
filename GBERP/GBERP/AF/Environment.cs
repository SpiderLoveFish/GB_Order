using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBERP.AF
{
    public class Environment
    {
        public static string AccessToken { get { return "GBERP"; } }
        public static Model.Identity Identity { get; set; }
        public static string FactoryID { get; set; }

        private static int _pageID = -1;
        public static int GetNewPageID()
        {
            return ++_pageID;
        }
    }
}
