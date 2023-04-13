using OpenQA.Selenium;
using System;
using System.Reflection;

namespace addressbook_web_tests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager applicationManager) : base(applicationManager) { }
        public GroupHelper Create(GroupData group)
        {
            applicationManager.NavigationHelper.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }
        public GroupHelper Remove(int number)
        {
            applicationManager.NavigationHelper.GoToGroupsPage();
            SelectGroup(number);
            SubmitGroupRemoval();
            ReturnToGroupsPage();
            return this;
        }
        public GroupHelper Modify(GroupData group, int number)
        {
            applicationManager.NavigationHelper.GoToGroupsPage();
            SelectGroup(number);
            InitGroupModification();
            FillGroupForm(group);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper CheckGroup(int number)
        {
            applicationManager.NavigationHelper.GoToGroupsPage();
            if (!IsThereAnyGroup(number))
            {
                GroupData group = new GroupData("name")
                {
                    Header = "header",
                    Footer = "footer"
                };
                Create(group);
            }
            return this;
        }

        public bool IsThereAnyGroup(int number)
        {
            return IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + number + "]"));
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.XPath("//input[@value='New group']")).Click();
            return this;
        }
        public GroupHelper FillGroupForm(GroupData group)
        {
            Insert(By.Name("group_name"), group.Name);
            Insert(By.Name("group_header"), group.Header);
            Insert(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Enter information']")).Click();
            return this;
        }
        public GroupHelper SelectGroup(int number)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + number + "]")).Click();
            return this;
        }
        public GroupHelper SubmitGroupRemoval()
        {
            driver.FindElement(By.XPath("//input[@value='Delete group(s)']")).Click();
            return this;
        }
        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.XPath("//input[@value='Edit group']")).Click();
            return this;
        }
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.XPath("//input[@value='Update']")).Click();
            return this;
        }

    }
}
