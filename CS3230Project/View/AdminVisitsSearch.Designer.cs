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
            this.footer = new System.Windows.Forms.TableLayoutPanel();
            this.returnToHomeButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.visitsDataGridView = new System.Windows.Forms.DataGridView();
            this.visitDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appointmentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nurseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.getVisitsButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.testsDataGridView = new System.Windows.Forms.DataGridView();
            this.testName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datePerformed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.results = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isAbnormal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.diagnosesDataGridView = new System.Windows.Forms.DataGridView();
            this.diagnosisDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.basedOnTests = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.header1 = new CS3230Project.View.Components.Headers.Header();
            this.tableLayoutPanel1.SuspendLayout();
            this.footer.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visitsDataGridView)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testsDataGridView)).BeginInit();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diagnosesDataGridView)).BeginInit();
            this.tableLayoutPanel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.footer, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.header1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(804, 876);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // footer
            // 
            this.footer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.footer.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.footer.ColumnCount = 3;
            this.footer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.footer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.footer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.footer.Controls.Add(this.returnToHomeButton, 0, 0);
            this.footer.Location = new System.Drawing.Point(4, 804);
            this.footer.Margin = new System.Windows.Forms.Padding(4);
            this.footer.Name = "footer";
            this.footer.RowCount = 1;
            this.footer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.footer.Size = new System.Drawing.Size(796, 68);
            this.footer.TabIndex = 13;
            // 
            // returnToHomeButton
            // 
            this.returnToHomeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.returnToHomeButton.BackColor = System.Drawing.Color.LightSlateGray;
            this.returnToHomeButton.FlatAppearance.BorderSize = 0;
            this.returnToHomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returnToHomeButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returnToHomeButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.returnToHomeButton.Location = new System.Drawing.Point(4, 4);
            this.returnToHomeButton.Margin = new System.Windows.Forms.Padding(4);
            this.returnToHomeButton.Name = "returnToHomeButton";
            this.returnToHomeButton.Size = new System.Drawing.Size(253, 60);
            this.returnToHomeButton.TabIndex = 4;
            this.returnToHomeButton.Text = "Back to Home";
            this.returnToHomeButton.UseVisualStyleBackColor = false;
            this.returnToHomeButton.Click += new System.EventHandler(this.FooterOnBackButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.visitsDataGridView, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.getVisitsButton, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 108);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.30556F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.69444F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(794, 334);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.startDateTimePicker, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.endDateTimePicker, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(788, 64);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(3, 35);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(388, 22);
            this.startDateTimePicker.TabIndex = 0;
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(397, 35);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(388, 22);
            this.endDateTimePicker.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "First Date";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(397, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Second Date";
            // 
            // visitsDataGridView
            // 
            this.visitsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.visitsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.visitDate,
            this.appointmentId,
            this.patientId,
            this.patientName,
            this.doctorName,
            this.nurseName});
            this.visitsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visitsDataGridView.Location = new System.Drawing.Point(3, 119);
            this.visitsDataGridView.Name = "visitsDataGridView";
            this.visitsDataGridView.RowHeadersVisible = false;
            this.visitsDataGridView.RowTemplate.Height = 24;
            this.visitsDataGridView.Size = new System.Drawing.Size(788, 212);
            this.visitsDataGridView.TabIndex = 1;
            this.visitsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.visitsDataGridView_CellClick);
            // 
            // visitDate
            // 
            this.visitDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.visitDate.HeaderText = "Visit Date";
            this.visitDate.Name = "visitDate";
            this.visitDate.Width = 82;
            // 
            // appointmentId
            // 
            this.appointmentId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.appointmentId.HeaderText = "Appointment ID";
            this.appointmentId.Name = "appointmentId";
            this.appointmentId.Width = 113;
            // 
            // patientId
            // 
            this.patientId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.patientId.HeaderText = "Patient ID";
            this.patientId.Name = "patientId";
            this.patientId.Width = 82;
            // 
            // patientName
            // 
            this.patientName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.patientName.HeaderText = "Patient Name";
            this.patientName.Name = "patientName";
            // 
            // doctorName
            // 
            this.doctorName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.doctorName.HeaderText = "Doctor Name";
            this.doctorName.Name = "doctorName";
            // 
            // nurseName
            // 
            this.nurseName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nurseName.HeaderText = "Nurse Name";
            this.nurseName.Name = "nurseName";
            // 
            // getVisitsButton
            // 
            this.getVisitsButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.getVisitsButton.BackColor = System.Drawing.Color.LightSlateGray;
            this.getVisitsButton.ForeColor = System.Drawing.SystemColors.Control;
            this.getVisitsButton.Location = new System.Drawing.Point(344, 73);
            this.getVisitsButton.Name = "getVisitsButton";
            this.getVisitsButton.Size = new System.Drawing.Size(106, 40);
            this.getVisitsButton.TabIndex = 2;
            this.getVisitsButton.Text = "Get Visits";
            this.getVisitsButton.UseVisualStyleBackColor = false;
            this.getVisitsButton.Click += new System.EventHandler(this.getVisitsButton_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.testsDataGridView, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel7, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(48, 453);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(707, 169);
            this.tableLayoutPanel4.TabIndex = 9;
            // 
            // testsDataGridView
            // 
            this.testsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.testsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.testName,
            this.datePerformed,
            this.results,
            this.isAbnormal});
            this.testsDataGridView.Location = new System.Drawing.Point(3, 40);
            this.testsDataGridView.Name = "testsDataGridView";
            this.testsDataGridView.RowHeadersVisible = false;
            this.testsDataGridView.RowTemplate.Height = 24;
            this.testsDataGridView.Size = new System.Drawing.Size(701, 138);
            this.testsDataGridView.TabIndex = 1;
            // 
            // testName
            // 
            this.testName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.testName.HeaderText = "TestName";
            this.testName.Name = "testName";
            // 
            // datePerformed
            // 
            this.datePerformed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.datePerformed.HeaderText = "Date Performed";
            this.datePerformed.Name = "datePerformed";
            this.datePerformed.Width = 116;
            // 
            // results
            // 
            this.results.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.results.HeaderText = "Results";
            this.results.Name = "results";
            this.results.Width = 77;
            // 
            // isAbnormal
            // 
            this.isAbnormal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.isAbnormal.HeaderText = "Abnormal";
            this.isAbnormal.Name = "isAbnormal";
            this.isAbnormal.Width = 90;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(701, 31);
            this.tableLayoutPanel7.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Completed Tests";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.diagnosesDataGridView, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel8, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(48, 628);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(707, 169);
            this.tableLayoutPanel5.TabIndex = 10;
            // 
            // diagnosesDataGridView
            // 
            this.diagnosesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.diagnosesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.diagnosisDescription,
            this.isFinal,
            this.basedOnTests});
            this.diagnosesDataGridView.Location = new System.Drawing.Point(3, 39);
            this.diagnosesDataGridView.Name = "diagnosesDataGridView";
            this.diagnosesDataGridView.RowHeadersVisible = false;
            this.diagnosesDataGridView.RowTemplate.Height = 24;
            this.diagnosesDataGridView.Size = new System.Drawing.Size(701, 134);
            this.diagnosesDataGridView.TabIndex = 1;
            // 
            // diagnosisDescription
            // 
            this.diagnosisDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.diagnosisDescription.HeaderText = "Description";
            this.diagnosisDescription.Name = "diagnosisDescription";
            // 
            // isFinal
            // 
            this.isFinal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.isFinal.HeaderText = "Final";
            this.isFinal.Name = "isFinal";
            this.isFinal.Width = 61;
            // 
            // basedOnTests
            // 
            this.basedOnTests.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.basedOnTests.HeaderText = "Based On Tests";
            this.basedOnTests.Name = "basedOnTests";
            this.basedOnTests.Width = 88;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(701, 30);
            this.tableLayoutPanel8.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(314, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Diagnoses";
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
            this.header1.Size = new System.Drawing.Size(794, 90);
            this.header1.TabIndex = 6;
            // 
            // AdminVisitsSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 876);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(820, 915);
            this.Name = "AdminVisitsSearch";
            this.Text = "AdminVisitsSearch";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.footer.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visitsDataGridView)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.testsDataGridView)).EndInit();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.diagnosesDataGridView)).EndInit();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Components.Headers.Header header1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView visitsDataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.DataGridView testsDataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.DataGridView diagnosesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn diagnosisDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn isFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn basedOnTests;
        private System.Windows.Forms.TableLayoutPanel footer;
        private System.Windows.Forms.Button returnToHomeButton;
        private System.Windows.Forms.Button getVisitsButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn testName;
        private System.Windows.Forms.DataGridViewTextBoxColumn datePerformed;
        private System.Windows.Forms.DataGridViewTextBoxColumn results;
        private System.Windows.Forms.DataGridViewTextBoxColumn isAbnormal;
        private System.Windows.Forms.DataGridViewTextBoxColumn visitDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn appointmentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn nurseName;
    }
}