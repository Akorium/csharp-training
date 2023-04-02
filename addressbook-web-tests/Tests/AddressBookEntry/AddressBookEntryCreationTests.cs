using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class AddressBookEntryCreationTests : TestBase
    {
 
        [Test]
        public void AddressBookEntryCreationTest()
        {
            AddressBookEntryData addressBookEntryData = new AddressBookEntryData("Test", "Test");
            applicationManager.AddressBookEntryHelper.Create(addressBookEntryData);
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();
        }
    }
}
