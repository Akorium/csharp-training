using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupModifivationTests : AuthorizationTestBase
    {
        private int group_number = 1;
        [Test]
        public void GroupModificationTest()
        {
            GroupData group = new GroupData("New_name")
            {
                Header = null,
                Footer = null
            };
            applicationManager.GroupHelper.CheckGroup(group_number);
            applicationManager.GroupHelper.Modify(group, group_number);
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();
        }
    }
}