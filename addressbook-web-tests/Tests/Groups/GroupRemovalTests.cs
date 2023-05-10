using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {
        private readonly int _groupNumberInDB = 0;
        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldgroups = applicationManager.GroupHelper.CheckGroupInDB(_groupNumberInDB);
            GroupData toBeRemoved = oldgroups[_groupNumberInDB];

            applicationManager.GroupHelper.Remove(toBeRemoved);
            Assert.AreEqual(oldgroups.Count - 1, applicationManager.GroupHelper.GetGroupsCount());
            List<GroupData> newgroups = GroupData.GetAllData();
            oldgroups.RemoveAt(_groupNumberInDB);

            Assert.AreEqual(oldgroups, newgroups);
            foreach (GroupData group in newgroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
