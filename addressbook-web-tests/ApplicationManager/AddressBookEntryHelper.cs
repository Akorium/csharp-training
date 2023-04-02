using OpenQA.Selenium;
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
        public AddressBookEntryHelper FillAddressBookEntryForm(AddressBookEntryData addressBookEntry)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(addressBookEntry.Firstname);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(addressBookEntry.LastName);
            return this;
        }
        public AddressBookEntryHelper SubmitAddressBookEntryCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Enter']")).Click();
            return this;
        }
        public AddressBookEntryHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }
        public AddressBookEntryHelper GoToEditPage(int number)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + ++number + "]/td[8]/a/img")).Click();
            return this;
        }
        public AddressBookEntryHelper SubmitAddressBookEntryModification()
        {
            driver.FindElement(By.XPath("//input[@value='Update']")).Click();
            return this;
        }
        public AddressBookEntryHelper SelectAddressBookEntry(int number)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + ++number + "]/td[1]/input")).Click();
            return this;
        }
        public AddressBookEntryHelper SubmitAddressBookEntryRemoval()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }
    }
}