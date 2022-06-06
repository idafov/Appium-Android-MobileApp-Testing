using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appium_First_Tests
{
    public class BaseTests
    {
        protected AndroidDriver<AndroidElement> driver;
        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";
        private AppiumOptions options;
        private const string AppPath = @"C:\Users\lhmdai1\Downloads\com.example.androidappsummator.apk";

        [OneTimeSetUp]
        public void Setup()
        {
            this.options = new AppiumOptions();
            options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Windows");
            options.AddAdditionalCapability(MobileCapabilityType.App, AppPath);

            driver = new AndroidDriver<AndroidElement>(new Uri(appiumServer), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

        }

        [SetUp]
        public void SetUp()
        {
            ClearFields();
        }

        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.CloseApp();
        }

        AndroidElement field1 => driver.FindElementById("com.example.androidappsummator:id/editText1");
        AndroidElement field2 => driver.FindElementById("com.example.androidappsummator:id/editText2");
        AndroidElement calcButton => driver.FindElementById("com.example.androidappsummator:id/buttonCalcSum");

        AndroidElement result => driver.FindElementById("com.example.androidappsummator:id/editTextSum");

        public void SumTwoPositiveNumbers(string a, string b)
        {
           
            field1.SendKeys(a);
            field2.SendKeys(b);
            calcButton.Click();
        }
        //
        public void SumTwoNegativeNumbers(string a, string b)
        {
            
            field1.SendKeys(a);
            field2.SendKeys(b);
            calcButton.Click();
        }

        public string GetResult()
        {
            return result.Text;
        }

        private static Random random = new Random();
        public string RandomString(int length = 1)
        {
            const string chars = "!@#$%^&*()_+:?><";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void SumTwoPositiveNumbersStartingWithSpecialSymbol(string a, string b)
        {
            field1.SendKeys(RandomString() + a);
            field2.SendKeys(RandomString() + b);
        }

        public void ClearFields()
        {
            field1.Clear();
            field2.Clear();
        }
    }
}
