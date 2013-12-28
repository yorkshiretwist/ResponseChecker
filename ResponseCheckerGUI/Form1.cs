using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using ResponseChecker;
using CreateTests;

namespace ResponseCheckerGUI
{
    public partial class Form1 : Form
    {
        #region Fields

        /// <summary>
        /// The title of the current test file
        /// </summary>
        private string testFileTitle;

        /// <summary>
        /// The index of the current test
        /// </summary>
        private int currentTestIndex;

        /// <summary>
        /// The index of the current test check
        /// </summary>
        private int currentTestCheckIndex;

        /// <summary>
        /// The current row index 
        /// </summary>
        private int rowIndex;

        /// <summary>
        /// The response checker instance
        /// </summary>
        private ResponseChecker.ResponseChecker responseChecker;

        #endregion

        public Form1()
        {
            InitializeComponent();
            //TestCreator creator = new TestCreator();
            //File.WriteAllText("D:\\projects\\ResponseChecker\\SampleTests.xml", creator.CreateSampleTests());
            responseChecker = new ResponseChecker.ResponseChecker();
        }

        /// <summary>
        /// When the start button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            cbFailedOnly.Visible = false;

            if (!responseChecker.Tests.Any())
            {
                ShowError("There are no tests in this test file. Please try again.");
                return;
            }

            Thread workerThread = new Thread(responseChecker.Run);
            workerThread.Start();
        }

        /// <summary>
        /// When the load test button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                responseChecker.Load(openFileDialog.FileName);

                if (responseChecker.Error == Error.None)
                {
                    ShowTests();
                    startButton.Enabled = true;
                }
            }
        }

        #region UI

        /// <summary>
        /// Sets the status of the current check for the current test
        /// </summary>
        /// <param name="status"></param>
        private void SetCheckStatus(CheckStatus status)
        {
            string message = "-";
            Color foreColor = Color.Gray;
            Color backColor = Color.White;

            switch (status)
            {
                case CheckStatus.InProgress:
                    message = "In progress...";
                    foreColor = Color.OrangeRed;
                    break;
                case CheckStatus.Succeeded:
                    message = "Passed";
                    foreColor = Color.Green;
                    break;
                case CheckStatus.Failed:
                    message = "Failed";
                    foreColor = Color.White;
                    backColor = Color.Firebrick;
                    break;
            }

            DataGridViewRow row = GetCheckRow(currentTestIndex, currentTestCheckIndex);
            if (row == null)
                return;

            MethodInvoker action = () =>
                {
                    row.Cells["checkStatus"].Value = message;
                    row.DefaultCellStyle.ForeColor = foreColor;
                    row.DefaultCellStyle.BackColor = backColor;
                };
            testGrid.BeginInvoke(action);
        }

        /// <summary>
        /// Returns the DataGridViewRow with the tag based on the given indexes
        /// </summary>
        /// <remarks>
        /// Yes, it would be better to use LINQ for this, but there isn't an easy way to get an IEnumerable of a DataGridViewRowCollection
        /// </remarks>
        /// <param name="testIndex"></param>
        /// <param name="checkIndex"></param>
        /// <returns></returns>
        private DataGridViewRow GetCheckRow(int testIndex, int checkIndex)
        {
            foreach (DataGridViewRow row in testGrid.Rows)
            {
                if (row.Tag != null && row.Tag.ToString() == string.Format("test_{0}_{1}", testIndex, checkIndex))
                    return row;
            }
            return null;
        }

        /// <summary>
        /// Shows the loaded tests
        /// </summary>
        private void ShowTests()
        {
            if (responseChecker.Tests == null || !responseChecker.Tests.Any())
            {
                ShowError("No tests loaded. Please choose a valid test file.");
                return;
            }

            // set up the datagrid
            foreach (Test test in responseChecker.Tests)
            {
                AddTestGridRows(test);
            }
        }

        /// <summary>
        /// Adds the rows for the given test
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        private void AddTestGridRows(Test test)
        {
            // increment the test index
            currentTestIndex++;

            // set the text check index to 0
            currentTestCheckIndex = 0;

            // test URL
            if (string.IsNullOrWhiteSpace(test.Url))
            {
                rowIndex = testGrid.Rows.Add();
                currentTestCheckIndex++;
                AddRow(testGrid.Rows[rowIndex], currentTestIndex, "URL for test not set");
                return;
            }

            // the index should only show for the main test check, i.e.e the URL responding OK
            rowIndex = testGrid.Rows.Add();
            currentTestCheckIndex++;
            AddRow(testGrid.Rows[rowIndex], currentTestIndex, string.Format("URL responds: {0}", test.Url));

            // timeout
            rowIndex = testGrid.Rows.Add();
            currentTestCheckIndex++;
            AddRow(testGrid.Rows[rowIndex], null, string.Format("Timeout: {0} milliseconds", test.Timeout));

            // checks
            foreach (Check check in test.Checks)
            {
                rowIndex = testGrid.Rows.Add();
                currentTestCheckIndex++;
                AddRow(testGrid.Rows[rowIndex], null, check.Description);
            }
        }

        /// <summary>
        /// Adds an individual row for the test datagridview
        /// </summary>
        /// <param name="testIndex"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        private void AddRow(DataGridViewRow row, int? testIndex, string description)
        {
            if (testIndex.HasValue)
                row.Cells["testIndex"].Value = testIndex.Value;

            row.Cells["checkDescription"].Value = description;

            row.Tag = string.Format("test_{0}_{1}", currentTestIndex, currentTestCheckIndex);
        }

        /// <summary>
        /// SHows an error message
        /// </summary>
        /// <param name="message"></param>
        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion
    }
}
