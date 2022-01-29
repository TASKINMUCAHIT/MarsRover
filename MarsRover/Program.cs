using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {                  
                Console.WriteLine("Welcome To Planet of Mars!");
                // Mars Planet Coordinate Limits
                Console.WriteLine("Please declare maximum X coordinate - Example Input : 5");
                int maxX = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please declare maximum Y coordinate - Example Input : 5");
                int maxY = Convert.ToInt32(Console.ReadLine());

                // Mars Cover Vehicles Current Coordinate 
                Console.WriteLine("Please declare current location and direction Of Rover Vehicle First - Example Input : 1 2 N");
                var input1 = Console.ReadLine();
                List<List<char>> inputListofListChar = new List<List<char>>();
                inputListofListChar.Add(input1.Trim().Replace(" ", string.Empty).ToCharArray().ToList());
                Console.WriteLine("Please declare current location and direction Of Rover Vehicle Second - Example Input : 3 3 E");
                var input2 = Console.ReadLine();
                inputListofListChar.Add(input2.Trim().Replace(" ", string.Empty).ToCharArray().ToList());


                // Info Process 
                var planetMars = new PlanetMars();
                planetMars.MaxX = maxX;
                planetMars.MaxY = maxY;

                foreach (var listOfChar in inputListofListChar)
                {
                    planetMars.MarsRoverVehicles.Add(new MarsRoverVehicle(Convert.ToInt32(listOfChar[0].ToString()), Convert.ToInt32(listOfChar[1].ToString()), listOfChar[2].ToString()));
                }


                // Movement orders Set
                Console.WriteLine("Please enter movement orders for  first rover of mars - Example Input : LMLMLMLMM");
                var input3 = Console.ReadLine();
                planetMars.MarsRoverVehicles[0].OrdersForMove = input3.ToUpper().Trim().Replace(" ", string.Empty).ToCharArray().Where(x => (x.ToString() == "L" || x.ToString() == "R" || x.ToString() == "M")).ToList();
                
                Console.WriteLine("Please enter movement orders for  second rover of mars - Example Input : MMRMMRMRRM");
                var input4 = Console.ReadLine();
                planetMars.MarsRoverVehicles[1].OrdersForMove = input4.ToUpper().Trim().Replace(" ", string.Empty).ToCharArray().Where(x => (x.ToString() == "L" || x.ToString() == "R" || x.ToString() == "M")).ToList();

                foreach (var marsRoverVehicle in planetMars.MarsRoverVehicles)
                {
                    foreach (var orderforMove in marsRoverVehicle.OrdersForMove)
                    {
                        marsRoverVehicle.CalculateNewDirecton(orderforMove.ToString());
                    }
                }

                Console.WriteLine("---------------------------OUT PUT ------------------------");
                Console.WriteLine(planetMars.MarsRoverVehicles[0].CurrentPointX.ToString()+" " + planetMars.MarsRoverVehicles[0].CurrentPointY.ToString() +" " + planetMars.MarsRoverVehicles[0].CurrentDirection);
                Console.WriteLine(planetMars.MarsRoverVehicles[1].CurrentPointX.ToString()+" " + planetMars.MarsRoverVehicles[1].CurrentPointY.ToString() +" " + planetMars.MarsRoverVehicles[1].CurrentDirection);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Something is wrong,Please try again!" + "Technical Detail: " + ex.InnerException.Message);
            }

            for (int i = 10; i >= 1; i--)
            {
                Console.WriteLine("Kapanış için "+i +" saniye kaldı...");
                System.Threading.Thread.Sleep(1000);
            }
            Environment.Exit(0);
        }
    }
}
