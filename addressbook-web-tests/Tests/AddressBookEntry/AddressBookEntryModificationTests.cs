using addressbook_web_tests;
using NUnit.Framework;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace addressbook_web_tests
{
    [TestFixture]
    public class AddressBookEntryModificationTests : AuthorizationTestBase
    {
        private int entry_number = 0;
        [Test]
        public void AddressBookEntryModificationTest() 
        {
            AddressBookEntryData addressBookEntryData = new AddressBookEntryData("Updated", "Updated");
            applicationManager.AddressBookEntryHelper.CheckEntry(entry_number);
            List<AddressBookEntryData> oldentries = applicationManager.AddressBookEntryHelper.GetEntryList();
            applicationManager.AddressBookEntryHelper.Modify(addressBookEntryData, entry_number);
            List<AddressBookEntryData> newentries = applicationManager.AddressBookEntryHelper.GetEntryList();
            oldentries[entry_number].Firstname = addressBookEntryData.Firstname;
            oldentries[entry_number].Lastname = addressBookEntryData.Lastname;
            oldentries.Sort();
            newentries.Sort();
            Assert.AreEqual(oldentries, newentries);
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();
        }
    }
}