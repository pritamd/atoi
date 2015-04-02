using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atoiProject
{
    public class unitTestDataObject
    {
        public int m_testCaseId;
        public string m_inputString;
        public int? m_expectedInt;
    }
    public static class unitTesting
    {
        private static unitTestDataObject [] getUnitTestData ()
        {
            unitTestDataObject [] retValue = new unitTestDataObject [22]
            {
                new unitTestDataObject ()  {m_testCaseId = 1, m_inputString = "123", m_expectedInt = 123},  
                new unitTestDataObject ()  {m_testCaseId = 2, m_inputString = "-123", m_expectedInt = -123},
                new unitTestDataObject ()  {m_testCaseId = 3, m_inputString = "    -123", m_expectedInt = -123},
                new unitTestDataObject ()  {m_testCaseId = 4, m_inputString = "  -123     ", m_expectedInt = -123},
                new unitTestDataObject ()  {m_testCaseId = 5, m_inputString = "-1  23", m_expectedInt = null},
                new unitTestDataObject ()  {m_testCaseId = 6, m_inputString = "    -123fgg", m_expectedInt = null},
                new unitTestDataObject ()  {m_testCaseId = 7, m_inputString = "-", m_expectedInt = null},
                new unitTestDataObject ()  {m_testCaseId = 8, m_inputString = " -  ", m_expectedInt = null},
                new unitTestDataObject ()  {m_testCaseId = 9, m_inputString = "1-23", m_expectedInt = null},
                new unitTestDataObject ()  {m_testCaseId = 10, m_inputString = "-1-23", m_expectedInt = null},
                new unitTestDataObject ()  {m_testCaseId = 11, m_inputString = "- 123", m_expectedInt = null},
                new unitTestDataObject ()  {m_testCaseId = 12, m_inputString = null, m_expectedInt = null},
                new unitTestDataObject ()  {m_testCaseId = 13, m_inputString = "", m_expectedInt = null},
                new unitTestDataObject ()  {m_testCaseId = 14, m_inputString = "12  3", m_expectedInt = null},
                new unitTestDataObject ()  {m_testCaseId = 15, m_inputString = "  12-3 ", m_expectedInt = null},
                new unitTestDataObject ()  {m_testCaseId = 16, m_inputString = "  ffff ", m_expectedInt = null},
                // test with Int32.MaxValue
                new unitTestDataObject ()  {m_testCaseId = 17, m_inputString = "2147483647  ", m_expectedInt = 2147483647},
                // test with Int32.MinValue
                new unitTestDataObject ()  {m_testCaseId = 18, m_inputString = "-2147483648", m_expectedInt = -2147483648},
                // test with Int32.MaxValue + 2
                new unitTestDataObject ()  {m_testCaseId = 19, m_inputString = "2147483649", m_expectedInt = null},
                // test with Int32.MinValue - 2
                new unitTestDataObject ()  {m_testCaseId = 20, m_inputString = "-2147483650", m_expectedInt = null}, 
                new unitTestDataObject ()  {m_testCaseId = 21, m_inputString = "  0  ", m_expectedInt = 0},
                new unitTestDataObject ()  {m_testCaseId = 22, m_inputString = "  -0  ", m_expectedInt = 0}
            };
            return (retValue);
        }

        /// <summary>
        /// This is the logging mechanism for this unit testing framework;  
        /// </summary>

        private static void unitTestLog (string inputString, params Object [] args)
        {
            Console.WriteLine(inputString, args);
        }

        public static void runUnitTest()
        {
            // Get the unit test data 
            unitTestDataObject[] unitTestData = getUnitTestData();
            List<string> failureTestCaseMessages = new List<string>();

            unitTestLog("Start of Unit testing ...");
            int? returnedResult = null;

            for (int i = 0; i < unitTestData.Count(); i++)
            {               
                try
                {
                    returnedResult = atoiUtilities.atoi(unitTestData[i].m_inputString.ToCharArray());
                }
                catch
                {
                    returnedResult = null;
                }

                if (returnedResult != unitTestData[i].m_expectedInt)
                {
                    string retunredResultString = "Null";
                    string expectedResultString = "Null";
                    
                    if (returnedResult.HasValue)
                    {
                        retunredResultString = returnedResult.Value.ToString ();
                    }

                    if (unitTestData[i].m_expectedInt.HasValue)
                    {
                        expectedResultString = unitTestData[i].m_expectedInt.Value.ToString ();
                    }
                    string errorMessage = "Failed Test Case id " + unitTestData[i].m_testCaseId + 
                        ";  Returned Result [" + retunredResultString + "] Expected Result [" + expectedResultString + "] ";
                    failureTestCaseMessages.Add(errorMessage);
                }
            }

            unitTestLog("End of Unit testing ...");

            if (failureTestCaseMessages.Count == 0)
            {
                unitTestLog("All tests PASSED");
            }
            else
            {
                unitTestLog("Number of failes Test cases are {0}; here is the list of failed test cases", failureTestCaseMessages.Count());
                foreach (string s in failureTestCaseMessages)
                {
                    unitTestLog(s);
                }
            }
        }
    }
}
