using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CS3230Project.ErrorMessages;
using CS3230Project.Model.Users.Patients;

namespace CS3230ProjectTests.Model.Accounts.Users
{
    [TestClass]
    public class PatientTests
    {
        [TestMethod]
        public void TestPatientIdLessThanZero()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(-1, "first1", "last1", new DateTime(2000, 1, 1), "male", "123 address", null, "Carrollton", "GA", "30117", "770-830-1330", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.PatientIdCannotBeLessThanZero);
        }

        [TestMethod]
        public void TestNullFirstName()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(1, null, "last1", new DateTime(2000, 1, 1), "male", "123 address", null, "Carrollton", "GA", "30117", "770-830-1330", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.FirstNameCannotBeNull);
        }

        [TestMethod]
        public void TestEmptyFirstName()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(1, "", "last1", new DateTime(2000, 1, 1), "male", "123 address", null, "Carrollton", "GA", "30117", "770-830-1330", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.FirstNameCannotBeEmpty);
        }

        [TestMethod]
        public void TestNullLastName()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(1, "first1", null, new DateTime(2000, 1, 1), "male", "123 address", null, "Carrollton", "GA", "30117", "770-830-1330", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.LastNameCannotBeNull);
        }

        [TestMethod]
        public void TestEmptyLastName()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(1, "first1", "", new DateTime(2000, 1, 1), "male", "123 address", null, "Carrollton", "GA", "30117", "770-830-1330", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.LastNameCannotBeEmpty);
        }

        [TestMethod]
        public void TestDateOfBirthWellBefore1900()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(1, "first1", "last1", new DateTime(1800, 8, 18), "male", "123 address", null, "Carrollton", "GA", "30117", "770-830-1330", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.DateOfBirthCannotBeBefore1900);
        }

        [TestMethod]
        public void TestDateOfBirthOneDayBefore1900()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(1, "first1", "last1", new DateTime(1899, 12, 31), "male", "123 address", null, "Carrollton", "GA", "30117", "770-830-1330", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.DateOfBirthCannotBeBefore1900);
        }

        [TestMethod]
        public void TestDateOfBirthFarInFuture()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(1, "first1", "last1", new DateTime(2222, 1, 1), "male", "123 address", null, "Carrollton", "GA", "30117", "770-830-1330", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.DateOfBirthCannotBeInTheFuture);
        }

        [TestMethod]
        public void TestDateOfBirthOneDayInFuture()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(1, "first1", "last1",  DateTime.Now.AddDays(1), "male", "123 address", null, "Carrollton", "GA", "30117", "770-830-1330", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.DateOfBirthCannotBeInTheFuture);
        }

        [TestMethod]
        public void TestNullGender()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(1, "first1", "last1", new DateTime(2000, 1, 1), null, "123 address", null, "Carrollton", "GA", "30117", "770-830-1330", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.GenderCannotBeNull);
        }

        [TestMethod]
        public void TestEmptyGender()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(1, "first1", "last1", new DateTime(2000, 1, 1), "", "123 address", null, "Carrollton", "GA", "30117", "770-830-1330", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.GenderCannotBeEmpty);
        }

        [TestMethod]
        public void TestNullAddressOne()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(1, "first1", "last1", new DateTime(2000, 1, 1), "Male", null, null, "Carrollton", "GA", "30117", "770-830-1330", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.AddressOneCannotBeNull);
        }

        [TestMethod]
        public void TestEmptyAddressOne()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(1, "first1", "last1", new DateTime(2000, 1, 1), "Male", "", null, "Carrollton", "GA", "30117", "770-830-1330", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.AddressOneCannotBeEmpty);
        }

        [TestMethod]
        public void TestNullCity()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(1, "first1", "last1", new DateTime(2000, 1, 1), "Male", "123 address", null, null, "GA", "30117", "770-830-1330", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.CityCannotBeNull);
        }

        [TestMethod]
        public void TestEmptyCity()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(1, "first1", "last1", new DateTime(2000, 1, 1), "Male", "123 address", null, "", "GA", "30117", "770-830-1330", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.CityCannotBeEmpty);
        }

        [TestMethod]
        public void TestNullState()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(1, "first1", "last1", new DateTime(2000, 1, 1), "Male", "123 address", null, "Carrollton", null, "30117", "770-830-1330", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.StateCannotBeNull);
        }

        [TestMethod]
        public void TestEmptyState()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(1, "first1", "last1", new DateTime(2000, 1, 1), "Male", "123 address", null, "Carrollton", "", "30117", "770-830-1330", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.StateCannotBeEmpty);
        }

        [TestMethod]
        public void TestNullZip()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(1, "first1", "last1", new DateTime(2000, 1, 1), "Male", "123 address", null, "Carrollton", "GA", null, "770-830-1330", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.ZipcodeCannotBeNull);
        }

        [TestMethod]
        public void TestEmptyZip()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(1, "first1", "last1", new DateTime(2000, 1, 1), "Male", "123 address", null, "Carrollton", "GA", "", "770-830-1330", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.ZipcodeCannotBeEmpty);
        }

        [TestMethod]
        public void TestNullPhone()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(1, "first1", "last1", new DateTime(2000, 1, 1), "Male", "123 address", null, "Carrollton", "GA", "30117", null, true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.PhoneNumberCannotBeNull);
        }

        [TestMethod]
        public void TestEmptyPhone()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(1, "first1", "last1", new DateTime(2000, 1, 1), "Male", "123 address", null, "Carrollton", "GA", "30117", "", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.PhoneNumberCannotBeEmpty);
        }

        [TestMethod]
        public void TestInvalidPhoneNoDashes()
        {
            var message = Assert.ThrowsException<FormatException>(() =>
            {
                _ = new Patient(1, "first1", "last1", new DateTime(2000, 1, 1), "Male", "123 address", null, "Carrollton", "GA", "30117", "7708301330", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.InvalidPhoneNumberFormat);
        }

        [TestMethod]
        public void TestInvalidPhoneCorrectFormatWithLetters()
        {
            var message = Assert.ThrowsException<FormatException>(() =>
            {
                _ = new Patient(1, "first1", "last1", new DateTime(2000, 1, 1), "Male", "123 address", null, "Carrollton", "GA", "30117", "7t0-8A0-13s0", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.InvalidPhoneNumberFormat);
        }

        [TestMethod]
        public void TestInvalidPhoneTooManyDigits()
        {
            var message = Assert.ThrowsException<FormatException>(() =>
            {
                _ = new Patient(1, "first1", "last1", new DateTime(2000, 1, 1), "Male", "123 address", null, "Carrollton", "GA", "30117", "7705-8305-13305", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.InvalidPhoneNumberFormat);
        }

        [TestMethod]
        public void TestInvalidPhoneWithParantheses()
        {
            var message = Assert.ThrowsException<FormatException>(() =>
            {
                _ = new Patient(1, "first1", "last1", new DateTime(2000, 1, 1), "Male", "123 address", null, "Carrollton", "GA", "30117", "(770) 830-1330", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.InvalidPhoneNumberFormat);
        }

        [TestMethod]
        public void TestValidPatientCreated()
        {
            var patient = new Patient(1, "first1", "last1", new DateTime(2000, 1, 1), "Male", "123 address", null, "Carrollton", "GA", "30117", "770-830-1330", true);
            Assert.AreEqual(1, patient.PatientId);
            Assert.AreEqual("first1", patient.FirstName);
            Assert.AreEqual("last1", patient.LastName);
            Assert.AreEqual(new DateTime(2000, 1, 1), patient.DateOfBirth);
            Assert.AreEqual("Male", patient.Gender);
            Assert.AreEqual("123 address", patient.AddressOne);
            Assert.IsNull(patient.AddressTwo);
            Assert.AreEqual("Carrollton", patient.City);
            Assert.AreEqual("GA", patient.State);
            Assert.AreEqual("30117", patient.Zipcode);
            Assert.AreEqual("770-830-1330", patient.PhoneNumber);
            Assert.IsTrue(patient.Status);
        }
    }
}
