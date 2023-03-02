using System;
using System.Collections.Generic;
using System.IO;

namespace GoalTracker
{

    class Program
    {
        static void Main(string[] args)
        {
            // Load saved goals from file
            List<Goal> goals = LoadGoalsFromFile();

            // Show menu and process user input
            while (true)
            {
                Console.WriteLine("\n=== GOAL TRACKER ===");
                Console.WriteLine("1. Add a goal");
                Console.WriteLine("2. Record an event");
                Console.WriteLine("3. Show goals");
                Console.WriteLine("4. Show score");
                Console.WriteLine("5. Exit");

                Console.Write("\nEnter your choice (1-5): ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Add a new goal
                        Console.Write("\nEnter goal type (1=simple, 2=eternal, 3=checklist): ");
                        int type = int.Parse(Console.ReadLine());

                        Console.Write("Enter goal description: ");
                        string description = Console.ReadLine();

                        Console.Write("Enter point value: ");
                        int pointValue = int.Parse(Console.ReadLine());

                        if (type == 1)
                        {
                            goals.Add(new SimpleGoal(description, pointValue));
                        }
                        else if (type == 2)
                        {
                            goals.Add(new EternalGoal(description, pointValue));
                        }
                        else if (type == 3)
                        {
                            Console.Write("Enter goal target count: ");
                            int targetCount = int.Parse(Console.ReadLine());
                            goals.Add(new ChecklistGoal(description, pointValue, targetCount));
                        }

                        Console.WriteLine("Goal added successfully.");
                        break;

                    case 2:
                        // Record an event
                        Console.Write("\nEnter goal Number (1-" + goals.Count + "): ");
                        int index = int.Parse(Console.ReadLine()) - 1;

                        if (index >= 0 && index < goals.Count)
                        {
                            goals[index].RecordEvent();
                            Console.WriteLine("Event recorded successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid goal index.");
                        }

                        break;

                    case 3:
                        // Show goals
                        Console.WriteLine("\n=== GOALS ===");
                        for (int i = 0; i < goals.Count; i++)
                        {
                            Console.Write(i + 1 + ". ");
                            goals[i].Print();
                        }
                        break;

                    case 4:
                        // Show score
                        int score = 0;
                        foreach (Goal goal in goals)
                        {
                            score += goal.Score;
                        }
                        Console.WriteLine("\nYour score is " + score + ".");
                        break;

                    case 5:
                        // Save goals to file and exit
                        SaveGoalsToFile(goals);
                        Console.WriteLine("\nGoodbye!");
                        return;

                    default:
                        Console.WriteLine("\nInvalid choice.");
                        break;
                }
            }
        }

        static List<Goal> LoadGoalsFromFile()
        {
            List<Goal> goals = new List<Goal>();

            try
            {
                StreamReader reader = new StreamReader("goals.txt");

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(',');
                    int type = int.Parse(parts[0]);
                    string description = parts[1];
                    int pointValue = int.Parse(parts[2]);

                    if (type == 1)
                    {
                    goals.Add(new SimpleGoal(description, pointValue));
                    }
                    else if (type == 2)
                    {
                        goals.Add(new EternalGoal(description, pointValue));
                    }
                    else if (type == 3)
                    {
                        int targetCount = int.Parse(parts[3]);
                        goals.Add(new ChecklistGoal(description, pointValue, targetCount));
                    }
               }

               reader.Close();//close
        }
        catch(FileNotFoundException)
        {
        //Filenotfound
        }

        return goals;
    }

        static void SaveGoalsToFile(List<Goal> goals)
        {
            StreamWriter writer = new StreamWriter("goals.txt");

        foreach (Goal goal in goals)
        {
            if (goal is SimpleGoal)
            {
                writer.WriteLine("1," + goal.Description + "," + goal.PointValue);
            }
            else if (goal is EternalGoal)
            {
                writer.WriteLine("2," + goal.Description + "," + goal.PointValue);
            }
            else if (goal is ChecklistGoal)
            {
                ChecklistGoal checklistGoal = (ChecklistGoal)goal;
                writer.WriteLine("3," + goal.Description + "," + goal.PointValue + "," + checklistGoal.TargetCount + "," + checklistGoal.EventCount);
            }
        }

        writer.Close();
    }
}
}
    