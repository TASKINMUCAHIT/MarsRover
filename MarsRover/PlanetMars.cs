using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class PlanetMars
    {
        public PlanetMars()
        {
            MarsRoverVehicles = new List<MarsRoverVehicle>();
        }
        public const int MinX = 0;
        public const int MinY = 0;

        public int MaxX { get; set; }
        public int MaxY { get; set; }
     
        public List<MarsRoverVehicle> MarsRoverVehicles { get; set; }
    }
}
