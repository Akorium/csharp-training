using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    public class AddEntryToGroupTests : AuthorizationTestBase
    {
        private readonly int _groupNumberInDB = 0;

        [Test]
        public void AddEntryToGroupTest()
        {
            GroupData group = applicationManager.GroupHelper.CheckGroupInDB(_groupNumberInDB)[_groupNumberInDB];
            List<AddressBookEntryData> oldEntries = group.GetEntries();
            AddressBookEntryData entry = applicationManager.AddressBookEntryHelper.CheckEntriesForGroup(oldEntries);

            applicationManager.AddressBookEntryHelper.AddEntryToGroup(entry, group);

            List<AddressBookEntryData> newEntries = group.GetEntries();
            oldEntries.Add(entry);
            newEntries.Sort();
            oldEntries.Sort();

            Assert.AreEqual(oldEntries, newEntries);
        }
    }
}
