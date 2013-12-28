using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResponseChecker;
using System.Xml.Serialization;
using System.IO;

namespace CreateTests
{
    public class TestCreator
    {
        /// <summary>
        /// Creates sample tests so we can check the serialization
        /// </summary>
        public string CreateSampleTests()
        {
            List<Test> tests = new List<Test>();

            // Simple request
            tests.Add(new Test
            {
                Title = "Simple request",
                Url = "http://localhost"
            });

            // Send headers
            tests.Add(new Test
            {
                Title = "Send headers",
                Url = "http://localhost/headertest",
                Method = "POST",
                Timeout = 60000,
                Headers = new List<Parameter>
                    {
                        new Parameter
                            {
                                Name = "header1",
                                Value = "header1value"
                            },
                        new Parameter
                            {
                                Name = "header2",
                                Value = "header2value"
                            }
                    }
            });

            // Send POST parameters
            tests.Add(new Test
            {
                Title = "Send POST parameters",
                Url = "http://localhost/posttest",
                Method = "POST",
                Timeout = 60000,
                PostParameters = new List<Parameter>
                    {
                        new Parameter
                            {
                                Name = "post1",
                                Value = "post1value"
                            },
                        new Parameter
                            {
                                Name = "post2",
                                Value = "post2value"
                            }
                    }
            });

            // Send query string parameters
            tests.Add(new Test
            {
                Title = "Send query string parameters",
                Url = "http://localhost/qstest",
                QuerystringParameters = new List<Parameter>
                    {
                        new Parameter
                            {
                                Name = "qs1",
                                Value = "qs1value"
                            },
                        new Parameter
                            {
                                Name = "qs2",
                                Value = "qs2value"
                            }
                    }
            });

            // Send credentials
            tests.Add(new Test
            {
                Title = "Send credentials",
                Url = "http://localhost/credentialstest",
                Credentials = new WebCredentials
                {
                    Username = "username",
                    Password = "password"
                }
            });

            // Check response body contains
            tests.Add(new Test
            {
                Title = "Check response body contains",
                Url = "http://localhost/responsebodycontainstest",
                Checks = new List<Check>
                {
                    new BodyContains
                    {
                        Text = "text"
                    }
                }
            });

            // Check response body does not contain
            tests.Add(new Test
            {
                Title = "Check response body does not contain",
                Url = "http://localhost/responsebodydoesnotcontaintest",
                Checks = new List<Check>
                {
                    new BodyDoesNotContain
                    {
                        Text = "text"
                    }
                }
            });

            // Check response headers contains
            tests.Add(new Test
            {
                Title = "Check response headers contains",
                Url = "http://localhost/responseheaderscontainstest",
                Checks = new List<Check>
                {
                    new HeadersContains
                    {
                        Name = "header",
                        Value = "value"
                    }
                }
            });

            // Check response headers does not contain
            tests.Add(new Test
            {
                Title = "Check response headers does not contain",
                Url = "http://localhost/responseheadersdoesnotcontaintest",
                Checks = new List<Check>
                {
                    new HeadersDoesNotContain
                    {
                        Name = "header",
                        Value = "value"
                    }
                }
            });

            // Multiple checks
            tests.Add(new Test
            {
                Title = "Multiple checks",
                Url = "http://localhost/multiplecheckstest",
                Checks = new List<Check>
                {
                    new BodyContains
                    {
                        Text = "BodyContains"
                    },
                    new BodyDoesNotContain
                    {
                        Text = "BodyDoesNotContain"
                    },
                    new HeadersContains
                    {
                        Name = "Headers",
                        Value = "Contains"
                    },
                    new HeadersDoesNotContain
                    {
                        Name = "Headers",
                        Value = "DoesNotContain"
                    }
                }
            });

            XmlSerializerNamespaces xns = new XmlSerializerNamespaces();
            xns.Add(string.Empty, string.Empty);
            XmlSerializer x = new XmlSerializer(tests.GetType(), new XmlRootAttribute("Tests"));
            StringWriter s = new StringWriter();
            x.Serialize(s, tests, xns);
            return s.GetStringBuilder().ToString();
        }
    }
}
