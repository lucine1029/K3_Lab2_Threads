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
        public static async Task DriveAsync(Car car)
        {
            car.Status = "Running";// initial the car status
            await Console.Out.WriteLineAsync($"{car.Name} started");

            double goalDistance = 10;
            int eventCounter = 30;
            while (car.Distance < goalDistance)
            {
                eventCounter--;
                if (eventCounter == 0)  //car problem happens every 30 secs
                {
                    await Car.CarProblemAsync(car);
                    eventCounter = 30;
                    car.Status = "In problem";
                }
                car.Distance += car.Speed / 3600.0; //the distance will add up by every second here                                                  
                await Task.Delay(1000);  // This make sure that each task run almost every 1 second, not accurate but good enough
            }
 
            if (car.Distance >= goalDistance)
            {
                if (Program.Winner == 0)
                {
                    Program.Winner = car.Id;
                    lock (lockerObject)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Congratulations, {car.Name} has reached the end! you are the winner!");
                        Console.ResetColor();
                    }
                }
                else
                {
                    lock (lockerObject)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Congratulations! {car.Name} has reached the end!");
                        Console.ResetColor();
                    }
                }
                car.Status = "Finished"; 
                //Environment.Exit(0);
            }
        }
    }
}
