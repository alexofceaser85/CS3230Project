﻿namespace CS3230Project.View
{
    partial class CreateAppointment
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
            this.label2 = new System.Windows.Forms.Label();
            this.appointmentDoctorDropDown = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.reasonTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.appointmentDatePicker = new System.Windows.Forms.DateTimePicker();
            this.AppointmentDateLabel = new System.Windows.Forms.Label();
            this.AppointmentDoctorErrorMessage = new System.Windows.Forms.Label();
            this.AppointmentReasonErrorMessage = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.PatientPhoneNumberLabel = new System.Windows.Forms.Label();
            this.PatientDateOfBirthLabel = new System.Windows.Forms.Label();
            this.PatientNameAndIdLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.header1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.submitChangesFooter1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1067, 629);
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
            this.header1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(1057, 86);
            this.header1.TabIndex = 0;
            // 
            // submitChangesFooter1
            // 
            this.submitChangesFooter1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.submitChangesFooter1.Location = new System.Drawing.Point(5, 566);
            this.submitChangesFooter1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.submitChangesFooter1.Name = "submitChangesFooter1";
            this.submitChangesFooter1.Size = new System.Drawing.Size(1057, 58);
            this.submitChangesFooter1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 100);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1059, 457);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.appointmentDoctorDropDown, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.reasonTextBox, 0, 8);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.appointmentDatePicker, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.AppointmentDateLabel, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.AppointmentDoctorErrorMessage, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.AppointmentReasonErrorMessage, 0, 9);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(346, 36);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 10;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(367, 384);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 165);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Doctor";
            // 
            // appointmentDoctorDropDown
            // 
            this.appointmentDoctorDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.appointmentDoctorDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.appointmentDoctorDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.appointmentDoctorDropDown.FormattingEnabled = true;
            this.appointmentDoctorDropDown.Location = new System.Drawing.Point(4, 190);
            this.appointmentDoctorDropDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.appointmentDoctorDropDown.Name = "appointmentDoctorDropDown";
            this.appointmentDoctorDropDown.Size = new System.Drawing.Size(359, 24);
            this.appointmentDoctorDropDown.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 226);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Reason";
            // 
            // reasonTextBox
            // 
            this.reasonTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reasonTextBox.Location = new System.Drawing.Point(4, 254);
            this.reasonTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reasonTextBox.Multiline = true;
            this.reasonTextBox.Name = "reasonTextBox";
            this.reasonTextBox.Size = new System.Drawing.Size(359, 101);
            this.reasonTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 111);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Date";
            // 
            // appointmentDatePicker
            // 
            this.appointmentDatePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.appointmentDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.appointmentDatePicker.Location = new System.Drawing.Point(4, 134);
            this.appointmentDatePicker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.appointmentDatePicker.Name = "appointmentDatePicker";
            this.appointmentDatePicker.Size = new System.Drawing.Size(359, 22);
            this.appointmentDatePicker.TabIndex = 7;
            this.appointmentDatePicker.ValueChanged += new System.EventHandler(this.appointmentDatePicker_ValueChanged);
            // 
            // AppointmentDateLabel
            // 
            this.AppointmentDateLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AppointmentDateLabel.AutoSize = true;
            this.AppointmentDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 0.25F);
            this.AppointmentDateLabel.Location = new System.Drawing.Point(4, 158);
            this.AppointmentDateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AppointmentDateLabel.Name = "AppointmentDateLabel";
            this.AppointmentDateLabel.Size = new System.Drawing.Size(0, 2);
            this.AppointmentDateLabel.TabIndex = 9;
            // 
            // AppointmentDoctorErrorMessage
            // 
            this.AppointmentDoctorErrorMessage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AppointmentDoctorErrorMessage.AutoSize = true;
            this.AppointmentDoctorErrorMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 0.25F);
            this.AppointmentDoctorErrorMessage.Location = new System.Drawing.Point(4, 217);
            this.AppointmentDoctorErrorMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AppointmentDoctorErrorMessage.Name = "AppointmentDoctorErrorMessage";
            this.AppointmentDoctorErrorMessage.Size = new System.Drawing.Size(0, 2);
            this.AppointmentDoctorErrorMessage.TabIndex = 10;
            // 
            // AppointmentReasonErrorMessage
            // 
            this.AppointmentReasonErrorMessage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AppointmentReasonErrorMessage.AutoSize = true;
            this.AppointmentReasonErrorMessage.Cursor = System.Windows.Forms.Cursors.Default;
            this.AppointmentReasonErrorMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 0.25F);
            this.AppointmentReasonErrorMessage.Location = new System.Drawing.Point(4, 370);
            this.AppointmentReasonErrorMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AppointmentReasonErrorMessage.Name = "AppointmentReasonErrorMessage";
            this.AppointmentReasonErrorMessage.Size = new System.Drawing.Size(0, 2);
            this.AppointmentReasonErrorMessage.TabIndex = 11;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.PatientPhoneNumberLabel, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.PatientDateOfBirthLabel, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.PatientNameAndIdLabel, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.71429F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.28571F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(359, 100);
            this.tableLayoutPanel4.TabIndex = 12;
            // 
            // PatientPhoneNumberLabel
            // 
            this.PatientPhoneNumberLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PatientPhoneNumberLabel.AutoSize = true;
            this.PatientPhoneNumberLabel.BackColor = System.Drawing.SystemColors.Control;
            this.PatientPhoneNumberLabel.Location = new System.Drawing.Point(4, 78);
            this.PatientPhoneNumberLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PatientPhoneNumberLabel.Name = "PatientPhoneNumberLabel";
            this.PatientPhoneNumberLabel.Size = new System.Drawing.Size(351, 16);
            this.PatientPhoneNumberLabel.TabIndex = 4;
            this.PatientPhoneNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PatientDateOfBirthLabel
            // 
            this.PatientDateOfBirthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PatientDateOfBirthLabel.AutoSize = true;
            this.PatientDateOfBirthLabel.BackColor = System.Drawing.SystemColors.Control;
            this.PatientDateOfBirthLabel.Location = new System.Drawing.Point(4, 51);
            this.PatientDateOfBirthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PatientDateOfBirthLabel.Name = "PatientDateOfBirthLabel";
            this.PatientDateOfBirthLabel.Size = new System.Drawing.Size(351, 16);
            this.PatientDateOfBirthLabel.TabIndex = 3;
            this.PatientDateOfBirthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PatientNameAndIdLabel
            // 
            this.PatientNameAndIdLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PatientNameAndIdLabel.AutoSize = true;
            this.PatientNameAndIdLabel.BackColor = System.Drawing.SystemColors.Control;
            this.PatientNameAndIdLabel.Location = new System.Drawing.Point(4, 25);
            this.PatientNameAndIdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PatientNameAndIdLabel.Name = "PatientNameAndIdLabel";
            this.PatientNameAndIdLabel.Size = new System.Drawing.Size(351, 16);
            this.PatientNameAndIdLabel.TabIndex = 2;
            this.PatientNameAndIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(4, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Create Appointment for Patient";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CreateAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 629);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CreateAppointment";
            this.Text = "CreateAppointment";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Components.Headers.Header header1;
        private Components.Footers.SubmitChangesFooter submitChangesFooter1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox appointmentDoctorDropDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox reasonTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker appointmentDatePicker;
        private System.Windows.Forms.Label AppointmentDateLabel;
        private System.Windows.Forms.Label AppointmentDoctorErrorMessage;
        private System.Windows.Forms.Label AppointmentReasonErrorMessage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label PatientPhoneNumberLabel;
        private System.Windows.Forms.Label PatientDateOfBirthLabel;
        private System.Windows.Forms.Label PatientNameAndIdLabel;
        private System.Windows.Forms.Label label1;
    }
}