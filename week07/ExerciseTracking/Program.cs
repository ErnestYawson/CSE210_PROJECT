using System;
using System.Collections.Generic;

abstract class Activity
{
    private DateTime date;
    private int minutes;

    public Activity(DateTime date, int minutes)
    {
        this.date = date;
        this.minutes = minutes;
    }

    public DateTime Date { get { return date; } }
    public int Minutes { get { return minutes; } }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return string.Format("{0} {1} ({2} min): Distance {3:F2} km, Speed {4:F2} kph, Pace: {5:F2} min per km",
                             Date.ToString("dd MMM yyyy"),
                             this.GetType().Name,
                             Minutes,
                             GetDistance(),
                             GetSpeed(),
                             GetPace());
    }
}

class Running : Activity
{
    private double distance; // in km

    public Running(DateTime date, int minutes, double distance)
        : base(date, minutes)
    {
        this.distance = distance;
    }

    public override double GetDistance() => distance;
    public override double GetSpeed() => (distance / Minutes) * 60;
    public override double GetPace() => Minutes / distance;
}

class Cycling : Activity
{
    private double speed; // in kph

    public Cycling(DateTime date, int minutes, double speed)
        : base(date, minutes)
    {
        this.speed = speed;
    }

    public override double GetDistance() => (speed * Minutes) / 60;
    public override double GetSpeed() => speed;
    public override double GetPace() => 60 / speed;
}

class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        this.laps = laps;
    }

    public override double GetDistance() => (laps * 50.0) / 1000.0; // distance in km
    public override double GetSpeed() => (GetDistance() / Minutes) * 60;
    public override double GetPace() => Minutes / GetDistance();
}

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2025, 6, 20), 30, 4.8), // 4.8 km in 30 mins
            new Cycling(new DateTime(2025, 6, 20), 45, 20.0), // 20 kph for 45 mins
            new Swimming(new DateTime(2025, 6, 20), 25, 40) // 40 laps in 25 mins
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}

