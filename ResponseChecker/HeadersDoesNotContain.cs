using System;
using System.Xml.Serialization;

namespace ResponseChecker
{
    /// <summary>
    /// Checks the response headers does not contain the given name, or optionally has the given name but it does not contain the given value
    /// </summary>
    [Serializable]
    public class HeadersDoesNotContain : Check
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("Value")]
        public string Value { get; set; }
    }
}
