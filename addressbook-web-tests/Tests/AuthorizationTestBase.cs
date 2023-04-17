using NUnit.Framework;

namespace addressbook_web_tests
{
    public class AuthorizationTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            applicationManager.AuthorizationHelper.AddressBookAuthorization(new AccountData("admin", "secret"));
        }
    }
}
