using Expleo.Anagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Expleo_Tests.Anagram_tests

{
    public class AnagramTests
    {
        [Theory]
        [InlineData("Mary","Army",true)]
        [InlineData("Mary1234","a1r2y3m4",true)]
        [InlineData("Mary","Mary",true)]
        [InlineData("Mary", "Arm", false)]
        [InlineData("Mary", "Armyy", false)]
        [InlineData("Mary","MarG",false)]
        [InlineData("","2a23sd",false)]
        [InlineData("","",false)]
        public void IsAnagram_success(string str1, string str2, bool expectedResult)
        {
            Anagram anagram = new();
            var result = anagram.IsAnagram(str1, str2);
            Assert.Equal(result, expectedResult);
        }

    }
}
