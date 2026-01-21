using System;
using System.Text;

namespace Pong {
    internal class Title {
        private static readonly string[] P = {
            "■■■■",
            "■  ■",
            "■■■■",
            "■   ",
            "■   "
        };

        private static readonly string[] O = {
            "■■■■",
            "■  ■",
            "■  ■",
            "■  ■",
            "■■■■"
        };

        private static readonly string[] N = {
            "■  ■",
            "■■ ■",
            "■ ■■",
            "■  ■",
            "■  ■"
        };

        private static readonly string[] G = {
            "■■■■",
            "■   ",
            "■ ■■",
            "■  ■",
            "■■■■"
        };

        private static string ScaleRowHorizontally(string originalRow, int horizontalScale) {
            StringBuilder scaledRowBuilder = new StringBuilder();
            foreach (char c in originalRow) {
                for (int k = 0; k < horizontalScale; k++) {
                    scaledRowBuilder.Append(c);
                }
            }
            return scaledRowBuilder.ToString();
        }

        public void Render() {
            int height = P.Length;
            int baseSpacing = 2;
            int scaleFactor = 4;

            int scaledSpacing = baseSpacing * scaleFactor;

            Console.WriteLine();

            for (int i = 0; i < height; i++) {
                string scaledPRow = ScaleRowHorizontally(P[i], scaleFactor);
                string scaledORow = ScaleRowHorizontally(O[i], scaleFactor);
                string scaledNRow = ScaleRowHorizontally(N[i], scaleFactor);
                string scaledGRow = ScaleRowHorizontally(G[i], scaleFactor);

                string combinedScaledLine =
                    scaledPRow + new string(' ', scaledSpacing) +
                    scaledORow + new string(' ', scaledSpacing) +
                    scaledNRow + new string(' ', scaledSpacing) +
                    scaledGRow;

                for (int j = 0; j < scaleFactor; j++) 
                    Console.WriteLine(combinedScaledLine);
            }

            var str = "Press Enter to start";
            var offset = str.Length / 2;
            Console.SetCursorPosition(Framework.SPACE_WIDTH - offset, Framework.SPACE_HEIGHT + 2);
            Console.WriteLine("Press Enter to start");
        }
    }
}