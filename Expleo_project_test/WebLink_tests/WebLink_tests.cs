using Expleo.WebPages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Expleo_project_test.WebLink_tests
{
    public class WebLink_tests
    {
        [Fact]
        public void FindLink_successfull()
        {
            WebLink webLink = new WebLink();
            string? str=webLink.FindLinks("https://www.google.com");
            Assert.NotNull(str);
        }
        
        [Theory]
        [InlineData("sometext")]
        [InlineData("")]
        [InlineData(" ")]
        public void FindLink_failue_invalidUrl(string url)
        {
            WebLink webLink = new WebLink();
            Assert.Throws<WebDriverArgumentException>(()=>webLink.FindLinks(url));
 
        }

        [Fact]
        public void FindLink_failue_UrlNotFound()
        {
            WebLink webLink = new WebLink();
            Assert.Throws<WebDriverException>(() => webLink.FindLinks("https://www.go234ogle.com"));

        }

    }
}
