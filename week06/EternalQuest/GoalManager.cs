using System;
using System.Collections.Generic;
using System.IO;
using System.Threading; 
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");
            
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails(); 
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
            if (running) { Console.WriteLine("Press Enter to continue..."); Console.ReadLine(); }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    public  void ListGoalNames()
    {
        Console.WriteLine("Goal Names:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("What type of goal would you like to create? ");
        string type = Console.ReadLine();
        
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string desc = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, desc, points));
            Console.WriteLine("Simple Goal created successfully!");
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, desc, points));
            Console.WriteLine("Eternal Goal created successfully!");
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
            Console.WriteLine("Checklist Goal created successfully!");
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            Goal selectedGoal = _goals[goalIndex];
            bool wasCompleted = selectedGoal.IsComplete();
            
            int pointsEarned = selectedGoal.RecordEvent();
            
            if (pointsEarned > 0)
            {
                _score += pointsEarned;
                
                
                if (selectedGoal is ChecklistGoal checklistGoal)
                {
                    if (checklistGoal.IsComplete() && !wasCompleted)
                    {
                        
                        ShowBonusCelebration(checklistGoal.GetBonus());
                        ShowCelebration("🏆 CHECKLIST GOAL COMPLETED! 🏆");
                    }
                    else
                    {
                        Console.WriteLine($"Great progress! You have earned {pointsEarned} points!");
                    }
                }
                else if (selectedGoal is SimpleGoal && !wasCompleted)
                {
                    ShowCelebration("🎯 SIMPLE GOAL COMPLETED! 🎯");
                }
                else if (selectedGoal is EternalGoal)
                {
                    Console.WriteLine($"⭐ Excellent! You earned {pointsEarned} points! Keep going! ⭐");
                }
                
                Console.WriteLine($"You now have {_score} points!");
            }
            else
            {
                Console.WriteLine("This goal is already completed!");
            }
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    public void SaveGoals()
    {
        string filename = "goals.txt"; 
        
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                
                writer.WriteLine(_score);
                
                
                foreach (var goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine($"Goals saved to {filename}!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        string filename = "goals.txt"; 
        
        if (!File.Exists(filename))
        {
            Console.WriteLine($"File {filename} not found.");
            return;
        }

        try
        {
            _goals.Clear(); 
            
            using (StreamReader reader = new StreamReader(filename))
            {
                
                string scoreLine = reader.ReadLine();
                if (scoreLine != null)
                {
                    _score = int.Parse(scoreLine);
                }

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    
                    if (parts[0] == "SimpleGoal")
                    {
                        SimpleGoal goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                        if (bool.Parse(parts[4])) 
                        {
                            goal.RecordEvent();
                        }
                        _goals.Add(goal);
                    }
                    else if (parts[0] == "EternalGoal")
                    {
                        EternalGoal goal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                        _goals.Add(goal);
                    }
                    else if (parts[0] == "ChecklistGoal")
                    {
                        ChecklistGoal goal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), 
                                                             int.Parse(parts[5]), int.Parse(parts[6]));
                        
                        int amountCompleted = int.Parse(parts[4]);
                        for (int i = 0; i < amountCompleted; i++)
                        {
                            goal.RecordEvent();
                        }
                        _goals.Add(goal);
                    }
                }
            }
            Console.WriteLine($"Goals loaded from {filename}!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }

    private void ShowCelebration(string message)
    {
        Console.WriteLine();
        Console.WriteLine("🎉🎉🎉🎉🎉🎉🎉🎉🎉🎉🎉🎉🎉🎉🎉");
        Console.WriteLine("    " + message);
        Console.WriteLine("🎉🎉🎉🎉🎉🎉🎉🎉🎉🎉🎉🎉🎉🎉🎉");
        
        // Animation effect
        for (int i = 0; i < 3; i++)
        {
            Thread.Sleep(500);
            Console.Write("✨ ");
        }
        Console.WriteLine();
        Thread.Sleep(1000);
    }

    private void ShowBonusCelebration(int bonusPoints)
    {
        Console.WriteLine();
        Console.WriteLine("💫💫💫 BONUS ACHIEVED! 💫💫💫");
        Console.WriteLine($"🏆 You earned an extra {bonusPoints} points! 🏆");
        
        
        string[] sparkles = { "✨", "⭐", "🌟", "💫", "⚡" };
        for (int i = 0; i < 8; i++)
        {
            Console.Write(sparkles[i % sparkles.Length] + " ");
            Thread.Sleep(300);
        }
        Console.WriteLine();
        Thread.Sleep(1500);
    }
}