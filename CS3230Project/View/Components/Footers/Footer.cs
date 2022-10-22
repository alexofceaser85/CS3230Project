using System;
using System.Windows.Forms;

namespace CS3230Project.View.Components.Footers
{
    /// <summary>
    /// The footer containing a submit changes button
    /// </summary>
    public partial class Footer : UserControl
    {
        /// <summary>
        /// The handler for if the submit button is clicked
        /// </summary>
        public event EventHandler BackButtonEventHandler;

        /// <summary>
        /// Initializes a new <see cref="SubmitChangesFooter"/>
        /// </summary>
        public Footer()
        {
            this.InitializeComponent();
        }

        private void backToHome_Click(object sender, EventArgs e)
        {
            this.BackButtonEventHandler?.Invoke(sender, e);
        }
    }
}
