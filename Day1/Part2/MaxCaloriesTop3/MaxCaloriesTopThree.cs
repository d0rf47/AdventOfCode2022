/**
--- Part Two ---
By the time you calculate the answer to the Elves' question, they've already realized that the Elf carrying the most Calories 
of food might eventually run out of snacks.

To avoid this unacceptable situation, the Elves would instead like to know the total Calories carried by the top three Elves 
carrying the most Calories. That way, even if one of those Elves runs out of snacks, they still have two backups.

In the example above, the top three Elves are the fourth Elf (with 24000 Calories), 
then the third Elf (with 11000 Calories), then the fifth Elf (with 10000 Calories). 
The sum of the Calories carried by these three elves is 45000.

Find the top three Elves carrying the most Calories. How many Calories are those Elves carrying in total?

*/

using System;
using System.IO;
using System.Linq;
namespace AdventOfCode_d0rf47
{
    class MaxCaloriesTopThree
    {
        
        static int Main(string[] args)
        {
            int[] MaxTopThree = {0,0,0};
            string filePath = "./input-calories.txt";
            if(!File.Exists(filePath))
            {
                Console.WriteLine("No File Found!");
                return 0;
            }else
            {
                using (StreamReader reader = File.OpenText(filePath))
                {
                    var lines = File.ReadLines(filePath);
                    int tempSum = 0;                    
                    foreach (var line in lines)
                    {                        
                        if(line.Length != 0 )
                        {
                            tempSum += Int32.Parse(line);                            
                        }else
                        {
                            for( int i = 0; i < 3; i++)
                            {
                                if(tempSum > MaxTopThree[i]){
                                    MaxTopThree[i] = tempSum;
                                    break;
                                }                                
                            }
                            tempSum = 0;                            
                        }
                    }
                    foreach(int i in MaxTopThree)
                        Console.WriteLine(i);
                    int totalSum = MaxTopThree.Sum();
                    Console.WriteLine(totalSum);                    
                }
                return 0;
            }
            
        }
    }
}