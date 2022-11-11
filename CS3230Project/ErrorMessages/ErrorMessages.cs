namespace CS3230Project.ErrorMessages
{
    /// <summary>
    /// The accounts data access layer error messages
    /// </summary>
    public static class AccountsErrorMessages
    {
        /// <summary>
        /// Error message for null login user name
        /// </summary>
        public static string LoginUserNameCannotBeNull = "The login user name cannot be null";
        /// <summary>
        /// Error message for empty login user name
        /// </summary>
        public static string LoginUserNameCannotBeEmpty = "The login user name cannot be empty";
        /// <summary>
        /// Error message for null login password
        /// </summary>
        public static string LoginPasswordCannotBeNull = "The login password cannot be null";
        /// <summary>
        /// Error message for empty login password
        /// </summary>
        public static string LoginPasswordCannotBeEmpty = "The login password cannot be empty";
    }

    /// <summary>
    /// The error messages for the nurse
    /// </summary>
    public static class NurseErrorMessages
    {
        /// <summary>
        /// Error message for id less than zero
        /// </summary>
        public static string IdCannotBeLessThanZero = "The nurse ID cannot be less than zero";
        /// <summary>
        /// Error message for null first name
        /// </summary>
        public static string FirstNameCannotBeNull = "The nurse first name cannot be null";
        /// <summary>
        /// Error message for empty first name
        /// </summary>
        public static string FirstNameCannotBeEmpty = "The nurse first name cannot be empty";
        /// <summary>
        /// Error message for null last name
        /// </summary>
        public static string LastNameCannotBeNull = "The nurse last name cannot be null";
        /// <summary>
        /// Error message for empty last name
        /// </summary>
        public static string LastNameCannotBeEmpty = "The nurse last name cannot be empty";
        /// <summary>
        /// Error message for null user name
        /// </summary>
        public static string UserNameCannotBeNull = "The nurse user name cannot be null";
        /// <summary>
        /// Error message for empty user name
        /// </summary>
        public static string UserNameCannotBeEmpty = "The nurse user name cannot be empty";
        /// <summary>
        /// Error message for date of birth before 1900
        /// </summary>
        public static string DateOfBirthCannotBeBefore1900 = "The nurse's date of birth cannot be before 1900.";
        /// <summary>
        /// Error message for date of birth in the future
        /// </summary>
        public static string DateOfBirthCannotBeInTheFuture = "The nurse's date of birth cannot be in the future.";
        /// <summary>
        /// Error message for null gender
        /// </summary>
        public static string GenderCannotBeNull = "The nurse's gender cannot be null.";
        /// <summary>
        /// Error message for empty gender
        /// </summary>
        public static string GenderCannotBeEmpty = "The nurse's gender cannot be empty.";
        /// <summary>
        /// Error message for gender being too long
        /// </summary>
        public static string GenderIsTooLong = "The nurse's gender is too long";
        /// <summary>
        /// Error message for null street address
        /// </summary>
        public static string AddressOneCannotBeNull = "The nurse's address one cannot be null.";
        /// <summary>
        /// Error message for empty street address
        /// </summary>
        public static string AddressOneCannotBeEmpty = "The nurse's address one cannot be empty.";
        /// <summary>
        /// Error message for address one being too long
        /// </summary>
        public static string AddressOneIsTooLong = "The nurse's one is too long";
        /// <summary>
        /// Error message for null address two
        /// </summary>
        public static string AddressTwoCannotBeNull = "The nurse's address two cannot be null";
        /// <summary>
        /// Error message for address two being too long
        /// </summary>
        public static string AddressTwoIsTooLong = "The nurse's two is too long";
        /// <summary>
        /// Error message for null city
        /// </summary>
        public static string CityCannotBeNull = "The nurse's city cannot be null.";
        /// <summary>
        /// Error message for empty city
        /// </summary>
        public static string CityCannotBeEmpty = "The nurse's city cannot be empty.";
        /// <summary>
        /// Error message for city being too long
        /// </summary>
        public static string CityIsTooLong = "The city is too long";
        /// <summary>
        /// Error message for null state
        /// </summary>
        public static string StateCannotBeNull = "The nurse's state cannot be null.";
        /// <summary>
        /// Error message for empty state
        /// </summary>
        public static string StateCannotBeEmpty = "The nurse's state cannot be empty.";
        /// <summary>
        /// Error message for state being too long
        /// </summary>
        public static string StateIsTooLong = "The nurse's state is too long";
        /// <summary>
        /// Error message for null zip code
        /// </summary>
        public static string ZipcodeCannotBeNull = "The nurse's zip code cannot be null.";
        /// <summary>
        /// Error message for empty zip code
        /// </summary>
        public static string ZipcodeCannotBeEmpty = "The nurse's zip code cannot be empty.";
        /// <summary>
        /// Error message for incorrect zip code size
        /// </summary>
        public static string ZipcodeMustHaveFiveCharacters =
            "The zip code is in incorrect format, must have five characters";
        /// <summary>
        /// Error message for incorrect zip code format
        /// </summary>
        public static string ZipcodeMustBeAllDigits =
            "The zip code is in incorrect format, must be all digits";

        /// <summary>
        /// Error message for zip code not having all digits and have five characters
        /// </summary>
        public static string ZipCodeMustBeAllDigitsAndHaveFiveCharacters =
            "The zip code must be five characters, all digits";
        /// <summary>
        /// Error message for null phone number
        /// </summary>
        public static string PhoneNumberCannotBeNull = "The nurse's phone number cannot be null.";
        /// <summary>
        /// Error message for empty phone number
        /// </summary>
        public static string PhoneNumberCannotBeEmpty = "The nurse's phone number cannot be empty.";
        /// <summary>
        /// Error message for an invalid phone number format
        /// </summary>
        public static string InvalidPhoneNumberFormat =
            "Phone number not in the correct format";
    }

    /// <summary>
    ///   The error messages for the patient
    /// </summary>
    public static class PatientErrorMessages
    {
        /// <summary>
        /// Error message for id less than zero
        /// </summary>
        public static string PatientIdCannotBeLessThanZero = "The patient ID cannot be less than zero";
        /// <summary>
        /// Error message for null first name
        /// </summary>
        public static string FirstNameCannotBeNull = "The patient first name cannot be null";
        /// <summary>
        /// Error message for empty first name
        /// </summary>
        public static string FirstNameCannotBeEmpty = "The patient first name cannot be empty";
        /// <summary>
        /// Error message for first name being too long
        /// </summary>
        public static string FirstNameIsTooLong = "The patient first name is too long";
        /// <summary>
        /// Error message for null last name
        /// </summary>
        public static string LastNameCannotBeNull = "The patient last name cannot be null";
        /// <summary>
        /// Error message for empty last name
        /// </summary>
        public static string LastNameCannotBeEmpty = "The patient last name cannot be empty";
        /// <summary>
        /// Error message for last name being too long
        /// </summary>
        public static string LastNameIsTooLong = "The patient last name is too long";
        /// <summary>
        /// Error message for both first and last names being either null or empty
        /// </summary>
        public static string FirstAndLastNamesCannotBothBeEmpty =
            "The patients first and last names cannot both be empty.";
        /// <summary>
        /// Error message for date of birth before 1900
        /// </summary>
        public static string DateOfBirthCannotBeBefore1900 = "The patient date of birth cannot be before 1900.";
        /// <summary>
        /// Error message for date of birth in the future
        /// </summary>
        public static string DateOfBirthCannotBeInTheFuture = "The patient date of birth cannot be in the future.";
        /// <summary>
        /// Error message for null gender
        /// </summary>
        public static string GenderCannotBeNull = "The patient gender cannot be null.";
        /// <summary>
        /// Error message for empty gender
        /// </summary>
        public static string GenderCannotBeEmpty = "The patient gender cannot be empty.";
        /// <summary>
        /// Error message for gender being too long
        /// </summary>
        public static string GenderIsTooLong = "The patient gender is too long";
        /// <summary>
        /// Error message for null street address
        /// </summary>
        public static string AddressOneCannotBeNull = "The patient address one cannot be null.";
        /// <summary>
        /// Error message for empty street address
        /// </summary>
        public static string AddressOneCannotBeEmpty = "The patient address one cannot be empty.";
        /// <summary>
        /// Error message for address one being too long
        /// </summary>
        public static string AddressOneIsTooLong = "The address one is too long";
        /// <summary>
        /// Error message for null address two
        /// </summary>
        public static string AddressTwoCannotBeNull = "The patient address two cannot be null";
        /// <summary>
        /// Error message for address two being too long
        /// </summary>
        public static string AddressTwoIsTooLong = "The address two is too long";
        /// <summary>
        /// Error message for null city
        /// </summary>
        public static string CityCannotBeNull = "The patient city cannot be null.";
        /// <summary>
        /// Error message for empty city
        /// </summary>
        public static string CityCannotBeEmpty = "The patient city cannot be empty.";
        /// <summary>
        /// Error message for city being too long
        /// </summary>
        public static string CityIsTooLong = "The city is too long";
        /// <summary>
        /// Error message for null state
        /// </summary>
        public static string StateCannotBeNull = "The patient state cannot be null.";
        /// <summary>
        /// Error message for empty state
        /// </summary>
        public static string StateCannotBeEmpty = "The patient state cannot be empty.";
        /// <summary>
        /// Error message for state being too long
        /// </summary>
        public static string StateIsTooLong = "The patient state is too long";
        /// <summary>
        /// Error message for null zip code
        /// </summary>
        public static string ZipcodeCannotBeNull = "The patient zip code cannot be null.";
        /// <summary>
        /// Error message for empty zip code
        /// </summary>
        public static string ZipcodeCannotBeEmpty = "The patient zip code cannot be empty.";
        /// <summary>
        /// Error message for incorrect zip code size
        /// </summary>
        public static string ZipcodeMustHaveFiveCharacters =
            "The zip code is in incorrect format, must have five characters";
        /// <summary>
        /// Error message for incorrect zip code format
        /// </summary>
        public static string ZipcodeMustBeAllDigits =
            "The zip code is in incorrect format, must be all digits";
        /// <summary>
        /// The error message for a zip code not all digits and five characters
        /// </summary>
        public static string ZipCodeMustBeAllDigitsAndHaveFiveCharacters =
            "The zip code must be five characters, all digits";
        /// <summary>
        /// Error message for null phone number
        /// </summary>
        public static string PhoneNumberCannotBeNull = "The patient phone number cannot be null.";
        /// <summary>
        /// Error message for empty phone number
        /// </summary>
        public static string PhoneNumberCannotBeEmpty = "The patient phone number cannot be empty.";
        /// <summary>
        /// Error message for an invalid phone number format
        /// </summary>
        public static string InvalidPhoneNumberFormat =
            "Phone number not in the correct format";
        /// <summary>
        /// Error message for an empty patient status
        /// </summary>
        public static string PatientStatusCannotBeEmpty = "The patient status cannot be empty";
        /// <summary>
        /// Error message for a null patient to add
        /// </summary>
        public static string PatientToAddCannotBeNull = "The patient to add cannot be null.";
        /// <summary>
        /// Error message for a null updated patient details
        /// </summary>
        public static string UpdatedPatientDetailsCannotBeNull = "The updated patient details cannot be null.";
        /// <summary>
        /// Error message for an empty updated patient details
        /// </summary>
        public static string UpdatedPatientDetailsCannotBeEmpty = "The updated patient details cannot be empty.";
        /// <summary>
        /// Error message for invalid patient details
        /// </summary>
        public static string UpdatedPatientDetailsAreInvalid = 
            "The updated patient details are invalid. Please correct and try again.";
    }

    /// <summary>
    ///   The error messages for the patient
    /// </summary>
    public static class DoctorErrorMessages
    {
        /// <summary>
        /// Error message for id less than zero
        /// </summary>
        public static string DoctorIdCannotBeLessThanZero = "The doctor ID cannot be less than zero";
        /// <summary>
        /// Error message for null first name
        /// </summary>
        public static string FirstNameCannotBeNull = "The doctor first name cannot be null";
        /// <summary>
        /// Error message for empty first name
        /// </summary>
        public static string FirstNameCannotBeEmpty = "The doctor first name cannot be empty";
        /// <summary>
        /// Error message for first name being too long
        /// </summary>
        public static string FirstNameIsTooLong = "The doctor first name is too long";
        /// <summary>
        /// Error message for null last name
        /// </summary>
        public static string LastNameCannotBeNull = "The doctor last name cannot be null";
        /// <summary>
        /// Error message for empty last name
        /// </summary>
        public static string LastNameCannotBeEmpty = "The doctor last name cannot be empty";
        /// <summary>
        /// Error message for last name being too long
        /// </summary>
        public static string LastNameIsTooLong = "The doctor last name is too long";
        /// <summary>
        /// Error message for both first and last names being either null or empty
        /// </summary>
        public static string FirstAndLastNamesCannotBothBeEmpty =
            "The doctor first and last names cannot both be empty.";
        /// <summary>
        /// Error message for date of birth before 1900
        /// </summary>
        public static string DateOfBirthCannotBeBefore1900 = "The doctor date of birth cannot be before 1900.";
        /// <summary>
        /// Error message for date of birth in the future
        /// </summary>
        public static string DateOfBirthCannotBeInTheFuture = "The doctor date of birth cannot be in the future.";
        /// <summary>
        /// Error message for null gender
        /// </summary>
        public static string GenderCannotBeNull = "The doctor gender cannot be null.";
        /// <summary>
        /// Error message for empty gender
        /// </summary>
        public static string GenderCannotBeEmpty = "The doctor gender cannot be empty.";
        /// <summary>
        /// Error message for gender being too long
        /// </summary>
        public static string GenderIsTooLong = "The doctor gender is too long";
        /// <summary>
        /// Error message for null street address
        /// </summary>
        public static string AddressOneCannotBeNull = "The doctor address one cannot be null.";
        /// <summary>
        /// Error message for empty street address
        /// </summary>
        public static string AddressOneCannotBeEmpty = "The doctor address one cannot be empty.";
        /// <summary>
        /// Error message for address one being too long
        /// </summary>
        public static string AddressOneIsTooLong = "The doctor one is too long";
        /// <summary>
        /// Error message for null address two
        /// </summary>
        public static string AddressTwoCannotBeNull = "The doctor address two cannot be null";
        /// <summary>
        /// Error message for address two being too long
        /// </summary>
        public static string AddressTwoIsTooLong = "The doctor two is too long";
        /// <summary>
        /// Error message for null city
        /// </summary>
        public static string CityCannotBeNull = "The doctor city cannot be null.";
        /// <summary>
        /// Error message for empty city
        /// </summary>
        public static string CityCannotBeEmpty = "The doctor city cannot be empty.";
        /// <summary>
        /// Error message for city being too long
        /// </summary>
        public static string CityIsTooLong = "The city is too long";
        /// <summary>
        /// Error message for null state
        /// </summary>
        public static string StateCannotBeNull = "The doctor state cannot be null.";
        /// <summary>
        /// Error message for empty state
        /// </summary>
        public static string StateCannotBeEmpty = "The doctor state cannot be empty.";
        /// <summary>
        /// Error message for state being too long
        /// </summary>
        public static string StateIsTooLong = "The doctor state is too long";
        /// <summary>
        /// Error message for null zip code
        /// </summary>
        public static string ZipcodeCannotBeNull = "The doctor zip code cannot be null.";
        /// <summary>
        /// Error message for empty zip code
        /// </summary>
        public static string ZipcodeCannotBeEmpty = "The doctor zip code cannot be empty.";
        /// <summary>
        /// Error message for incorrect zip code size
        /// </summary>
        public static string ZipcodeMustHaveFiveCharacters =
            "The zip code is in incorrect format, must have five characters";
        /// <summary>
        /// Error message for incorrect zip code format
        /// </summary>
        public static string ZipcodeMustBeAllDigits =
            "The zip code is in incorrect format, must be all digits";

        /// <summary>
        /// Error message for zip code not having all digits and have five characters
        /// </summary>
        public static string ZipCodeMustBeAllDigitsAndHaveFiveCharacters =
            "The zip code must be five characters, all digits";
        /// <summary>
        /// Error message for null phone number
        /// </summary>
        public static string PhoneNumberCannotBeNull = "The doctor phone number cannot be null.";
        /// <summary>
        /// Error message for empty phone number
        /// </summary>
        public static string PhoneNumberCannotBeEmpty = "The doctor phone number cannot be empty.";
        /// <summary>
        /// Error message for an invalid phone number format
        /// </summary>
        public static string InvalidPhoneNumberFormat =
            "Phone number not in the correct format";
        /// <summary>
        /// Error message for a null patient to add
        /// </summary>
        public static string DoctorToAddCannotBeNull = "The doctor to add cannot be null.";
        /// <summary>
        /// Error message for a null updated patient details
        /// </summary>
        public static string UpdatedDoctorDetailsCannotBeNull = "The updated doctor details cannot be null.";
        /// <summary>
        /// Error message for an empty updated patient details
        /// </summary>
        public static string UpdatedDoctorDetailsCannotBeEmpty = "The updated doctor details cannot be empty.";
        /// <summary>
        /// Error message for doctor specialties cannot be null
        /// </summary>
        public static string SpecialtiesCannotBeNull = "The doctors specialties cannot be null";
    }

    /// <summary>
    /// The error messages for the appointment
    /// </summary>
    public static class AppointmentErrorMessages
    {
        /// <summary>
        /// The error message for an appointment ID less than zero
        /// </summary>
        public static string AppointmentIdCannotBeLessThanZero = "The appointment ID cannot be less than zero";
        /// <summary>
        /// The error message for a null appointment patient
        /// </summary>
        public static string PatientCannotBeNull = "The appointment patient cannot be null";

        /// <summary>
        /// The error message for a null appointment doctor
        /// </summary>
        public static string DoctorCannotBeNull = "The appointment doctor cannot be null";
        /// <summary>
        /// The error message for a null appointment reason
        /// </summary>
        public static string ReasonCannotBeNull = "The appointment reason cannot be null";
        /// <summary>
        /// The error message for an empty appointment reason
        /// </summary>
        public static string ReasonCannotBeEmpty = "The appointment reason cannot be empty";
        /// <summary>
        /// The error message for an appointment reason that is too long
        /// </summary>
        public static string ReasonCannotBeTooLong = "The appointment reason is too long";
    }

    /// <summary>
    /// The error messages for the appointment manager
    /// </summary>
    public static class AppointmentManagerErrorMessages
    {
        /// <summary>
        /// The error message for a patient ID less than zero 
        /// </summary>
        public static string PatientIdToGetCannotBeLessThanZero =
            "The patient ID to get appointments for cannot be less than zero";
        /// <summary>
        /// The error message for a patient ID less than zero 
        /// </summary>
        public static string PatientIdToAddCannotBeLessThanZero =
            "The patient ID to add an appointment for cannot be less than zero";
        /// <summary>
        /// The error message for a date time in the past
        /// </summary>
        public static string DateTimeCannotBeInThePast =
            "The appointment date and time must be in the future";
        /// <summary>
        /// The error message for a doctor ID less than zero
        /// </summary>
        public static string DoctorIdToAddCannotBeLessThanZero =
            "The doctor ID to add an appointment for cannot be less than zero";
        /// <summary>
        /// The error message for a null appointment reason
        /// </summary>
        public static string AppointmentReasonCannotBeNull = "The appointment reason cannot be null";
        /// <summary>
        /// The error message for an empty appointment reason
        /// </summary>
        public static string AppointmentReasonCannotBeEmpty = "The appointment reason cannot be empty";
        /// <summary>
        /// The appointment reason cannot be above the maximum length
        /// </summary>
        public static string AppointmentReasonCannotBeAboveMaxLength =
            "The appointment reason cannot be above max length";
    }

    /// <summary>
    /// The error messages for the Create Appointment form validation
    /// </summary>
    public class CreateAppointmentValidationMessages
    {
        /// <summary>
        /// The error message for a date time in the past
        /// </summary>
        public static string DateTimeCannotBeInThePast =
            "The appointment date and time must be in the future";
        /// <summary>
        /// The error message for an empty doctor selection
        /// </summary>
        public static string DoctorSelectionCannotBeEmpty = "Must select a doctor";
        /// <summary>
        /// The error message for an empty appointment reason
        /// </summary>
        public static string AppointmentReasonCannotBeEmpty = "The appointment reason cannot be empty";
        /// <summary>
        /// The appointment reason cannot be above the maximum length
        /// </summary>
        public static string AppointmentReasonCannotBeAboveMaxLength =
            "The appointment reason cannot be above max length";
    }

    /// <summary>
    ///   The error messages for the visits
    /// </summary>
    public static class VisitErrorMessages
    {
        /// <summary>
        /// The error message for appointment id cannot be less than zero
        /// </summary>
        public static string AppointmentIDCannotBeLessThanZero = "Appointment ID cannot be less than zero.";
        /// <summary>
        /// The error message for nurse id cannot be less than zero
        /// </summary>
        public static string NurseIDCannotBeLessThanZero = "Nurse ID cannot be less than zero.";
        /// <summary>
        /// The error message for nurse cannot be empty
        /// </summary>
        public static string NurseCannotBeEmpty = "Nurse cannot be empty.";
        /// <summary>
        /// The error message for body temp cannot be less than zero
        /// </summary>
        public static string BodyTempCannotBeLessThanZero = "Body temp cannot be less than zero.";
        /// <summary>
        /// The error message for body temp cannot be empty
        /// </summary>
        public static string BodyTempCannotBeEmpty = "Body temp cannot be empty.";
        /// <summary>
        /// The error message for body temp must be a valid decimal number.
        /// </summary>
        public static string BodyTempMustBeValidDecimal = "Body temp must be a valid decimal number.";
        /// <summary>
        /// The error message for pulse cannot be less than zero
        /// </summary>
        public static string PulseCannotBeLessThanZero = "Pulse cannot be less than zero.";
        /// <summary>
        /// The error message for pulse cannot be empty
        /// </summary>
        public static string PulseCannotBeEmpty = "Pulse cannot be empty.";
        /// <summary>
        /// The error message for pulse must be a valid integer
        /// </summary>
        public static string PulseMustBeValidInteger = "Pulse must be a valid integer.";
        /// <summary>
        /// The error message for height cannot be less than zero
        /// </summary>
        public static string HeightCannotBeLessThanZero = "Height cannot be less than zero.";
        /// <summary>
        /// The error message for height cannot be empty
        /// </summary>
        public static string HeightCannotBeEmpty = "Height cannot be empty.";
        /// <summary>
        /// The error message for height must be a valid decimal number
        /// </summary>
        public static string HeightMustBeValidDecimal = "Height must be a valid decimal number.";
        /// <summary>
        /// The error message for weight cannot be less than zero
        /// </summary>
        public static string WeightCannotBeLessThanZero = "Weight cannot be less than zero.";
        /// <summary>
        /// The error message for weight cannot be empty
        /// </summary>
        public static string WeightCannotBeEmpty = "Weight cannot be empty.";
        /// <summary>
        /// The error message for weight must be a valid decimal number
        /// </summary>
        public static string WeightMustBeValidDecimal = "Weight must be a valid decimal number.";
        /// <summary>
        /// The error message for symptoms cannot be empty
        /// </summary>
        public static string SymptomsCannotBeEmpty = "Symptoms cannot be empty.";
        /// <summary>
        /// The error message for symptoms cannot be null
        /// </summary>
        public static string SymptomsCannotBeNull = "Symptoms cannot be null.";
        /// <summary>
        /// The error message for visit symptoms length is too long
        /// </summary>
        public static string SymptomsLengthIsTooLong = "The visit symptoms is too long.";
        /// <summary>
        /// The error message for systolic blood pressure cannot be less than zero
        /// </summary>
        public static string SystolicBloodPressureCannotBeLessThanZero =
            "Systolic Blood Pressure cannot be less than zero.";
        /// <summary>
        /// The error message for systolic blood pressure cannot be empty
        /// </summary>
        public static string SystolicBloodPressureCannotBeEmpty =
            "Systolic Blood Pressure cannot be empty.";
        /// <summary>
        /// The error message for systolic blood pressure must be a valid integer
        /// </summary>
        public static string SystolicBloodPressureMustBeValidInteger =
            "Systolic Blood Pressure must be a valid integer.";
        /// <summary>
        /// The error message for diastolic blood pressure cannot be less than zero
        /// </summary>
        public static string DiastolicBloodPressureCannotBeLessThanZero =
            "Diastolic Blood Pressure cannot be less than zero.";
        /// <summary>
        /// The error message for diastolic blood pressure cannot be empty
        /// </summary>
        public static string DiastolicBloodPressureCannotBeEmpty =
            "Diastolic Blood Pressure cannot be empty.";
        /// <summary>
        /// The error message for diastolic blood pressure must be a valid integer
        /// </summary>
        public static string DiastolicBloodPressureMustBeValidInteger =
            "Diastolic Blood Pressure must be a valid integer.";
        /// <summary>
        /// The error message for visit to add cannot be null
        /// </summary>
        public static string VisitToAddCannotBeNull = "Visit to add cannot be null.";
        /// <summary>
        /// The error message for footer cannot be null
        /// </summary>
        public static string FooterCannotBeNull = "Footer cannot be null.";
        /// <summary>
        /// The error message for modified visit cannot be null
        /// </summary>
        public static string ModifiedVisitCannotBeNull = "Modified visit cannot be null.";
    }
    /// <summary>
    /// The error messages for the tests
    /// </summary>
    public static class TestsErrorMessages
    {
        /// <summary>
        /// The appointment id for a test cannot be less than zero
        /// </summary>
        public static string AppointmentIdForTestCannotBeLessThanZero =
            "The appointment id for a test cannot be less than zero";
        /// <summary>
        /// The test's code cannot be less than zero
        /// </summary>
        public static string TestCodeForTestCannotBeLessThanZero = "The test code cannot be less than zero";
        /// <summary>
        /// The test's name cannot be null
        /// </summary>
        public static string TestNameCannotBeNull = "The test name cannot be null";
        /// <summary>
        /// The test's name cannot be empty
        /// </summary>
        public static string TestNameCannotBeEmpty = "The test name cannot be empty";
        /// <summary>
        /// The test's results cannot be null
        /// </summary>
        public static string TestResultsCannotBeNull = "The test results cannot be null";
        /// <summary>
        /// The test's results cannot be empty
        /// </summary>
        public static string TestResultsCannotBeEmpty = "The test results cannot be empty";
    }

    /// <summary>
    /// The error messages for the test manager
    /// </summary>
    public class TestManagerErrorMessages
    {
        /// <summary>
        /// The error message saying the test results cannot be null
        /// </summary>
        public static string TestResultsToAddCannotBeNull = "The test results to add cannot be null";

        /// <summary>
        /// The error message saying the test results to add cannot be empty
        /// </summary>
        public static string TestResultsCannotBeEmpty = "The test results to add cannot be empty";

        /// <summary>
        /// The non submitted test to add cannot be null
        /// </summary>
        public static string NonSubmittedTestToAddCannotBeNull = "The test to add cannot be null";

        /// <summary>
        /// The non submitted test to remove cannot be null
        /// </summary>
        public static string NonSubmittedTestToRemoveCannotBeNull = "The test to remove cannot be null";
        /// <summary>
        /// The date of the test results cannot be before the current date
        /// </summary>
        public static string CannotAddTestResultsBeforeCurrentDate = "Cannot add test results before the current date";
    }
}
