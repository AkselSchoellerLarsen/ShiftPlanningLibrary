using ShiftPlanningLibrary;

namespace ShiftPlanningLibraryTesting {
    [TestClass]
    public class ShiftTests {
        [TestMethod]
        public void ShiftTestPositive() {
            DateTime start = DateTime.Now;
            DateTime end = start.AddHours(1);

            IShift shift = new Shift(start, end);

            Assert.AreEqual(start, shift.Start);
            Assert.AreEqual(end, shift.End);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ShiftTestZeroDuration() {
            DateTime start = DateTime.Now;
            DateTime end = start;

            IShift shift = new Shift(start, end);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ShiftTestNegativeDuration() {
            DateTime start = DateTime.Now;
            DateTime end = start.AddHours(-1);

            IShift shift = new Shift(start, end);
        }

        [TestMethod]
        public void ShiftTestEquivalence() {
            DateTime start = DateTime.Now;
            DateTime end = start.AddHours(1);

            IShift a = new Shift(start, end);
            IShift b = new Shift(start, end);

            Assert.IsTrue(a.Equals(a));
            Assert.IsTrue(b.Equals(b));
            Assert.IsFalse(a.Equals(b));
        }

        [TestMethod]
        public void ShiftTestIdUniqueness() {
            DateTime start = DateTime.Now;
            DateTime end = start.AddHours(1);

            List<int> idList = new List<int> { -3, -2, -1, 0, 1, 2, 3 };
            foreach(int id in idList) {
                _ = new Shift(id, start, end);
            }

            IShift autoId = new Shift(start, end);

            for(int i=0; i<100; i++) {
                idList.Add(new Shift(start, end).Id);
            }

            Assert.IsFalse(idList.Contains(autoId.Id));
        }

        [TestMethod]
        public void ShiftTestUserNoIdPositive() {
            string userEmail = "Example@Email.com";
            DateTime start = DateTime.Now;
            DateTime end = start.AddHours(1);

            IShift shift = new Shift(userEmail, start, end);

            Assert.AreEqual(userEmail.ToLowerInvariant(), shift.UserEmail);
            Assert.AreEqual(start, shift.Start);
            Assert.AreEqual(end, shift.End);
        }

        [TestMethod]
        public void ShiftTestUserAndIdPositive() {
            int id = int.MinValue/2;
            string userEmail = "Example@Email.com";
            DateTime start = DateTime.Now;
            DateTime end = start.AddHours(1);

            IShift shift = new Shift(id, userEmail, start, end);

            Assert.AreEqual(id, shift.Id);
            Assert.AreEqual(userEmail.ToLowerInvariant(), shift.UserEmail);
            Assert.AreEqual(start, shift.Start);
            Assert.AreEqual(end, shift.End);
        }
    }
}