namespace ShiftPlanningLibrary {
    public interface IShift {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TimeSpan Duration {
            get {
                return End - Start;
            }
        }
    }
}
