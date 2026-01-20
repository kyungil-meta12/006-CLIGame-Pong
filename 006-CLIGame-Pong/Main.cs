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
                var timer = new System.Timers.Timer(TIMER_INTERVAL);
                timer.AutoReset = true;
                timer.Enabled = true;
                timer.Elapsed += TimerCallback;

                Console.Clear();

                // prepare ball
                ball = new Ball(SPACE_WIDTH, SPACE_HEIGHT / 2);

                // prepare outline
                outline = new(SPACE_WIDTH, SPACE_HEIGHT);
                outline.Render();

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

        private static void SwapBuffers() {
            string blankLine = new string(' ', SPACE_WIDTH * 2 + 1);
            for (int i = 0; i < SPACE_HEIGHT; i++) {
                Console.SetCursorPosition(1, 1 + i);
                Console.WriteLine(blankLine);
            }
            Console.SetCursorPosition(5, 1);
        }

        private static void TimerCallback(Object source, ElapsedEventArgs e) {
            ball.Update();

            SwapBuffers();
            ball.Render();
        }
    }
}
