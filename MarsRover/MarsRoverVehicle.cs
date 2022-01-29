using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{

    public class MarsRoverVehicle
    {
        public MarsRoverVehicle(int currentPointX, int currentPointY, string currentDirection)
        {
            CurrentPointX = currentPointX;
            CurrentPointY = currentPointY;
            CurrentDirection = currentDirection;
            DictionaryDirections = new Dictionary<string, int>();
            DictionaryDirections.Add("N", 0); //North
            DictionaryDirections.Add("W", 90);  //West
            DictionaryDirections.Add("S", 180);  //South
            DictionaryDirections.Add("E", 270); //East
        }

        public int CurrentPointX { get; set; }
        public int CurrentPointY { get; set; }
        public string CurrentDirection { get; set; }
        public List<char> OrdersForMove { get; set; }
        protected IDictionary<string, int> DictionaryDirections { get; set; }

        public void CalculateNewDirecton(string codeforMove)
        {
            var angleofDirection = DictionaryDirections.Where(x => x.Key == CurrentDirection).FirstOrDefault().Value;

            if (codeforMove == "L")
            {
                if (angleofDirection == 0)
                {
                    angleofDirection = 360;
                }
                angleofDirection -= 90;
                if (angleofDirection == 360)
                {
                    angleofDirection = 0;
                }
                CurrentDirection = DictionaryDirections.Where(x => x.Value == angleofDirection).FirstOrDefault().Key;
            }

            if (codeforMove == "R")
            {
                angleofDirection += 90;
                if (angleofDirection == 360)
                {
                    angleofDirection = 0;
                }
                CurrentDirection = DictionaryDirections.Where(x => x.Value == angleofDirection).FirstOrDefault().Key;
            }

            if (codeforMove == "M")
            {
                switch (CurrentDirection)
                {
                    case "N":
                        CurrentPointY += 1;
                        break;
                    case "W":
                        CurrentPointX += 1;
                        break;
                    case "S":
                        CurrentPointY -= 1;
                        break;
                    case "E":
                        CurrentPointX -= 1;
                        break;
                    default:
                        break;
                }
            }
        }

    }


}
