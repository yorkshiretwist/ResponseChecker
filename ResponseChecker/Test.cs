using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ResponseChecker
{
    /// <summary>
    /// Represents a single test, which may have multiple checks
    /// </summary>
    [Serializable]
    public class Test
    {
        /// <summary>
        /// The title for this test
        /// </summary>
        [XmlAttribute("Title")]
        public string Title { get; set; }

        /// <summary>
        /// The URL to request
        /// </summary>
        [XmlAttribute("Url")]
        public string Url { get; set; }

        /// <summary>
        /// The method to use (GET, POST etc)
        /// </summary>
        [XmlAttribute("Method")]
        public string Method
        {
            get { return _method; }
            set { _method = value; }
        }
        private string _method = "GET";

        /// <summary>
        /// The basic credentials to send
        /// </summary>
        public WebCredentials Credentials { get; set; }

        /// <summary>
        /// The timeout period in milliseconds
        /// </summary>
        [XmlAttribute("Timeout")]
        public int Timeout
        {
            get { return _timeout; }
            set { _timeout = value; }
        }
        private int _timeout = 5000;

        /// <summary>
        /// The headers to send
        /// </summary>
        [XmlElement("Header")]
        public List<Parameter> Headers { get; set; }

        /// <summary>
        /// The querystring parameters to send
        /// </summary>
        [XmlElement("QuerystringParameter")]
        public List<Parameter> QuerystringParameters { get; set; }

        /// <summary>
        /// The post parameters to send
        /// </summary>
        [XmlElement("PostParameter")]
        public List<Parameter> PostParameters { get; set; }

        /// <summary>
        /// The content type to send
        /// </summary>
        [XmlAttribute("ContentType")]
        public string ContentType { get; set; }

        /// <summary>
        /// The list of checks to perform on the response
        /// </summary>
        [XmlArray("Checks")]
        [XmlArrayItem("BodyContains", typeof(BodyContains))]
        [XmlArrayItem("BodyDoesNotContain", typeof(BodyDoesNotContain))]
        [XmlArrayItem("HeadersContains", typeof(HeadersContains))]
        [XmlArrayItem("HeadersDoesNotContain", typeof(HeadersDoesNotContain))]
        public List<Check> Checks { get; set; }

        /// <summary>
        /// The status of this test
        /// </summary>
        [XmlIgnore]
        public TestStatus Status { get; internal set; }

        /// <summary>
        /// The exception raised by this test
        /// </summary>
        [XmlIgnore]
        public Exception Exception { get; internal set; }
    }
}
