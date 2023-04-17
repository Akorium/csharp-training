using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupModifivationTests : AuthorizationTestBase
    {
        private readonly int _groupNumber = 0;
        [Test]
        public void GroupModificationTest()
        {
            GroupData group = new GroupData("New_name")
            {
                Header = null,
                Footer = null
            };
            applicationManager.GroupHelper.CheckGroup(_groupNumber);
            List<GroupData> oldgroups = applicationManager.GroupHelper.GetGroupList();
            GroupData oldGroup = oldgroups[_groupNumber];
            applicationManager.GroupHelper.Modify(group, _groupNumber);
            Assert.AreEqual(oldgroups.Count, applicationManager.GroupHelper.GetGroupsCount());
            List<GroupData> newgroups = applicationManager.GroupHelper.GetGroupList();
            oldgroups[_groupNumber].Name = group.Name;
            oldgroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldgroups, newgroups);
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();
            foreach (GroupData newGroup in newgroups)
            {
                if (newGroup.Id == oldGroup.Id)
                {
                    Assert.AreEqual(group.Name, newGroup.Name);
                }
            }
        }
    }
}