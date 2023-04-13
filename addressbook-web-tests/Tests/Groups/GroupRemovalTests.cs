using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthorizationTestBase
    {
        private int group_number = 1;
        [Test]
        public void GroupRemovalTest()
        {
            applicationManager.GroupHelper.CheckGroup(group_number);
            applicationManager.GroupHelper.Remove(group_number);
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();
        }
    }
}
