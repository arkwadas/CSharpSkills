using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_v2_popawna
{
    class FileManager : IManager
    {
        public void SaveLamp(Lamp lamp)
        {
            var path = "lamps.txt";
            var content = "Lampa: " + "Wysokość - " + lamp.Height + " Moc - " + lamp.Power;
            File.WriteAllText(path, content);
        }

    }
}
