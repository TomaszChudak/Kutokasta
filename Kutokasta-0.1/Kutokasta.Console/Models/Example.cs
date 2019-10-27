using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kutokasta.Console.Models
{
    [DataContract]
    public class Example
    {
        [DataMember(Name = "input")] public List<int> Input { get; set; }

        [DataMember(Name = "output")] public int Output { get; set; }
    }
}