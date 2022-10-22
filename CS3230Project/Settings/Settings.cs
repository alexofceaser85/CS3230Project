namespace CS3230Project.Settings
{
    /// <summary>
    /// The settings for the patient
    /// </summary>
    public class UserSettings
    {
        /// <summary>
        /// The maximum length of the patient name
        /// </summary>
        public const int NameMaximumLength = 25;
        /// <summary>
        /// The maximum length of the patient's address components
        /// </summary>
        public const int AddressComponentMaximumLength = 50;
        /// <summary>
        /// The maximum length of the patient's gender
        /// </summary>
        public const int GenderMaximumLength = 6;
        /// <summary>
        /// The maximum length of the patient's zip code
        /// </summary>
        public const int ZipCodeLength = 5;
        /// <summary>
        /// The maximum length of the patient's state
        /// </summary>
        public const int StateMaximumLength = 50;
    }

    /// <summary>
    /// The settings for the appointment
    /// </summary>
    public class AppointmentSettings
    {
        /// <summary>
        /// The maximum length for an appointment reason
        /// </summary>
        public const int AppointmentReasonMaximumLength = 100;
    }
}
