using System;

class Program
{
    static void Main(string[] args)
    {
        //Core Requirement 1: Ask the user for a series of numbers until 0 is entered
        List<int> numbers = new List<int>();
        int input;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        do
        {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());

            if (input != 0)
            numbers.Add(input);

        } while (input != 0);

        //Core Requirement 2: Compute the sum of the numbers
        int sum = numbers.Sum();

        //Core Requirement 3: Compute the average of the numbers
        double average = numbers.Average();

        //Find the largest number
        int maxNumber = numbers.Max();

        // Display core results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {maxNumber}");

        // Stretch Challenge 1: Find the smallest positivenumber
        int smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty(0).Min();
        
        // Stretch Challenge 2: Sort the list and display the new, sorted list
        List<int> sortedList = numbers.OrderBy(n => n).ToList();
        
        //Display stretch challenge results
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        Console.WriteLine($"The sorted list is: ");
        foreach (var num in sortedList)
        {
            Console.WriteLine(num);
        }
    }
}