using System;
using System.Collections.Generic;

namespace DiceOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert num of Dice Sides: ");
            String sidesString = Console.ReadLine();
            int sides = Int32.Parse(sidesString);


            Console.WriteLine("Insert num of Die: ");
            String diesString = Console.ReadLine();
            int dies = Int32.Parse(diesString);
          

            DiceOdds d1 = new DiceOdds(sides, dies);
            Console.Write("\n\n");
            d1.PrintCombinations();

            Console.Write("\n\n");
            Console.WriteLine("Get Percentile of a roll: ");
            String roll = Console.ReadLine();
            Console.WriteLine("Percentile of roll: " + d1.CalculatePercentileOfRoll(Int32.Parse(roll)) + "th" );


            Console.ReadKey();

        }

    }
}
