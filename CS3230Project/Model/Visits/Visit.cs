using System;
using CS3230Project.ErrorMessages;

namespace CS3230Project.Model.Visits
{
    /// <summary>
    ///   Holds the information for the visits
    /// </summary>
    public class Visit
    {

        /// <summary>
        /// The ID for the appointment
        /// </summary>
        public int AppointmentID { get; }
        /// <summary>
        /// The ID for the nurse assisting with the visit
        /// </summary>
        public int NurseID { get; }
        /// <summary>
        /// The body temp of the patient at the time of the visit
        /// </summary>
        public double BodyTemp { get; }
        /// <summary>
        /// The Pulse of the patient at the time of the visit
        /// </summary>
        public int Pulse { get; }
        /// <summary>
        /// The Height of the patient at the time of the visit
        /// </summary>
        public double Height { get; }
        /// <summary>
        /// The Weight of the patient at the time of the visit
        /// </summary>
        public double Weight { get; }
        /// <summary>
        /// The Height of the patient at the time of the visit
        /// </summary>
        public string Symptoms { get; }
        /// <summary>
        /// The systolic blood pressure of the patient at the time of the visit
        /// </summary>
        public int SystolicBloodPressure { get; }
        /// <summary>
        /// The diastolic blood pressure of the patient at the time of the visit
        /// </summary>
        public int DiastolicBloodPressure { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Visit" /> class.
        ///
        /// Precondition:
        ///     AppointmentID MORE THAN OR EQUAL TO 0
        ///     AND NurseID MORE THAN OR EQUAL TO 0
        ///     AND BodyTemp MORE THAN OR EQUAL TO 0
        ///     AND Pulse MORE THAN OR EQUAL TO 0
        ///     AND Height MORE THAN OR EQUAL TO 0
        ///     AND Weight MORE THAN OR EQUAL TO 0
        ///     AND !Symptoms.isEmpty()
        ///     AND Symptoms != null
        ///     AND Symptoms.length() LESS THAN OR EQUAL TO 100
        ///     AND SystolicBloodPressure MORE THAN OR EQUAL TO 0
        ///     AND DiastolicBloodPressure MORE THAN OR EQUAL TO 0
        /// Post-condition: visits.length = visits.length @prev + 1
        /// </summary>
        /// <param name="appointmentID">The appointment identifier.</param>
        /// <param name="nurseID">The nurse identifier.</param>
        /// <param name="bodyTemp">The body temporary.</param>
        /// <param name="pulse">The Pulse.</param>
        /// <param name="height">The Height.</param>
        /// <param name="weight">The Weight.</param>
        /// <param name="symptoms">The Symptoms.</param>
        /// <param name="systolicBloodPressure">The systolic blood pressure.</param>
        /// <param name="diastolicBloodPressure">The diastolic blood pressure.</param>
        /// <exception cref="System.ArgumentException"></exception>
        public Visit(int appointmentID, int nurseID, double bodyTemp, int pulse, double height, double weight, string symptoms, int systolicBloodPressure, int diastolicBloodPressure)
        {
            if (appointmentID < 0)
            {
                throw new ArgumentException(VisitErrorMessages.AppointmentIDCannotBeLessThanZero);
            }
            if (nurseID < 0)
            {
                throw new ArgumentException(VisitErrorMessages.NurseIDCannotBeLessThanZero);
            }
            if (bodyTemp < 0)
            {
                throw new ArgumentException(VisitErrorMessages.BodyTempCannotBeLessThanZero);
            }
            if (pulse < 0)
            {
                throw new ArgumentException(VisitErrorMessages.PulseCannotBeLessThanZero);
            }
            if (height < 0)
            {
                throw new ArgumentException(VisitErrorMessages.HeightCannotBeLessThanZero);
            }
            if (weight < 0)
            {
                throw new ArgumentException(VisitErrorMessages.WeightCannotBeLessThanZero);
            }
            if (symptoms.Trim().Length == 0)
            {
                throw new ArgumentException(VisitErrorMessages.SymptomsCannotBeEmpty);
            }
            if (symptoms == null)
            {
                throw new ArgumentException(VisitErrorMessages.SymptomsCannotBeNull);
            }
            if (symptoms.Length > Settings.VisitSettings.VisitSymptomsMaximumLength)
            {
                throw new ArgumentException(VisitErrorMessages.SymptomsLengthIsTooLong);
            }
            if (systolicBloodPressure < 0)
            {
                throw new ArgumentException(VisitErrorMessages.SystolicBloodPressureCannotBeLessThanZero);
            }
            if (diastolicBloodPressure < 0)
            {
                throw new ArgumentException(VisitErrorMessages.DiastolicBloodPressureCannotBeLessThanZero);
            }

            this.AppointmentID = appointmentID;
            this.NurseID = nurseID;
            this.BodyTemp = bodyTemp;
            this.Pulse = pulse;
            this.Height = height;
            this.Weight = weight;
            this.Symptoms = symptoms;
            this.SystolicBloodPressure = systolicBloodPressure;
            this.DiastolicBloodPressure = diastolicBloodPressure;
        }
    }
}
