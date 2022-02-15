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
        public void findLinks(string urlPath)
        {
            Uri? uriResult;
        bool result = Uri.TryCreate(urlPath,UriKind.RelativeOrAbsolute, out uriResult) 
    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme==Uri.UriSchemeHttps);
    if (!result)
    {
        Console.WriteLine("Invalid URL...\nPlease enter a valid URL");
        return;
    }
            var chromeOptions = new ChromeOptions();
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Eager;

            IWebDriver driver = new ChromeDriver(chromeOptions);
            try
            {
                Console.WriteLine("The webpage is reading....\n");
                driver.Navigate().GoToUrl(uriResult.AbsoluteUri);
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
