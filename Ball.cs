namespace Pong {
    internal class Ball {
        public int x, y;

        int dirX, dirY;

        public Ball(int x, int y) {
            this.x = x;
            this.y = y;

            // random move dir
            Random random = new Random();
            int[] dirList = [-1, 1];
            dirX = dirList[random.Next(0, 2)];
            dirY = dirList[random.Next(0, 2)];
        }

        public void Update() {
            x += dirX * 2;
            y += dirY;

            if (x < MainLoop.outline.left) {
                x = MainLoop.outline.left;
                dirX *= -1;
                x += dirX * 2;
            }

            if (x > MainLoop.outline.right) {
                x = MainLoop.outline.right;
                dirX *= -1;
                x += dirX * 2;
            }

            if (y < MainLoop.outline.top) {
                y = MainLoop.outline.top;
                dirY *= -1;
                y += dirY;
            }

            if (y > MainLoop.outline.bottom) {
                y = MainLoop.outline.bottom;
                dirY *= -1;
                y += dirY;
            }
        }

        public void Render() {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("  ");
            Console.ResetColor();
        }
    }
}
