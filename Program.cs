using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab8GetToKnowClassmates
{

    class Program
    {

        static void Main(string[] args)
        {
            StudentInformation();
        }

        static void StudentInformation()
        {
            List<string> namesList = new List<string> { "Brian", "Cameron", "Rachel", "Kevin", "Mary", "Samantha", "Jake", "Sam", "Bryce", "Dylan" };
            List<string> foodsList = new List<string> { "Curry", "Pizza", "Ramen", "Spaghetti", "Muesli", "Fondue", "Kielbasa", "BiBimBop", "Garden Salad", "Katsu" };
            List<string> sportsList = new List<string> { "Association Football", "American Football", "Ice Hockey", "Basketball", "eSports", "Tennis", "Volleyball", "Field Hockey", "Handball", "Baseball" };
            List<string> townList = new List<string> { "Detroit", "Dearborn", "Lansing", "Grand Haven", "Allendale", "West Bloomfield", "Las Vegas", "Denver", "Los Angeles", "Boston" };
            List<int> numberList = new List<int> { 2, 10, 6, 420, 300, 150, 8, 9999, 9, 777 };
            {
               bool continuing = true;
                while (continuing == true)
                {
                    for (int i = 0; i < namesList.Count; i++)
                    {
                        Console.WriteLine($"{i + 1,-10}{namesList[i],-15}");
                    }

                    int students = int.Parse(GetUserInput($"Input a number corresponding to the student to learn a few bits of information about them."));

                    if (students >= 1 && students <= 1000)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Student #{students} : {namesList[students - 1]}\n");
                        Console.WriteLine("The four topics we have on students: hometown, favorite food, number and sport.\n");
                        string topic = GetUserInput($"Which topic do you want to know about concerning {namesList[students - 1]}?");
                        topic = VerifyUserTopic(topic, $"Incorrect information. Please input either 'food', 'sport', 'number' or 'hometown'.");

                        if (topic == "food")
                        {
                            Console.WriteLine($"Favorite food of {namesList[students - 1]}: {foodsList[students - 1]}");
                        }
                        if (topic == "sport")
                        {
                            Console.WriteLine($"Favorite sport of {namesList[students - 1]}: {sportsList[students - 1]}");
                        }
                        if (topic == "number")
                        {
                            Console.WriteLine($"Favorite number of {namesList[students - 1]}: {numberList[students - 1]}");
                        }
                        else if (topic == "hometown")
                        {
                            Console.WriteLine($"Hometown of {namesList[students - 1]}: {townList[students - 1]}");
                        }

                        string studentAnswer = GetUserInput("Add a student? y/n");
                        if (studentAnswer == "y")
                        {
                            namesList.Add(GetUserInput("Enter their name: "));
                            foodsList.Add(GetUserInput("Enter their favorite food: "));
                            sportsList.Add(GetUserInput("Enter their favorite sport: "));
                            townList.Add(GetUserInput("Enter their hometown: "));
                            numberList.Add(int.Parse(GetUserInput("Enter their favorite number: ")));
                            continuing = true;
                        }
                        if (studentAnswer == "n")
                        {
                            if (!UserContinueOrAdd("Learn about more students?"))
                            {
                                continuing = true;
                            }
                        }
                    }
                }
            }
        }
        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string userInput = Console.ReadLine();
            while (String.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Invalid input. Read previous prompt and input correctly");
                userInput = Console.ReadLine();
            }
            return userInput;
        }
        public static string VerifyUserTopic(string userTopic, string message)
        {
            while (userTopic != "hometown" && userTopic != "food" && userTopic != "sport" && userTopic != "number")
            {
                Console.WriteLine(message);
                userTopic = Console.ReadLine();
            }
            return userTopic;
        }
        public static bool UserContinueOrAdd(string message)
        {
            Console.WriteLine(message);
            String input = Console.ReadLine().ToLower();

            while (input != "n" && input != "y")
            {
                Console.WriteLine("Invalid input. Try y/n");
                input = Console.ReadLine();
            }

            if (input == "n")
            {
                Console.WriteLine("Goodbye.");
                return false;
            }
            return true;
        }
    }
}