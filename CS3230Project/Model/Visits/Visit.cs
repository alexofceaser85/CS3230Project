using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS3230Project.ErrorMessages;

namespace CS3230Project.Model.Visits
{
    public class Visit
    {

        public int appointmentID { get; }
        
        public int nurseID { get; }

        public double bodyTemp { get; }

        public int pulse { get; }

        public double height { get; }

        public double weight { get; }

        public string symptoms { get; }

        public int systolicBloodPressure { get; }

        public int diastolicBloodPressure { get; }

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
