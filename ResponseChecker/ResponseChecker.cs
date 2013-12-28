using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ResponseChecker
{
    public class ResponseChecker
    {
        #region Private fields

        /// <summary>
        /// The XML document containing the tests for this response checker instance
        /// </summary>
        private XmlDocument _xmlDocument;

        #endregion

        #region Public properties

        /// <summary>
        /// The tests for this response checker instance
        /// </summary>
        public IList<Test> Tests;

        /// <summary>
        /// The title for these tests
        /// </summary>
        public string Title;

        /// <summary>
        /// The error raised by this response checker instance
        /// </summary>
        public Error Error;

        /// <summary>
        /// The exception raised by this response checker instance
        /// </summary>
        public Exception Exception;

        #endregion

        #region Public methods

        /// <summary>
        /// Load the tests in the given file
        /// </summary>
        public bool Load(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Error = Error.FileNotFound;
                return false;
            }

            string text = File.ReadAllText(fileName);

            if (string.IsNullOrWhiteSpace(text))
            {
                Error = Error.FileEmpty;
                return false;
            }

            try
            {
                ParseTestFileXml(text);
            }
            catch (Exception ex)
            {
                Error = Error.FileCouldNotBeParsed;
                return false;
            }

            if (!Tests.Any())
            {
                Error = Error.NoTestsFound;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Run the tests
        /// </summary>
        public void Run()
        {
            try
            {
                foreach (Test test in Tests)
                {
                    RunTest(test);
                }
            }
            catch (Exception ex)
            {
                Error = Error.ExceptionRunningTest;
                Exception = ex;
            }
        }

        #endregion

        #region Private methods

        #region Loading tests

        /// <summary>
        /// Parses the XML of a test file to get the tests
        /// </summary>
        /// <param name="text"></param>
        private void ParseTestFileXml(string text)
        {
            _xmlDocument = new XmlDocument();
            _xmlDocument.LoadXml(text);

            Tests = new List<Test>();
            XmlNodeList testNodes = _xmlDocument.SelectNodes("//Test");
            foreach (XmlNode testNode in testNodes)
            {
                Test test = DeserialiseTestNode(testNode);
                if (test != null)
                    Tests.Add(test);
            }

            GetTitle();
        }

        /// <summary>
        /// Gets the title for these tests
        /// </summary>
        private void GetTitle()
        {
            XmlNode testsNode = _xmlDocument.SelectSingleNode("//Tests");
            if (testsNode != null)
            {
                XmlAttribute titleAttribute = testsNode.Attributes.Cast<XmlAttribute>().SingleOrDefault(a => string.Compare(a.Name, "title", true) == 0);
                if (titleAttribute != null)
                    Title = titleAttribute.InnerText;
            }
        }

        /// <summary>
        /// Deserialises a test node and returns the resulting test object
        /// </summary>
        /// <param name="testNode"></param>
        /// <returns></returns>
        private Test DeserialiseTestNode(XmlNode testNode)
        {
            XmlSerializer x = new XmlSerializer(typeof(Test));
            Test test = x.Deserialize(new StringReader(testNode.OuterXml)) as Test;

            if (test == null)
            {
                return null;
            }

            foreach (Check check in test.Checks)
            {
                check.Description = GetCheckDescription(check);
            }

            return test;
        }

        /// <summary>
        /// Returns a human-readable description for the current check
        /// </summary>
        /// <param name="check"></param>
        /// <returns></returns>
        private string GetCheckDescription(Check check)
        {
            if (check is BodyContains)
            {
                BodyContains thisCheck = check as BodyContains;
                return string.Format("Body contains '{0}'", thisCheck.Text);
            }
            if (check is BodyDoesNotContain)
            {
                BodyDoesNotContain thisCheck = check as BodyDoesNotContain;
                return string.Format("Body does not contain '{0}'", thisCheck.Text);
            }
            if (check is HeadersContains)
            {
                HeadersContains thisCheck = check as HeadersContains;
                if (string.IsNullOrWhiteSpace(thisCheck.Value))
                {
                    return string.Format("Headers contains item '{0}'", thisCheck.Name);
                }

                return string.Format("Headers contains item '{0}' with value containing '{1}", thisCheck.Name, thisCheck.Value);
            }
            if (check is HeadersDoesNotContain)
            {
                HeadersDoesNotContain thisCheck = check as HeadersDoesNotContain;
                if (string.IsNullOrWhiteSpace(thisCheck.Value))
                {
                    return string.Format("Headers does not contain item '{0}'", thisCheck.Name);
                }

                return string.Format("Headers does not contain item '{0}', or item value does not contain '{1}", thisCheck.Name, thisCheck.Value);
            }
            return "Unknown check";
        }

        #endregion

        #region Running tests

        /// <summary>
        /// Run an individual test
        /// </summary>
        /// <param name="test"></param>
        private void RunTest(Test test)
        {
            test.Status = TestStatus.InProgress;

            try
            {
                using (CookieAwareWebClient client = new CookieAwareWebClient())
                {
                    // handle POST requests
                    if (test.Method.ToUpper() == "POST")
                    {
                        client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    }

                    // set parameters
                    SetHeaders(test, client);
                    NameValueCollection postParameters = GetPostParameters(test);

                    // do the request and get the response
                    byte[] responsebytes = client.UploadValues(test.Url, test.Method, postParameters);
                    string responsebody = Encoding.UTF8.GetString(responsebytes);

                    // run checks
                }
            }
            catch (Exception ex)
            {
                test.Status = TestStatus.ExceptionEncountered;
                test.Exception = ex;
            }
        }

        /// <summary>
        /// Sets any headers on the client
        /// </summary>
        /// <param name="test"></param>
        /// <param name="client"></param>
        private void SetHeaders(Test test, CookieAwareWebClient client)
        {
            if (test.Headers == null || !test.Headers.Any())
                return;

            foreach (Parameter param in test.Headers)
            {
                client.Headers.Add(param.Name, param.Value);
            }
        }

        /// <summary>
        /// Gets any POST parameters as a NameValueCollection
        /// </summary>
        /// <param name="test"></param>
        private NameValueCollection GetPostParameters(Test test)
        {
            if (test.PostParameters == null || !test.PostParameters.Any())
                return null;

            NameValueCollection parameters = new NameValueCollection();
            foreach (Parameter param in test.Headers)
            {
                parameters.Add(param.Name, param.Value);
            }

            return parameters;
        }

        #endregion

        #endregion
    }
}
