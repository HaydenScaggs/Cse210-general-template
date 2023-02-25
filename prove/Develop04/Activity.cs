// The base class for all activities
public abstract class Activity
{
    // The name of the activity
    public string Name { get; set; }//get and set  name

    // The description of the activity
    public string Description { get; set; }

    // The duration of the activity in seconds
    public int Duration { get; set; }//get the duration and set

    // The method to run the activity
    public abstract void RunActivity(); //Publi
}