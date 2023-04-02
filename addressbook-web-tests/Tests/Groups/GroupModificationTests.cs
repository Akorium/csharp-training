using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupModifivationTests : TestBase
    {

        [Test]
        public void GroupModificationTest()
        {
            GroupData group = new GroupData("New_name")
            {
                Header = "New_header",
                Footer = "New_footer"
            };

            applicationManager.GroupHelper.Modify(group, 1);
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();
        }
    }
}