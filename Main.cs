using System;
using System.Timers;

namespace Pong {
    internal class MainLoop {
        // outline renderer
        public static Outline outline = new(42, 20);

        // title renderer
        private static Title title = new();

        // ball
        public static Ball ball;

        // if true program end
        static bool forceExit = false;

        static void Main(string[] args)  {
            while (true) {
                // render title
                title.Render();

                // start the game if enter input
                // exit the game if esc input
                while (true) {
                    var input = Console.ReadKey();
                    if (input.Key == ConsoleKey.Enter)
                        break;
                    else if (input.Key == ConsoleKey.Escape) {
                        forceExit = true;
                        break;
                    }
                }

                if (forceExit)
                    break;

                // prepare timer
                System.Timers.Timer timer = new System.Timers.Timer(100);
                timer.AutoReset = true;
                timer.Enabled = true;
                timer.Elapsed += TimerCallback;

                // prepare ball
                ball = new Ball((outline.right - outline.left) / 2, (outline.bottom - outline.top) / 2);

                // exit the game if esc input
                while (true) {
                    var input = Console.ReadKey();
                    if (input.Key == ConsoleKey.Escape)
                        break;
                }

                // stop programm
                timer.Stop();
                timer.Dispose();
                Console.Clear();
            }

            // render stop message
            Console.Clear();
            Console.WriteLine("Stop run.");
        }

        private static void TimerCallback(Object source, ElapsedEventArgs e) {
            ball.Update();

            Console.Clear();
            outline.Render();
            ball.Render();
        }
    }
}
