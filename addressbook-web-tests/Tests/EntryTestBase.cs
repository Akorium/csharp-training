using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    public class EntryTestBase : AuthorizationTestBase
    {
        [TearDown]
        public void CompareEntriesUI_DB()
        {
            if (PERFORM_LONG_UI_CHEKS)
            {
                List<AddressBookEntryData> fromUI = applicationManager.AddressBookEntryHelper.GetEntryList();
                List<AddressBookEntryData> fromDB = AddressBookEntryData.GetAllData();
                fromDB.Sort();
                fromUI.Sort();
                Assert.AreEqual(fromUI, fromDB);
                applicationManager.AuthorizationHelper.LogoutFromAddressBook();
            }
        }
    }
}
