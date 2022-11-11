using System;
using System.Drawing;
using System.Windows.Forms;

namespace CS3230Project.View.Validation
{
    /// <summary>
    ///   Shows the UI messages that validate the inputs
    /// </summary>
    public static class CheckupValidation
    {

        private static readonly Font LabelCollapsedFont = new Font("Segoe UI", 1);
        private static readonly Font LabelNotCollapsedFont = new Font("Segoe UI", 8);

        /// <summary>
        /// Verifies the systolic blood pressure input.
        /// </summary>
        /// <param name="systolicBloodPressureTextBox">The systolic blood pressure text box.</param>
        /// <param name="systolicBloodPressureTextBoxErrorMessage">The systolic blood pressure text box error message.</param>
        public static void VerifySystolicBloodPressureInput(TextBox systolicBloodPressureTextBox,
            Label systolicBloodPressureTextBoxErrorMessage)
        {
            systolicBloodPressureTextBoxErrorMessage.ForeColor = Color.Red;
            if (systolicBloodPressureTextBox.Text.Trim().Length == 0)
            {
                systolicBloodPressureTextBoxErrorMessage.Font = LabelNotCollapsedFont;
                systolicBloodPressureTextBoxErrorMessage.Text = ErrorMessages.VisitErrorMessages.SystolicBloodPressureCannotBeEmpty;
            }
            else if (!int.TryParse(systolicBloodPressureTextBox.Text, out int n))
            {
                systolicBloodPressureTextBoxErrorMessage.Font = LabelNotCollapsedFont;
                systolicBloodPressureTextBoxErrorMessage.Text = ErrorMessages.VisitErrorMessages.SystolicBloodPressureMustBeValidInteger;
            }
            else
            {
                systolicBloodPressureTextBoxErrorMessage.Font = LabelCollapsedFont;
                systolicBloodPressureTextBoxErrorMessage.Text = "";
            }
        }

        /// <summary>
        /// Verifies the diastolic blood pressure input.
        /// </summary>
        /// <param name="diastolicBloodPressureTextBox">The diastolic blood pressure text box.</param>
        /// <param name="diastolicBloodPressureTextBoxErrorMessage">The diastolic blood pressure text box error message.</param>
        public static void VerifyDiastolicBloodPressureInput(TextBox diastolicBloodPressureTextBox,
            Label diastolicBloodPressureTextBoxErrorMessage)
        {
            diastolicBloodPressureTextBoxErrorMessage.ForeColor = Color.Red;
            if (diastolicBloodPressureTextBox.Text.Trim().Length == 0)
            {
                diastolicBloodPressureTextBoxErrorMessage.Font = LabelNotCollapsedFont;
                diastolicBloodPressureTextBoxErrorMessage.Text = ErrorMessages.VisitErrorMessages.DiastolicBloodPressureCannotBeEmpty;
            }
            else if (!int.TryParse(diastolicBloodPressureTextBox.Text, out int n))
            {
                diastolicBloodPressureTextBoxErrorMessage.Font = LabelNotCollapsedFont;
                diastolicBloodPressureTextBoxErrorMessage.Text = ErrorMessages.VisitErrorMessages.DiastolicBloodPressureMustBeValidInteger;
            }
            else
            {
                diastolicBloodPressureTextBoxErrorMessage.Font = LabelCollapsedFont;
                diastolicBloodPressureTextBoxErrorMessage.Text = "";
            }
        }

        /// <summary>
        /// Verifies the body temperature input.
        /// </summary>
        /// <param name="bodyTemperatureTextBox">The body temperature text box.</param>
        /// <param name="bodyTemperatureTextBoxErrorMessage">The body temperature text box error message.</param>
        public static void VerifyBodyTemperatureInput(TextBox bodyTemperatureTextBox,
            Label bodyTemperatureTextBoxErrorMessage)
        {
            bodyTemperatureTextBoxErrorMessage.ForeColor = Color.Red;
            if (bodyTemperatureTextBox.Text.Trim().Length == 0)
            {
                bodyTemperatureTextBoxErrorMessage.Font = LabelNotCollapsedFont;
                bodyTemperatureTextBoxErrorMessage.Text = ErrorMessages.VisitErrorMessages.BodyTempCannotBeEmpty;
            }
            else if (!Double.TryParse(bodyTemperatureTextBox.Text, out double n))
            {
                bodyTemperatureTextBoxErrorMessage.Font = LabelNotCollapsedFont;
                bodyTemperatureTextBoxErrorMessage.Text = ErrorMessages.VisitErrorMessages.BodyTempMustBeValidDecimal;
            }
            else
            {
                bodyTemperatureTextBoxErrorMessage.Font = LabelCollapsedFont;
                bodyTemperatureTextBoxErrorMessage.Text = "";
            }
        }

