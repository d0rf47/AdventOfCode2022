/**
--- Part Two ---

The Elf finishes helping with the tent and sneaks back over to you. "Anyway, the second column says how the round needs to end: X means you need to lose, Y means you need to end the round in a draw, and Z means you need to win. Good luck!"

The total score is still calculated in the same way, but now you need to figure out what shape to choose so the round ends as indicated. The example above now goes like this:

    In the first round, your opponent will choose Rock (A), and you need the round to end in a draw (Y), so you also choose Rock. This gives you a score of 1 + 3 = 4.
    In the second round, your opponent will choose Paper (B), and you choose Rock so you lose (X) with a score of 1 + 0 = 1.
    In the third round, you will defeat your opponent's Scissors with Rock for a score of 1 + 6 = 7.

Now that you're correctly decrypting the ultra top secret strategy guide, you would get a total score of 12.

Following the Elf's instructions for the second column, what would your total score be if everything goes exactly according to your strategy guide?

*/
using System;
using System.IO;
using System.Linq;

namespace AdventOfCode_d0rf47
{
    /**
    * Elfs:
    * A = Rock = 1
    * B = Paper = 2
    * C = scissors = 3
    *
    * Me:
    * X = Rock = 1
    * Y = Paper = 2
    * Z = Scissor = 3
    * Win = 6
    * Draw = 3
    * Lose = 0
    */
    class RockPaperScissors
    {
        static void Main(string[] args)
        {
            int finalScore = 0;
            string filePath = "./input-strategy.txt";
            IDictionary<string, int> MoveValues = new Dictionary<string, int>()
            {
                {"X", 1},
                {"Y", 2},
                {"Z", 3}
            };
            if(!File.Exists(filePath))
            {
                Console.WriteLine("No File Found!");
                return;
            }

            using (StreamReader reader =  File.OpenText(filePath))
            {
                var lines = File.ReadAllLines(filePath);     
                foreach(var line in lines)
                {
                    int roundScore = 0;
                    string[] moves = line.Split(' ');

                    roundScore += GetScore(moves[0], moves[1]);
                    roundScore += MoveValues[moves[1]];
                    finalScore += roundScore;                    
                }

            }
            Console.WriteLine($" Final Score: {finalScore}");
        }

        // return 6, 3, 0 depending on win draw or lose
        public static int GetScore(string them, string me)
        {
            //need to redfine this based on new problem strat
            // my moves char will determine the required outcome and this
            //change what the actual move response may be
            switch (them)
            {
                //rock
                case "A": 
                    if(me == "Y")
                        return 6;
                    if(me == "X")
                        return 3;
                    else
                        return 0;                    
                //paper
                case "B":
                    if(me == "Z")
                        return 6;
                    if(me == "Y")
                        return 3;
                    else
                        return 0;
                //scissors
                case "C":
                    if(me == "X")
                        return 6;
                    if(me == "Z")
                        return 3;
                    else
                        return 0;
            }
            return 0;
        }
    }
}
