using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToGalaxy
{
    public class Type1QuestionUtil
    {
        public void Solve(string statement, Dictionary<string, string> newGalaxyRomanConversion, TypeOfQuestion typeOfQuestion)
        {
            string romanValueFromStatement = RomanNumber.ConvertWordsToRoman(statement, newGalaxyRomanConversion);
            RomanNumber romanNumber = new RomanNumber(romanValueFromStatement);
            int romanIntegerValue = romanNumber.ConvertRomanNumber();
            if (romanIntegerValue <= 0)
            {
                Console.WriteLine("Roman value is not correct!");
            }
            else
            {
                typeOfQuestion.Solve(romanIntegerValue, statement, newGalaxyRomanConversion);
            }
        }
    }
}