        /// <summary>
        /// Verifies the pulse input.
        /// </summary>
        /// <param name="pulseTextBox">The pulse text box.</param>
        /// <param name="pulseTextBoxErrorMessage">The pulse text box error message.</param>
        public static void VerifyPulseInput(TextBox pulseTextBox, Label pulseTextBoxErrorMessage)
        {
            pulseTextBoxErrorMessage.ForeColor = Color.Red;
            if (pulseTextBox.Text.Trim().Length == 0)
            {
                pulseTextBoxErrorMessage.Font = LabelNotCollapsedFont;
                pulseTextBoxErrorMessage.Text = ErrorMessages.VisitErrorMessages.PulseCannotBeEmpty;
            }
            else if (!int.TryParse(pulseTextBox.Text, out int n))
            {
                pulseTextBoxErrorMessage.Font = LabelNotCollapsedFont;
                pulseTextBoxErrorMessage.Text = ErrorMessages.VisitErrorMessages.PulseMustBeValidInteger;
            }
            else
            {
                pulseTextBoxErrorMessage.Font = LabelCollapsedFont;
                pulseTextBoxErrorMessage.Text = "";
            }
        }

        /// <summary>
        /// Verifies the height input.
        /// </summary>
        /// <param name="heightTextBox">The height text box.</param>
        /// <param name="heightTextBoxErrorMessage">The height text box error message.</param>
        public static void VerifyHeightInput(TextBox heightTextBox, Label heightTextBoxErrorMessage)
        {
            heightTextBoxErrorMessage.ForeColor = Color.Red;
            if (heightTextBox.Text.Trim().Length == 0)
            {
                heightTextBoxErrorMessage.Font = LabelNotCollapsedFont;
                heightTextBoxErrorMessage.Text = ErrorMessages.VisitErrorMessages.HeightCannotBeEmpty;
            }
            else if (!Double.TryParse(heightTextBox.Text, out double n))
            {
                heightTextBoxErrorMessage.Font = LabelNotCollapsedFont;
                heightTextBoxErrorMessage.Text = ErrorMessages.VisitErrorMessages.HeightMustBeValidDecimal;
            }
            else
            {
                heightTextBoxErrorMessage.Font = LabelCollapsedFont;
                heightTextBoxErrorMessage.Text = "";
            }
        }

        /// <summary>
        /// Verifies the weight input.
        /// </summary>
        /// <param name="weightTextBox">The weight text box.</param>
        /// <param name="weightTextBoxErrorMessage">The weight text box error message.</param>
        public static void VerifyWeightInput(TextBox weightTextBox, Label weightTextBoxErrorMessage)
        {
            weightTextBoxErrorMessage.ForeColor = Color.Red;
            if (weightTextBox.Text.Trim().Length == 0)
            {
                weightTextBoxErrorMessage.Font = LabelNotCollapsedFont;
                weightTextBoxErrorMessage.Text = ErrorMessages.VisitErrorMessages.WeightCannotBeEmpty;
            }
            else if (!Double.TryParse(weightTextBox.Text, out double n))
            {
                weightTextBoxErrorMessage.Font = LabelNotCollapsedFont;
                weightTextBoxErrorMessage.Text = ErrorMessages.VisitErrorMessages.WeightMustBeValidDecimal;
            }
            else
            {
                weightTextBoxErrorMessage.Font = LabelCollapsedFont;
                weightTextBoxErrorMessage.Text = "";
            }
        }

        /// <summary>
        /// Verifies the nurse input.
        /// </summary>
        /// <param name="nurseComboBox">The nurse ComboBox.</param>
        /// <param name="nurseComboBoxErrorMessage">The nurse ComboBox error message.</param>
        public static void VerifyNurseInput(ComboBox nurseComboBox, Label nurseComboBoxErrorMessage)
        {
            nurseComboBoxErrorMessage.ForeColor = Color.Red;
            if (nurseComboBox.Text.Trim().Length == 0)
            {
                nurseComboBoxErrorMessage.Font = LabelNotCollapsedFont;
                nurseComboBoxErrorMessage.Text = ErrorMessages.VisitErrorMessages.NurseCannotBeEmpty;
            }
            else
            {
                nurseComboBoxErrorMessage.Font = LabelCollapsedFont;
                nurseComboBoxErrorMessage.Text = "";
            }
        }

        /// <summary>
        /// Verifies the symptoms input.
        /// </summary>
        /// <param name="symptomsTextBox">The symptoms text box.</param>
        /// <param name="symptomsTextBoxErrorMessage">The symptoms text box error message.</param>
        public static void VerifySymptomsInput(TextBox symptomsTextBox, Label symptomsTextBoxErrorMessage)
        {
            symptomsTextBoxErrorMessage.ForeColor = Color.Red;
            if (symptomsTextBox.Text.Trim().Length == 0)
            {
                symptomsTextBoxErrorMessage.Font = LabelNotCollapsedFont;
                symptomsTextBoxErrorMessage.Text = ErrorMessages.VisitErrorMessages.SymptomsCannotBeEmpty;
            }
            else if (symptomsTextBox.Text.Trim().Length > 100)
            {
                symptomsTextBoxErrorMessage.Font = LabelNotCollapsedFont;
                symptomsTextBoxErrorMessage.Text = ErrorMessages.VisitErrorMessages.SymptomsLengthIsTooLong;
            }
            else
            {
                symptomsTextBoxErrorMessage.Font = LabelCollapsedFont;
                symptomsTextBoxErrorMessage.Text = "";
            }
        }
    }
}
