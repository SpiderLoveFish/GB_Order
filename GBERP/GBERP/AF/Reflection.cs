using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBERP.AF
{
    public class Reflection
    {
        private static Dictionary<string, Type> _knownTypes = new Dictionary<string, Type>();
        static Reflection()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            foreach (var t in assembly.GetTypes()
                .Where(p => p.Namespace.StartsWith("GBERP")))
            {
                if (t.Name[0] != '<')
                    _knownTypes.Add(t.FullName, t);
            }
        }

        public static object Create(string tn)
        {
            if (_knownTypes.ContainsKey(tn))
                return System.Activator.CreateInstance(_knownTypes[tn]);
            return null;
        }
    }
}
