using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace K3_Lab2_Threads
{
    internal class Race
    {
        static object lockerObject = new object();
        public static async Task DriveAsync(Car car, List<Car> carPlaceList)
        {
            car.Status = "Running";// initial the car status
            double goalDistance = 10;
            int eventCounter = 30;
            while (car.Distance < goalDistance)
            {
                eventCounter--;
                if (eventCounter == 0)  //car problem happens every 30 secs
                {
                    car.Status = "In problem";
                    await Car.CarProblemAsync(car);
                    eventCounter = 30;
                }
                car.Distance += car.Speed / 3600.0; //the distance will add up by every second here                                                  
                await Task.Delay(1000);  // This make sure that each task run almost every 1 second, not accurate but good enough
            }

            if (car.Distance >= goalDistance)
            {
                lock (lockerObject)
                {
                    Winner.AddCarPlaceList(car, carPlaceList); //when the car reaches the end, call AddCarPlaceList() to add it to the List

                    if (Winner.winner == 0)
                    {
                        Winner.winner = car.Id;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Congratulations, {car.Name} has reached the end! You are the winner!");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Congratulations! {car.Name} has reached the end!");
                        Console.ResetColor();
                        if(carPlaceList.Count == 4) 
                        {
                            Console.WriteLine();
                            Console.WriteLine("The competition has finished now, please press [Enter] to see the Place List!");
                        }
                    }
                }
                car.Status = "Finished";
            }
        }
    }
}
