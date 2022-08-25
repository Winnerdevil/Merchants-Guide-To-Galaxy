using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToGalaxy
{
    public class MerchantsGuideToGalaxySolver
    {
        public void Decode()
        {
            List<string> Statements = InputUtil.ReadInput(); // Read Input
            Dictionary<string, string> newGalaxyRomanConversion = new Dictionary<string, string>();
            Dictionary<string, string> newGalaxyItemConversion = new Dictionary<string, string>();
            TypeOfQuestion typeOfQuestion;

            foreach (string statement in Statements)
            {
                if (statement.Contains("how much is"))
                {
                    // Type 1 Question (Roman Conversion)
                    typeOfQuestion = new RomanConvertionQuestion();
                    Type1QuestionUtil type1QuestionUtil = new Type1QuestionUtil();
                    type1QuestionUtil.Solve(statement, newGalaxyRomanConversion, typeOfQuestion);
                }
                else if (statement.Contains("how many Credits"))
                {
                    // Type 2 Question (Item Cost)
                    typeOfQuestion = new ItemCostQuestion();
                    Type2QuestionUtil type2QuestionUtil = new Type2QuestionUtil();
                    type2QuestionUtil.Solve(statement, newGalaxyRomanConversion, newGalaxyItemConversion, typeOfQuestion);
                }
                else if (statement.Contains("Credits") && statement.Contains("is"))
                {
                    prepareItemDictionary(newGalaxyRomanConversion, newGalaxyItemConversion, statement);
                }
                else if (!statement.Contains("Credits") && statement.Contains("is"))
                {
                    prepareRomanDictionary(newGalaxyRomanConversion, statement);
                }
                else
                {
                    // Type 3 Question (Invalid)
                    typeOfQuestion = new InvalidQuestion();
                    Type3QuestionSolver type3QuestionSolver = new Type3QuestionSolver();
                    type3QuestionSolver.Solve(typeOfQuestion);
                }
            }
            Console.ReadKey();
        }

        private static void prepareRomanDictionary(Dictionary<string, string> newGalaxyRomanConversion, string statement)
        {
            string keyInRomanConversion = statement.Split(' ')[0];
            string valueInRomanConversion = statement.Split(' ')[2];
            newGalaxyRomanConversion.Add(keyInRomanConversion, valueInRomanConversion);
        }

        private static void prepareItemDictionary(Dictionary<string, string> newGalaxyRomanConversion, Dictionary<string, string> newGalaxyItemConversion, string statement)
        {
            string itemName = "";
            string romanValueFromStatement = RomanNumber.ConvertWordsToRoman(statement, newGalaxyRomanConversion);
            RomanNumber romanNumber = new RomanNumber(romanValueFromStatement);
            int romanIntegerValue = romanNumber.ConvertRomanNumber();
            int Credits = -1;
            foreach (string word in statement.Split(' '))
            {
                if (newGalaxyRomanConversion.ContainsKey(word) == false)
                {
                    itemName = word;
                    break;
                }
            }
            foreach (string word in statement.Split(' '))
            {
                try
                {
                    if (Credits == -1)
                    {
                        Credits = int.Parse(word);
                    }
                }
                catch (Exception e)
                {
                    // No use
                }
            }
            if (romanIntegerValue <= 0)
            {
                Console.WriteLine("Roman value is not correct!");
            }
            else
            {
                newGalaxyItemConversion.Add(itemName, "" + Credits / romanIntegerValue);
            }
        }
    }
}
