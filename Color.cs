using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DiscordAPI
{
    public struct Color
    {
        public int r;
        public int g;
        public int b;

        private int int_hex;

        public Color(int int_hex)
        {
            this.int_hex = int_hex;

            r = (int_hex >> 16) & 0xff;
            g = (int_hex >> 8) & 0xff;
            b = int_hex & 0xff;
        }

        public Color(int r, int g, int b)
        {
            r = Math.Clamp(r, 0, 255);
            g = Math.Clamp(g, 0, 255);
            b = Math.Clamp(b, 0, 255);

            int_hex = (r << 16) + (g << 8) + b;

            this.r = r;
            this.g = g;
            this.b = b;
        }

        /// <summary>
        /// returns integer representation of hexadecimal color code
        /// </summary>
        /// <returns></returns>
        public int GetInt()
        {
            return int_hex;
        }
    }
}
