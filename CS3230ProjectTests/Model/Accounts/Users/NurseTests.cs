using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CS3230Project.ErrorMessages;
using CS3230Project.Model.Accounts.Users;

namespace CS3230ProjectTests.Model.Accounts.Users
{
    [TestClass]
    public class NurseTests
    {
        [TestMethod]
        public void ShouldNotAllowIdOneBelowZero()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Nurse(-1, "TestFirst", "TestSecond", "TestUserName");
            });
            Assert.AreEqual(message.Message, NurseErrorMessages.IdCannotBeLessThanZero);
        }

        [TestMethod]
        public void ShouldNotAllowIdWellBelowZero()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Nurse(-100, "TestFirst", "TestSecond", "TestUserName");
            });
            Assert.AreEqual(message.Message, NurseErrorMessages.IdCannotBeLessThanZero);
        }

        [TestMethod]
        public void ShouldNotAllowNullFirstName()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Nurse(1, null, "TestSecond", "TestUserName");
            });
            Assert.AreEqual(message.Message, NurseErrorMessages.FirstNameCannotBeNull);
        }

        [TestMethod]
        public void ShouldNotAllowEmptyFirstName()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Nurse(1, "", "TestSecond", "TestUserName");
            });
            Assert.AreEqual(message.Message, NurseErrorMessages.FirstNameCannotBeEmpty);
        }

        [TestMethod]
        public void ShouldNotAllowBlankFirstName()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Nurse(1, "       ", "TestSecond", "TestUserName");
            });
            Assert.AreEqual(message.Message, NurseErrorMessages.FirstNameCannotBeEmpty);
        }

        [TestMethod]
        public void ShouldNotAllowNullLastName()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Nurse(1, "TestFirst", null, "TestUserName");
            });
            Assert.AreEqual(message.Message, NurseErrorMessages.LastNameCannotBeNull);
        }

        [TestMethod]
        public void ShouldNotAllowEmptyLastName()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Nurse(1, "TestFirst", "", "TestUserName");
            });
            Assert.AreEqual(message.Message, NurseErrorMessages.LastNameCannotBeEmpty);
        }

        [TestMethod]
        public void ShouldNotAllowBlankLastName()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Nurse(1, "TestFirst", "          ", "TestUserName");
            });
            Assert.AreEqual(message.Message, NurseErrorMessages.LastNameCannotBeEmpty);
        }

        [TestMethod]
        public void ShouldNotAllowNullUserName()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Nurse(1, "TestFirst", "TestLast", null);
            });
            Assert.AreEqual(message.Message, NurseErrorMessages.UserNameCannotBeNull);
        }

        [TestMethod]
        public void ShouldNotAllowEmptyUserName()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Nurse(1, "TestFirst", "TestLast", "");
            });
            Assert.AreEqual(message.Message, NurseErrorMessages.UserNameCannotBeEmpty);
        }

        [TestMethod]
        public void ShouldNotAllowBlankUserName()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Nurse(1, "TestFirst", "TestLast", "           ");
            });
            Assert.AreEqual(message.Message, NurseErrorMessages.UserNameCannotBeEmpty);
        }

        [TestMethod]
        public void ShouldAllowValidValues()
        {
            var nurse = new Nurse(1, "TestFirst", "TestLast", "FirstLast");

            Assert.AreEqual(1, nurse.Id);
            Assert.AreEqual("TestFirst", nurse.FirstName);
            Assert.AreEqual("TestLast", nurse.LastName);
            Assert.AreEqual("FirstLast", nurse.UserName);
        }
    }
}
