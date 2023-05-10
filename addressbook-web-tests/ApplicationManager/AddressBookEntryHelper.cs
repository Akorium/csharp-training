using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace addressbook_web_tests
{
    public class AddressBookEntryHelper : HelperBase
    {
        public AddressBookEntryHelper(ApplicationManager applicationManager) : base(applicationManager) { }
        public void Create(AddressBookEntryData addressBookEntryData)
        {
            applicationManager.NavigationHelper.GoToAddressBookEntryCreationPage();
            FillAddressBookEntryForm(addressBookEntryData);
            SubmitAddressBookEntryCreation();
            ReturnToHomePage();
        }
        public void Modify(AddressBookEntryData addressBookEntryData, int number)
        {
            GoToEditPage(number);
            FillAddressBookEntryForm(addressBookEntryData);
            SubmitAddressBookEntryModification();
            ReturnToHomePage();
        }
        public void Modify(AddressBookEntryData addressBookEntryData, AddressBookEntryData toBeModified)
        {
            applicationManager.NavigationHelper.GoToHomePage();
            GoToEditPage(toBeModified.Id);
            FillAddressBookEntryForm(addressBookEntryData);
            SubmitAddressBookEntryModification();
            ReturnToHomePage();
        }

        public void Remove(int number)
        {
            SelectAddressBookEntry(number);
            SubmitAddressBookEntryRemoval();
            applicationManager.NavigationHelper.GoToHomePage();
        }
        public void Remove(AddressBookEntryData toBeRemoved)
        {
            applicationManager.NavigationHelper.GoToHomePage();
            SelectAddressBookEntry(toBeRemoved.Id);
            SubmitAddressBookEntryRemoval();
            applicationManager.NavigationHelper.GoToHomePage();
        }
        public void CheckEntry(int number)
        {
            if (!IsThereAnyEntry(number))
            {
                CreateDefaultEntry();
            }
        }

        private void CreateDefaultEntry()
        {
            AddressBookEntryData addressBookEntryData = new AddressBookEntryData("Test", "Test");
            Create(addressBookEntryData);
        }

        public List<AddressBookEntryData> CheckEntryInDB(int entryNumber)
        {
            List<AddressBookEntryData> entriesInDB = AddressBookEntryData.GetAllData();
            int entriesToAdd = ++entryNumber - entriesInDB.Count;
            if (entriesToAdd > 0)
            {
                for (int i = 0; i < entriesToAdd; i++)
                {
                    CreateDefaultEntry();
                }
                return AddressBookEntryData.GetAllData();
            }
            return entriesInDB;
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
            return IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr[" + number + 2 + "]/td[1]/input"));
        }
        public void FillAddressBookEntryForm(AddressBookEntryData addressBookEntry)
        {
            Insert(By.Name("firstname"), addressBookEntry.Firstname);
            Insert(By.Name("lastname"), addressBookEntry.Lastname);
        }
        public void SubmitAddressBookEntryCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Enter']")).Click();
            entriesCache = null;
        }
        public void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }
        public void GoToEditPage(int number)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + number + 2 + "]/td[8]/a/img")).Click();
        }
        private void GoToEditPage(string id)
        {
            driver.FindElement(By.XPath("//a[@href='edit.php?id=" + id + "']")).Click();
        }
        public void SubmitAddressBookEntryModification()
        {
            driver.FindElement(By.XPath("//input[@value='Update']")).Click();
            entriesCache = null;
        }
        public void SubmitAddressBookEntryRemoval()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            entriesCache = null;
        }

        public AddressBookEntryData GetEntryInformationFromTable(int number)
        {
            applicationManager.NavigationHelper.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.XPath("//table[@id='maintable']/tbody/tr[" + number + 2 + "]/td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allNumbers = cells[5].Text;
            return new AddressBookEntryData(firstName, lastName)
            {
                Address = address,
                AllNumbers = allNumbers
            };
        }

        public AddressBookEntryData GetEntryInformationFromEditForm(int number)
        {
            applicationManager.NavigationHelper.GoToHomePage();
            GoToEditPage(number);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homeNumber = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobileNumber = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workNumber = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            return new AddressBookEntryData(firstName, lastName)
            {
                Address = address,
                HomeNumber = homeNumber,
                MobileNumber = mobileNumber,
                WorkNumber = workNumber,
                EMail = email,
                EMail2 = email2,
                Email3 = email3
            };
        }
        public int GetNumberOfEntries()
        {
            applicationManager.NavigationHelper.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match match = new Regex(@"\d+").Match(text);
            return int.Parse(match.Value);
        }
        public string GetEntryInformationFromDeatils(int entryNumber)
        {
            applicationManager.NavigationHelper.GoToHomePage();
            GoToDetailsPage(entryNumber);
            string allDeatils = driver.FindElement(By.CssSelector("div#content")).Text;
            return allDeatils;
        }

        public void GoToDetailsPage(int entryNumber)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + entryNumber + 2 + "]/td[7]/a/img")).Click();
        }

        public void AddEntryToGroup(AddressBookEntryData entry, GroupData group)
        {
            applicationManager.NavigationHelper.GoToHomePage();
            SetGroupFilter("[all]");
            SelectAddressBookEntry(entry.Id);
            SelectGroupToAdd(group.Name);
            SubmitActionWithEntry("add");
        }
        public void RemoveEntryFromGroup(AddressBookEntryData entryToRemove, GroupData group)
        {
            applicationManager.NavigationHelper.GoToHomePage();
            SetGroupFilter(group.Name);
            SelectAddressBookEntry(entryToRemove.Id);
            SubmitActionWithEntry("remove");
        }
        public List<AddressBookEntryData> CheckEntryToRemove(GroupData group)
        {
            List<AddressBookEntryData> entriesInGroup = group.GetEntries();
            if (entriesInGroup.Count == 0)
            {
                AddressBookEntryData newEntry = CheckEntryInDB(0).First();
                AddEntryToGroup(newEntry, group);
                return group.GetEntries();
            }
            return entriesInGroup;
        }

        public void SubmitActionWithEntry(string action)
        {
            driver.FindElement(By.Name(action)).Click();
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }
        public void SelectAddressBookEntry(int number)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + number + 2 + "]/td[1]/input")).Click();
        }

        public void SelectAddressBookEntry(string id)
        {
            driver.FindElement(By.Id(id)).Click();
        }

        public void SetGroupFilter(string filter)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("" + filter + "");
        }
    }
}