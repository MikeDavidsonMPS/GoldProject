using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Program
    {
        private static Dictionary<string, object> dict;

        //DICTIONARY ("Key" is the word, "Value" is the Definiton)
        private static void Add(string strKey, object dataType)
        {
            if (!dict.ContainsKey(strKey))
            {
                dict.Add(strKey, dataType);
            }
            else
            {
                dict[strKey] = dataType;
            }
        }

        private static T GetAnyValue<T>(string strKey)
        {
            object obj;
            T retType;

            dict.TryGetValue(strKey, out obj);

            try
            {
                retType = (T)obj;
            }
            catch
            {
                retType = default(T);
            }
            return retType;
        }
        static void Main(string[] args)
        {
            {
                dict = new Dictionary<string, object>();

                Add("pi", 3.14159);
                Add("john", "wayne");

                Console.WriteLine("pi=" + GetAnyValue<double>("pi"));
                Console.WriteLine("john=" + GetAnyValue<string>("john"));

                Console.ReadLine();
            }
        }
    }
}
