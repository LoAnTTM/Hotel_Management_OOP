using System;
using System.Diagnostics;

namespace BookingSystem
{
    public interface IRoom
    {
        int id { get; set; }
        int price { get; set; }
        bool isAvailable { get; set; }
        bool isUse { get; set; }
        string roomType { get; set; }
        public void add();
        public void display();
    }

    abstract class Room
    {
        public int id { get; set; }
        public int price { get; set; }
        public string roomType { get; set; }
        public bool isAvailable { get; set; }
        public bool isUse { get; set; }

        public void addBase()
        {
            Console.Write("Input room id: ");
            id = Int32.Parse(Console.ReadLine());
            isAvailable = true;
            isUse = false; // Set isUse to false by default
        }

        public abstract void display();
    }

    class SingleRoom : Room, IRoom
    {
        public SingleRoom()
        {
            roomType = "Single Room";
        }
        public void add()
        {
            base.addBase();
            Console.Write("Input price for Single Room: ");
            price = Int32.Parse(Console.ReadLine());
        }
        public override void display()
        {
            Console.WriteLine($"Room {id}, price : ${price}, room type: {roomType}, available: {isAvailable}");
        }
    }

    class DoubleRoom : Room, IRoom
    {
        public DoubleRoom()
        {
            roomType = "Double Room";
        }
        public void add()
        {
            base.addBase();
            Console.Write("Input price for Double Room: ");
            price = Int32.Parse(Console.ReadLine());
        }
        public override void display()
        {
            Console.WriteLine($"Room {id}, price : ${price}, room type: {roomType}, available: {isAvailable}");
        }
    }

    class VIPRoom : Room, IRoom
    {
        public VIPRoom()
        {
            roomType = "VIP Room";
        }
        public void add()
        {
            base.addBase();
            Console.Write("Input price for VIP Room: ");
            price = Int32.Parse(Console.ReadLine());
        }
        public override void display()
        {
            Console.WriteLine($"Room {id}, price : ${price}, room type: {roomType}, available: {isAvailable}");
        }
    }   
}

