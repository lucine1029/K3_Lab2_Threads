using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K3_Lab2_Threads
{
    internal class Winner
    {
        public static int winner { get; set; }  // create a shared variable winner, need to use lock in the task

        public static void AddCarPlaceList(Car car, List<Car> carPlaceList) //create a method to add the car to the list when it reaches the end
        {
            carPlaceList.Add(car);
        }
    }
}
