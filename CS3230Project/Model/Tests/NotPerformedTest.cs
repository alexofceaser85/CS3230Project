using System;
using CS3230Project.ErrorMessages;

namespace CS3230Project.Model.Tests
{
    /// <summary>
    /// Holds the information for a test
    /// </summary>
    public class NotPerformedTest : Test
    {
        /// <summary>
        /// The appointment ID
        /// </summary>
        public int AppointmentId { get; }
        /// <summary>
        /// The test code
        /// </summary>
        public int Code => base.Code;
        /// <summary>
        /// The test name
        /// </summary>
        public string Name => base.Name;

        /// <summary>
        /// Initializes a new <see cref="NotPerformedTest"/>
        /// Precondition:
        /// testCode MORE THAN OR EQUAL TO 0
        /// AND testName != null
        /// AND testName.Length != 0
        /// Postcondition:
        /// this.AppointmentId == appointmentId
        /// AND this.TestCode == testCode
        /// AND this.TestName == testName
        /// </summary>
        /// <param name="code">The test code</param>
        /// <param name="name">The test name</param>
        /// <param name="appointmentId">The appointment ID for the test</param>
        public NotPerformedTest(int appointmentId, int code, string name)
        {
            if (appointmentId < 0)
            {
                throw new ArgumentException(TestsErrorMessages.AppointmentIdForTestCannotBeLessThanZero);
            }

            this.AppointmentId = appointmentId;
            base.Code = code;
            base.Name = name;
        }
    }
}
