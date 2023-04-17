using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthorizationTestBase
    {
        private readonly int _groupNumber = 0;
        [Test]
        public void GroupRemovalTest()
        {
            applicationManager.GroupHelper.CheckGroup(_groupNumber);
            List<GroupData> oldgroups = applicationManager.GroupHelper.GetGroupList();
            applicationManager.GroupHelper.Remove(_groupNumber);
            Assert.AreEqual(oldgroups.Count - 1, applicationManager.GroupHelper.GetGroupsCount());
            List<GroupData> newgroups = applicationManager.GroupHelper.GetGroupList();
            GroupData toBeRemoved = oldgroups[_groupNumber];
            oldgroups.RemoveAt(_groupNumber);
            Assert.AreEqual(oldgroups, newgroups);
            foreach (GroupData group in newgroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();
        }
    }
}
