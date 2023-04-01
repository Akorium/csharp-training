using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;
        public NavigationHelper(ApplicationManager applicationManager, string baseURL) : base(applicationManager) 
        {
            this.baseURL = baseURL;
        }
        public NavigationHelper OpenAddressBookPage()
        {
            driver.Navigate().GoToUrl(baseURL);
            return this;
        }
        public NavigationHelper GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }
        public NavigationHelper GoToAddressBookEntryCreationPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
    }
}
