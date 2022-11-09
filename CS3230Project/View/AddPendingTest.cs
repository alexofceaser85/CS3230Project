using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CS3230Project.Model.Tests;
using CS3230Project.ViewModel.Tests;

namespace CS3230Project.View
{
    /// <summary>
    /// The form to add a pending test
    /// </summary>
    public partial class AddPendingTest : Form
    {
        private readonly List<AvailableTest> availableTests;
        /// <summary>
        /// The event that adds a test
        /// </summary>
        public event EventHandler<TestAddedEventArgs> TestAddedEvent;
        /// <summary>
        /// Initializes a new <see cref="AddPendingTest"/>
        /// </summary>
        /// <param name="appointmentId">The appointment Id</param>
        /// <param name="pendingTests">The pending tests</param>
        public AddPendingTest(int appointmentId, List<NotPerformedTest> pendingTests)
        {
            this.InitializeComponent();
            this.availableTests = TestsManagerViewModel.GetAvailableTests(appointmentId).Where(at => !pendingTests.Any(pt => at.Code == pt.Code)).ToList();

            foreach (var test in this.availableTests)
            {
                this.AvailableTestsSelect.Items.Add(test.Code + " " + test.Name);
            }

            this.submitChangesFooter1.BackButtonEventHandler += this.SubmitChangesFooter1OnBackButtonEventHandler;
            this.submitChangesFooter1.SubmitButtonEventHandler += this.SubmitChangesFooter1OnSubmitButtonEventHandler;
        }

        private void SubmitChangesFooter1OnSubmitButtonEventHandler(object sender, EventArgs e)
        {
            this.OnTestAddedEvent(new TestAddedEventArgs { TestAdded = this.availableTests[this.AvailableTestsSelect.SelectedIndex] });
        }
        /// <summary>
        /// The event on a test added
        /// </summary>
        /// <param name="args">The event args</param>
        protected virtual void OnTestAddedEvent(TestAddedEventArgs args)
        {
            this.TestAddedEvent?.Invoke(this, new TestAddedEventArgs { TestAdded = this.availableTests[this.AvailableTestsSelect.SelectedIndex] });
            this.Close();
        }

        private void SubmitChangesFooter1OnBackButtonEventHandler(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    /// <summary>
    /// The event arguments for a test added
    /// </summary>
    public class TestAddedEventArgs : EventArgs
    {
        /// <summary>
        /// The test added
        /// </summary>
        public AvailableTest TestAdded { get; set; }
    }
}
