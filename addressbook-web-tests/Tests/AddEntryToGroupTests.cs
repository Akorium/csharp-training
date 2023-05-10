using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace addressbook_web_tests
{
    public class AddEntryToGroupTests : AuthorizationTestBase
    {
        private readonly int _groupNumberInDB = 0;
        [Test]
        public void AddEntryToGroupTest()
        {
            GroupData group = GroupData.GetAllData()[_groupNumberInDB];
            List<AddressBookEntryData> oldEntries = group.GetEntries();
            AddressBookEntryData entry = AddressBookEntryData.GetAllData().Except(oldEntries).First();

            applicationManager.AddressBookEntryHelper.AddEntryToGroup(entry, group);

            List<AddressBookEntryData> newEntries = group.GetEntries();
            oldEntries.Add(entry);
            newEntries.Sort();
            oldEntries.Sort();

            Assert.AreEqual(oldEntries, newEntries);
        }
    }
}
