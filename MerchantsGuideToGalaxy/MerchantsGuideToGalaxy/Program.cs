using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToGalaxy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * II Silver, IV gold, XX Iron
             * 2 silver = 34 => 17
             * 4 gold = 57800
             * 20 Iron = 3910
             * 
             * XLII => 50 - 10 = 2 = 42
             * IV silver => 68
             * 
             * how much is
             * how many Credits
             * is without Credits
             * is with Credits
             * 
             * Alogrithm & Design
             * 1. Take the symbol and make Dictionary from statements
             * 2. Take the items Credits from the Statements
             * 3. Solve Question based on its type
             *      3.1 Type 1 -> Roman Convertion
             *      3.2 Type 2 -> Items Cost
             *      3.3 Type 3 -> Invalid Questions.
             */
            Console.WriteLine("Welcome, Please Provide Input");
            MerchantsGuideToGalaxySolver merchantsGuideToGalaxySolver = new MerchantsGuideToGalaxySolver();
            merchantsGuideToGalaxySolver.Decode();
        }
    }
}
