using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Timers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace demoo
{
    [TestClass]
    public class CheckLogFiles
    {
      
        [ClassInitialize]
        public static void Reloading(TestContext testContext)
        {
            //Initilizes a new instance of the Timer class, and sets the Timer.Interval property to the specified number of milliseconds
            
            //TimeSpan represents a time interval

            //TimeSpan.FromSeconds(double value) returns TimeSpan that returns number of seconds, where specification is accurate to the nearest millisecond.

            //TimeSpan.TotalMilliseconds - Gets the value of the current timespan structure expressed in whole and fractional seconds.

            Timer t = new Timer(TimeSpan.FromSeconds(10).TotalMilliseconds); // Set the time (10 seconds in this case)
            t.AutoReset = true;

            //occurs when Timer elapsed
            t.Elapsed += new System.Timers.ElapsedEventHandler(your_method);

            //Start raising the Timer.Elapsed event by setting Timer.Enabled to true
            t.Start();
        }

        // This method is called every 10 seconds
        private static void your_method(object sender, ElapsedEventArgs e)
        {
            ReadLogFile();
        }

        ////to extract data from "log.txt", store into variables and print it
        public static void ReadLogFile()
        {
            //System.IO.SystemReader implements a System.IO.TextReader that reads a character from a byte stream in particular encoding
            System.IO.StreamReader reader = new System.IO.StreamReader(@"C:\Users\YOGESH GARG\source\repos\demoo\demoo\log.txt");
            
            //gets the value that indicates whether the current stream position is at the end of the stream
            while (!reader.EndOfStream)
            {
                //reads line of characters from current stream and returns data as a string
                var line = reader.ReadLine();
                var values = line.Split(' ');

                //get the current date time
                Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt") + " :   "+ values[0] + " " + values[1]);
            }
        }

        //same code of "MSTEST FOR GOOGLE & FACEBOOK
        IWebDriver driver = new ChromeDriver();

        [TestInitialize]
        public void Initilize()
        {
            //maximize the browser
            driver.Manage().Window.Maximize();

            //set Implicit Time Wait as well
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TestMethod]
        public void TestMethod0()
        {
            try
            {
                //set url of driver 
                driver.Url = "http://google.com";

                //finding element with the Name "q" and entering "Regression Testing" there, after that enter is pressed (keyboard)
                driver.FindElement(By.Name("q")).SendKeys("Regression Testing" + Keys.Enter);

                // press browser's back button
                driver.Navigate().Back();

                // press browser's front button
                driver.Navigate().Forward();

                // refresh current page
                driver.Navigate().Refresh();

                //current page title from the browser
                Console.WriteLine(driver.Title);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception encountered : " + e);
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                // to go to this url
                driver.Url = "http://facebook.com";

                //extract "username or email" field from the login page and entered the provided email there
                driver.FindElement(By.Id("email")).SendKeys("email");

                //extract "password" field and entered the provided password and press enter (keyboard)
                driver.FindElement(By.Id("pass")).SendKeys("password" + Keys.Enter);

                // extract the profile element and click 
                driver.FindElement(By.XPath("//*[@href='https://www.facebook.com/tanisha.garg.94617/']")).Click();

                //extract the "Friends" tab and click 
                driver.FindElement(By.XPath("//*[@href='https://www.facebook.com/tanisha.garg.94617/friends']")).Click();

                // verify

                //this variable contains true if the mentioned element is displayed
                bool a = driver.FindElement(By.XPath("//*[@href='https://www.facebook.com/tanisha.garg.94617/friends']")).Displayed;

                //information about the element returned by FindElement
                Console.WriteLine(driver.FindElement(By.XPath("//*[@href='https://www.facebook.com/tanisha.garg.94617/friends']")));

                //just to check
                Console.WriteLine(a == true);

                //assert 
                Assert.AreEqual(a, true);

                //assert
                Assert.IsTrue(a); // preferable
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception encountered : " + e);
            }
        }

        [TestCleanup]
        public void CleanUp()
        {
            //closes the browser
            driver.Close();

            //most important step
            driver.Quit();
        }
    }
}
