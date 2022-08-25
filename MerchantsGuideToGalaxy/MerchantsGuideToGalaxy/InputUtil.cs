using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToGalaxy
{
    public class InputUtil
    {
        public static List<string> ReadInput()
        {
            List<string> testStatement = new List<string>();
            bool doMoreInput;
            do
            {
                doMoreInput = false;
                testStatement.Add(Console.ReadLine());
                Console.WriteLine("Do you want to input more Statment? (Y or N)");
                string choice = Console.ReadLine();
                if (choice == "y" || choice == "Y")
                {
                    doMoreInput = true;
                }
            } while (doMoreInput);

            return testStatement;
        }
    }
}
