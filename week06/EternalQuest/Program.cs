using System;
using System;
using System.Collections.Generic;

abstract class Goal
{
    protected string Name;
    protected string Description;
    protected int Points;

    public Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
    }

    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDetails();
}

class SimpleGoal : Goal
{
    private bool Completed;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        Completed = false;
    }

    public override int RecordEvent()
    {
        if (!Completed)
        {
            Completed = true;
            return Points;
        }
        return 0;
    }

    public override bool IsComplete() => Completed;

    public override string GetDetails() => $"[ {(Completed ? "X" : " ")} ] {Name} ({Description})";
}

class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) {}

    public override int RecordEvent() => Points;

    public override bool IsComplete() => false;

    public override string GetDetails() => $"[∞] {Name} ({Description})";
}

class ChecklistGoal : Goal
{
    private int TargetCount;
    private int CurrentCount;
    private int BonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        TargetCount = targetCount;
        CurrentCount = 0;
        BonusPoints = bonusPoints;
    }

    public override int RecordEvent()
    {
        if (CurrentCount < TargetCount)
        {
            CurrentCount++;
            if (CurrentCount == TargetCount)
                return Points + BonusPoints;
            else
                return Points;
        }
        return 0;
    }

    public override bool IsComplete() => CurrentCount >= TargetCount;

    public override string GetDetails() => $"[ {(IsComplete() ? "X" : " ")} ] {Name} ({Description}) -- Completed {CurrentCount}/{TargetCount}";
}

class GoalManager
{
    private List<Goal> Goals = new List<Goal>();
    private int Score = 0;

    public void AddGoal(Goal goal) => Goals.Add(goal);

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < Goals.Count)
            Score += Goals[goalIndex].RecordEvent();
    }

    public void DisplayGoals()
    {
        for (int i = 0; i < Goals.Count; i++)
            Console.WriteLine($"{i + 1}. {Goals[i].GetDetails()}");
    }

    public void DisplayScore() => Console.WriteLine($"Current Score: {Score}");
}

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nEternal Quest Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Quit");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Select Goal Type: 1) Simple 2) Eternal 3) Checklist");
                    string type = Console.ReadLine();

                    Console.Write("Enter name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter description: ");
                    string desc = Console.ReadLine();
                    Console.Write("Enter points: ");
                    int pts = int.Parse(Console.ReadLine());

                    if (type == "1")
                        manager.AddGoal(new SimpleGoal(name, desc, pts));
                    else if (type == "2")
                        manager.AddGoal(new EternalGoal(name, desc, pts));
                    else if (type == "3")
                    {
                        Console.Write("Enter target count: ");
                        int target = int.Parse(Console.ReadLine());
                        Console.Write("Enter bonus points: ");
                        int bonus = int.Parse(Console.ReadLine());
                        manager.AddGoal(new ChecklistGoal(name, desc, pts, target, bonus));
                    }
                    break;
                case "2":
                    manager.DisplayGoals();
                    break;
                case "3":
                    manager.DisplayGoals();
                    Console.Write("Select goal to record: ");
                    int index = int.Parse(Console.ReadLine()) - 1;
                    manager.RecordEvent(index);
                    break;
                case "4":
                    manager.DisplayScore();
                    break;
                case "5":
                    running = false;
                    break;
            }
        }
    }
}


