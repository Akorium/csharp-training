using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class AuthorizationHelper : HelperBase
    {
        public AuthorizationHelper(ApplicationManager applicationManager) : base(applicationManager) { }
        public void AddressBookAuthorization(AccountData account)
        {
            if (IsAuthorized())
            {
                if (IsAuthorized(account))
                {
                    return;
                }
                LogoutFromAddressBook();
            }
            Insert(By.Name("user"), account.Username);
            Insert(By.Name("pass"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public bool IsAuthorized(AccountData account)
        {
            return IsAuthorized()
                && GetAuthorizedUserName() == account.Username;
        }

        private string GetAuthorizedUserName()
        {
            string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            return text.Substring(1, text.Length - 2);
        }

        public bool IsAuthorized()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public void LogoutFromAddressBook()
        {
            if (IsAuthorized())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
                _ = driver.FindElement(By.Name("user"));
            }

        }
    }
}
