﻿using NUnit.Framework;
using System;
using System.Text;

namespace addressbook_web_tests
{
    public class TestBase
    {
        protected ApplicationManager applicationManager;
        public static bool PERFORM_LONG_UI_CHEKS = true;

        [SetUp]
        public void SetupApplicationManager()
        {
            applicationManager = ApplicationManager.GetInstance();
        }
        public static Random random = new Random();
        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(random.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                _ = builder.Append(Convert.ToChar(32 + Convert.ToInt32(random.NextDouble() * 65)));
            }
            return builder.ToString();
        }
    }
}
