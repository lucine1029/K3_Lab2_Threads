using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.ConstrainedExecution;

namespace K3_Lab2_Threads
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            object lockerObject = new object();
            //create 4 car objects
            Car car1 = new Car("Red_Chilly", 1);
            Car car2 = new Car("Blue_Cheese", 2);
            Car car3 = new Car("Golden_Orange", 3);
            Car car4 = new Car("Dark_Sky", 4);
            //create the carPlaceList, so we can add a car to the list when the car reach the end
            List<Car> carPlaceList = new List<Car>();

            // create 4 tasks for these 4 cars, so they are runing on own tread
            Task task1 = Task.Run(async () => await Race.DriveAsync(car1, carPlaceList));
            Task task2 = Task.Run(async () => await Race.DriveAsync(car2, carPlaceList));
            Task task3 = Task.Run(async () => await Race.DriveAsync(car3, carPlaceList));
            Task task4 = Task.Run(async () => await Race.DriveAsync(car4, carPlaceList));
            await Console.Out.WriteLineAsync("The competition has started!");
            await Console.Out.WriteLineAsync();

            //in the main thread, check car status when press[enter]
            bool status = true;
            while (status)
            {
                lock (lockerObject)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Please press [enter] to check the status of the competition: ");
                    Console.ResetColor();
                }
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    lock (lockerObject)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Status of the competition: ");
                        Console.WriteLine($"{car1.Name,-15}: {car1.Distance.ToString("0.00"),-6} km \t>>>> Speed: {car1.Speed,-6} km/h, \t>>>> car is {car1.Status}.");
                        Console.WriteLine($"{car2.Name,-15}: {car2.Distance.ToString("0.00"),-6} km \t>>>> Speed: {car2.Speed,-6} km/h, \t>>>> car is {car2.Status}.");
                        Console.WriteLine($"{car3.Name,-15}: {car3.Distance.ToString("0.00"),-6} km \t>>>> Speed: {car3.Speed,-6} km/h, \t>>>> car is {car3.Status}.");
                        Console.WriteLine($"{car4.Name,-15}: {car4.Distance.ToString("0.00"),-6} km \t>>>> Speed: {car4.Speed,-6} km/h, \t>>>> car is {car4.Status}.");
                        Console.WriteLine();
                        Console.ResetColor();
                    }
                    //when all cars reach the end, the competition ends
                    if (car1.Status == "Finished" && car2.Status == "Finished" && car3.Status == "Finished" && car4.Status == "Finished")
                    {
                        await Console.Out.WriteLineAsync($"The competition has finished now.");
                        Thread.Sleep(3000);
                        await Console.Out.WriteLineAsync($"{car1.Name} is Number {carPlaceList.IndexOf(car1) + 1}");
                        await Console.Out.WriteLineAsync($"{car2.Name} is Number {carPlaceList.IndexOf(car2) + 1}");
                        await Console.Out.WriteLineAsync($"{car3.Name} is Number {carPlaceList.IndexOf(car3) + 1}");
                        await Console.Out.WriteLineAsync($"{car4.Name} is Number {carPlaceList.IndexOf(car4) + 1}");
                        await Console.Out.WriteLineAsync("BYE~~~~~~~~~~~~");
                        status = false;
                        Environment.Exit(0);
                    }
                }
            }

            ////wait for all the tasks to complete or cancael
            //try
            //{
            //    Task.WaitAll(task1, task2, task3, task4);
            //    await Console.Out.WriteLineAsync($"The competition has finished now.");
            //}
            //catch (AggregateException e)
            //{
            //    e.Handle(e => e is OperationCanceledException);
            //}
        }
    }
}