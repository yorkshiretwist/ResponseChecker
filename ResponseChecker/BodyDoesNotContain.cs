using System;
using System.Xml.Serialization;

namespace ResponseChecker
{
    /// <summary>
    /// Check that the response body does not contain the given text
    /// </summary>
    [Serializable]
    public class BodyDoesNotContain : Check
    {
        [XmlAttribute("Text")]
        public string Text { get; set; }
    }
}
