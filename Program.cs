namespace BookingSystem;

class Program
{
    static void Main(string[] args)
    {
        // Initialize data
        List<IRoom> rooms = new List<IRoom>();
        rooms.Add(new SingleRoom { id = 01, price = 500, isAvailable = true, isUse = false });
        rooms.Add(new DoubleRoom { id = 02, price = 1000, isAvailable = true, isUse = false });
        rooms.Add(new VIPRoom { id = 03, price = 2000, isAvailable = true, isUse = false });
        List<ICustomer> customers = new List<ICustomer>();
        customers.Add(new Customer { Id = 1, Name = "Test", Email = "Test@test.com", IdCard = "123qwe" });
        List<IBooking> bookings = new List<IBooking>();

        //Print menu
        static void ShowMenu()
        {
            Console.WriteLine("****** HOTEL MANAGEMENT ******");
            Console.WriteLine("==============================");
            Console.WriteLine("# 1. Show rooms information  #");
            Console.WriteLine("# 2. Add room                #");
            Console.WriteLine("# 3. Check in room           #");
            Console.WriteLine("# 4. Check out room          #");
            Console.WriteLine("# 5. Exit                    #");
            Console.WriteLine("------------------------------");
            Console.Write(    "===>Choose your action : ");
        }
        int choice = 0;
        do
        {
            try
            {
                ShowMenu();
                choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        showRooms(rooms);
                        break;
                    case 2:
                        Console.Clear();
                        addRoom(rooms);
                        break;
                    case 3:
                        Console.Clear();
                        bookRoom(rooms, customers, bookings);
                        break;
                    case 4:
                        Console.Clear();
                        checkoutRoom(rooms, bookings);
                        break;
                    case 5:
                        Console.WriteLine("Exiting..........");
                        break;
                    default:
                        Console.WriteLine("Input Failed");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        } while (choice != 5);

        //1. Show available room
        static void showRooms(List<IRoom> rooms)
        {
            foreach (IRoom room in rooms)
            {
                room.display();
            }
        }

        //2. Add room
        static void addRoom(List<IRoom> rooms)
        {
            int roomType = 0;
            IRoom room = null;
            do
            {
                Console.Write("Select room type (1: Single, 2: Double, 3: VIP): ");
                roomType = Int32.Parse(Console.ReadLine());
                switch (roomType) {
                    case 1:
                        room = new SingleRoom();
                        break;
                    case 2:
                        room = new DoubleRoom();
                        break;
                    case 3:
                        room = new VIPRoom();
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            } while (room == null);
            room.add();
            rooms.Add(room);
        }

        //3. Check in room
        //Finđ or add customer
        static ICustomer findOrAddCustomer(List<ICustomer> customers, string idCard)
        {
            // First, try to find the customer
            foreach (Customer customer in customers)
            {
                if (customer.IdCard.Equals(idCard))
                {
                    Console.WriteLine("Customer is exists");
                    return customer;
                }
            }

            // If the customer is not found, then add a new customer
            Customer newCustomer = new Customer();
            newCustomer.addInfo();
            customers.Add(newCustomer);
            return newCustomer;
        }

        // Choice room
        static IRoom choiceRoom(List<IRoom> rooms, int filterAction = 0)
        {
            // Display rooms based on the filter
            foreach (IRoom room in rooms)
            {
                if (filterAction == 1 && room.isUse == true)
                {
                    room.display();
                } else if (filterAction == 2 && room.isAvailable == true)
                {
                    room.display();
                } else if (filterAction == 0)
                {
                    room.display();
                }
            }
            // Allow user to choose a room
            IRoom chosedRoom = null;
            do
            {
                Console.Write("Please input room id: ");
                int roomId = Int32.Parse(Console.ReadLine());
                //Find room
                foreach (IRoom room in rooms)
                {
                    if (room.id.Equals(roomId))
                    {
                        chosedRoom = room;
                    }
                }
            } while (chosedRoom == null);
            return chosedRoom;
        }

        static void bookRoom(List<IRoom> rooms, List<ICustomer> customers, List<IBooking> bookings)
        {
            Console.Write("Please input customer Idcard: ");
            string customerId = Console.ReadLine();
            ICustomer customer = findOrAddCustomer(customers, customerId);
            IRoom room = null;
            do
            {
                room = choiceRoom(rooms, 2);
            } while (room == null || room.isAvailable == false);
            Booking booking = new Booking();
            int bookingId = bookings.Count;
            booking.Book(room, customer, bookingId);
            bookings.Add(booking);
        }

        //5. Check out room
        static void checkoutRoom(List<IRoom> rooms, List<IBooking> bookings)
        {
            IRoom room = choiceRoom(rooms, 1);
            if (room.isAvailable == true)
            {
                Console.WriteLine("Room is not using");
            }
            else
            {
                foreach (IBooking booking in bookings)
                {
                    if (booking.BookedRoom.id == room.id && booking.BookedRoom.isUse == true)
                    {
                        booking.Display(room, booking.BookedBy);
                        booking.CheckoutRoom(room);
                    }
                }
            }
        }
    }
}

