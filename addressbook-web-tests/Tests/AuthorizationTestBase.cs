using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
