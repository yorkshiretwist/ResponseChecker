using System;
using System.Xml.Serialization;

namespace ResponseChecker
{
    /// <summary>
    /// Check the response headers contains the given name, optionally containing the given value
    /// </summary>
    [Serializable]
    public class HeadersContains : Check
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("Value")]
        public string Value { get; set; }
    }
}
