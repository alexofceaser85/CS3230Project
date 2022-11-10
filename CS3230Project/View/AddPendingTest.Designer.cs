namespace CS3230Project.View
{
    partial class AddPendingTest
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label75 = new System.Windows.Forms.Label();
            this.tableLayoutPanel64 = new System.Windows.Forms.TableLayoutPanel();
            this.TestSelectErrorMessage = new System.Windows.Forms.Label();
            this.AvailableTestsSelect = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel64.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.submitChangesFooter1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.37548F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.62452F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(651, 261);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // submitChangesFooter1
            // 
            this.submitChangesFooter1.Location = new System.Drawing.Point(3, 218);
            this.submitChangesFooter1.Name = "submitChangesFooter1";
            this.submitChangesFooter1.Size = new System.Drawing.Size(645, 40);
            this.submitChangesFooter1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(196, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.89474F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(258, 209);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel64, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.TestSelectErrorMessage, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.AvailableTestsSelect, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 58);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(252, 93);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label75
            // 
            this.label75.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label75.AutoSize = true;
            this.label75.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label75.Location = new System.Drawing.Point(39, 0);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(174, 40);
            this.label75.TabIndex = 0;
            this.label75.Text = "Add Pending Test";
            this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel64
            // 
            this.tableLayoutPanel64.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel64.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tableLayoutPanel64.ColumnCount = 1;
            this.tableLayoutPanel64.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel64.Controls.Add(this.label75, 0, 0);
            this.tableLayoutPanel64.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel64.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel64.Name = "tableLayoutPanel64";
            this.tableLayoutPanel64.RowCount = 1;
            this.tableLayoutPanel64.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel64.Size = new System.Drawing.Size(252, 40);
            this.tableLayoutPanel64.TabIndex = 1;
            // 
            // TestSelectErrorMessage
            // 
            this.TestSelectErrorMessage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TestSelectErrorMessage.AutoSize = true;
            this.TestSelectErrorMessage.Location = new System.Drawing.Point(3, 76);
            this.TestSelectErrorMessage.Name = "TestSelectErrorMessage";
            this.TestSelectErrorMessage.Size = new System.Drawing.Size(0, 13);
            this.TestSelectErrorMessage.TabIndex = 2;
            this.TestSelectErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AvailableTestsSelect
            // 
            this.AvailableTestsSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AvailableTestsSelect.FormattingEnabled = true;
            this.AvailableTestsSelect.Location = new System.Drawing.Point(3, 46);
            this.AvailableTestsSelect.Name = "AvailableTestsSelect";
            this.AvailableTestsSelect.Size = new System.Drawing.Size(246, 21);
            this.AvailableTestsSelect.TabIndex = 3;
            // 
            // AddPendingTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AddPendingTest";
            this.Text = "AddPendingTest";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel64.ResumeLayout(false);
            this.tableLayoutPanel64.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Components.Footers.SubmitChangesFooter submitChangesFooter1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel64;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label TestSelectErrorMessage;
        private System.Windows.Forms.ComboBox AvailableTestsSelect;
    }
}