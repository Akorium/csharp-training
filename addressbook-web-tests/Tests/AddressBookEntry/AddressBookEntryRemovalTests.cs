using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class AddressBookEntryRemovalTests : TestBase
    {
        [Test]
        public void AddressBookEntryModificationTest()
        {
            applicationManager.AddressBookEntryHelper.Remove(1);
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();
        }
    }
}
