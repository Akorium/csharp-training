using System;

namespace addressbook_web_tests
{
    public class AddressBookEntryData : IEquatable<AddressBookEntryData>, IComparable<AddressBookEntryData>
    {
        private string firstname;
        private string lastname;

        public AddressBookEntryData(string firstname, string lastname)
        { 
            this.firstname = firstname;
            this.lastname = lastname;
        }
        public bool Equals(AddressBookEntryData anotherEntry)
        {
            if (Object.ReferenceEquals(anotherEntry, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, anotherEntry))
            {
                return true;
            }
            return (Firstname == anotherEntry.Firstname)&&(Lastname == anotherEntry.Lastname);
        }
        public override int GetHashCode()
        {
            return (Firstname.GetHashCode())&(Lastname.GetHashCode());
        }
        public override string ToString()
        {
            return "Firstname & Lastname=" + Firstname + " " + Lastname;
        }

        public int CompareTo(AddressBookEntryData anotherEntry)
        {
            if (Object.ReferenceEquals(anotherEntry, null))
            {
                return 1;
            }
            return Lastname.CompareTo(anotherEntry.Lastname);
        }
        public string Firstname
        { 
            get 
            { 
                return firstname; 
            }
            set 
            {
                firstname = value;
            }
        }

        public string Lastname 
        {
            get
            {
                return lastname;
            }
            set
            { 
                lastname = value; 
            }
        }
    }
}
