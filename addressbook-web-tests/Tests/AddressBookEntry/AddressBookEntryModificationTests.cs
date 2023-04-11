using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class AddressBookEntryModificationTests : AuthorizationTestBase
    {
        [Test]
        public void AddressBookEntryModificationTest() 
        {
            AddressBookEntryData addressBookEntryData = new AddressBookEntryData("Updated", "Updated");
            applicationManager.AddressBookEntryHelper.Modify(addressBookEntryData, 1);
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();
        }
    }
}
