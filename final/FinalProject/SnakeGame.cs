class SnakeGame : IRenderable
{
    private static readonly Position Origin = new Position(0, 0);

    private Direction _currentDirection;
    private Direction _nextDirection;
    private Snake _snake;
    private Apple _apple;

    public SnakeGame()
    {
        _snake = new Snake(Origin, initialSize: 5);
        _apple = CreateApple();
        _currentDirection = Direction.Right;
        _nextDirection = Direction.Right;
    }

    public bool GameOver => _snake.Dead;

    public void OnKeyPress(ConsoleKey key)
    {
        Direction newDirection;

        switch (key)
        {
            case ConsoleKey.W:
                newDirection = Direction.Up;
                break;

            case ConsoleKey.A:
                newDirection = Direction.Left;
                break;

            case ConsoleKey.S:
                newDirection = Direction.Down;
                break;

            case ConsoleKey.D:
                newDirection = Direction.Right;
                break;

            default:
                return;
        }

        
        if (newDirection == OppositeDirectionTo(_currentDirection))
        {//Logic for certain directions
            return;
        }

        _nextDirection = newDirection;
    }

    public void OnGameTick()
    {
        if (GameOver) throw new InvalidOperationException();

        _currentDirection = _nextDirection;
        _snake.Move(_currentDirection);

        // Logic for if position occupies same space eat
        if (_snake.Head.Equals(_apple.Position))
        {
            _snake.Grow();
            _apple = CreateApple();
        }
    }

    public void Render()
    {
        Console.Clear();
        _snake.Render();
        _apple.Render();
        Console.SetCursorPosition(0, 0);
    }

    private static Direction OppositeDirectionTo(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up: return Direction.Down;
            case Direction.Left: return Direction.Right;
            case Direction.Right: return Direction.Left;
            case Direction.Down: return Direction.Up;
            default: throw new ArgumentOutOfRangeException();
        }
    }

    private static Apple CreateApple()//Grid Grid   maybe use public class grid  getters and setters
    {
        //Yes, the constants numberOfRows and numberOfColumns can be factored out into a separate class or configuration file to make the code more maintainable and flexible.
        const int numberOfRows = 20;
        const int numberOfColumns = 20;

        var random = new Random();
        var top = random.Next(0, numberOfRows + 1);
        var left = random.Next(0, numberOfColumns + 1);
        var position = new Position(top, left);
        var apple = new Apple(position);

        return apple;
    }
}