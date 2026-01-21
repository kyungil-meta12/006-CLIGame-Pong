using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong {
    internal class WinnerScreen {
        private int winnerNumber;

        public WinnerScreen(int playerNumber) {
            this.winnerNumber = playerNumber;
        }

        public void Render() {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Player {winnerNumber} wins!\n");
            Console.WriteLine("Press enter to go back to title.");
        }
    }
}
