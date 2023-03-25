class Snake : IRenderable
{
    private List<Position> _body;
    private int _growthSpurtsRemaining;

    public Snake(Position spawnLocation, int initialSize = 1)
    {
        _body = new List<Position> { spawnLocation };
        _growthSpurtsRemaining = Math.Max(0, initialSize - 1);
        Dead = false;
    }

    public bool Dead { get; private set; }
    public Position Head => _body.First();
    private IEnumerable<Position> Body => _body.Skip(1);

    public void Move(Direction direction)
    {
        
    }

    public void Grow()
    {

    }

    public void Render()
    {
        Console.SetCursorPosition(Head.Left, Head.Top);
        Console.Write("0");

        foreach (var position in Body)
        {
            Console.SetCursorPosition(position.Left, position.Top);
            Console.Write("■");
        }
    }

    private static bool PositionIsValid(Position position) =>
        position.Top >= 0 && position.Left >= 0;
}