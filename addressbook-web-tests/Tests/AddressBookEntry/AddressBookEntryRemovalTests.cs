using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class AddressBookEntryRemovalTests : AuthorizationTestBase
    {
        private int entry_number = 1;
        [Test]
        public void AddressBookEntryRemovalTest()
        {
            applicationManager.AddressBookEntryHelper.CheckEntry(entry_number);
            applicationManager.AddressBookEntryHelper.Remove(entry_number);
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();
        }
    }
}
