using System;
using System.Windows.Forms;

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

        private Form currentForm;

        /// <summary>
        /// Initializes a new <see cref="SubmitChangesFooter"/>
        /// </summary>
        public SubmitChangesFooter()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new <see cref="SubmitChangesFooter"/>
        /// <param name="currentForm"> The current Form</param>
        /// </summary>
        public SubmitChangesFooter(Form currentForm)
        {
            this.currentForm = currentForm;
            this.InitializeComponent();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            this.SubmitButtonEventHandler?.Invoke(sender, e);
        }

        private void backToHome_Click(object sender, EventArgs e)
        {
            Form homeForm = new Home();
            homeForm.Location = this.currentForm.Location;
            homeForm.StartPosition = FormStartPosition.Manual;
            homeForm.FormClosing += delegate { Show(); };
            this.currentForm.Hide();
            homeForm.Size = this.currentForm.Size;
            homeForm.ShowDialog();
            this.currentForm.Close();
        }
    }
}
