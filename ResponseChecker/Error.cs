using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponseChecker
{
    /// <summary>
    /// Enumeration of the errors that can occur within the ResponseChecker application
    /// </summary>
    public enum Error
    {
        /// <summary>
        /// No error encountered
        /// </summary>
        None,

        /// <summary>
        /// The test XML file could not be found
        /// </summary>
        FileNotFound,

        /// <summary>
        /// The test XML file was empty
        /// </summary>
        FileEmpty,

        /// <summary>
        /// The test XML file could not be parsed
        /// </summary>
        FileCouldNotBeParsed,

        /// <summary>
        /// No tests were found in the XML file
        /// </summary>
        NoTestsFound,

        /// <summary>
        /// There was an exception when running a test
        /// </summary>
        ExceptionRunningTest
    }
}
