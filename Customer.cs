using System;
using System.Numerics;
using System.Xml.Linq;

namespace BookingSystem
{
    public interface ICustomer
    {
        int Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        string IdCard { get; set; }
    }

    class Customer: ICustomer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string IdCard { get; set; } 

        public void addInfo()
        {
            Console.Write("Input customer id: ");
            Id = Int32.Parse(Console.ReadLine());

            Console.Write("Input customer name: ");
            Name = Console.ReadLine();

            Console.Write("Input customer email: ");
            Email = Console.ReadLine();

            Console.Write("Input customer ID Card/Passport number: ");
            IdCard = Console.ReadLine();
        }
    }
}

