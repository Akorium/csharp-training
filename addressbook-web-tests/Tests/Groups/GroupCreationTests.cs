using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : AuthorizationTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30).Replace("'", "").Replace(@"\", "").Replace("<", "").Replace(" ", ""))
                {
                    Header = GenerateRandomString(100).Replace("'", "").Replace(@"\", "").Replace("<", ""),
                    Footer = GenerateRandomString(100).Replace("'", "").Replace(@"\", "").Replace("<", "")
                });
            }
            return groups;
        }
        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreationTest(GroupData group)
        {
            List<GroupData> oldgroups = applicationManager.GroupHelper.GetGroupList();
            applicationManager.GroupHelper.Create(group);
            Assert.AreEqual(oldgroups.Count + 1, applicationManager.GroupHelper.GetGroupsCount());
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
            Assert.AreEqual(oldgroups.Count, applicationManager.GroupHelper.GetGroupsCount());
            List<GroupData> newgroups = applicationManager.GroupHelper.GetGroupList();
            oldgroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldgroups, newgroups);

        }
    }
}
