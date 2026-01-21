using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong {
    public class StringUtil {
        // renders string at position with middle aligned
        public void RenderStringMiddleAligned(int x, int y, string str) {
            Console.SetCursorPosition(x - (str.Length / 2), y);
            Console.Write(str);
        }

        // renders string at position
        public void RenderString(int x, int y, string str) {
            Console.SetCursorPosition(x, y);
            Console.Write(str);
        }
    }
}
