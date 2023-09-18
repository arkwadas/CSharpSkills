using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_v2_popawna
{
    abstract class Item
    {
        public int Height { get; protected set; } // dzięki private tych wartości nie możemy modyfikować np myLamp2.Height = 1; nie możemy tego zrobić
    }
}
