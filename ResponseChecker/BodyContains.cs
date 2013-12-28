using System;
using System.Xml.Serialization;

namespace ResponseChecker
{
    /// <summary>
    /// Check that the response body does contain the given text
    /// </summary>
    [Serializable]
    public class BodyContains : Check
    {
        [XmlAttribute("Text")]
        public string Text { get; set; }
    }
}
