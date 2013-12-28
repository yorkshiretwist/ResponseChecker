using System;
using System.Net;

namespace ResponseChecker
{
    /// <summary>
    /// A web client that allows the storing of cookies
    /// </summary>
    /// <remarks>
    /// Code from http://stackoverflow.com/questions/11118712/webclient-accessing-page-with-credentials
    /// </remarks>
    public class CookieAwareWebClient : WebClient
    {
        /// <summary>
        /// Time in milliseconds
        /// </summary>
        public int Timeout { get; set; }

        public CookieAwareWebClient()
        {
            CookieContainer = new CookieContainer();
        }

        /// <summary>
        /// The cookie container
        /// </summary>
        public CookieContainer CookieContainer { get; private set; }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = (HttpWebRequest)base.GetWebRequest(address);
            request.CookieContainer = CookieContainer;
            return request;
        }
    }
}
