using System;
using System.Xml.Serialization;

namespace ResponseChecker
{
    /// <summary>
    /// Stores the name and value of a parameter for use with headers, querystring or post parameters
    /// </summary>
    [Serializable]
    public class Parameter
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("Value")]
        public string Value { get; set; }
    }
}
