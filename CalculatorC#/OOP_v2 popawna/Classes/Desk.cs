using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_v2_popawna
{
    class Desk : Item
    {
        private int Width { get; set; }

        public Desk(int height, int width)
        {
            Height = height;
            Width = width;
        }

    }
}
