namespace CS3230Project.View
{
    partial class AddTestResults
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.submitChangesFooter1 = new CS3230Project.View.Components.Footers.SubmitChangesFooter();
            this.header1 = new CS3230Project.View.Components.Headers.Header();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.TestResultsHeader = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TestDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.TestDateErrorMessage = new System.Windows.Forms.Label();
            this.TestAbnormalCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TestResultsTextInput = new System.Windows.Forms.TextBox();
            this.ResultsErrorMessage = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.submitChangesFooter1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.header1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.44444F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.55556F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // submitChangesFooter1
            // 
            this.submitChangesFooter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.submitChangesFooter1.Location = new System.Drawing.Point(3, 399);
            this.submitChangesFooter1.Name = "submitChangesFooter1";
            this.submitChangesFooter1.Size = new System.Drawing.Size(794, 48);
            this.submitChangesFooter1.TabIndex = 0;
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.AliceBlue;
            this.header1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.header1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.header1.Location = new System.Drawing.Point(3, 3);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(794, 71);
            this.header1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 80);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(794, 313);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.TestResultsHeader, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.TestDateTimePicker, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.TestDateErrorMessage, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.TestAbnormalCheckBox, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.TestResultsTextInput, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.ResultsErrorMessage, 0, 7);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(234, 57);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 8;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(326, 199);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // TestResultsHeader
            // 
            this.TestResultsHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.TestResultsHeader.AutoSize = true;
            this.TestResultsHeader.Location = new System.Drawing.Point(119, 0);
            this.TestResultsHeader.Name = "TestResultsHeader";
            this.TestResultsHeader.Size = new System.Drawing.Size(88, 20);
            this.TestResultsHeader.TabIndex = 0;
            this.TestResultsHeader.Text = "Add Test Results";
            this.TestResultsHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Test Date";
            // 
            // TestDateTimePicker
            // 
            this.TestDateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TestDateTimePicker.Location = new System.Drawing.Point(3, 43);
            this.TestDateTimePicker.Name = "TestDateTimePicker";
            this.TestDateTimePicker.Size = new System.Drawing.Size(320, 20);
            this.TestDateTimePicker.TabIndex = 2;
            // 
            // TestDateErrorMessage
            // 
            this.TestDateErrorMessage.AutoSize = true;
            this.TestDateErrorMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 0.25F);
            this.TestDateErrorMessage.Location = new System.Drawing.Point(3, 65);
            this.TestDateErrorMessage.Name = "TestDateErrorMessage";
            this.TestDateErrorMessage.Size = new System.Drawing.Size(0, 2);
            this.TestDateErrorMessage.TabIndex = 3;
            this.TestDateErrorMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TestAbnormalCheckBox
            // 
            this.TestAbnormalCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TestAbnormalCheckBox.AutoSize = true;
            this.TestAbnormalCheckBox.Location = new System.Drawing.Point(3, 73);
            this.TestAbnormalCheckBox.Name = "TestAbnormalCheckBox";
            this.TestAbnormalCheckBox.Size = new System.Drawing.Size(70, 17);
            this.TestAbnormalCheckBox.TabIndex = 4;
            this.TestAbnormalCheckBox.Text = "Abnormal";
            this.TestAbnormalCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Results";
            // 
            // TestResultsTextInput
            // 
            this.TestResultsTextInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TestResultsTextInput.Location = new System.Drawing.Point(3, 120);
            this.TestResultsTextInput.Multiline = true;
            this.TestResultsTextInput.Name = "TestResultsTextInput";
            this.TestResultsTextInput.Size = new System.Drawing.Size(320, 74);
            this.TestResultsTextInput.TabIndex = 6;
            // 
            // ResultsErrorMessage
            // 
            this.ResultsErrorMessage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ResultsErrorMessage.AutoSize = true;
            this.ResultsErrorMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 0.25F);
            this.ResultsErrorMessage.Location = new System.Drawing.Point(3, 197);
            this.ResultsErrorMessage.Name = "ResultsErrorMessage";
            this.ResultsErrorMessage.Size = new System.Drawing.Size(0, 2);
            this.ResultsErrorMessage.TabIndex = 7;
            // 
            // AddTestResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AddTestResults";
            this.Text = "AddTestResults";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Components.Footers.SubmitChangesFooter submitChangesFooter1;
        private Components.Headers.Header header1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label TestResultsHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker TestDateTimePicker;
        private System.Windows.Forms.Label TestDateErrorMessage;
        private System.Windows.Forms.CheckBox TestAbnormalCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TestResultsTextInput;
        private System.Windows.Forms.Label ResultsErrorMessage;
    }
}