using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ConfigInterfacing.Shared
{
    public interface IBaseConfig
    {
        string Name { get; set; }
    }

    [DataContract]
    public class Config : IBaseConfig
    {

        public string Name { get; set; }
        public static object Initialize(string file, Type t)
        {

            var ser = new DataContractJsonSerializer(t);
            using (var stream = File.OpenRead(file))
            {
                
                var result = ser.ReadObject(stream);
                return result;
            }
        }
    }
}
