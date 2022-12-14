/**
From: https://adventofcode.com/2022/day/1
This list represents the Calories of the food carried by five Elves:
1000
2000
3000

4000

5000
6000

7000
8000
9000

10000

    The first Elf is carrying food with 1000, 2000, and 3000 Calories, a total of 6000 Calories.
    The second Elf is carrying one food item with 4000 Calories.
    The third Elf is carrying food with 5000 and 6000 Calories, a total of 11000 Calories.
    The fourth Elf is carrying food with 7000, 8000, and 9000 Calories, a total of 24000 Calories.
    The fifth Elf is carrying one food item with 10000 Calories.

In case the Elves get hungry and need extra snacks, they need to know which Elf to ask: 
they'd like to know how many Calories are being carried by the Elf carrying the most Calories. In the example above, this is 24000 (carried by the fourth Elf).

Find the Elf carrying the most Calories. How many total Calories is that Elf carrying?
*/
using System;
using System.IO;
namespace AdventOfCode_d0rf47
{
    class MaxCalories
    {
        static int Main(string[] args)
        {
            //hold current max val
            int currMax = 0; 
            // read file
            // iterate over records --> first value = max
            // if next val > currMax currMax = next Val
            // console.writeline(maxValue)
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
                    int i = 0;
                    foreach (var line in lines)
                    {
                        i++;
                        if(line.Length != 0 )
                        {
                            tempSum += Int32.Parse(line);                            
                        }else
                        {
                            if(tempSum > currMax)
                                currMax = tempSum;
                            tempSum = 0;
                        }
                    }Console.WriteLine(currMax);
                    return 0;
                }
            }
            
            
        }
    }
}