using System;
namespace BookingSystem
{
    public interface IBooking
    {
        int Id { get; set; }
        IRoom BookedRoom { get; set; }
        ICustomer BookedBy { get; set; }
        DateTime Checkin { get; set; }
        DateTime Checkout { get; set; }
        void Book(IRoom room, ICustomer customer, int bookId);
        void CheckoutRoom(IRoom BookedRoom);
        void Display(IRoom BookedRoom, ICustomer customer);
    }

    class Booking : IBooking
	{
        public int Id { get; set; }
        public IRoom BookedRoom { get; set; }
        public ICustomer BookedBy { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }

        public void Book(IRoom room, ICustomer customer, int bookId)
        {
            if (room.isAvailable)
            {
                room.isUse = true;
                room.isAvailable = false;
                Id = bookId;
                Checkin = DateTime.Now;
                BookedRoom = room;
                BookedBy = customer;
                Console.WriteLine($"-->{room.roomType} {room.id} has been booked since {Checkin}.");
            }
            else
            {
                Console.WriteLine($"->{room.roomType} {room.id} is not available.");
            }
        }

        public void CheckoutRoom(IRoom BookedRoom)
        {
            if (BookedRoom.isUse)
            {
                BookedRoom.isUse = false;
                BookedRoom.isAvailable = true;
                Checkout = DateTime.Now;
                Console.WriteLine($"-->{BookedRoom.roomType} {BookedRoom.id} had been checked out. Thank you!. Hope to see you again.");
            }
            else
            {
                Console.WriteLine($"->{BookedRoom.roomType} {BookedRoom.id} is not in use.");
            }
        }

        //public void Book(int bookingId, Room room, Customer customer)
        //{
        //    Id = bookingId;
        //    room.isAvailable = false;
        //    room.isUse = true;
        //    BookedRoom = room;
        //    BookedBy = customer;
        //    Checkin = DateTime.Now;
        //}

        //public void CheckoutRoom()
        //{
        //    Checkout = DateTime.Now;
        //    BookedRoom.isAvailable = true;
        //    BookedRoom.isUse = false;
        //    double roomCharge = Math.Round(BookedRoom.price * Checkout.Subtract(Checkin).TotalHours, 2);
        //    Console.WriteLine($"Total bill: ${roomCharge}");
        //}

        public void Display(IRoom BookedRoom, ICustomer customer)
        {
            Console.WriteLine("-----BOOKING INFORMATION------");
            Console.WriteLine($"Booking Id: {Id+1}");
            Console.WriteLine($"Room Id: {BookedRoom.id}");
            Console.WriteLine($"Booked By: {customer.Name}");
            Console.WriteLine($"Check-in Date: {Checkin}");
            Console.WriteLine($"Checkout Date: {Checkout}");
        }
    }
}

