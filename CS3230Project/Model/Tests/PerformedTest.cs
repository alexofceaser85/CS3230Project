using System;
using CS3230Project.ErrorMessages;

namespace CS3230Project.Model.Tests
{
    /// <summary>
    /// Holds the information for a performed test
    /// </summary>
    public class PerformedTest : Test
    {
        /// <summary>
        /// The appointment ID
        /// </summary>
        public int AppointmentId { get; }
        /// <summary>
        /// The results of the performed test
        /// </summary>
        public string Results { get; }
        /// <summary>
        /// Whether of not the performed test is abnormal
        /// </summary>
        public bool IsAbnormal { get; }
        /// <summary>
        /// The date and time of the performed test
        /// </summary>
        public DateTime TestDateTime { get; }

        /// <summary>
        /// Initializes a new <see cref="PerformedTest"/>
        ///
        /// Precondition:
        /// appointmentId MORE THAN OR EQUAL TO 0
        /// AND testCode MORE THAN OR EQUAL TO 0
        /// AND testName != null
        /// AND testName.Length != 0
        /// AND results != null
        /// AND results.Length != 0
        /// Postcondition:
        /// this.AppointmentId == appointmentId
        /// AND this.TestCode == testCode
        /// AND this.TestName == testName
        /// AND this.Results == results
        /// AND this.IsAbnormal == isAbnormal
        /// AND this.TestDateTime == testDateTime
        /// </summary>
        /// <param name="appointmentId">The appointment Id for the performed test</param>
        /// <param name="testCode">The performed test's code</param>
        /// <param name="testName">The name of the performed test</param>
        /// <param name="results">The performed test's results</param>
        /// <param name="isAbnormal">Whether or not the performed test was abnormal</param>
        /// <param name="testDateTime">The date and time the performed test was performed</param>
        /// <exception cref="ArgumentException">If the preconditions are not met</exception>
        public PerformedTest(int appointmentId, int testCode, string testName, string results, bool isAbnormal,
            DateTime testDateTime)
        {
            if (results == null)
            {
                throw new ArgumentException(TestsErrorMessages.TestResultsCannotBeNull);
            }

            if (results.Trim().Length == 0)
            {
                throw new ArgumentException(TestsErrorMessages.TestResultsCannotBeEmpty);
            }

            if (results.Trim().Length == 0)
            {
                throw new ArgumentException(TestsErrorMessages.TestResultsCannotBeEmpty);
            }

            this.AppointmentId = appointmentId;
            base.Code = testCode;
            base.Name = testName;
            this.Results = results;
            this.IsAbnormal = isAbnormal;
            this.TestDateTime = testDateTime;
        }
    }
}
