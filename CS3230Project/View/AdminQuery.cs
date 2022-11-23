using System;
using System.Data;
using System.Windows.Forms;
using CS3230Project.View.Validation;
using CS3230Project.View.WindowSwitching;
using CS3230Project.ViewModel.Admins;
using MySql.Data.MySqlClient;

namespace CS3230Project.View
{
    /// <summary>
    /// The page for the admin query
    /// </summary>
    public partial class AdminQuery : Form
    {
        private string adminQueryExceptionHeader = "Query Error";
        private string adminQueryArgumentExceptionMessage = "Invalid Query Values";
        private string adminQuerySuccessHeader = "Query Successful";
        private string adminQuerySuccessMessage = "Query Successfully Ran";

        /// <summary>
        /// Initializes a new <see cref="AdminQuery"/>
        /// </summary>
        public AdminQuery()
        {
            this.InitializeComponent();
            this.submitChangesFooter1.SubmitButtonEventHandler += this.SubmitChangesFooter1OnSubmitButtonEventHandler;
            this.submitChangesFooter1.BackButtonEventHandler += this.SubmitChangesFooter1OnBackButtonEventHandler;
            this.header1.LogoutEventHandler += this.Header1OnLogoutEventHandler;
        }

        private void Header1OnLogoutEventHandler(object sender, EventArgs e)
        {
            SwitchForms.SwitchToLogin(this);
        }

        private void SubmitChangesFooter1OnBackButtonEventHandler(object sender, EventArgs e)
        {
            SwitchForms.Switch(this, new AdminHome());
        }

        private void SubmitChangesFooter1OnSubmitButtonEventHandler(object sender, EventArgs e)
        {
            try
            {
                AdminQueryValidation.VerifyAdminQuery(this.queryTextBox, this.EnterQueryErrorMessage);
                var tableData = AdminServiceViewModel.RunAdminQuery(this.queryTextBox.Text);
                this.updateResultsTable(tableData);
                MessageBox.Show(this.adminQuerySuccessMessage, this.adminQuerySuccessHeader);
            }
            catch (MySqlException sqlException)
            {
                MessageBox.Show(sqlException.Message, this.adminQueryExceptionHeader);
            }
            catch (ArgumentException)
            {
                MessageBox.Show(this.adminQueryArgumentExceptionMessage, this.adminQueryExceptionHeader);
            }
        }

        private void updateResultsTable(DataTable tableData)
        {
            this.queryResultsTable.Columns.Clear();
            this.queryResultsTable.Rows.Clear();
            foreach (var column in tableData.Columns)
            {
                this.queryResultsTable.Columns.Add(column.ToString(), column.ToString());
            }

            foreach (DataRow row in tableData.Rows)
            {
                this.queryResultsTable.Rows.Add(row.ItemArray);
            }
        }
    }
}
