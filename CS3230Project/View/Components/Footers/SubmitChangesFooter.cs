using System;
using System.Windows.Forms;
using CS3230Project.ErrorMessages;

namespace CS3230Project.View.Components.Footers
{
    /// <summary>
    /// The footer containing a submit changes button
    /// </summary>
    public partial class SubmitChangesFooter : UserControl
    {
        /// <summary>
        /// The handler for if the submit button is clicked
        /// </summary>
        public event EventHandler SubmitButtonEventHandler;

        /// <summary>
        /// The handler for if the submit button is clicked
        /// </summary>
        public event EventHandler BackButtonEventHandler;

        /// <summary>
        /// Initializes a new <see cref="SubmitChangesFooter"/>
        /// </summary>
        public SubmitChangesFooter()
        {
            this.InitializeComponent();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            this.SubmitButtonEventHandler?.Invoke(sender, e);
        }

        private void backToHome_Click(object sender, EventArgs e)
        {
            this.BackButtonEventHandler?.Invoke(sender, e);
        }

        /// <summary>
        /// Hides the submit button.
        ///
        /// Precondition: footer != null
        /// Post-Condition: the submit button is hidden.
        /// </summary>
        /// <param name="footer">The footer.</param>
        public void HideSubmitButton(SubmitChangesFooter footer)
        {
            if (footer == null)
            {
                throw new ArgumentException(VisitErrorMessages.FooterCannotBeNull);
            }

            footer.Submit.Hide();
        }

        public void ShowSubmitButton(SubmitChangesFooter footer)
        {
            if (footer == null)
            {
                throw new ArgumentException(VisitErrorMessages.FooterCannotBeNull);
            }

            footer.Submit.Show();
        }
    }
}
