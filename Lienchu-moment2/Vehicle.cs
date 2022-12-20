using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LienChuHuangMoment2
{

    // Create a class to define Vehicles' data type.
    internal class Vehicle
    {
        public string make;
        public string model;
        public string year;
        public string color;
        public string id;
        public int cost { get; private set; }
        public int price { get; set; }

 
        // Create a static data type 
        public static int vehicleCount = 0;

        // Create 2 static data type constructor for counting vehicles
        public static int AddCount()
        {
            return ++vehicleCount;
        }
        public static int RemoveCount()
        {
            return --vehicleCount;
        }

        public static int indexOFMakeId()
        {
            return AddCount();
        }

        // Create a constructor with the same name as its class.
        public Vehicle(string id, string make, string model, string color, string year)
        {
            this.id = id;
            this.make = make;
            this.model = model;
            this.color = color;
            this.year = year;
            AddCount();
        }

        // Create an other constructor with the same name but different arguments.
        public Vehicle(string id, string make, string model, string color, string year, int price)
        {
            this.id = id;
            this.make = make;
            this.model = model;
            this.color = color;
            this.year = year;
            this.cost = (int)(price / 1.15);
            this.price = price;
        }
    }
}
