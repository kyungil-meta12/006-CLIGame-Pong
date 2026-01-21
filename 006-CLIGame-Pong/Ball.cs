namespace Pong {
    internal class Ball {
        private int initialX, initialY;
        private int x, y;
        private int dirX, dirY;

        public Ball(int x, int y) {
            this.x = x;
            this.y = y;
            initialX = x;
            initialY = y;

            // random move dir
            Random random = new Random();
            int[] dirList = [-1, 1];
            dirX = dirList[random.Next(0, 2)];
            dirY = dirList[random.Next(0, 2)];
        }

        private void ResetBallState() {
            x = initialX;
            y = initialY;
            Random random = new Random();
            int[] dirList = [-1, 1];
            dirX = dirList[random.Next(0, 2)];
            dirY = dirList[random.Next(0, 2)];
        }

        public void Update() {
            x += dirX * 2;
            y += dirY;

            var outline = Framework.outline;
            var p1 = Framework.p1;
            var p2 = Framework.p2;

            // p1 collide
            if (x < outline.left + 2 && p1.top <= y && y <= p1.bottom) {
                x = outline.left + 2;
                dirX *= -1;
                x += dirX * 2;
            }

            // left wall collide // p2 wins // reset ball position // reset ball state
            else if (x < outline.left) {
                x = outline.left;
                dirX *= -1;
                x += dirX * 2;
                Framework.p2Score.AddScore();
                ResetBallState();
            }

            // p2 collide
            if (x > outline.right - 2 && p2.top <= y && y <= p2.bottom) {
                x = outline.right - 2;
                dirX *= -1;
                x += dirX * 2;
            }

            // right wall collide // p1 wins // reset ball position // reset ball state
            else if (x > outline.right) {
                x = outline.right;
                dirX *= -1;
                x += dirX * 2;
                Framework.p1Score.AddScore();
                ResetBallState();
            }

            // top wall collide
            if (y < outline.top) {
                y = outline.top;
                dirY *= -1;
                y += dirY;
            }

            // bottom wall collide
            if (y > outline.bottom) {
                y = outline.bottom;
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
