using NUnit.Framework;
using System;

namespace addressbook_web_tests
{
    [TestFixture]
    public class AddressBookEntryCreationTests : AuthorizationTestBase
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
