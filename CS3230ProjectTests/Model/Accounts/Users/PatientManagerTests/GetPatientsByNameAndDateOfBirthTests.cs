﻿using CS3230Project.ErrorMessages;
using CS3230Project.Model.Users.Patients;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CS3230ProjectTests.Model.Accounts.Users.PatientManagerTests
{
    [TestClass]
    public class GetPatientsByNameAndDateOfBirthTests
    {
        [TestMethod]
        public void TestDateOfBirthWellBefore1900()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                PatientManager.GetPatientsByNameAndDateOfBirth("first", "last", new DateTime(1800, 1, 1));
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.DateOfBirthCannotBeBefore1900);
        }

        [TestMethod]
        public void TestDateOfBirthOneDayBefore1900()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                PatientManager.GetPatientsByNameAndDateOfBirth("first", "last", new DateTime(1899, 12, 31));
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.DateOfBirthCannotBeBefore1900);
        }

        [TestMethod]
        public void TestDateOfBirthFarInFuture()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                PatientManager.GetPatientsByNameAndDateOfBirth("first", "last", new DateTime(2222, 1, 1));
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.DateOfBirthCannotBeInTheFuture);
        }

        [TestMethod]
        public void TestDateOfBirthOneDayInFuture()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                PatientManager.GetPatientsByNameAndDateOfBirth("first", "last", DateTime.Now.AddDays(1));
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.DateOfBirthCannotBeInTheFuture);
        }

        [TestMethod]
        public void TestNullFirstAndLastNames()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                PatientManager.GetPatientsByNameAndDateOfBirth(null, null, DateTime.Now);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.FirstAndLastNamesCannotBothBeNullOrEmpty);
        }

        [TestMethod]
        public void TestEmptyFirstAndLastNames()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                PatientManager.GetPatientsByNameAndDateOfBirth("", "", DateTime.Now);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.FirstAndLastNamesCannotBothBeNullOrEmpty);
        }

        [TestMethod]
        public void TestNullFirstEmptyLastNames()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                PatientManager.GetPatientsByNameAndDateOfBirth(null, "", DateTime.Now);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.FirstAndLastNamesCannotBothBeNullOrEmpty);
        }

        [TestMethod]
        public void TestEmptyFirstNullLastNames()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                PatientManager.GetPatientsByNameAndDateOfBirth("", null, DateTime.Now);
            });
            Assert.AreEqual(message.Message, PatientErrorMessages.FirstAndLastNamesCannotBothBeNullOrEmpty);
        }

        /*
        [TestMethod]
        public void TestValidFirstNameAndDateOfBirthNullLastName()
        {
            Assert.AreEqual(1, PatientManager.GetPatientsByNameAndDateOfBirth("pat", null, DateTime.Now).Count);
            Assert.AreEqual("pat", PatientManager.GetPatientsByNameAndDateOfBirth("pat", null, DateTime.Now)[0].FirstName);
        }

        [TestMethod]
        public void TestValidLastNameAndDateOfBirthNullFirstName()
        {
            Assert.AreEqual(1, PatientManager.GetPatientsByNameAndDateOfBirth(null, "patient", DateTime.Now).Count);
            Assert.AreEqual("pat", PatientManager.GetPatientsByNameAndDateOfBirth(null, "patient", DateTime.Now)[0].LastName);
        }

        [TestMethod]
        public void TestValidFirstNameAndDateOfBirthEmptyLastName()
        {
            Assert.AreEqual(1, PatientManager.GetPatientsByNameAndDateOfBirth("pat", "", DateTime.Now).Count);
            Assert.AreEqual("pat", PatientManager.GetPatientsByNameAndDateOfBirth("pat", "", DateTime.Now)[0].FirstName);
        }

        [TestMethod]
        public void TestValidLastNameAndDateOfBirthEmptyFirstName()
        {
            Assert.AreEqual(1, PatientManager.GetPatientsByNameAndDateOfBirth("", "patient", DateTime.Now).Count);
            Assert.AreEqual("pat", PatientManager.GetPatientsByNameAndDateOfBirth("", "patient", DateTime.Now)[0].LastName);
        }

        [TestMethod]
        public void TestValidFirstAndLastNamesAndDateOfBirth()
        {
            Assert.AreEqual(1, PatientManager.GetPatientsByNameAndDateOfBirth("pat", "patient", DateTime.Now).Count);
            Assert.AreEqual("pat", PatientManager.GetPatientsByNameAndDateOfBirth("pat", "patient", DateTime.Now)[0].FirstName);
            Assert.AreEqual("patient", PatientManager.GetPatientsByNameAndDateOfBirth("pat", "patient", DateTime.Now)[0].LastName);
            Assert.AreEqual(DateTime.Now, PatientManager.GetPatientsByNameAndDateOfBirth("pat", "patient", DateTime.Now)[0].DateOfBirth);
        }
        */
    }
}
