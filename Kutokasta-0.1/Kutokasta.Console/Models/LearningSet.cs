using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kutokasta.Console.Models
{
    [DataContract]
    public class LearningSet
    {
        [DataMember(Name = "name")] public string Name { get; set; }

        [DataMember(Name = "examples")] public IEnumerable<Example> Examples { get; set; }
    }
}