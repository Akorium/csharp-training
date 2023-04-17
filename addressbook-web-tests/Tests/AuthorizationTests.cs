using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class AuthorizationTests : TestBase
    {
        [Test]
        public void AuthorizationWithValidCredentials()
        {
            AccountData accountData = new AccountData("admin", "secret");
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();
            applicationManager.AuthorizationHelper.AddressBookAuthorization(accountData);
            Assert.IsTrue(applicationManager.AuthorizationHelper.IsAuthorized(accountData));
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();
        }

        [Test]
        public void AuthorizationWithInvalidCredentials()
        {
            AccountData accountData = new AccountData("admin", "invalidpassword");
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();
            applicationManager.AuthorizationHelper.AddressBookAuthorization(accountData);
            Assert.IsFalse(applicationManager.AuthorizationHelper.IsAuthorized(accountData));
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();
        }
    }
}
