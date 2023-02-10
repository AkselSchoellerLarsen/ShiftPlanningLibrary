using System.Collections.Generic;

namespace ShiftPlanningLibrary {
    public class Shift : IShift {
		private static int _nextId;

        private int _id;
		private DateTime _start;
		private DateTime _end;
        private string? _userEmail;

        public int Id {
            get {
                return _id;
            } 
            set {
                _id = value;
                UpdateGlobalId(value);
            }
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

        public string? UserEmail {
            get {
                if(_userEmail == "") {
                    return null;
                }
                return _userEmail;
            }
            set {
                _userEmail = (value ?? "").ToLowerInvariant();
            }
        }

        public Shift(int id, string userEmail, DateTime start, DateTime end) {
            Start = start;
            End = end;
            UserEmail = userEmail;
            Id = id;
        }
        public Shift(int id, DateTime start, DateTime end) {
            Start = start;
            End = end;
            Id = id;
        }
        public Shift(string userEmail, DateTime start, DateTime end) : this(_nextId, userEmail, start, end) { }
        public Shift(DateTime start, DateTime end) : this(_nextId, start, end) { }
        public Shift() { }

        private void UpdateGlobalId(int id) {
            if(id >= _nextId) {
                _nextId = id + 1;
            }
        }

        public override bool Equals(object? obj) {
            if(obj is Shift) {
                Shift other = (Shift)obj;
                return this.Id == other.Id && this.GetHashCode() == other.GetHashCode();
            }
            return false;
        }

        public override int GetHashCode() {
            int i = 0;
            if(UserEmail is not null) { i = UserEmail.GetHashCode(); }
            return (i + Id.GetHashCode() * Start.GetHashCode() * End.GetHashCode()) % int.MaxValue;
        }
    }
}