using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthorizationTestBase
    {
        private int group_number = 0;
        [Test]
        public void GroupRemovalTest()
        {
            applicationManager.GroupHelper.CheckGroup(group_number);
            List<GroupData> oldgroups = applicationManager.GroupHelper.GetGroupList();
            applicationManager.GroupHelper.Remove(group_number);
            List<GroupData> newgroups = applicationManager.GroupHelper.GetGroupList();
            oldgroups.RemoveAt(group_number);
            Assert.AreEqual(oldgroups, newgroups);
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();
        }
    }
}
