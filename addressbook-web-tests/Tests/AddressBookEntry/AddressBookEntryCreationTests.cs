using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class AddressBookEntryCreationTests : AuthorizationTestBase
    {
 
        [Test]
        public void AddressBookEntryCreationTest()
        {
            AddressBookEntryData addressBookEntryData = new AddressBookEntryData("Firstname", "Lastname");
            List<AddressBookEntryData> oldEntries = applicationManager.AddressBookEntryHelper.GetEntryList();
            applicationManager.AddressBookEntryHelper.Create(addressBookEntryData);
            List<AddressBookEntryData> newEntries = applicationManager.AddressBookEntryHelper.GetEntryList();
            oldEntries.Add(addressBookEntryData);
            oldEntries.Sort();
            newEntries.Sort();
            Assert.AreEqual(oldEntries, newEntries);
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();

        }
    }
}
