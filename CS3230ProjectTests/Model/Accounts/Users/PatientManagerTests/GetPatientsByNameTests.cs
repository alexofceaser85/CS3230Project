using System;
using CS3230Project.ErrorMessages;
using CS3230Project.Model.Users.Patients;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CS3230ProjectTests.Model.Accounts.Users.PatientManagerTests
{
    [TestClass]
    public class GetPatientsByNameTests
    {
        [TestMethod]
        public void TestNullFirstAndLastNames()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                PatientManager.GetPatientsByName(null, null);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.FirstAndLastNamesCannotBothBeEmpty);
        }

        [TestMethod]
        public void TestEmptyFirstAndLastNames()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                PatientManager.GetPatientsByName("", "");
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.FirstAndLastNamesCannotBothBeEmpty);
        }

        [TestMethod]
        public void TestNullFirstEmptyLastNames()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                PatientManager.GetPatientsByName(null, "");
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.FirstAndLastNamesCannotBothBeEmpty);
        }

        [TestMethod]
        public void TestEmptyFirstNullLastNames()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                PatientManager.GetPatientsByName("", null);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.FirstAndLastNamesCannotBothBeEmpty);
        }
    }
}
