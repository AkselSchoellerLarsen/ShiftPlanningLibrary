namespace ShiftPlanningLibrary {
    public class Shift : IShift {
		private static uint _nextId;

        private uint _id;
		private DateTime _start;
		private DateTime _end;

		public DateTime Start {
			get { return _start; }
			set {
                _start = value;
                if(value >= End) {
                    throw new ArgumentException("Shift: End must be after Start");
                }
            }
		}
        public DateTime End {
            get { return _end; }
            set {
                _end = value;
                if (value <= Start) {
                    throw new ArgumentException("Shift: End must be after Start");
                }
            }
        }

        public Shift(DateTime start, DateTime end, uint id) {
            _start = start;
            End = end;
            UpdateGlobalId(id);
            _id = id;
        }
        public Shift(DateTime start, DateTime end) : this(start, end, _nextId++) { }

        private void UpdateGlobalId(uint id) {
            _nextId = id+1;
        }

        public override bool Equals(object? obj) {
            if(obj is Shift) {
                Shift other = (Shift)obj;
                return _id == other._id;
            }
            return false;
        }

        public override int GetHashCode() {
            return (_nextId.GetHashCode() * Start.GetHashCode() * End.GetHashCode()) % int.MaxValue;
        }
    }
}