using System;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        DateTime birthDateValue;
        while (true)
        {
            Console.Write("Enter your birthdate (MM/dd/yyyy): ");
            string birthdate = Console.ReadLine();
            if (Regex.IsMatch(birthdate, @"^(0[1-9]|1[0-2])\/(0[1-9]|[12][0-9]|3[01])\/\d{4}$") &&
                DateTime.TryParseExact(birthdate, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDateValue))
                break;
            Console.WriteLine("Invalid birthdate format.");
        }

        int age = DateTime.Now.Year - birthDateValue.Year;
        if (DateTime.Now.DayOfYear < birthDateValue.DayOfYear) age--;

        string filePath = "user_info.txt";
        File.WriteAllText(filePath, $"Name: {name}\nBirthdate: {birthDateValue:MM/dd/yyyy}\nAge: {age}");
        Console.WriteLine($"\n{File.ReadAllText(filePath)}");

        Console.Write("\nEnter a directory path: ");
        string directoryPath = Console.ReadLine();
        if (Directory.Exists(directoryPath))
            foreach (var file in Directory.GetFiles(directoryPath))
                Console.WriteLine(file);
        else
            Console.WriteLine("Directory not found.");

        Console.Write("\nEnter a string: ");
        string inputString = Console.ReadLine();
        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        Console.WriteLine($"Formatted string in Title Case: {textInfo.ToTitleCase(inputString.ToLower())}");

        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine("Garbage collection completed.");
    }
}


