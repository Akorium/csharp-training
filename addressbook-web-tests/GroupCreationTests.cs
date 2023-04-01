using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {

        [Test]
        public void GroupCreationTest()
        {
            OpenAddressBookPage();
            AddressBookAuthorization(new AccountData ("admin", "secret"));
            GoToGroupsPage();
            InitGroupCreation();
            GroupData group = new GroupData("name");
            group.Header = "header";
            group.Footer = "footer";
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            LogoutFromAddressBook();
        }
    }
}
