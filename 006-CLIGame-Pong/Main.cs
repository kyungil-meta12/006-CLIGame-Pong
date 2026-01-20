using System;
using System.Timers;

namespace Pong {
    internal class Framework {
        public const int SPACE_WIDTH    = 42;
        public const int SPACE_HEIGHT   = 20;
        public const int TIMER_INTERVAL = 100;

        // outline renderer
        public static Outline outline;

        // title renderer
        private static Title title;

        // ball
        public static Ball ball;

        // player
        public static Player p1;
        public static Player p2;

        // if true program end
        static bool forceExit = false;

        static void Main(string[] args)  {
            while (true) {
                // render title
                title = new();
                title.Render();

                while (true) {
                    var input = Console.ReadKey();

                    // game start
                    if (input.Key == ConsoleKey.Enter)
                        break;

                    // game exit
                    else if (input.Key == ConsoleKey.Escape) {
                        forceExit = true;
                        break;
                    }
                }
                
                // game exit
                if (forceExit)
                    break;

                // prepare timer
                var timer = new System.Timers.Timer(TIMER_INTERVAL);
                timer.AutoReset = true;
                timer.Enabled = true;
                timer.Elapsed += MainLoop;

                Console.Clear();

                // prepare ball
                ball = new Ball(SPACE_WIDTH, SPACE_HEIGHT / 2);

                // prepare outline
                outline = new(SPACE_WIDTH, SPACE_HEIGHT);
                outline.Render();

                // perpare players
                p1 = new(1, SPACE_HEIGHT / 2, 7);
                p2 = new(outline.right, SPACE_HEIGHT / 2, 7);

                while (true) {
                    var input = Console.ReadKey(true);

                    // exit to title
                    if (input.Key == ConsoleKey.Escape)
                        break;

                    // key input to p1
                    if (input.Key == ConsoleKey.A || input.Key == ConsoleKey.Z)
                        p1.InputKey(input.Key);

                    // key input to p2
                    if (input.Key == ConsoleKey.DownArrow || input.Key == ConsoleKey.UpArrow)
                        p2.InputKey(input.Key);
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
            string blankLine = new string(' ', SPACE_WIDTH * 2 + 2);
            for (int i = 0; i < SPACE_HEIGHT; i++) {
                Console.SetCursorPosition(1, 1 + i);
                Console.WriteLine(blankLine);
            }
            Console.SetCursorPosition(5, 1);
        }

        private static void MainLoop(Object source, ElapsedEventArgs e) {
            ball.Update();

            SwapBuffers();
            ball.Render();
            p1.Render();
            p2.Render();
        }
    }
}
