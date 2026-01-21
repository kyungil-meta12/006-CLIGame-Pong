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
            // middle align
            var outline = Framework.outline;
            var winStr = $"Player{winnerNumber} wins!";
            var winStrOffset = winStr.Length / 2;
            var backStr = "Press enter to go back to title.";
            var backStrOffset = backStr.Length / 2;
            Console.SetCursorPosition((outline.right - outline.left) / 2 - winStrOffset, (outline.bottom - outline.top) / 2);
            Console.WriteLine($"Player{winnerNumber} wins!");
            Console.SetCursorPosition((outline.right - outline.left) / 2 - backStrOffset, (outline.bottom - outline.top) / 2 + 1);
            Console.WriteLine("Press enter to go back to title.");
        }
    }
}
