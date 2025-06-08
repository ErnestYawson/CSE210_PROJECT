using System;
// Base Activity Class
public abstract class MindfulnessActivity
{
    protected string name;
    protected string description;
    protected int duration;

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"--- {name} ---\n{description}");
        Console.Write("Enter duration in seconds: ");
        duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        PerformActivity();
        Console.WriteLine($"\nWell done! You completed the {name} activity for {duration} seconds.");
        ShowSpinner(3);
    }

    protected abstract void PerformActivity();

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

// Breathing Activity
public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
    {
        name = "Breathing Activity";
        description = "This activity will help you relax by guiding you through slow breathing.";
    }

    protected override void PerformActivity()
    {
        int interval = 5;
        int cycles = duration / (interval * 2);
        for (int i = 0; i < cycles; i++)
        {
            Console.Write("Breathe in... ");
            Countdown(interval);
            Console.Write("Breathe out... ");
            Countdown(interval);
        }
    }
}

// Reflection Activity
public class ReflectionActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What did you learn about yourself through this experience?"
    };

    public ReflectionActivity()
    {
        name = "Reflection Activity";
        description = "Reflect on moments of strength and resilience.";
    }

    protected override void PerformActivity()
    {
        var random = new Random();
        Console.WriteLine($"Prompt: {prompts[random.Next(prompts.Count)]}");
        ShowSpinner(3);

        int elapsed = 0;
        while (elapsed < duration)
        {
            Console.WriteLine(questions[random.Next(questions.Count)]);
            ShowSpinner(5);
            elapsed += 5;
        }
    }
}

// Listing Activity
public class ListingActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who have you helped this week?",
        "What blessings have you noticed today?"
    };

    public ListingActivity()
    {
        name = "Listing Activity";
        description = "List as many positive things as you can.";
    }

    protected override void PerformActivity()
    {
        var random = new Random();
        Console.WriteLine($"Prompt: {prompts[random.Next(prompts.Count)]}");
        Console.WriteLine("You may begin in:");
        Countdown(5);

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        int count = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }
        Console.WriteLine($"You listed {count} items!");
    }
}

// Program Entry
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program\nChoose an activity:");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Listing");
            Console.WriteLine("4. Quit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            MindfulnessActivity activity = null;
            switch (choice)
            {
                case "1": activity = new BreathingActivity(); break;
                case "2": activity = new ReflectionActivity(); break;
                case "3": activity = new ListingActivity(); break;
                case "4": return;
                default: Console.WriteLine("Invalid option."); Thread.Sleep(1000); continue;
            }

            activity.StartActivity();
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }
    }
}
