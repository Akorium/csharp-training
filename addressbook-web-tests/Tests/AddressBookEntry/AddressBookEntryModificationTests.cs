using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class AddressBookEntryModificationTests : AuthorizationTestBase
    {
        private readonly int _entryNumber = 0;
        [Test]
        public void AddressBookEntryModificationTest() 
        {
            AddressBookEntryData addressBookEntryData = new AddressBookEntryData("newFirstname", "newLastname");
            applicationManager.AddressBookEntryHelper.CheckEntry(_entryNumber);
            List<AddressBookEntryData> oldEntries = applicationManager.AddressBookEntryHelper.GetEntryList();
            applicationManager.AddressBookEntryHelper.Modify(addressBookEntryData, _entryNumber);
            List<AddressBookEntryData> newEntries = applicationManager.AddressBookEntryHelper.GetEntryList();
            oldEntries[_entryNumber].Firstname = addressBookEntryData.Firstname;
            oldEntries[_entryNumber].Lastname = addressBookEntryData.Lastname;
            oldEntries.Sort();
            newEntries.Sort();
            Assert.AreEqual(oldEntries, newEntries);
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();
        }
    }
}