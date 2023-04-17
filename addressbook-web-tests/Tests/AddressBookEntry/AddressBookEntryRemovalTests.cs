using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class AddressBookEntryRemovalTests : AuthorizationTestBase
    {
        private readonly int _entryNumber = 0;
        [Test]
        public void AddressBookEntryRemovalTest()
        {
            applicationManager.AddressBookEntryHelper.CheckEntry(_entryNumber);
            List<AddressBookEntryData> oldentries = applicationManager.AddressBookEntryHelper.GetEntryList();
            applicationManager.AddressBookEntryHelper.Remove(_entryNumber);
            List<AddressBookEntryData> newentries = applicationManager.AddressBookEntryHelper.GetEntryList();
            oldentries.RemoveAt(_entryNumber);
            Assert.AreEqual(oldentries, newentries);
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();
        }
    }
}
