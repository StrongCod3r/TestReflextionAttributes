using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestReflextionAttributes.SP
{

    abstract public class DataContext
    {
        private static Dictionary<string, MetadataObject> metaObjects = new Dictionary<string, MetadataObject>();

        public DataContext()
        {

        }

        public static string RegisteObject(Type t)
        {
            var metaObject = GetMetadataObject(t.Name);
            if (metaObject is null)
            {
                metaObject = MetadataUtils.CreateMetadataObject(t);
                metaObjects.Add(metaObject.Name, metaObject);
            }
            return metaObject.Name;
        }

        public static MetadataObject GetMetadataObject(string name)
        {
            MetadataObject result = null;
            metaObjects.TryGetValue(name, out result);
            return result;
        }

        public static void Process<T>(List<T> data) where T: class
        {
            var name = RegisteObject(typeof(T));
            var metaObject = GetMetadataObject(name);

            Console.WriteLine(metaObject.SPName);
            Console.WriteLine("=====================================");
            foreach (var d in data)
            {
                foreach (var prop in metaObject.Properties)
                {
                    Console.WriteLine($"{prop.SPDisplayName ?? prop.Name}: {d.GetPropValue(prop.Name)}");
                }
                Console.WriteLine("------------------------");
            }
        }
    }
}
