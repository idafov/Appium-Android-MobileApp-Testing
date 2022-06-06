using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;

namespace Appium_Vivino
{
    public class VivinoTests : BaseTests
    {
        [Test]
        public void Test1()
        {
            ClickTryUsOut();
            Assert.IsTrue(ImageAfterClickOnTryUsOutDisplayed());

            for (int i = 0; i < 5; i++)
            {
                NextButton.Click();
            }
            
            Assert.IsTrue(ContinueWithoutAcc.Displayed);

            ContinueWithoutAcc.Click();

            CreateAccButton.Click();

            RegisterUser();

            AddPersonalDetails();
        }
    }
}