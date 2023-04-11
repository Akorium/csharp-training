using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    [TestFixture]
    public class AuthorizationTests : TestBase
    {
        [Test]
        public void AuthorizationWithValidCredentials()
        {
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();
            AccountData accountData = new AccountData("admin", "secret");
            applicationManager.AuthorizationHelper.AddressBookAuthorization(accountData);
            Assert.IsTrue(applicationManager.AuthorizationHelper.IsAuthorized(accountData));
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();
        }

        [Test]
        public void AuthorizationWithInvalidCredentials()
        {
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();
            AccountData accountData = new AccountData("admin", "invalidpassword");
            applicationManager.AuthorizationHelper.AddressBookAuthorization(accountData);
            Assert.IsFalse(applicationManager.AuthorizationHelper.IsAuthorized(accountData));
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();
        }
    }
}
