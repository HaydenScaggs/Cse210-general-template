using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public static class Program
{
    public static async Task Main(string[] args)
    {
          // Set the rate at which the game updates and initialize a new SnakeGame object.
        var tickRate = TimeSpan.FromMilliseconds(150);
        var snakeGame = new SnakeGame();

          // Create a cancellation token source to signal when the user cancels the game.
        using (var cts = new CancellationTokenSource())
        {
              // Define a task that monitors the console input for key presses and updates the SnakeGame object accordingly.
            async Task MonitorKeyPresses()
            {
                while (!cts.Token.IsCancellationRequested)
                {
                    if (Console.KeyAvailable)
                    {
                        var key = Console.ReadKey(intercept: true).Key;
                        snakeGame.OnKeyPress(key);
                    }
                    
                    // Delay for a short time to avoid constantly polling the console input.
                    await Task.Delay(10);
                }
            }

              // Start the key press monitoring task.
            var monitorKeyPresses = MonitorKeyPresses();

               // Start the game loop.
            do
            {
                // Update the game state, render the game board, and wait for the specified tick rate.
                snakeGame.OnGameTick();
                snakeGame.OnGameTick();
                snakeGame.Render();
                await Task.Delay(tickRate);
            } while (!snakeGame.GameOver);

             // Flash the game board three times to indicate the end of the game.
            for (var i = 0; i < 3; i++)
            {
                Console.Clear();
                await Task.Delay(500);
                snakeGame.Render();
                await Task.Delay(500);
            }
            // Cancel the key press monitoring task and wait for it to complete.
            cts.Cancel();
            await monitorKeyPresses;
        }
    }
}