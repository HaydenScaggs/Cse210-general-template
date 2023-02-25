//The class for the listing activity
public class ListingActivity : Activity
{
    // The list of prompts
    public List<string> Prompts { get; set; }

    // overridden implementation from base class
    public override void RunActivity()
    {
        // Show the starting message
        Console.WriteLine($"Starting {Name} which will last for {Duration} seconds.");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine("Prepare to begin...");

        // Pause for 5000 milisec or 5 seconds
        System.Threading.Thread.Sleep(5000);

        // Get a random prompt
        Random random = new Random();
        int promptIndex = random.Next(0, Prompts.Count - 1);
        Console.WriteLine(Prompts[promptIndex]);

        // Sleep Again
        System.Threading.Thread.Sleep(Duration * 1000);

        // Start Listing
        Console.WriteLine("Start listing...");
        int itemCount = 0;
        while (Duration > 0)
        {
            string input = Console.ReadLine();
            itemCount++;
            Duration--;
        }

        // Show the ending message
        Console.WriteLine("Good job!");
        Console.WriteLine($"You have completed the {Name} activity for {Duration} seconds and listed {itemCount} items.");
        Console.WriteLine("Thank you for participating.");
    }
}