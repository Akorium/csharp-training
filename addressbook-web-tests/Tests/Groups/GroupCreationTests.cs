using NUnit.Framework;
using System.Collections.Generic;

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
            List<GroupData> oldgroups = applicationManager.GroupHelper.GetGroupList();
            applicationManager.GroupHelper.Create(group);
            List<GroupData> newgroups = applicationManager.GroupHelper.GetGroupList();
            oldgroups.Add(group);
            oldgroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldgroups, newgroups);
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
            List<GroupData> oldgroups = applicationManager.GroupHelper.GetGroupList();
            applicationManager.GroupHelper.Create(group);
            List<GroupData> newgroups = applicationManager.GroupHelper.GetGroupList();
            oldgroups.Add(group);
            oldgroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldgroups, newgroups);
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();
        }
        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("'badname")
            {
                Header = "",
                Footer = ""
            };
            List<GroupData> oldgroups = applicationManager.GroupHelper.GetGroupList();
            applicationManager.GroupHelper.Create(group);
            List<GroupData> newgroups = applicationManager.GroupHelper.GetGroupList();
            oldgroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldgroups, newgroups);

        }
    }
}
