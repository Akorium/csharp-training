using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthorizationTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            applicationManager.GroupHelper.Remove(1);
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();
        }
    }
}
