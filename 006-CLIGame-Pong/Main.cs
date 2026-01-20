using System;
using System.Timers;

namespace Pong {
    internal class MainLoop {
        public const int SPACE_WIDTH    = 42;
        public const int SPACE_HEIGHT   = 20;
        public const int TIMER_INTERVAL = 100;

        // outline renderer
        public static Outline outline;

        // title renderer
        private static Title title;

        // ball
        public static Ball ball;

        // if true program end
        static bool forceExit = false;

        static void Main(string[] args)  {
            while (true) {
                // render title
                title = new();
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
                System.Timers.Timer timer = new System.Timers.Timer(TIMER_INTERVAL);
                timer.AutoReset = true;
                timer.Enabled = true;
                timer.Elapsed += TimerCallback;

                // prepare ball
                ball = new Ball(SPACE_WIDTH, SPACE_HEIGHT / 2);
                outline = new(SPACE_WIDTH, SPACE_HEIGHT);

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
