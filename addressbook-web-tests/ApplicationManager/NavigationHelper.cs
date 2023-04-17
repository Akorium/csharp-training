using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class NavigationHelper : HelperBase
    {
        private readonly string _baseURL;
        public NavigationHelper(ApplicationManager applicationManager, string baseURL) : base(applicationManager) 
        {
            this._baseURL = baseURL;
        }
        public void OpenAddressBookPage()
        {
            if (driver.Url == _baseURL)
            {
                return;
            }
            driver.Navigate().GoToUrl(_baseURL);
        }
        public void GoToGroupsPage()
        {
            if (driver.Url == _baseURL + "group.php" && IsElementPresent(By.XPath("//input[@value='New group']")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void GoToAddressBookEntryCreationPage()
        {
            if (driver.Url == _baseURL + "edit.php" && IsElementPresent(By.XPath("//input[@value='Enter']")))
            { 
                return;
            }
            driver.FindElement(By.LinkText("add new")).Click();
        }
        public void GoToHomePage()
        {
            if (driver.Url == _baseURL)
            {
                return;
            }
            driver.FindElement(By.LinkText("home")).Click();
        }
    }
}
