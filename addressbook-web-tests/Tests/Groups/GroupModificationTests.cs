using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupModifivationTests : AuthorizationTestBase
    {
        private int group_number = 0;
        [Test]
        public void GroupModificationTest()
        {
            GroupData group = new GroupData("New_name")
            {
                Header = null,
                Footer = null
            };
            applicationManager.GroupHelper.CheckGroup(group_number);
            List<GroupData> oldgroups = applicationManager.GroupHelper.GetGroupList();
            applicationManager.GroupHelper.Modify(group, group_number);
            List<GroupData> newgroups = applicationManager.GroupHelper.GetGroupList();
            oldgroups[group_number].Name = group.Name;
            oldgroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldgroups, newgroups);
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();
        }
    }
}