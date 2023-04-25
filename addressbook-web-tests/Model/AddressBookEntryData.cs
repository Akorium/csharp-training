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
            return "Firstname = " + Firstname + ";\n" + "Lastname = " + Lastname;
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
        public string EMail { get; set; }
        public string EMail2 { get; set; }
        public string Email3 { get; set; }

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
                    return (DataInDetails(Firstname, "") + DataInDetails(Lastname, " ") + DataInDetails(Address, "\r\n") 
                        + "\r\n" + DataInDetails(HomeNumber, "\r\n" + "H: ") + DataInDetails(MobileNumber, "\r\n" + "M: ") 
                        + DataInDetails(WorkNumber, "\r\n" + "W: ") + DataInDetails(EMail, "\r\n")
                        + DataInDetails(EMail2, "\r\n") + DataInDetails(Email3, "\r\n")).Trim();
                }
            }
            set { details = value; }
        }
        private string DataInDetails(string data, string label)
        {
            return (string.IsNullOrEmpty(data)) ? "" : label + data;
        }
    }
}
