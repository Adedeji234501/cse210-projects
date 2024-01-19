class Program
{
    static void Main()
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        journal.WriteNewEntry();
                        break;
                    case 2:
                        journal.DisplayJournal();
                        break;
                    case 3:
                        Console.Write("Enter the filename to save: ");
                        string saveFilename = Console.ReadLine();
                        journal.SaveToFile(saveFilename);
                        break;
                    case 4:
                        Console.Write("Enter the filename to load: ");
                        string loadFilename = Console.ReadLine();
                        journal.LoadFromFile(loadFilename);
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}
