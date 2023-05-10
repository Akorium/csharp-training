using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace addressbook_web_tests
{
    public class RemoveEntryFromGroupTests : AuthorizationTestBase
    {
        private readonly int _groupNumberInDB = 0;

        [Test]
        public void RemoveEntryFromGroupTest()
        {
            GroupData group = applicationManager.GroupHelper.CheckGroupInDB(_groupNumberInDB)[_groupNumberInDB];
            List<AddressBookEntryData> oldEntries = applicationManager.AddressBookEntryHelper.CheckEntryToRemove(group); ;
            AddressBookEntryData entryToRemove = oldEntries.First();

            applicationManager.AddressBookEntryHelper.RemoveEntryFromGroup(entryToRemove, group);

            List<AddressBookEntryData> newEntries = group.GetEntries();
            oldEntries.RemoveAt(0);
            newEntries.Sort();
            oldEntries.Sort();

            Assert.AreEqual(oldEntries, newEntries);
        }
    }
}
