using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MerchantsGuideToGalaxy
{
    public class RomanNumber
    {
        private readonly static Dictionary<char, int> ROMAN_SYMBOL_DICTIONARY = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        private string _romanNumber { get; }

        public RomanNumber(string romanNumber)
        {
             _romanNumber = romanNumber;
        }

        public int ConvertRomanNumber()
        { 
            if (ValidatedRomanNumber(_romanNumber) == false)
            {
                return -1;
            }
            int integerValue = 0;
            for (int i = 0; i < _romanNumber.Length; i++) 
            {
                int currentIndex = i;
                int nextIndex = i + 1;
                if (nextIndex < _romanNumber.Length && ROMAN_SYMBOL_DICTIONARY[_romanNumber[currentIndex]] < ROMAN_SYMBOL_DICTIONARY[_romanNumber[nextIndex]])
                {
                    integerValue -= ROMAN_SYMBOL_DICTIONARY[_romanNumber[currentIndex]];
                }
                else
                {
                    integerValue += ROMAN_SYMBOL_DICTIONARY[_romanNumber[currentIndex]];
                }
            }

            return integerValue;
        }

        public static bool ValidatedRomanNumber(string _strRomanNumber)
        {
            if (_strRomanNumber == null || _strRomanNumber == "")
            {
                return false;
            }
            for (int i =  0; i < _strRomanNumber.Length; i++) 
            {
                char romanSymbol = _strRomanNumber[i];
                // unwanted symbol (not present in roman symbol)
                if (ROMAN_SYMBOL_DICTIONARY.ContainsKey(romanSymbol) == false) { return false; }
                // more than 3 I, X, C, M is not allowed & D, L, V can never be repeated
                if (isRepeatativeConditionFalse(_strRomanNumber, romanSymbol, i))
                {
                    return false;
                }
                // after I only V, X, I is allowed, after X only L, C, X is allowed, after C only D, M, C is allowed
                if (nextAllowedCharCondition(_strRomanNumber, romanSymbol, i))
                {
                    return false;
                }
            }
            return true;
        }
        private static bool nextAllowedCharCondition(string _strRomanNumber, char _romanSymbol, int index)
        {
            if (index + 1 >= _strRomanNumber.Length) return false;
            int nextIndex = index + 1;
            bool conditionForI = (_romanSymbol != 'I') || (_romanSymbol == 'I' 
                && (_strRomanNumber[nextIndex] == 'I' || _strRomanNumber[nextIndex] == 'V' || _strRomanNumber[nextIndex] == 'X'));
            bool conditionForX = (_romanSymbol != 'X') || (_romanSymbol == 'X'
                && (_strRomanNumber[nextIndex] == 'X' || _strRomanNumber[nextIndex] == 'L' || _strRomanNumber[nextIndex] == 'C'));
            bool conditionForC = (_romanSymbol != 'C') || (_romanSymbol == 'C'
                && (_strRomanNumber[nextIndex] == 'C' || _strRomanNumber[nextIndex] == 'D' || _strRomanNumber[nextIndex] == 'M'));

            return !conditionForI || !conditionForX || !conditionForC;
        }

        private static bool isRepeatativeConditionFalse(string _strRomanNumber, char _romanSymbol, int index)
        {
            for (int i = 1; i < _strRomanNumber.Length; i++)
            {
                int previousIndex = i - 1;
                int currentIndex = i;
                if ((_strRomanNumber[currentIndex] == 'D' || _strRomanNumber[currentIndex] == 'L' || _strRomanNumber[currentIndex] == 'V') 
                    && _strRomanNumber[previousIndex] == _strRomanNumber[currentIndex])
                {
                    return true;
                }
            }

            if (index + 4 > _strRomanNumber.Length) { return false; }

            if (_romanSymbol == 'I' || _romanSymbol == 'X' || _romanSymbol == 'C' || _romanSymbol == 'M')
            {
                
                string nextFourChar = _strRomanNumber.Substring(index, 4);
                for (int i = 1; i < 4; i++)
                {
                    int previousIndex = i - 1;
                    int currentIndex = i;
                    if (nextFourChar[previousIndex] != nextFourChar[currentIndex])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        public static string ConvertWordsToRoman(string statement, Dictionary<string, string> _newGalaxyDictionary)
        {
            string romanNumberFromStatement = "";

            foreach (string word in statement.Split(' '))
            {
                if (_newGalaxyDictionary.ContainsKey(word))
                {
                    romanNumberFromStatement += _newGalaxyDictionary[word];
                }
            }

            return romanNumberFromStatement;
        }
    }
}
