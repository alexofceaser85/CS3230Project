namespace CS3230Project.View
{
    partial class AdminVisitsSearch
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
            this.header1 = new CS3230Project.View.Components.Headers.Header();
            this.submitChangesFooter1 = new CS3230Project.View.Components.Footers.SubmitChangesFooter();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.visitDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nurseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testsOrdered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testAbnormality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diagnosis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.submitChangesFooter1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.header1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.08734F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.19214F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.72052F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // header1
            // 
            this.header1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.header1.BackColor = System.Drawing.Color.AliceBlue;
            this.header1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.header1.Location = new System.Drawing.Point(5, 5);
            this.header1.Margin = new System.Windows.Forms.Padding(5);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(790, 80);
            this.header1.TabIndex = 6;
            // 
            // submitChangesFooter1
            // 
            this.submitChangesFooter1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.submitChangesFooter1.Location = new System.Drawing.Point(5, 383);
            this.submitChangesFooter1.Margin = new System.Windows.Forms.Padding(5);
            this.submitChangesFooter1.Name = "submitChangesFooter1";
            this.submitChangesFooter1.Size = new System.Drawing.Size(790, 62);
            this.submitChangesFooter1.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 93);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.30556F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.69444F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(794, 282);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.dateTimePicker1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.dateTimePicker2, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(788, 62);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(3, 34);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(388, 22);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(397, 34);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(388, 22);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "First Date";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(397, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Second Date";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.visitDate,
            this.patientId,
            this.patientName,
            this.doctorName,
            this.nurseName,
            this.testsOrdered,
            this.testAbnormality,
            this.diagnosis});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(788, 208);
            this.dataGridView1.TabIndex = 1;
            // 
            // visitDate
            // 
            this.visitDate.HeaderText = "Visit Date";
            this.visitDate.Name = "visitDate";
            // 
            // patientId
            // 
            this.patientId.HeaderText = "Patient ID";
            this.patientId.Name = "patientId";
            // 
            // patientName
            // 
            this.patientName.HeaderText = "Patient Name";
            this.patientName.Name = "patientName";
            // 
            // doctorName
            // 
            this.doctorName.HeaderText = "Doctor Name";
            this.doctorName.Name = "doctorName";
            // 
            // nurseName
            // 
            this.nurseName.HeaderText = "Nurse Name";
            this.nurseName.Name = "nurseName";
            // 
            // testsOrdered
            // 
            this.testsOrdered.HeaderText = "Tests Ordered";
            this.testsOrdered.Name = "testsOrdered";
            // 
            // testAbnormality
            // 
            this.testAbnormality.HeaderText = "Test Abnormality";
            this.testAbnormality.Name = "testAbnormality";
            // 
            // diagnosis
            // 
            this.diagnosis.HeaderText = "Diagnosis";
            this.diagnosis.Name = "diagnosis";
            // 
            // AdminVisitsSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AdminVisitsSearch";
            this.Text = "AdminVisitsSearch";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Components.Headers.Header header1;
        private Components.Footers.SubmitChangesFooter submitChangesFooter1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn visitDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn nurseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn testsOrdered;
        private System.Windows.Forms.DataGridViewTextBoxColumn testAbnormality;
        private System.Windows.Forms.DataGridViewTextBoxColumn diagnosis;
    }
}