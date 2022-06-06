using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appium_Vivino
{
    public class BaseTests
    {
       
        public AndroidDriver<AndroidElement> driver;
        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";
        private AppiumOptions options;
        private const string AppAct = "com.sphinx_solution.activities.SplashActivity";
        //private const string AppPath = @"C:\Users\lhmdai1\Downloads\vivino.web.app_8.18.11-8181199_minAPI19(arm64-v8a,armeabi,armeabi-v7a,mips,x86,x86_64)(nodpi)_apkmirror.com.apk";

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            this.options = new AppiumOptions();
            options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            options.AddAdditionalCapability("appPackage", "vivino.web.app");
            options.AddAdditionalCapability("appActivity", AppAct);

            driver = new AndroidDriver<AndroidElement>(new Uri(appiumServer), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
        }

        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.CloseApp();
        }

        public AndroidElement TryUsOut => driver.FindElementById("vivino.web.app:id/txtTryUsOut");
        public AndroidElement ImageAfterTryUsOut => driver.FindElementById("vivino.web.app:id/image");
        public AndroidElement NextButton => driver.FindElementById("vivino.web.app:id/next");

        public AndroidElement ContinueWithoutAcc => driver.FindElementById("vivino.web.app:id/continue_without_account");

        public AndroidElement CreateAccButton => driver.FindElementById("vivino.web.app:id/create_free_account");

        public AndroidElement Email => driver.FindElementById("vivino.web.app:id/edtEmail");
        public AndroidElement Pass => driver.FindElementById("vivino.web.app:id/edtPasswordl");
        public AndroidElement FName => driver.FindElementById("vivino.web.app:id/edtUserName");
        public AndroidElement LName => driver.FindElementById("vivino.web.app:id/edtUserSurname");
        public AndroidElement AgreeTerms => driver.FindElementById("vivino.web.app:id/new_profile_agree_terms");
        public AndroidElement DoneButton => driver.FindElementById("vivino.web.app:id/action_done");

        //



        public void ClickTryUsOut()
        {
            TryUsOut.Click();
        }

        public bool ImageAfterClickOnTryUsOutDisplayed()
        {
            return ImageAfterTryUsOut.Displayed;
        }

        public void RegisterUser()
        {
            Email.Click();
            Email.SendKeys("SamoBotev@abv.bg");
            Pass.Click();
            Pass.SendKeys("1912");
        }

        public void AddPersonalDetails()
        {
            FName.Click();
            FName.SendKeys("Vinarq");
            LName.Click();
            LName.SendKeys("Vinarov");
            AgreeTerms.Click();
            DoneButton.Click();
        }
    }
}
