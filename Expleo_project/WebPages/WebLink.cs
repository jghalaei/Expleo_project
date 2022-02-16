using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expleo.WebPages
{
    public class WebLink
    {
        public string FindLinks(string urlPath)
        {
            string result;
            var chromeOptions = new ChromeOptions();
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Eager;
            IWebDriver driver = new ChromeDriver(chromeOptions);
            try
            {
                Console.WriteLine("The webpage is reading....\n");
                driver.Navigate().GoToUrl(urlPath);
                var elements = driver.FindElements(By.TagName("a"));
                result= "The existing web-links are as following :";
                foreach (IWebElement element in elements)
                {
                    result += "\n" + element.GetAttribute("href");
                }                
                return result;
            }
            catch( WebDriverException exception)
            {
              
                throw exception;
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
