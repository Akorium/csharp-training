using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class AddressBookEntryRemovalTests : AuthorizationTestBase
    {
        [Test]
        public void AddressBookEntryRemovalTest()
        {
            applicationManager.AddressBookEntryHelper.Remove(1);
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();
        }
    }
}
