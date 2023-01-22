namespace ShiftPlanningLibrary {
    public class Shift : IShift {
		private static int _nextId;

        private int _id;
		private DateTime _start;
		private DateTime _end;

        public int Id {
            get { return _id; }
        }

		public DateTime Start {
			get { return _start; }
			set {
                _start = value;
                if(value >= End && End != default(DateTime)) {
                    throw new ArgumentException("Shift: End must be after Start");
                }
            }
		}
        public DateTime End {
            get { return _end; }
            set {
                _end = value;
                if (value <= Start && Start != default(DateTime)) {
                    throw new ArgumentException("Shift: End must be after Start");
                }
            }
        }

        public Shift(int id, DateTime start, DateTime end) {
            Start = start;
            End = end;
            UpdateGlobalId(id);
            _id = id;
        }
        public Shift(DateTime start, DateTime end) : this(_nextId, start, end) { }
        public Shift() {
            _id = _nextId;
            UpdateGlobalId(Id);
        }

        private void UpdateGlobalId(int id) {
            if(id >= _nextId) {
                _nextId = id + 1;
            }
        }

        public override bool Equals(object? obj) {
            if(obj is Shift) {
                Shift other = (Shift)obj;
                return _id == other._id && GetHashCode() == other.GetHashCode();
            }
            return false;
        }

        public override int GetHashCode() {
            return (_nextId.GetHashCode() * Start.GetHashCode() * End.GetHashCode()) % int.MaxValue;
        }
    }
}