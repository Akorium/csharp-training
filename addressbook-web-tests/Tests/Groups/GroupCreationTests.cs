using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : AuthorizationTestBase
    {

        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("name")
            {
                Header = "header",
                Footer = "footer"
            };

            applicationManager.GroupHelper.Create(group);
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();
        }
        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("")
            {
                Header = "",
                Footer = ""
            };

            applicationManager.GroupHelper.Create(group);
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();
        }
    }
}
