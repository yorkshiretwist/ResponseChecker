using System;
using System.Xml.Serialization;

namespace ResponseChecker
{
    /// <summary>
    /// Base check
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(BodyContains))]
    [XmlInclude(typeof(BodyDoesNotContain))]
    [XmlInclude(typeof(HeadersContains))]
    [XmlInclude(typeof(HeadersDoesNotContain))]
    public class Check
    {
        /// <summary>
        /// The title for this check
        /// </summary>
        [XmlAttribute("Title")]
        public string Title { get; set; }

        /// <summary>
        /// The human-readable description for this check, automatically created
        /// </summary>
        [XmlIgnore]
        public string Description { get; internal set; }

        /// <summary>
        /// The status of this check
        /// </summary>
        [XmlIgnore]
        public CheckStatus Status { get; internal set; }
    }
}
