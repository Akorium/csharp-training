using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupModifivationTests : AuthorizationTestBase
    {

        [Test]
        public void GroupModificationTest()
        {
            GroupData group = new GroupData("New_name")
            {
                Header = null,
                Footer = null
            };

            applicationManager.GroupHelper.Modify(group, 1);
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();
        }
    }
}