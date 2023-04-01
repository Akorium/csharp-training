using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class AddressBookEntryCreationTests : TestBase
    {
 
        [Test]
        public void AddressBookEntryCreationTest()
        {
            OpenAddressBookPage();
            AddressBookAuthorization(new AccountData("admin", "secret"));
            GoToAddressBookEntryCreationPage();
            FillAddressBookEntryForm(new AddressBookEntryData("Test", "Test"));
            SubmitAddressBookEntryCreation();
            ReturnToHomePage();
            LogoutFromAddressBook();
        }
    }
}
