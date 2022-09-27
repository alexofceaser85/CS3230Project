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
            Assert.AreEqual(message.Message, PatientErrorMessages.FirstAndLastNamesCannotBothBeNullOrEmpty);
        }

        [TestMethod]
        public void TestEmptyFirstAndLastNames()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                PatientManager.GetPatientsByName("", "");
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.FirstAndLastNamesCannotBothBeNullOrEmpty);
        }

        [TestMethod]
        public void TestNullFirstEmptyLastNames()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                PatientManager.GetPatientsByName(null, "");
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.FirstAndLastNamesCannotBothBeNullOrEmpty);
        }

        [TestMethod]
        public void TestEmptyFirstNullLastNames()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                PatientManager.GetPatientsByName("", null);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.FirstAndLastNamesCannotBothBeNullOrEmpty);
        }

        [TestMethod]
        public void TestValidFirstNameNullLastName()
        {
            Assert.AreEqual(1, PatientManager.GetPatientsByName("pat", null).Count);
            Assert.AreEqual("pat", PatientManager.GetPatientsByName("pat", null)[0].FirstName);
        }

        [TestMethod]
        public void TestValidLastNameNullFirstName()
        {
            Assert.AreEqual(1, PatientManager.GetPatientsByName(null, "patient").Count);
            Assert.AreEqual("pat", PatientManager.GetPatientsByName(null, "patient")[0].FirstName);
        }

        [TestMethod]
        public void TestValidFirstNameEmptyLastName()
        {
            Assert.AreEqual(1, PatientManager.GetPatientsByName("pat", "").Count);
            Assert.AreEqual("pat", PatientManager.GetPatientsByName("pat", "")[0].FirstName);
        }

        [TestMethod]
        public void TestValidLastNameEmptyFirstName()
        {
            Assert.AreEqual(1, PatientManager.GetPatientsByName("", "patient").Count);
            Assert.AreEqual("pat", PatientManager.GetPatientsByName("", "patient")[0].FirstName);
        }

        [TestMethod]
        public void TestValidFirstAndLastNames()
        {
            Assert.AreEqual(1, PatientManager.GetPatientsByName("pat", "patient").Count);
            Assert.AreEqual("pat", PatientManager.GetPatientsByName("pat", "patient")[0].FirstName);
            Assert.AreEqual("patient", PatientManager.GetPatientsByName("pat", "patient")[0].LastName);
        }
        
    }
}
