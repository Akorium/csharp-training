﻿using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace addressbook_web_tests
{
    [Table(Name = "addressbook")]
    public class AddressBookEntryData : IEquatable<AddressBookEntryData>, IComparable<AddressBookEntryData>
    {
        private string allNumbers;
        private string details;
        public AddressBookEntryData()
        {
        }
        public AddressBookEntryData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
        public bool Equals(AddressBookEntryData anotherEntry)
        {
            return !(anotherEntry is null)
&& (ReferenceEquals(this, anotherEntry) || ((Firstname == anotherEntry.Firstname) && (Lastname == anotherEntry.Lastname) && (Id == anotherEntry.Id)));
        }
        public override int GetHashCode()
        {
            return (Firstname.GetHashCode()) & (Lastname.GetHashCode()) & (Id.GetHashCode());
        }
        public override string ToString()
        {
            return "Firstname = " + Firstname + ";\n" + "Lastname = " + Lastname;
        }

        public int CompareTo(AddressBookEntryData anotherEntry)
        {
            return anotherEntry is null
                ? 1
                : Lastname == anotherEntry.Lastname ? Firstname.CompareTo(anotherEntry.Firstname) : Lastname.CompareTo(anotherEntry.Lastname);
        }
        [Column(Name = "firstname")]
        public string Firstname { get; set; }
        [Column(Name = "lastname")]
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string HomeNumber { get; set; }
        public string MobileNumber { get; set; }
        public string WorkNumber { get; set; }
        public string EMail { get; set; }
        public string EMail2 { get; set; }
        public string Email3 { get; set; }
        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }
        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public string AllNumbers
        {
            get => allNumbers ?? (CleanUp(HomeNumber) + CleanUp(MobileNumber) + CleanUp(WorkNumber)).Trim();
            set => allNumbers = value;
        }

        private string CleanUp(string number)
        {
            return number == null || number == "" ? "" : Regex.Replace(number, "[ -()]", "") + "\r\n";
        }
        public string Details
        {
            get => details ?? (DataInDetails(Firstname, "") + DataInDetails(Lastname, " ") + DataInDetails(Address, "\r\n")
                        + "\r\n" + DataInDetails(HomeNumber, "\r\n" + "H: ") + DataInDetails(MobileNumber, "\r\n" + "M: ")
                        + DataInDetails(WorkNumber, "\r\n" + "W: ") + LineBreak(HomeNumber, MobileNumber, WorkNumber) + DataInDetails(EMail, "\r\n")
                        + DataInDetails(EMail2, "\r\n") + DataInDetails(Email3, "\r\n")).Trim();
            set => details = value;
        }
        private string DataInDetails(string data, string label)
        {
            return string.IsNullOrEmpty(data) ? "" : label + data;
        }
        private string LineBreak(string data1, string data2, string data3)
        {
            return string.IsNullOrEmpty(data1) && string.IsNullOrEmpty(data2) && string.IsNullOrEmpty(data3) ? "" : "\r\n";
        }
        public static List<AddressBookEntryData> GetAllData()
        {
            using (AddressBookDB dB = new AddressBookDB())
            {
                return (from e in dB.Entries.Where(x => x.Deprecated == "0000-00-00 00:00:00") select e).ToList();

            }
        }
    }
}
