// The class for the reflection activity
public class ReflectionActivity : Activity
{
    // The list of prompts
    public List<string> Prompts { get; set; }

    // The list of questions
    public List<string> Questions { get; set; }

    // Override the RunActivity method from the base class
    public override void RunActivity()
    {
        // Show the starting message
        Console.WriteLine($"Starting {Name} which will last for {Duration} seconds.");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine("Prepare to begin...");

        // Pause for a few seconds
        System.Threading.Thread.Sleep(3000);

        // Get a random prompt
        Random random = new Random();
        int promptIndex = random.Next(0, Prompts.Count - 1);
        Console.WriteLine(Prompts[promptIndex]);

        // Ask the questions
        for (int i = 0; i < Questions.Count; i++)
        {
            Console.WriteLine(Questions[i]);
            System.Threading.Thread.Sleep(Duration * 1000);

            // Show a spinner while the program is paused
            Console.CursorLeft = 0;
            Console.Write("-");
            System.Threading.Thread.Sleep(900);
            Console.CursorLeft = 0;
            Console.Write("/");
            System.Threading.Thread.Sleep(900);
            Console.CursorLeft = 0;
            Console.Write("-");
            System.Threading.Thread.Sleep(900);
            Console.CursorLeft = 0;
            Console.Write("\\");
            System.Threading.Thread.Sleep(900);
        }

        // Show the ending message
        Console.WriteLine("Good job!");
        Console.WriteLine($"You have completed the {Name} activity for {Duration} seconds.");
        Console.WriteLine("Thank you for participating.");
    }
}