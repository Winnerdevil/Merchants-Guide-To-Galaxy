using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToGalaxy
{
    public interface TypeOfQuestion
    {
        string Solve(int _romanValue, string _question, Dictionary<string, string> _keyValuePairs);
    }

    public class RomanConvertionQuestion : TypeOfQuestion
    {
        public string Solve(int _romanValue, string _question, Dictionary<string, string> _keyValuePairs)
        {
            string answer = "";
            bool foundIS = false;
            foreach (string word in _question.Split(' '))
            {
                if (foundIS)
                {
                    answer += word + " ";
                }
                foundIS |= word == "is";
            }
            answer = answer.Split('?')[0];
            answer += "is " + _romanValue;
            Console.WriteLine(answer);
            return answer;
        }
    }

    public class ItemCostQuestion : TypeOfQuestion
    {
        public string Solve(int _romanValue, string _question, Dictionary<string, string> _itemCostConvertion)
        {
            string answer = "";
            bool foundIS = false;
            int itemCost = 0;
            foreach (string word in _question.Split(' '))
            {
                if (foundIS)
                {
                    answer += word + " ";
                }
                foundIS |= word == "is";
                if (_itemCostConvertion.ContainsKey(word))
                {
                    itemCost = int.Parse(_itemCostConvertion[word]) * _romanValue;
                }
            }
            answer = answer.Split('?')[0];
            answer += "is " + itemCost + " Credits";
            Console.WriteLine(answer);

            return answer;
        }
    }

    public class InvalidQuestion : TypeOfQuestion
    {
        public string Solve(int _romanValue, string _question, Dictionary<string, string> _keyValuePairs)
        {
            string answer = "I have no idea what you are talking about";
            Console.WriteLine(answer);
            return answer;
        }
    }
}
