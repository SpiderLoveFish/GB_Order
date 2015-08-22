using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBERP.AF
{
    public class ResourceFile
    {
        private static Dictionary<string, string> _resourcePath;
        private const string _resourceFilePrefix = "pack://application:,,,/GBERP;component/";
        public static string MapPath(string uri)
        {
            return _resourceFilePrefix + uri;
        }
        /// <summary>
        /// 将虚拟路径名转换为物理文件路径名
        /// </summary>
        /// <param name="fullTypeName">一个ViewModel的虚拟路径(即类型全名)</param>
        /// <param name="catagoryName">XML文件的类型名(如DefaultValue,或Ribbon)</param>
        /// <returns></returns>
        public static string MapXMLPath(string fullTypeName, string catagoryName)
        {
            var path = fullTypeName.Substring("GBERP.ViewModel".Length).Replace(".", "/") + ".xml";
            return MapPath("XML/" + catagoryName + path);
        }

        public static bool Exists(string path)
        {
            if (string.IsNullOrEmpty(path) || path.Length <= _resourceFilePrefix.Length)
                return false;
            path = path.Substring(_resourceFilePrefix.Length).ToLower();
            if(_resourcePath==null)
            {
                _resourcePath = new Dictionary<string, string>();
                var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                var resourceName = assembly.GetName().Name + ".g";
                var resourceManager = new System.Resources.ResourceManager(resourceName, assembly);
                try
                {
                    var resourceSet = resourceManager.GetResourceSet(culture, true, true);
                    foreach (System.Collections.DictionaryEntry resource in resourceSet)
                    {
                        _resourcePath.Add(resource.Key.ToString(), "");
                    }
                }
                finally
                {
                    resourceManager.ReleaseAllResources();
                }
            }

            return _resourcePath.ContainsKey(path);
        }
    }
}
