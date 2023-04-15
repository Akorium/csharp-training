using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace addressbook_web_tests
{
    [TestFixture]
    public class AddressBookEntryCreationTests : AuthorizationTestBase
    {
 
        [Test]
        public void AddressBookEntryCreationTest()
        {
            AddressBookEntryData addressBookEntryData = new AddressBookEntryData("Test", "Test");
            List<AddressBookEntryData> oldentries = applicationManager.AddressBookEntryHelper.GetEntryList();
            applicationManager.AddressBookEntryHelper.Create(addressBookEntryData);
            List<AddressBookEntryData> newentries = applicationManager.AddressBookEntryHelper.GetEntryList();
            oldentries.Add(addressBookEntryData);
            oldentries.Sort();
            newentries.Sort();
            Assert.AreEqual(oldentries, newentries);
            applicationManager.AuthorizationHelper.LogoutFromAddressBook();

        }
    }
}
