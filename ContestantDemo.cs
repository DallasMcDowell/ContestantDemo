using System;
using System.Collections.Generic;

class ContestantDemo
{
    static void Main()
    {
        int numContestants = GetValidContestantCount();
        List<Contestant> contestants = new List<Contestant>();

        // Data Entry
        for (int i = 0; i < numContestants; i++)
        {
            Console.WriteLine($"\nEnter details for contestant {i + 1}:");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            int age = GetValidAge();
            char talentCode = GetValidTalentCode();

            // Determine type based on age
            Contestant contestant;
            if (age <= 12)
                contestant = new ChildContestant(name, age, talentCode);
            else if (age <= 17)
                contestant = new TeenContestant(name, age, talentCode);
            else
                contestant = new AdultContestant(name, age, talentCode);

            contestants.Add(contestant);
        }

        // Display total revenue
        double totalRevenue = CalculateTotalRevenue(contestants);
        Console.WriteLine($"\nTotal Expected Revenue: ${totalRevenue}\n");

        // Talent Search Feature
        SearchByTalentCode(contestants);
    }

    static int GetValidContestantCount()
    {
        int count;
        do
        {
            Console.Write("Enter the number of contestants (0-30): ");
        } while (!int.TryParse(Console.ReadLine(), out count) || count < 0 || count > 30);
        return count;
    }

    static int GetValidAge()
    {
        int age;
        do
        {
            Console.Write("Enter age: ");
        } while (!int.TryParse(Console.ReadLine(), out age) || age < 0);
        return age;
    }

    static char GetValidTalentCode()
    {
        char code;
        bool isValid;
        do
        {
            Console.Write("Enter talent code (S: Singing, D: Dancing, M: Musical Instrument, O: Other): ");
            isValid = char.TryParse(Console.ReadLine().ToUpper(), out code) &&
                      Array.Exists(Contestant.TalentCodes, x => x == code);
            if (!isValid)
                Console.WriteLine("Invalid code. Try again.");
        } while (!isValid);
        return code;
    }

    static double CalculateTotalRevenue(List<Contestant> contestants)
    {
        double total = 0;
        foreach (var contestant in contestants)
        {
            total += contestant.EntryFee;
        }
        return total;
    }

    static void SearchByTalentCode(List<Contestant> contestants)
    {
        while (true)
        {
            Console.Write("\nEnter a talent code to search (S, D, M, O) or Q to quit: ");
            char code = Console.ReadLine().ToUpper()[0];
            if (code == 'Q') break;

            List<Contestant> filtered = contestants.FindAll(c => c.TalentCode == code);
            if (filtered.Count == 0)
                Console.WriteLine("No contestants found.");
            else
                filtered.ForEach(c => Console.WriteLine(c));
        }
    }
}
