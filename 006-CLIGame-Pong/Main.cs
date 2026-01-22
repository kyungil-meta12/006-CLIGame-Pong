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

        // player score
        public static PlayerScore p1Score;
        public static PlayerScore p2Score;

        // winner screen
        public static WinnerScreen winnerScreen;

        // string render util
        public static StringUtil sUtil = new();

        // if true program end
        private static bool forceExit = false;

        // if true game end
        private static bool gameEnd = false;

        private static readonly string[] colon = {
            "     ",
            "  ■  ",
            "     ",
            "  ■  ",
            "     "
        };

        private static readonly string[] p1str = {
            "■■■■■■   ■■",
            "■    ■    ■",
            "■■■■■■    ■",
            "■         ■",
            "■        ■■■"
        };

        private static readonly string[] p2str = {
            "■■■■■■  ■■■■■",
            "■    ■      ■",
            "■■■■■■  ■■■■■",
            "■       ■",
            "■       ■■■■■"
        };



        private static int colonX = 0;
        private static int colonY = 0;

        static void Main(string[] args)  {
            // clear console first
            while (true) {
                Console.Clear();

                // game end state init
                gameEnd = false;

                // render title
                title = new();
                title.Render();

                while (true) {
                    var input = Console.ReadKey(true);

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

                // prepare player scores
                p1Score = new(25, outline.bottom + 2, 1);
                p2Score = new(outline.right - 28, outline.bottom + 2, 2);

                // prepare colon and player str
                colonX = ((outline.right - 28) + 25) / 2;
                colonY = outline.bottom + 2;

                // render colon
                Console.SetCursorPosition(colonX, colonY);
                for (int i = 0; i < colon.Length; i++) {
                    Console.SetCursorPosition(colonX, colonY + i);
                    Console.Write(colon[i]);
                }

                // render p1 str
                Console.SetCursorPosition(0, colonY);
                for (int i = 0; i < p1str.Length; i++) {
                    Console.SetCursorPosition(0, colonY + i);
                    Console.Write(p1str[i]);
                }

                // render p2 str
                Console.SetCursorPosition(outline.right - 11, colonY);
                for (int i = 0; i < p2str.Length; i++) {
                    Console.SetCursorPosition(outline.right - 11, colonY + i);
                    Console.Write(p2str[i]);
                }

                while (true) {
                    var input = Console.ReadKey(true);

                    // exit to title
                    if (input.Key == ConsoleKey.Escape)
                        break;

                    if (!gameEnd) {
                        // key input to p1
                        if (input.Key == ConsoleKey.A || input.Key == ConsoleKey.Z)
                            p1.InputKey(input.Key);

                        // key input to p2
                        if (input.Key == ConsoleKey.DownArrow || input.Key == ConsoleKey.UpArrow)
                            p2.InputKey(input.Key);
                    }

                    else {
                        // when game end input enter to exit to title
                        if (input.Key == ConsoleKey.Enter) {
                            gameEnd = false;
                            break;
                        }
                    }
                }

                // stop programm
                timer.Stop();
                timer.Dispose();
                Console.Clear();
            }

            // game stop message
            Console.Clear();
            Console.WriteLine("Stop run.");
        }

        // clears console with less-flickering operation
        private static void ClearBuffer() {
            string blankLine = new string(' ', SPACE_WIDTH * 2 + 2);
            for (int i = 0; i < SPACE_HEIGHT; i++) {
                Console.SetCursorPosition(1, 1 + i);
                Console.WriteLine(blankLine);
            }
            Console.SetCursorPosition(5, 1);
        }

        private static void MainLoop(Object source, ElapsedEventArgs e) {
            if (!gameEnd)
                ball.Update();

            // if any player gets score 3 then game ends
            if (p1Score.CheckWin()) {
                gameEnd = true;
                winnerScreen = new(1);
            }
            else if (p2Score.CheckWin()) {
                gameEnd = true;
                winnerScreen = new(2);
            }

            ClearBuffer();

            if(!gameEnd)
                ball.Render();

            p1.Render();
            p2.Render();

            p1Score.Render();
            p2Score.Render();

            if (gameEnd)
                winnerScreen.Render();
        }
    }
}
