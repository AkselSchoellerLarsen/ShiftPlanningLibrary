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

            List<int> idList = new List<int> { 1, 10, 100, 1000, 5, 50, 500, -1, 0 };

            IShift a = new Shift(idList[0], start, end);
            IShift b = new Shift(idList[1], start, end);
            IShift c = new Shift(idList[2], start, end);
            IShift d = new Shift(idList[3], start, end);
            IShift e = new Shift(idList[4], start, end);
            IShift f = new Shift(idList[5], start, end);
            IShift g = new Shift(idList[6], start, end);
            IShift h = new Shift(idList[7], start, end);
            IShift i = new Shift(idList[8], start, end);
            IShift j = new Shift(start, end);

            Assert.IsFalse(idList.Contains(j.Id));
        }
    }
}