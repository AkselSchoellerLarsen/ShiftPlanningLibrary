using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftPlanningLibrary {
    public class User : IUser {
        private string _email;

        public virtual string Email {
            get {
                return _email;
            }
            set {
                _email = value.ToLowerInvariant();
            }
        }
        public virtual string Password { get; set; }
        public virtual bool IsAdmin { get; set; }

        public User(string email, string password, bool isAdmin) {
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
        }
        public User(string email, string password) : this(email, password, false) { }
        public User() {
            Email = "";
            Password = "";
        }

        public override bool Equals(object? obj) {
            if(obj is not User) {
                return false;
            }
            User other = obj as User ?? new User();
            if(other.Email == "") {
                return false;
            }
            return this.Email == other.Email && this.Password == other.Password && this.IsAdmin == other.IsAdmin;
        }

        public override int GetHashCode() {
            return (Email.GetHashCode() * Password.GetHashCode()) % int.MaxValue;
        }
    }
}
