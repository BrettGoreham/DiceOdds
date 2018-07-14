using System;
using System.Collections.Generic;
using System.Text;

namespace DiceOdds
{
    class DiceOdds
    {
        private int sides;
        private int dies;
        private Dictionary<int, long> probabilityDict;

        public DiceOdds(int sides, int dies)
        {
            this.sides = sides;
            this.dies = dies;
            StartCombinatoinCalculation();
        }

        public void PrintCombinations() { 
            Console.WriteLine("Number Of Combinations: " + Math.Pow(sides, dies));
            for (int i = dies; i <= sides* dies; i++)
            {
                double percChance = (((double)probabilityDict[i]) / Math.Pow(sides, dies));
                Console.WriteLine("Combinations to make " + i + ": " + probabilityDict[i] + "\tPercent Chance: " + String.Format("{0:0.0000}", percChance));
            }
        }

        public double CalculatePercentileOfRoll(int roll)
        {
            long combinationsEqualOrLess = 0;
            foreach(int key in probabilityDict.Keys)
            {

                if(key <= roll)
                {
                    combinationsEqualOrLess += probabilityDict[key];
                }
            }
            
            return (((double)combinationsEqualOrLess) / Math.Pow(sides, dies)) * 100;
        }




        private void StartCombinatoinCalculation()
        {
            List<int> sideNumbers = new List<int>();
            for(int i = 0; i < dies; i++)
            {
                sideNumbers.Add(sides);
            }
            probabilityDict = recursiveDicePossibilitiesCaluclator(sideNumbers);
        }

        private Dictionary<int, long> recursiveDicePossibilitiesCaluclator(List<int> sideNumbers)
        {
            if (sideNumbers.Count == 1)
            {
                return populateDictionaryForOneSide(sideNumbers[0]);
            }
            else
            {

                Dictionary<int, long> dict = populateDictionaryForOneSide(sideNumbers[0]);
                sideNumbers.RemoveAt(0);

                Dictionary<int, long> restDict = recursiveDicePossibilitiesCaluclator(sideNumbers);

                return CombineRollDictionaries(dict, restDict);

            }


        }

        private Dictionary<int, long> populateDictionaryForOneSide(int sides)
        {

            Dictionary<int, long> dict = new Dictionary<int, long>();
            for (int i = 1; i <= sides; i++)
            {
                dict.Add(i, 1);
            }
            return dict;
        }

        private Dictionary<int, long> CombineRollDictionaries(Dictionary<int, long> dict1, Dictionary<int, long> dict2)
        {
            Dictionary<int, long> dict = new Dictionary<int, long>();
            foreach (int dict1key in dict1.Keys)
            {
                foreach (int dict2key in dict2.Keys)
                {
                    long value1 = dict1[dict1key];
                    long value2 = dict2[dict2key];
                    long initValue;

                    dict.TryGetValue(dict1key + dict2key, out initValue);

                    dict[dict1key + dict2key] = initValue + (value1 * value2);
                }
            }

            return dict;
        }
    }
}
