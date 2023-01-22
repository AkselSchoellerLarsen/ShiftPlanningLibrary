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

            IShift a = new Shift(1, start, end);
            IShift b = new Shift(10, start, end);
            IShift c = new Shift(100, start, end);
            IShift d = new Shift(1000, start, end);
            IShift e = new Shift(5, start, end);
            IShift f = new Shift(50, start, end);
            IShift g = new Shift(500, start, end);
            IShift h = new Shift(-1, start, end);
            IShift i = new Shift(0, start, end);
            IShift j = new Shift(start, end);

            Assert.IsTrue(j.Id == 1001);
        }
    }
}