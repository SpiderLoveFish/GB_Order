using GBERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GBERP.AF
{
    public class DefaultValue
    {
        private static Dictionary<string, XElement> _cachedFile = new Dictionary<string, XElement>();
        public static ReturnValue<String> GetDefaultValue(string path, string propertyName, List<TextValuePair> list)
        {
            var rv = new ReturnValue<string>();
            XElement root;
            if (_cachedFile.ContainsKey(path))
                root = _cachedFile[path];
            else
            {
                root = XDocument.Load(System.Windows.Application.GetResourceStream(
                    new Uri(ResourceFile.MapXMLPath(path, "DefaultValue"))).Stream).Root;
                _cachedFile.Add(path, root);
            }

            var items = root.Elements("item");
            foreach (var item in items)
            {
                if (item.Attribute("key").Value == propertyName)
                {
                    var ia = item.Attribute("value");
                    if (ia != null)
                    {
                        rv.Output1 = ia.Value;
                        return rv;
                    }
                    ia = item.Attribute("text");
                    if (ia != null)
                    {
                        var li = list.FirstOrDefault(p => p.Text == ia.Value);
                        if (li != null)
                        {
                            rv.Output1 = li.Value;
                            return rv;
                        }
                        else
                        {
                            rv.Result = false;
                            rv.Message = BuildErrorMessage(path, propertyName, "text not found.");
                            return rv;
                        }
                    }
                    ia = item.Attribute("index");
                    if (ia != null)
                    {
                        int idx;
                        if (int.TryParse(ia.Value, out idx))
                        {
                            if (list.Count > idx)
                            {
                                rv.Output1 = list[idx].Value;
                                return rv;
                            }
                            else
                            {
                                rv.Result = false;
                                rv.Message = BuildErrorMessage(path, propertyName, "index out of range.");
                                return rv;
                            }
                        }
                        else
                        {
                            rv.Result = false;
                            rv.Message = BuildErrorMessage(path, propertyName, "index is not an integer.");
                            return rv;
                        }

                    }
                }
            }
            rv.Result = false;
            rv.Message = BuildErrorMessage(path, propertyName, "Property name not found.");
            return rv;
        }

        private static string BuildErrorMessage(string path, string propertyName, string msg)
        {
            return "GetDefaultValue failed of path '" + path + "', property name '" + propertyName + "', error message:" + msg;
        }
    }
}
