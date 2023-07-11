using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        readonly static Random rng = new Random();
        static bool cont;
        readonly static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main()
        {
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");            
            cont = UserInput(Console.ReadLine().ToLower());
            if (cont == false)
            {
                return;
            }
            
            Console.WriteLine();
            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("What is your age? ");
            int userAge = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            bool seeList = UserInput(Console.ReadLine().ToLower());
            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                bool addToList = UserInput(Console.ReadLine().ToLower());
                Console.WriteLine();
                    while (addToList)
                    {
                        Console.Write("What would you like to add? ");
                        string userAddition = Console.ReadLine();
                        activities.Add(userAddition);
                        foreach (string activity in activities)
                        {
                            Console.Write($"{activity} ");
                            Thread.Sleep(250);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Would you like to add more? yes/no: ");
                        addToList = UserInput(Console.ReadLine().ToLower());
                    }
            }

            while (cont)
            {
                //Console.Write("Connecting to the database");
                //for (int i = 0; i < 10; i++)
                //{
                //    Console.Write(". ");
                //    Thread.Sleep(500);
                //}
                //        Console.WriteLine();
                //        Console.Write("Choosing your random activity");
                //for (int i = 0; i < 9; i++)
                //{
                //    Console.Write(". ");
                //    Thread.Sleep(500);
                //}
                //    Console.WriteLine();
                    int randomNumber = rng.Next(activities.Count);
                    string randomActivity = activities[randomNumber];
                        if (userAge < 21 && randomActivity == "Wine Tasting")
                        {
                            Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                            Console.WriteLine("Pick something else!");
                            activities.Remove(randomActivity);
                            randomNumber = rng.Next(activities.Count);
                            randomActivity = activities[randomNumber];
                        }
                    Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: "); 
                    cont = UserInput(Console.ReadLine().ToLower());
                
            }
        }

        static bool UserInput(string input)
        {      
            switch (input.ToLower())
            {
                case "redo":                    
                case "yes":
                case "sure":
                case "continue":
                    return true;
                case "no":
                case "no thanks":
                case "exit":
                case "end":
                case "keep":
                    Console.WriteLine("Alright.");
                    return false;
                default:
                    Console.WriteLine("Invalid Input, please try again.");
                    return UserInput(input);
            }
        }
    }
}
