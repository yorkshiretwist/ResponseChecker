using System;
using System.Xml.Serialization;

namespace ResponseChecker
{
    /// <summary>
    /// Stores the basic credentials
    /// </summary>
    /// <remarks>
    /// It would have been better to use ICredentials for this, but after 10 minutes trying I couldn't get that
    /// to be serializable, so I did this simple class instead.
    /// </remarks>
    [Serializable]
    public class WebCredentials
    {
        [XmlAttribute("Username")]
        public string Username { get; set; }

        [XmlAttribute("Password")]
        public string Password { get; set; }
    }
}
