using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class AddressBookEntryInformationTests : AuthorizationTestBase
    {
        private readonly int _entryNumber = 0;
        [Test]
        public void EntryInformationTest()
        {
            AddressBookEntryData fromTable = applicationManager.AddressBookEntryHelper.GetEntryInformationFromTable(_entryNumber);
            AddressBookEntryData fromForm = applicationManager.AddressBookEntryHelper.GetEntryInformationFromEditForm(_entryNumber);
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllNumbers, fromForm.AllNumbers);
        }
        [Test]
        public void EntryDetailsTest()
        {
            AddressBookEntryData fromForm = applicationManager.AddressBookEntryHelper.GetEntryInformationFromEditForm(_entryNumber);
            string fromDetails = applicationManager.AddressBookEntryHelper.GetEntryInformationFromDeatils(_entryNumber);
            Assert.AreEqual(fromDetails, fromForm.Details);
        }
    }
}
