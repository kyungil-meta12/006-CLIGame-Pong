namespace Pong {
    internal class Player {
        private int length;
        private int x, y;
        public int top, bottom;

        public Player(int x, int y, int length) {
            this.x = x;
            this.y = y;
            this.length = length;
            top = y - (length / 2);
            bottom = y + (length / 2);
        }

        public void Render() {
            Console.BackgroundColor = ConsoleColor.White;
            for (int i = 0; i < length; i++) {
                Console.SetCursorPosition(x, y - (length / 2) + i);
                Console.WriteLine("  ");
            }
            Console.ResetColor();
        }

        public void InputKey(ConsoleKey input) {
            if (input == ConsoleKey.DownArrow || input == ConsoleKey.Z)
                y += 1;
            else if (input == ConsoleKey.UpArrow || input == ConsoleKey.A)
                y -= 1;

            var outline = Framework.outline;

            y = Math.Clamp(y, outline.top + length / 2, outline.bottom - length / 2);
            top = y - (length / 2);
            bottom = y + (length / 2);
        }
    }
}
