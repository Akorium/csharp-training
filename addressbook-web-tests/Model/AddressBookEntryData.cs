using System;
using System.Text.RegularExpressions;

namespace addressbook_web_tests
{
    public class AddressBookEntryData : IEquatable<AddressBookEntryData>, IComparable<AddressBookEntryData>
    {
        private string allNumbers;
        private string details;

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
        public string Address { get; set; }
        public string HomeNumber { get; set; }
        public string MobileNumber { get; set; }
        public string WorkNumber { get; set; }
        public string AllNumbers
        {
            get
            {
                if (allNumbers != null)
                {
                    return allNumbers;
                }
                else
                {
                    return (CleanUp(HomeNumber) + CleanUp(MobileNumber) + CleanUp(WorkNumber)).Trim();
                }
            }
            set { allNumbers = value; }
        }

        private string CleanUp(string number)
        {
            if (number == null || number == "")
            {
                return "";
            }
            return Regex.Replace(number, "[ -()]", "") + "\r\n";
        }
        public string Details
        {
            get
            {
                if (details != null)
                {
                    return details;
                }
                else
                {
                    return Firstname + " " + Lastname + AddressInDetails(Address) + NumberInDetails(HomeNumber, "H: ") + NumberInDetails(MobileNumber, "M: ") + NumberInDetails(WorkNumber, "W: ");
                }
            }
            set { details = value; }
        }
        private string AddressInDetails(string address)
        {
            if ((!string.IsNullOrEmpty(HomeNumber)|| !string.IsNullOrEmpty(MobileNumber) || !string.IsNullOrEmpty(WorkNumber)) && (address == null || address == ""))
            {
                return "\r\n";
            }
            else if (string.IsNullOrEmpty(address))
            {
                return "";
            }
            else if (!string.IsNullOrEmpty(HomeNumber) || !string.IsNullOrEmpty(MobileNumber) || !string.IsNullOrEmpty(WorkNumber))
            {
                return "\r\n" + address + "\r\n";
            }
            return "\r\n" + address;
        }
        private string NumberInDetails(string number, string lable)
        {
            return (string.IsNullOrEmpty(number)) ?  "" : "\r\n" + lable + number;
        }
    }
}
