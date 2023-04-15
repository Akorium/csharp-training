using addressbook_web_tests;
using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class AddressBookEntryRemovalTests : AuthorizationTestBase
    {
        private int entry_number = 0;
        [Test]
        public void AddressBookEntryRemovalTest()
        {
            applicationManager.AddressBookEntryHelper.CheckEntry(entry_number);
            List<AddressBookEntryData> oldentries = applicationManager.AddressBookEntryHelper.GetEntryList();
            applicationManager.AddressBookEntryHelper.Remove(entry_number);
            List<AddressBookEntryData> newentries = applicationManager.AddressBookEntryHelper.GetEntryList();
            oldentries.RemoveAt(entry_number);
            Assert.AreEqual(oldentries, newentries);
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();
        }
    }
}
