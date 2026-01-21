namespace Pong {
    public class Outline {
        private readonly int width, height;

        public int left, right;
        public int bottom, top;
        public int centerX, centerY;

        public Outline(int width, int height) {
            this.width = width;
            this.height = height;

            // set map clamp range
            left = 1;
            top = 1;
            right = width * 2 + 1;
            bottom = height;
            centerX = (right - left) / 2;
            centerY = (bottom - top) / 2; 

            Console.CursorVisible = false;
        }

        public void Render() {
            Console.SetCursorPosition(0, 0);

            //////////// upside
            Console.Write("┌─");
            for (int i = 0; i < width; i++)
                Console.Write("──");
            Console.WriteLine("─┐");

            //////////// middle line
            for (int i = 0; i < height; i++) {
                Console.Write("│ ");
                Console.SetCursorPosition(width * 2 + 2, i + 1);
                Console.WriteLine(" │");
            }

            //////////// downside
            Console.Write("└─");
            for (int i = 0; i < width; i++)
                Console.Write("──");
            Console.WriteLine("─┘");
        }
    }
}
