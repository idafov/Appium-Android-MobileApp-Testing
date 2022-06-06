using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using System;

namespace Appium_First_Tests
{
    public class AppiumCalcTesting : BaseTests
    {

        [Test]
        public void Sum_Positive_A_B()
        {
            SumTwoPositiveNumbers("10", "10");
            Assert.AreEqual("20", GetResult());
        }

        [Test]
        public void Test_Sum_Two_Positive_Numbers()
        {
            SumTwoPositiveNumbers("5", "2");
            
            Assert.AreEqual("7", GetResult());
        }

        [Test]
        public void Test_Sum_Two_Negative_Numbers()
        {
            SumTwoNegativeNumbers("-3", "-2");
            
            Assert.AreEqual("-5", GetResult());
        }

        [Test]
        public void Test_Sum_One_Negative_And_One_Positive_Numbers()
        {
            SumTwoNegativeNumbers("-3", "3");
            
            Assert.AreEqual("0", GetResult());
        }

        [Test]
        public void Test_Sum_One_Negative_And_One_Positive_Numbers_Case2()
        {
            SumTwoNegativeNumbers("3", "-3");
            
            Assert.AreEqual("0", GetResult());
        }

        [Test]
        public void Test_Sum_TwoBigNumbers()
        {
            SumTwoNegativeNumbers(int.MaxValue.ToString(), "1024");
            
            Assert.AreEqual("2147484671", GetResult());
        }

        [Test]
        public void Test_Sum_TwoDoubleNumbers()
        {
            SumTwoNegativeNumbers("2.5", "7.5");
            
            Assert.AreEqual("10.0", GetResult());
        }

        [Test]
        public void Test_Sum_TwoNegativeDoubleNumbers()
        {
            SumTwoNegativeNumbers("-18.5", "-8.3");
            
            Assert.AreEqual("-26.8", GetResult());
        }

        [Test]
        public void Test_Sum_OneNegative_AndOnePositive_DoubleNumbers()
        {
            SumTwoNegativeNumbers("-26.2", "4.4");
            
            Assert.AreEqual("-21.8", GetResult());
        }

        [Test]
        public void Test_Sum_TwoNegative_Numbers()
        {
            SumTwoNegativeNumbers("-26.25", "-4.48");
            
            Assert.AreEqual("-30.73", GetResult());
        }

        [Test]
        public void Test_Sum_Strings_Numbers()
        {
            SumTwoNegativeNumbers("ivan", "asen");
            
            Assert.AreEqual("error", GetResult());
        }

        [Test]
        public void Test_Sum_Chards_Numbers()
        {
            SumTwoNegativeNumbers("x", "y");
            
            Assert.AreEqual("error", GetResult());
        }

        [Test]
        public void Test_Sum_NumAndString_Numbers()
        {
            SumTwoNegativeNumbers("15", "abc");
            
            Assert.AreEqual("error", GetResult());
        }

        [Test]
        public void Test_Sum_Zeros_Numbers()
        {
            SumTwoNegativeNumbers("0", "0");
            
            Assert.AreEqual("0", GetResult());
        }

        [Test]
        public void Test_Big_Double_Numbers()
        {
            SumTwoNegativeNumbers(double.MaxValue.ToString(), float.MaxValue.ToString());
            
            Assert.AreEqual("error", GetResult());
        }

        [Test]
        public void Test_Calculation_In_Fields()
        {
            SumTwoNegativeNumbers("5+2", "5+2");
            
            Assert.AreEqual("error", GetResult());
        }

        [Test]
        public void Test_Calculation_In_Fields_Case2()
        {
            SumTwoNegativeNumbers("(5+2) + 1", "(8.5 + (-0)");
            
            Assert.AreEqual("error", GetResult());
        }

        [Test]
        public void Test_Sum_TwoPositiveNumbers_Coma()
        {
            SumTwoNegativeNumbers("8,6", "9,9");
            
            Assert.AreEqual("185", GetResult());
        }

        [Test]
        public void Test_Sum_TwoPositiveNumbers_Coma_Case2()
        {
            SumTwoNegativeNumbers("-8,6", "-9,9");
            
            Assert.AreEqual("-185", GetResult());
        }

        [Test]
        public void Test_Sum_TwoPositiveNumbers_Space()
        {
            SumTwoNegativeNumbers(" 6", "7");
            
            Assert.AreEqual("13", GetResult());
        }

        [Test]
        public void Test_Sum_TwoPositiveNumbers_ManySpaces()
        {
            SumTwoNegativeNumbers("        6", "7");
            
            Assert.AreEqual("13", GetResult());
        }

        [Test]
        public void Test_Sum_TwoPositiveNumbers_ManySpacesAndTab()
        {
            SumTwoNegativeNumbers("        6", "    7");
            
            Assert.AreEqual("13", GetResult());
        }

        [Test]
        public void Test_Invalid_Input()
        {
            SumTwoNegativeNumbers("- 6", "7");
            
            Assert.AreEqual("error", GetResult());
        }

        [Test]
        public void Test_Invalid_Symbol_In_FirstField()
        {
            for (int i = 0; i < 10; i++)
            {
                SumTwoPositiveNumbersStartingWithSpecialSymbol("5", "5");
               
                Assert.AreEqual("error", GetResult());
                ClearFields();
            }
        }
    }
}