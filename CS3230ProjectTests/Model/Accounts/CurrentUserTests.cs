using Microsoft.VisualStudio.TestTools.UnitTesting;
using CS3230Project.Model.Accounts;
using CS3230Project.Model.Users;

namespace CS3230ProjectTests.Model.Accounts
{
    [TestClass]
    public class CurrentUserTests
    {
        [TestMethod]
        public void ShouldAssignCurrentUser()
        {
            var nurse = new Nurse(1, "First", "Last", "FirstLast");
            CurrentUser.User = nurse;
            Assert.AreEqual(CurrentUser.User, nurse);
        }
    }
}
