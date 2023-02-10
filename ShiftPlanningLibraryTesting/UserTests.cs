using ShiftPlanningLibrary;

namespace ShiftPlanningLibraryTesting {
    [TestClass]
    public class UserTests {
        [TestMethod]
        public void UserTestFullConstructorPositive() {
            IUser user = new User("Example@email.com", "not1234", true);
            Assert.IsTrue(user.IsAdmin);
        }
        [TestMethod]
        public void UserTestHalfConstructorPositive() {
            IUser user = new User("Example@email.com", "not1234");
            Assert.IsFalse(user.IsAdmin);
        }
        [TestMethod]
        public void UserTestEmptyConstructorPositive() {
            IUser user = new User();
            
            string email = "Example@email.com";
            string password = "not1234";

            user.Email = email;
            user.Password = password;

            Assert.AreEqual(email.ToLowerInvariant(), user.Email);
            Assert.AreEqual(password, user.Password);
            Assert.AreEqual(false, user.IsAdmin);
        }

        [TestMethod]
        public void UserTestNegativeCase() {
            IUser user = new User();

            string email = "Example@email.com";
            string password = "not1234";

            user.Email = email;
            user.Password = password;

            Assert.AreNotEqual(email, user.Email);
            Assert.AreEqual(password, user.Password);
            Assert.AreEqual(false, user.IsAdmin);
        }

        [TestMethod]
        public void UserTestEquivalence() {
            string email = "Example@Email.com";
            string password = "not1234";

            IUser user1 = new User(email, password, false);
            IUser user2 = new User();
            user2.Email = email;
            user2.Password = password;
            IUser user3 = new User(email.ToLowerInvariant(), password);

            Assert.AreEqual(user1, user2);
            Assert.AreEqual(user1, user3);
            Assert.AreEqual(user2, user3);

            user1.Email = "éxámple@émáil.com";
            user2.Password = "1234";
            user3.IsAdmin = true;

            Assert.AreNotEqual(user1, user2);
            Assert.AreNotEqual(user1, user3);
            Assert.AreNotEqual(user2, user3);
        }
    }
}