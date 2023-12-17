using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace K3_Lab2_Threads
{
    internal class Car
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public double Speed { get; set; }
        public double Distance { get; set; }
        public string Status { get; set; } //added status property to show see if car is running, finished or in trouble
        public Car(string name, int id) //Car constructure, we set the car's starting speed is 120km/h, start distance is 0 km
        {
            Name = name;
            Speed = 120;            
            Id = id;
            Distance = 0.0;
        }

        static object lockerObject = new object();
        public static async Task CarProblemAsync(Car car)
        {
            Random r = new Random();
            int randomNum = r.Next(1, 51);
            if (randomNum == 1) //Out of gas, stops 30 sec, 1/50 prob
            {
                lock (lockerObject)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"We got a problem! {car.Name} ran out of gas.");
                    Console.ResetColor();
                }
                await Task.Delay(30000);
            }
            else if (randomNum <= 3) //Puncture, stops 20 sec, 2/50 prob
            {
                lock (lockerObject)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"We got a problem! {car.Name} got punctured.");
                    Console.ResetColor();
                }
                await Task.Delay(20000);
            }
            else if (randomNum <= 8) //Bird on the windshield,stops 10 sec, 5/50 prob
            {
                lock (lockerObject)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"We got a problem! {car.Name} just had a bird poo attach!");
                    Console.ResetColor();
                }
                await Task.Delay(10000);
            }
            else if (randomNum <= 18) //Engine failure, speed reduce by 1km/h, 10/50 prob
            {
                lock (lockerObject)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"We got a problem! {car.Name}'s engine failed.");
                    Console.ResetColor();
                }
                car.Speed -= 10;
            }
        }
    }
}
