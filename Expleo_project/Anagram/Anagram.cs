using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expleo.Anagram
{
    public class Anagram
    {

        public  bool IsAnagram(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
                return false;
            if (str1.Length != str2.Length)
                return false;

            List<char> firstStr = str1.ToLower().ToList();
            List<char> secondStr = str2.ToLower().ToList();
            firstStr.Sort();
            secondStr.Sort();

            for (int i = 0; i < firstStr.Count; i++)
                if (firstStr[i] != secondStr[i])
                    return false;
            return true;
        }
    }
}
