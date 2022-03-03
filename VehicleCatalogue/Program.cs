using System;
using System.Linq;
using System.Collections.Generic;

namespace VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] vehicleInfo = input.Split().ToArray();

                string type = vehicleInfo[0];
                string model = vehicleInfo[1];
                string color = vehicleInfo[2];
                int horesepower = int.Parse(vehicleInfo[3]);

                Vehicle vehicle = new Vehicle(type, model, color, horesepower);
                vehicles.Add(vehicle);
            }

            while ((input = Console.ReadLine()) != "Close the Catalogue")
            {
                Vehicle selectedVehicle = vehicles.FirstOrDefault(x => x.Model == input);

                if (selectedVehicle != null)
                {
                    string vehicleType = string.Empty;
                    if (selectedVehicle.Type == "car")
                    {
                        vehicleType = "Car";
                    }
                    else
                    {
                        vehicleType = "Truck";
                    }

                    Console.WriteLine($"Type: {vehicleType}");
                    Console.WriteLine($"Model: {selectedVehicle.Model}");
                    Console.WriteLine($"Color: {selectedVehicle.Color}");
                    Console.WriteLine($"Horsepower: {selectedVehicle.Horsepower}");
                }
            }

            List<Vehicle> cars = vehicles.Where(x => x.Type == "car").ToList();
            List<Vehicle> trucks = vehicles.Where(x => x.Type == "truck").ToList();

            double averageCarHp = 0;
            if (cars.Count > 0)
            {
                averageCarHp = (cars.Sum(x => (double)x.Horsepower)) / cars.Count;
            }
            double averageTruckHp = 0;
            if (trucks.Count > 0)
            {
                averageTruckHp = (trucks.Sum(x => (double)x.Horsepower)) / trucks.Count;
            }

            Console.WriteLine($"Cars have average horsepower of: {averageCarHp:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {averageTruckHp:f2}.");
        }
    }

    public class Vehicle
    {
        public Vehicle(string type, string model, string color, int horsepower)
        {
            Type = type;
            Model = model;
            Color = color;
            Horsepower = horsepower;
        }
        
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }
    }
}
