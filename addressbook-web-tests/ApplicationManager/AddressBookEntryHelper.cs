using OpenQA.Selenium;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace addressbook_web_tests
{
    public class AddressBookEntryHelper : HelperBase
    {
        public AddressBookEntryHelper(ApplicationManager applicationManager) : base(applicationManager) { }
        public AddressBookEntryHelper Create(AddressBookEntryData addressBookEntryData)
        {
            applicationManager.NavigationHelper.GoToAddressBookEntryCreationPage();
            FillAddressBookEntryForm(addressBookEntryData);
            SubmitAddressBookEntryCreation();
            ReturnToHomePage();
            return this;
        }
        public AddressBookEntryHelper Modify(AddressBookEntryData addressBookEntryData, int number)
        {
            GoToEditPage(number);
            FillAddressBookEntryForm(addressBookEntryData);
            SubmitAddressBookEntryModification();
            ReturnToHomePage();
            return this;
        }
        public AddressBookEntryHelper Remove(int number)
        {
            SelectAddressBookEntry(number);
            SubmitAddressBookEntryRemoval();
            applicationManager.NavigationHelper.GoToHomePage();
            return this;
        }
        public AddressBookEntryHelper CheckEntry(int number)
        {
            if (!IsThereAnyEntry(number))
            {
                AddressBookEntryData addressBookEntryData = new AddressBookEntryData("Test", "Test");
                Create(addressBookEntryData);
            }
            return this;
        }

        private List<AddressBookEntryData> entriesCache = null;

        public List<AddressBookEntryData> GetEntryList()
        {
            if (entriesCache == null)
            {
                entriesCache = new List<AddressBookEntryData>();
                applicationManager.NavigationHelper.GoToHomePage();
                string[] firstname = GetDataArray(By.XPath("//td[3]"));
                string[] lastname = GetDataArray(By.XPath("//td[2]"));
                for (int i = 0; i < firstname.Length; i++)
                {
                    entriesCache.Add(new AddressBookEntryData(firstname[i], lastname[i]));
                }
            }
            return new List<AddressBookEntryData>(entriesCache);
        }

        private string[] GetDataArray(By locator)
        {
            ICollection<IWebElement> data = driver.FindElements(locator);
            string[] dataarray = new string[data.Count];
            int counter = 0;
            foreach (IWebElement element in data)
            {
                dataarray[counter] = element.Text;
                counter++;
            }
            return dataarray;
        }

        public bool IsThereAnyEntry(int number)
        {
            return IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr[" + number+2 + "]/td[1]/input"));
        }
        public AddressBookEntryHelper FillAddressBookEntryForm(AddressBookEntryData addressBookEntry)
        {
            Insert(By.Name("firstname"), addressBookEntry.Firstname);
            Insert(By.Name("lastname"), addressBookEntry.Lastname);
            return this;
        }
        public AddressBookEntryHelper SubmitAddressBookEntryCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Enter']")).Click();
            entriesCache = null;
            return this;
        }
        public AddressBookEntryHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }
        public AddressBookEntryHelper GoToEditPage(int number)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + number+2 + "]/td[8]/a/img")).Click();
            return this;
        }
        public AddressBookEntryHelper SubmitAddressBookEntryModification()
        {
            driver.FindElement(By.XPath("//input[@value='Update']")).Click();
            entriesCache = null;
            return this;
        }
        public AddressBookEntryHelper SelectAddressBookEntry(int number)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + number+2 + "]/td[1]/input")).Click();
            return this;
        }
        public AddressBookEntryHelper SubmitAddressBookEntryRemoval()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            entriesCache = null;
            return this;
        }
    }
}