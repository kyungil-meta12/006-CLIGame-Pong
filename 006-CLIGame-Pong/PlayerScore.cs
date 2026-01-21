using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong {
    public class PlayerScore {
        private int score;
        private int x, y;
        private int playerNumber;

        public PlayerScore(int x, int y, int playerNumber) {
            this.x = x;
            this.y = y;
            score = 0;
            this.playerNumber = playerNumber;
        }

        public void AddScore() {
            score++;
        }

        public void Render() {
            Framework.sUtil.RenderString(x, y, $"Player{playerNumber} Score: {score}");
        }

        public bool CheckWin() {
            return (score == 3); // returns true if score is 3 and ends game
        }
    }
}
