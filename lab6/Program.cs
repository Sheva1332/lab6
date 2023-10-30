using System;
using System.Collections.Generic;

public abstract class Vehicle
{
    public double Speed { get; set; }
    public int Capacity { get; set; }

    public abstract void Move();
}

public class Human
{
    public double Speed { get; set; }

    public void Move()
    {
        Console.WriteLine("Human is moving.");
    }
}

public class Car : Vehicle
{
    public Car()
    {
        Speed = 100;
        Capacity = 4;
    }

    public override void Move()
    {
        Console.WriteLine("Car is driving.");
    }
}

public class Bus : Vehicle
{
    public Bus()
    {
        Speed = 60;
        Capacity = 40;
    }

    public override void Move()
    {
        Console.WriteLine("Bus is moving.");
    }
}

public class Train : Vehicle
{
    public Train()
    {
        Speed = 120;
        Capacity = 200;
    }

    public override void Move()
    {
        Console.WriteLine("Train is moving.");
    }
}

public class Route
{
    public string StartPoint { get; set; }
    public string EndPoint { get; set; }

    public Route(string startPoint, string endPoint)
    {
        StartPoint = startPoint;
        EndPoint = endPoint;
    }
}

public class TransportNetwork
{
    private List<Vehicle> vehicles;

    public TransportNetwork()
    {
        vehicles = new List<Vehicle>();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    public void RemoveVehicle(Vehicle vehicle)
    {
        vehicles.Remove(vehicle);
    }

    public void MoveAllVehicles()
    {
        foreach (var vehicle in vehicles)
        {
            vehicle.Move();
        }
    }

}

class Program
{
    static void Main()
    {
        var car = new Car();
        var bus = new Bus();
        var train = new Train();

        var network = new TransportNetwork();
        network.AddVehicle(car);
        network.AddVehicle(bus);
        network.AddVehicle(train);

        network.MoveAllVehicles();
    }
}
