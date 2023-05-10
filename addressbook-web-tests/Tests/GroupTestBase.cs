using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    public class GroupTestBase : AuthorizationTestBase
    {
        [TearDown]
        public void CompareGroupsUI_DB()
        {
            if (PERFORM_LONG_UI_CHEKS)
            {
                List<GroupData> fromUI = applicationManager.GroupHelper.GetGroupList();
                List<GroupData> fromDB = GroupData.GetAllData();
                fromDB.Sort();
                fromUI.Sort();
                Assert.AreEqual(fromUI, fromDB);
                applicationManager.AuthorizationHelper.LogoutFromAddressBook();
            }
        }
    }
}
