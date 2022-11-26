using System;
using CS3230Project.ErrorMessages;

namespace CS3230Project.Model.Tests
{
    /// <summary>
    ///   Holds the information for the admin search test
    /// </summary>
    public class AdminSearchTest
    {

        /// <summary>
        /// The Name of the test
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// The results of the test
        /// </summary>
        public string Results { get; }
        /// <summary>
        /// Whether of not the test is abnormal
        /// </summary>
        public bool IsAbnormal { get; }
        /// <summary>
        /// The date of the test
        /// </summary>
        public string Date { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminSearchTest" /> class.
        ///
        /// Precondition:   name.length() MORE THAN 0 AND
        ///                 name != null AND
        ///                 datePerformed.length() MORE THAN 0 AND
        ///                 datePerformed != null AND
        ///                 results != null AND
        ///  
        /// Post-condition: a new admin search test is created
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="datePerformed">The date performed.</param>
        /// <param name="result">The result.</param>
        /// <param name="isAbnormal">if set to <c>true</c> [is abnormal].</param>
        public AdminSearchTest(string name, string datePerformed, string result, bool isAbnormal)
        {
            if (name.Trim().Length == 0)
            {
                throw new ArgumentException(AdminSearchTestErrorMessages.TestNameCannotBeEmpty);
            }
            if (name == null)
            {
                throw new ArgumentException(AdminSearchTestErrorMessages.TestNameCannotBeNull);
            }
            if (datePerformed.Trim().Length == 0)
            {
                throw new ArgumentException(AdminSearchTestErrorMessages.DatePerformedCannotBeEmpty);
            }
            if (datePerformed == null)
            {
                throw new ArgumentException(AdminSearchTestErrorMessages.DatePerformedCannotBeNull);
            }
            if (result == null)
            {
                throw new ArgumentException(AdminSearchTestErrorMessages.TestResultsCannotBeNull);
            }

            this.Name = name;
            this.Date = datePerformed;
            this.Results = result;
            this.IsAbnormal = isAbnormal;
        }

    }
}
