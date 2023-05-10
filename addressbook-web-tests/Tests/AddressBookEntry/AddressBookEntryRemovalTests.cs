using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class AddressBookEntryRemovalTests : EntryTestBase
    {
        private readonly int _entryNumber = 0;
        [Test]
        public void AddressBookEntryRemovalTest()
        {
            List<AddressBookEntryData> oldEntries = applicationManager.AddressBookEntryHelper.CheckEntryInDB(_entryNumber);
            AddressBookEntryData toBeRemoved = oldEntries[_entryNumber];
            applicationManager.AddressBookEntryHelper.Remove(toBeRemoved);

            List<AddressBookEntryData> newEntries = AddressBookEntryData.GetAllData();
            oldEntries.RemoveAt(_entryNumber);

            Assert.AreEqual(oldEntries, newEntries);
        }
    }
}
