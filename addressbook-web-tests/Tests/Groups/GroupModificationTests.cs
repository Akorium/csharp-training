using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupModifivationTests : GroupTestBase
    {
        private readonly int _groupNumberInDB = 0;
        [Test]
        public void GroupModificationTest()
        {
            GroupData group = new GroupData("New_name")
            {
                Header = null,
                Footer = null
            };
            List<GroupData> oldgroups = applicationManager.GroupHelper.CheckGroupInDB(_groupNumberInDB);
            GroupData toBeModified = oldgroups[_groupNumberInDB];

            applicationManager.GroupHelper.Modify(group, toBeModified);
            Assert.AreEqual(oldgroups.Count, applicationManager.GroupHelper.GetGroupsCount());
            List<GroupData> newgroups = GroupData.GetAllData();
            oldgroups[_groupNumberInDB].Name = group.Name;
            oldgroups.Sort();
            newgroups.Sort();

            Assert.AreEqual(oldgroups, newgroups);
            foreach (GroupData newGroup in newgroups)
            {
                if (newGroup.Id == toBeModified.Id)
                {
                    Assert.AreEqual(group.Name, newGroup.Name);
                }
            }
        }
    }
}