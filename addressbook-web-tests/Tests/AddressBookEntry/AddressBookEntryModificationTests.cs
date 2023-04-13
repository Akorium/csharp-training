using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class AddressBookEntryModificationTests : AuthorizationTestBase
    {
        private int entry_number = 1;
        [Test]
        public void AddressBookEntryModificationTest() 
        {
            AddressBookEntryData addressBookEntryData = new AddressBookEntryData("Updated", "Updated");
            applicationManager.AddressBookEntryHelper.CheckEntry(entry_number);
            applicationManager.AddressBookEntryHelper.Modify(addressBookEntryData, entry_number);
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();
        }
    }
}
