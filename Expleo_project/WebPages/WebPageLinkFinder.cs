using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expleo.WebPages
{
    public class WebPageLinkFinder
    {
        public void findLinks(string uri)
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Eager;

            IWebDriver driver = new ChromeDriver(chromeOptions);
            try
            {
                Console.WriteLine("The webpage is reading....\n");
                driver.Navigate().GoToUrl(uri);
                var elements = driver.FindElements(By.TagName("a"));
                Console.WriteLine("The existing web-links are as following :\n ");
                foreach (IWebElement element in elements)
                {
                    Console.WriteLine(element.GetAttribute("href"));
                }
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
