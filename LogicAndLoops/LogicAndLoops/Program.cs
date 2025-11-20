using System;
using System.IO;

internal class Program
{
    static void Main(string[] args)
    {

        //1. Ask the user for their name
        Console.Write("Enter your name: ");
        string username = Console.ReadLine();

        //The score file will be saved as: name.txt
        string filename = $"{username}.txt";

        //2. Load previous score if it exists
        int score = 0;

        if (File.Exists(filename))
        {
            //Read old score from file and convert to int
            string savedText = File.ReadAllText(filename);
            score = int.Parse(savedText);
            Console.WriteLine($"Welcome back, {username}! Your previous score was {score}.");
        }
        else
        {
            Console.WriteLine($"Welcome, {username}! Starting a new score file.");
        }

        Console.WriteLine("Start pressing keys! Press ENTER to end the game.");

        //3. Main game loop
        while (true)
        {
            //Read a key without showing it on screen
            var key = Console.ReadKey(true);

            //If ENTER is pressed, break out of the loop
            if (key.Key == ConsoleKey.Enter)
            {
                break;
            }

            //Add 1 point for every keypress
            score++;

            //Show the updated score
            Console.WriteLine($"Score: {score}");
        }

        //4. Save the final score to the file
        File.WriteAllText(filename, score.ToString());

        Console.WriteLine($"\nGame over, {username}!");
        Console.WriteLine($"Your score ({score}) has been saved to {filename}.");
    }
}

