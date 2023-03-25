class Apple : IRenderable
{
    public Apple(Position position)
    {
        Position = position;
    }

    public Position Position { get; }

    public void Render()//Cursor must stay within console or error.
    {
        Console.SetCursorPosition(Position.Left, Position.Top);
        Console.Write("X");
    }
}