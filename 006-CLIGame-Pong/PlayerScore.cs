namespace Pong {
    public class PlayerScore {
        private readonly string[] eraser = {
            "       ",
            "       ",
            "       ",
            "       ",
            "       ",
        };

        private readonly string[] zero = {
            "■■■■■",
            "■   ■",
            "■   ■",
            "■   ■",
            "■■■■■"
        };

        private readonly string[] one = {
            " ■■  ",
            "  ■  ",
            "  ■  ",
            "  ■  ",
            " ■■■ "
        };

        private readonly string[] two = {
            "■■■■■",
            "    ■",
            "■■■■■",
            "■",
            "■■■■■"
        };

        private readonly string[] three = {
            "■■■■■",
            "    ■",
            "■■■■■",
            "    ■",
            "■■■■■"
        };

        private int score;
        private int prevScore;
        private int x, y;

        public PlayerScore(int x, int y, int playerNumber) {
            this.x = x;
            this.y = y;
            score = 0;
            prevScore = -1;
        }

        public void AddScore() {
            score++;
        }

        private void RenderNumber(int num) {
           
            string[] targetNumber;

            switch (num) {
            case 0: targetNumber = zero;   break;
            case 1: targetNumber = one;    break;
            case 2: targetNumber = two;    break;
            case 3: targetNumber = three;  break;
            default: return;
            }
            
            for (int i = 0; i < targetNumber.Length; i++) {
                Console.SetCursorPosition(x, y + i);
                Console.Write(targetNumber[i]);
            }
        }

        public void Render() {
            // render once when player score changed
            if (prevScore != score) {
                for (int i = 0; i < eraser.Length; i++) {
                    Console.SetCursorPosition(x, y + i);
                    Console.Write(eraser[i]);
                }

                RenderNumber(score);
                prevScore = score;
            }
        }

        public bool CheckWin() {
            return (score == 3); // returns true if score is 3 and ends game
        }
    }
}
