using System;

namespace addressbook_web_tests
{
    public class AddressBookEntryData : IEquatable<AddressBookEntryData>, IComparable<AddressBookEntryData>
    {
        public AddressBookEntryData(string firstname, string lastname)
        { 
            Firstname = firstname;
            Lastname = lastname;
        }
        public bool Equals(AddressBookEntryData anotherEntry)
        {
            if (anotherEntry is null)
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
            if (anotherEntry is null)
            {
                return 1;
            }
            if (Lastname ==  anotherEntry.Lastname)
            {
                return Firstname.CompareTo(anotherEntry.Firstname);
            }
            return Lastname.CompareTo(anotherEntry.Lastname);
        }
        public string Firstname { get; set; }

        public string Lastname { get; set; }
    }
}
