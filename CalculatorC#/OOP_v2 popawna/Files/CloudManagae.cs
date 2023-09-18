using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_v2_popawna
{
    internal class CloudManagae : IManager // interface jest implementowany, klasa możę być tylko jedna i dziedziczona, ale za to moze byc nieskonczenie wiele interface np : class, intrfasce1, intrface2
    {
        public void SaveLamp(Lamp lamp)
        {
            // nalezy stworzyc implementacje zapisu do chmury
        }
    }
}
