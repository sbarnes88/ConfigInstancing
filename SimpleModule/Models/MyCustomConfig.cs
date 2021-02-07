using ConfigInterfacing.Shared;
using System.Runtime.Serialization;

namespace SimpleModule.Models
{
    [DataContract]
    public class MyCustomConfig : IBaseConfig
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public TestElement Element { get; set; }
    }

    [DataContract]
    public class TestElement
    {
        [DataMember]
        public int Value { get; set; }
        [DataMember]
        public string FilePath { get; set; }
    }
}
