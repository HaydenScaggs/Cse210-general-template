// The class for the breathing activity
public class BreathingActivity : Activity
{
    // Override the RunActivity method from the base class
    public override void RunActivity()
    {
        // Show the starting message
        Console.WriteLine($"Starting {Name} which will last for {Duration} seconds.");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine("Prepare to begin...");

        // Pause for a few seconds
        System.Threading.Thread.Sleep(3000);

        // Start the activity
        Console.WriteLine("Breathe in...");
        System.Threading.Thread.Sleep(Duration * 1000);
        Console.WriteLine("Breathe out...");
        System.Threading.Thread.Sleep(Duration * 1000);

        // Show the ending message
        Console.WriteLine("Good job!");
        Console.WriteLine($"You have completed the {Name} activity for {Duration} seconds.");
        Console.WriteLine("Thank you for participating.");
    }
}