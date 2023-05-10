using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class AddressBookEntryModificationTests : EntryTestBase
    {
        private readonly int _entryNumber = 0;
        [Test]
        public void AddressBookEntryModificationTest()
        {
            AddressBookEntryData addressBookEntryData = new AddressBookEntryData("newFirstname", "newLastname");
            List<AddressBookEntryData> oldEntries = applicationManager.AddressBookEntryHelper.CheckEntryInDB(_entryNumber);
            AddressBookEntryData toBeModified = oldEntries[_entryNumber];

            applicationManager.AddressBookEntryHelper.Modify(addressBookEntryData, toBeModified);
            List<AddressBookEntryData> newEntries = AddressBookEntryData.GetAllData();
            toBeModified.Firstname = addressBookEntryData.Firstname;
            toBeModified.Lastname = addressBookEntryData.Lastname;
            oldEntries.Sort();
            newEntries.Sort();
            Assert.AreEqual(oldEntries, newEntries);
        }
    }
}