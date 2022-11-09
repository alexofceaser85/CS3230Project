using System.Collections.Generic;
using CS3230Project.Model.Tests;

namespace CS3230Project.ViewModel.Tests
{
    /// <summary>
    /// The view model for the tests manager
    /// </summary>
    public class TestsManagerViewModel
    {
        private readonly TestManager testsManager;

        /// <summary>
        /// The performed tests
        /// </summary>
        public List<PerformedTest> PerformedTests => this.testsManager.PerformedTests;

        /// <summary>
        /// The tests that are not yet performed
        /// </summary>
        public List<NotPerformedTest> NotPerformedTests => this.testsManager.NotPerformedTests;

        /// <summary>
        /// The tests that are not yet submitted
        /// </summary>
        public List<NotPerformedTest> NotSubmittedTests => this.testsManager.NotSubmittedTests;

        /// <summary>
        /// Initializes a new <see cref="TestsManagerViewModel"/>
        /// </summary>
        /// <param name="appointmentId">The id of the appointment</param>
        public TestsManagerViewModel(int appointmentId)
        {
            this.testsManager = new TestManager(appointmentId);
        }

        /// <summary>
        /// Adds test results
        /// </summary>
        /// <param name="testResultsToAdd">The test results to add</param>
        public void AddTestResults(PerformedTest testResultsToAdd)
        {
            this.testsManager.AddTestResults(testResultsToAdd);
        }

        /// <summary>
        /// Adds a non submitted test
        /// </summary>
        /// <param name="testToAdd">The non submitted test to add</param>
        public void AddNonSubmittedTest(NotPerformedTest testToAdd)
        {
            this.testsManager.AddNonSubmittedTest(testToAdd);
        }

        /// <summary>
        /// Removes a non submitted test
        /// </summary>
        /// <param name="testToRemove">The non submitted test to remove</param>
        public void RemoveNonSubmittedTest(NotPerformedTest testToRemove)
        {
            this.testsManager.RemoveNonSubmittedTest(testToRemove);
        }

        /// <summary>
        /// Gets a non submitted test
        /// </summary>
        /// <param name="code">The code of the test to get</param>
        /// <returns>A test that has not been submitted</returns>
        public NotPerformedTest GetNotSubmittedTest(int code)
        {
            return this.testsManager.GetNotSubmittedTest(code);
        }

        /// <summary>
        /// Submits the tests
        /// </summary>
        public void SubmitTests()
        {
            this.testsManager.SubmitTests();
        }

        /// <summary>
        /// Gets the available tests
        /// </summary>
        /// <returns>The available tests</returns>
        public static List<AvailableTest> GetAvailableTests(int appointmentId)
        {
            return TestManager.GetAvailableTests(appointmentId);
        }
    }
}
