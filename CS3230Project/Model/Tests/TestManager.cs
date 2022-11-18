using System;
using System.Collections.Generic;
using CS3230Project.DAL.Tests;
using CS3230Project.ErrorMessages;
using MySql.Data.MySqlClient;

namespace CS3230Project.Model.Tests
{
    /// <summary>
    /// The manager class for the tests
    /// </summary>
    public class TestManager
    {
        /// <summary>
        /// The appointment for the tests
        /// </summary>
        public int AppointmentId { get; }
        /// <summary>
        /// The performed tests
        /// </summary>
        public List<PerformedTest> PerformedTests { get; }
        /// <summary>
        /// The tests that are not yet performed
        /// </summary>
        public List<NotPerformedTest> NotPerformedTests { get; }
        /// <summary>
        /// The tests that are not yet submitted
        /// </summary>
        public List<NotPerformedTest> NotSubmittedTests { get; private set; }

        /// <summary>
        /// Instantiates a new <see cref="TestManager"/>
        ///
        /// Precondition: None
        /// Postcondition:
        /// this.PerformedTests == the List of performed tests
        /// AND this.NotPerformedTests == the List of not performed tests
        /// AND this.NotSubmittedTests == new List of not submitted tests
        /// AND this.appointmentId == appointmentId
        /// </summary>
        public TestManager(int appointmentId)
        {
            this.AppointmentId = appointmentId;
            this.NotSubmittedTests = new List<NotPerformedTest>();
            try
            {
                this.PerformedTests = TestsDal.GetCompletedTestsForAppointment(this.AppointmentId);
                this.NotPerformedTests = TestsDal.GetNonCompletedTestsForAppointment(this.AppointmentId);
            }
            catch (MySqlException)
            {
                this.PerformedTests = new List<PerformedTest>();
                this.NotPerformedTests = new List<NotPerformedTest>();
            }
        }

        /// <summary>
        /// Adds test results
        ///
        /// Precondition: testResultsToAdd != null
        /// Postcondition: The results are added
        /// </summary>
        /// <param name="testResultsToAdd">The test results to add</param>
        public void AddTestResults(PerformedTest testResultsToAdd)
        {
            if (testResultsToAdd == null)
            {
                throw new ArgumentException(TestManagerErrorMessages.TestResultsToAddCannotBeNull);
            }

            if (testResultsToAdd.TestDateTime < DateTime.Today)
            {
                throw new ArgumentException(TestManagerErrorMessages.CannotAddTestResultsBeforeCurrentDate);
            }
            TestsDal.AddTestResults(testResultsToAdd);
        }

        /// <summary>
        /// Adds a non submitted test
        ///
        /// Precondition: testToAdd != null
        /// Postcondition: The non submitted test is added
        /// </summary>
        /// <param name="testToAdd">The test to add</param>
        public void AddNonSubmittedTest(NotPerformedTest testToAdd)
        {
            if (testToAdd == null)
            {
                throw new ArgumentException(TestManagerErrorMessages.NonSubmittedTestToAddCannotBeNull);
            }
            this.NotSubmittedTests.Add(testToAdd);
        }

        /// <summary>
        /// Removes a non submitted test
        ///
        /// Precondition: testToAdd != null
        /// Postcondition: The non submitted test is removed
        /// </summary>
        /// <param name="testToRemove">The test to remove</param>
        public void RemoveNonSubmittedTest(NotPerformedTest testToRemove)
        {
            if (testToRemove == null)
            {
                throw new ArgumentException(TestManagerErrorMessages.NonSubmittedTestToRemoveCannotBeNull);
            }
            this.NotSubmittedTests.Remove(testToRemove);
        }

        /// <summary>
        /// Gets a non submitted test
        /// </summary>
        /// <param name="code">The code of the non submitted test</param>
        /// <returns>The found item if it is the list, null otherwise</returns>
        public NotPerformedTest GetNotSubmittedTest(int code)
        {
            return this.NotSubmittedTests.Find(x => x.Code == code);
        }

        /// <summary>
        /// Submits the tests
        /// </summary>
        public void SubmitTests()
        {
            TestsDal.AddTests(this.NotSubmittedTests);
            this.NotSubmittedTests = new List<NotPerformedTest>();
        }

        /// <summary>
        /// Gets the possible tests
        /// </summary>
        /// <returns>All of the possible tests</returns>
        public static List<AvailableTest> GetAvailableTests(int appointmentId)
        {
            return TestsDal.GetPossibleTests(appointmentId);
        }
    }
}
