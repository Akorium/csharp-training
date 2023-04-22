using NUnit.Framework;
using System;


namespace addressbook_web_tests
{
    [TestFixture]
    public class SearchTests : AuthorizationTestBase
    {
        [Test]
        public void SearchTest()
        {
            
            Console.Out.Write(applicationManager.AddressBookEntryHelper.GetNumberOfEntries());
        }
    }
}
