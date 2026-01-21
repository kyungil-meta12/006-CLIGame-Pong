using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong {
    public class WinnerScreen {
        private int winnerNumber;

        public WinnerScreen(int playerNumber) {
            this.winnerNumber = playerNumber;
        }

        public void Render() {
            var outline = Framework.outline;
            Framework.sUtil.RenderStringMiddleAligned(outline.centerX, outline.centerY, $"Player{winnerNumber} wins!");
            Framework.sUtil.RenderStringMiddleAligned(outline.centerX, outline.centerY + 1, "Press enter to go back to title.");
        }
    }
}
