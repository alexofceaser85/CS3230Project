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
        public int appointmentID { get; }
        /// <summary>
        /// The ID for the nurse assisting with the visit
        /// </summary>
        public int nurseID { get; }
        /// <summary>
        /// The body temp of the patient at the time of the visit
        /// </summary>
        public double bodyTemp { get; }
        /// <summary>
        /// The pulse of the patient at the time of the visit
        /// </summary>
        public int pulse { get; }
        /// <summary>
        /// The height of the patient at the time of the visit
        /// </summary>
        public double height { get; }
        /// <summary>
        /// The weight of the patient at the time of the visit
        /// </summary>
        public double weight { get; }
        /// <summary>
        /// The height of the patient at the time of the visit
        /// </summary>
        public string symptoms { get; }
        /// <summary>
        /// The systolic blood pressure of the patient at the time of the visit
        /// </summary>
        public int systolicBloodPressure { get; }
        /// <summary>
        /// The diastolic blood pressure of the patient at the time of the visit
        /// </summary>
        public int diastolicBloodPressure { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Visit" /> class.
        ///
        /// Precondition:
        ///     appointmentID MORE THAN OR EQUAL TO 0
        ///     AND nurseID MORE THAN OR EQUAL TO 0
        ///     AND bodyTemp MORE THAN OR EQUAL TO 0
        ///     AND pulse MORE THAN OR EQUAL TO 0
        ///     AND height MORE THAN OR EQUAL TO 0
        ///     AND weight MORE THAN OR EQUAL TO 0
        ///     AND !symptoms.isEmpty()
        ///     AND symptoms != null
        ///     AND systolicBloodPressure MORE THAN OR EQUAL TO 0
        ///     AND diastolicBloodPressure MORE THAN OR EQUAL TO 0
        /// Post-condition: visits.length = visits.length @prev + 1
        /// </summary>
        /// <param name="appointmentID">The appointment identifier.</param>
        /// <param name="nurseID">The nurse identifier.</param>
        /// <param name="bodyTemp">The body temporary.</param>
        /// <param name="pulse">The pulse.</param>
        /// <param name="height">The height.</param>
        /// <param name="weight">The weight.</param>
        /// <param name="symptoms">The symptoms.</param>
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
            if (systolicBloodPressure < 0)
            {
                throw new ArgumentException(VisitErrorMessages.SystolicBloodPressureCannotBeLessThanZero);
            }
            if (diastolicBloodPressure < 0)
            {
                throw new ArgumentException(VisitErrorMessages.DiastolicBloodPressureCannotBeLessThanZero);
            }

            this.appointmentID = appointmentID;
            this.nurseID = nurseID;
            this.bodyTemp = bodyTemp;
            this.pulse = pulse;
            this.height = height;
            this.weight = weight;
            this.symptoms = symptoms;
            this.systolicBloodPressure = systolicBloodPressure;
            this.diastolicBloodPressure = diastolicBloodPressure;
        }
    }
}
