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
        public void PatientIdShouldNotBeOneLessThanZero()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(-1, "First", "Last", DateTime.Today, "Male", "777-777-7777", "Address", "", "Carrollton", "Georgia",
                    "11111", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.PatientIdCannotBeLessThanZero);
        }

        [TestMethod]
        public void PatientIdShouldNotBeWellLessThanZero()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(-100, "First", "Last", DateTime.Today, "Male", "777-777-7777", "Address", "", "Carrollton", "Georgia",
                    "11111", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.PatientIdCannotBeLessThanZero);
        }

        [TestMethod]
        public void PatientFirstNameShouldNotBeNull()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "Last", null, DateTime.Today, "Male", "777-777-7777", "Address", "", "Carrollton", "Georgia",
                    "11111", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.FirstNameCannotBeNull);
        }

        [TestMethod]
        public void PatientFirstNameShouldNotBeEmpty()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "Last", "", DateTime.Today, "Male", "777-777-7777", "Address", "", "Carrollton", "Georgia",
                    "11111",  true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.FirstNameCannotBeEmpty);
        }

        [TestMethod]
        public void PatientFirstNameShouldNotBeAllSpaces()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "Last", "       ", DateTime.Today, "Male", "777-777-7777", "Address", "", "Carrollton", "Georgia",
                    "11111",  true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.FirstNameCannotBeEmpty);
        }

        [TestMethod]
        public void PatientFirstNameShouldNotBeTooLong()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "Last", 
                    "TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST", 
                    DateTime.Today, "Male", "777-777-7777", "Address", "", "Carrollton", "Georgia", "11111", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.FirstNameIsTooLong);
        }

        [TestMethod]
        public void PatientLastNameShouldNotBeNull()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, null, "First", DateTime.Today, "Male", "777-777-7777", "Address", "", "Carrollton", "Georgia",
                    "11111",  true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.LastNameCannotBeNull);
        }

        [TestMethod]
        public void PatientLastNameShouldNotBeEmpty()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "", "First", DateTime.Today, "Male", "777-777-7777", "Address", "", "Carrollton", "Georgia",
                    "11111",  true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.LastNameCannotBeEmpty);
        }

        [TestMethod]
        public void PatientLastNameShouldNotBeAllSpaces()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "      ", "First", DateTime.Today, "Male", "777-777-7777", "Address", "", "Carrollton", "Georgia",
                    "11111",  true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.LastNameCannotBeEmpty);
        }

        [TestMethod]
        public void PatientLastNameShouldNotBeTooLong()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST", "First",
                    DateTime.Today, "Male", "777-777-7777", "Address", "", "Carrollton", "Georgia", "11111", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.LastNameIsTooLong);
        }

        [TestMethod]
        public void PatientDateOfBirthShouldNotBeBelow1900()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "First", "Last", new DateTime(1899, 12, 31), "Male", "777-777-7777", "Address", "", "Carrollton", "Georgia",
                    "11111",  true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.DateOfBirthCannotBeBefore1900);
        }

        [TestMethod]
        public void PatientDateOfBirthShouldNotBePastCurrentDate()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "First", "Last", DateTime.Today.AddDays(1), "Male", "777-777-7777", "Address", "", "Carrollton", "Georgia",
                    "11111",  true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.DateOfBirthCannotBeInTheFuture);
        }

        [TestMethod]
        public void PatientGenderCannotBeNull()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "First", "Last", DateTime.Today, null, "777-777-7777", "Address", "", "Carrollton", "Georgia",
                    "11111",  true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.GenderCannotBeNull);
        }

        [TestMethod]
        public void PatientGenderCannotBeEmpty()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "First", "Last", DateTime.Today, "", "777-777-7777", "Address", "", "Carrollton", "Georgia",
                    "11111",  true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.GenderCannotBeEmpty);
        }

        [TestMethod]
        public void PatientGenderCannotBeAllSpaces()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "First", "Last", DateTime.Today, "    ", "777-777-7777", "Address", "", "Carrollton", "Georgia",
                    "11111",  true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.GenderCannotBeEmpty);
        }

        [TestMethod]
        public void PatientGenderShouldNotBeTooLong()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "Last", "First", DateTime.Today, "TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST"
                    , "777-777-7777", "Address", "", "Carrollton", "Georgia", "11111", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.GenderIsTooLong);
        }

        [TestMethod]
        public void PatientAddressOneCannotBeNull()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "First", "Last", DateTime.Today, "Male", "777-777-7777", null, "", "Carrollton", "Georgia",
                    "11111", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.AddressOneCannotBeNull);
        }

        [TestMethod]
        public void PatientAddressOneCannotBeEmpty()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "First", "Last", DateTime.Today, "Male", "777-777-7777", "", "", "Carrollton", "Georgia",
                    "11111",  true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.AddressOneCannotBeEmpty);
        }

        [TestMethod]
        public void PatientAddressOneCannotBeAllSpaces()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "First", "Last", DateTime.Today, "Male", "777-777-7777", "      ", "", "Carrollton", "Georgia",
                    "11111", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.AddressOneCannotBeEmpty);
        }

        [TestMethod]
        public void PatientAddressOneShouldNotBeTooLong()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "Last", "First", DateTime.Today, "Male"
                    , "777-777-7777", "TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST", "", "Carrollton", "Georgia", "11111", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.AddressOneIsTooLong);
        }

        [TestMethod]
        public void PatientAddressTwoCannotBeNull()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "First", "Last", DateTime.Today, "Male", "777-777-7777", "Address", null, "Carrollton", "Georgia",
                    "11111",  true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.AddressTwoCannotBeNull);
        }

        [TestMethod]
        public void PatientAddressTwoShouldNotBeTooLong()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "Last", "First", DateTime.Today, "Male"
                    , "777-777-7777", "Address", "TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST", "Carrollton", "Georgia", "11111", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.AddressTwoIsTooLong);
        }

        [TestMethod]
        public void PatientCityCannotBeNull()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "First", "Last", DateTime.Today, "Male", "777-777-7777", "Address", "", null, "Georgia",
                    "11111",  true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.CityCannotBeNull);
        }

        [TestMethod]
        public void PatientCityCannotBeEmpty()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "First", "Last", DateTime.Today, "Male", "777-777-7777", "Address", "", "", "Georgia",
                    "11111",  true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.CityCannotBeEmpty);
        }

        [TestMethod]
        public void PatientCityCannotBeAllSpaces()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "First", "Last", DateTime.Today, "Male", "777-777-7777", "Address", "", "   ", "Georgia",
                    "11111",  true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.CityCannotBeEmpty);
        }

        [TestMethod]
        public void PatientCityShouldNotBeTooLong()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "Last", "First", DateTime.Today, "Male"
                    , "777-777-7777", "Address", "", "TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST", "GEORGIA", "11111", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.CityIsTooLong);
        }

        [TestMethod]
        public void PatientStateCannotBeNull()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "First", "Last", DateTime.Today, "Male", "777-777-7777", "Address", "", "Carrollton", null,
                    "11111",  true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.StateCannotBeNull);
        }

        [TestMethod]
        public void PatientStateCannotBeEmpty()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "First", "Last", DateTime.Today, "Male", "777-777-7777", "Address", "", "Carrollton", "",
                    "11111",  true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.StateCannotBeEmpty);
        }

        [TestMethod]
        public void PatientStateCannotBeAllSpaces()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "First", "Last", DateTime.Today, "Male", "777-777-7777", "Address", "", "Carrollton", "     ",
                    "11111",  true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.StateCannotBeEmpty);
        }

        [TestMethod]
        public void PatientStateShouldNotBeTooLong()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "Last", "First", DateTime.Today, "Male"
                    , "777-777-7777", "Address", "", "Carrollton", "TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST", "11111", true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.StateIsTooLong);
        }

        [TestMethod]
        public void PatientZipCodeCannotBeNull()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "First", "Last", DateTime.Today, "Male", "777-777-7777", "Address", "", "Carrollton", "Georgia",
                    null,  true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.ZipcodeCannotBeNull);
        }

        [TestMethod]
        public void PatientZipCodeCannotBeEmpty()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "First", "Last", DateTime.Today, "Male", "777-777-7777", "Address", "", "Carrollton", "Georgia",
                    "",  true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.ZipcodeCannotBeEmpty);
        }

        [TestMethod]
        public void PatientZipCodeCannotBeAllSpaces()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "First", "Last", DateTime.Today, "Male", "777-777-7777", "Address", "", "Carrollton", "Georgia",
                    "      ",  true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.ZipcodeCannotBeEmpty);
        }

        [TestMethod]
        public void PatientZipCodeMustBeAllDigits()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "First", "Last", DateTime.Today, "Male", "777-777-7777", "Address", "", "Carrollton", "Georgia",
                    "ddddd",  true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.ZipcodeMustBeAllDigits);
        }

        [TestMethod]
        public void PatientZipCodeCannotContainLessThanFiveDigits()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "First", "Last", DateTime.Today, "Male", "777-777-7777", "Address", "", "Carrollton", "Georgia",
                    "1234",  true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.ZipcodeMustHaveFiveCharacters);
        }

        [TestMethod]
        public void PatientZipCodeCannotContainMoreThanFiveDigits()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "First", "Last", DateTime.Today, "Male", "777-777-7777", "Address", "", "Carrollton", "Georgia",
                    "123456",  true);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.ZipcodeMustHaveFiveCharacters);
        }

        [TestMethod]
        public void PatientPhoneNumberCannotBeNull()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "First", "Last", DateTime.Today, "Male", null, "Address", "", "Carrollton", "Georgia",
                    "11111", true);
            });

            Assert.AreEqual(message.Message, PatientErrorMessages.PhoneNumberCannotBeNull);
        }

        [TestMethod]
        public void PatientPhoneNumberCannotBeEmpty()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "First", "Last", DateTime.Today, "Male", "", "Address", "", "Carrollton", "Georgia",
                    "11111", true);
            });

            Assert.AreEqual(message.Message, PatientErrorMessages.PhoneNumberCannotBeEmpty);
        }

        [TestMethod]
        public void PatientPhoneNumberCannotBeAllSpaces()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "First", "Last", DateTime.Today, "Male", "       ", "Address", "", "Carrollton", "Georgia",
                    "11111", true);
            });

            Assert.AreEqual(message.Message, PatientErrorMessages.PhoneNumberCannotBeEmpty);
        }

        [TestMethod]
        public void PatientPhoneNumberCannotContainLessThanTwelveDigits()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "First", "Last", DateTime.Today, "Male", "770-770-777", "Address", "", "Carrollton", "Georgia",
                    "11111", true);
            });

            Assert.AreEqual(message.Message, PatientErrorMessages.InvalidPhoneNumberFormat);
        }

        [TestMethod]
        public void PatientPhoneNumberCannotContainMoreThanTwelveDigits()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Patient(100, "First", "Last", DateTime.Today, "Male", "770-770-77755", "Address", "", "Carrollton", "Georgia",
                    "11111", true);
            });

            Assert.AreEqual(message.Message, PatientErrorMessages.InvalidPhoneNumberFormat);
        }

        [TestMethod]
        public void ShouldCreateValidPatient()
        {
            var patient = _ = new Patient(100, "Last", "First", DateTime.Today, "Male", "777-777-7777", "Address", "", "Carrollton", "Georgia",
                "11111", true);

            Assert.AreEqual(100, patient.PatientId);
            Assert.AreEqual("First", patient.FirstName);
            Assert.AreEqual("Last", patient.LastName);
            Assert.AreEqual(DateTime.Today, patient.DateOfBirth);
            Assert.AreEqual("Male", patient.Gender);
            Assert.AreEqual("Address", patient.AddressOne);
            Assert.AreEqual("", patient.AddressTwo);
            Assert.AreEqual("Carrollton", patient.City);
            Assert.AreEqual("Georgia", patient.State);
            Assert.AreEqual("11111", patient.Zipcode);
            Assert.AreEqual("777-777-7777", patient.PhoneNumber);
            Assert.AreEqual(true, patient.Status);
        }
    }
}
