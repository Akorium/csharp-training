using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class AddressBookEntryCreationTests : AuthorizationTestBase
    {
        public static IEnumerable<AddressBookEntryData> RandomEntryDataProvider()
        {
            List<AddressBookEntryData> entries = new List<AddressBookEntryData>();
            for (int i = 0; i < 5; i++)
            {
                string firstname = GenerateRandomString(30).Replace("'", "").Replace(@"\", "").Replace("<", "");
                string lastname = GenerateRandomString(30).Replace("'", "").Replace(@"\", "").Replace("<", "");
                entries.Add(new AddressBookEntryData(firstname, lastname));
            }
            return entries;
        }

        [Test, TestCaseSource("RandomEntryDataProvider")]
        public void AddressBookEntryCreationTest(AddressBookEntryData addressBookEntryData)
        {
            List<AddressBookEntryData> oldEntries = applicationManager.AddressBookEntryHelper.GetEntryList();
            applicationManager.AddressBookEntryHelper.Create(addressBookEntryData);
            List<AddressBookEntryData> newEntries = applicationManager.AddressBookEntryHelper.GetEntryList();
            oldEntries.Add(addressBookEntryData);
            oldEntries.Sort();
            newEntries.Sort();
            Assert.AreEqual(oldEntries, newEntries);
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();

        }
    }
}
