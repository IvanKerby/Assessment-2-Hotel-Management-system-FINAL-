/* 
 * Project Name: Langham Hotel Management
 * Author Name: Ivan Kerby Pedrina
 * Date: Oct 11 2023 
 * Application Purpose: develop a software that helps in day to day operations
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace Assessment2Task2
{
    // Custom Class - Room
    public class Room
    {
        public int RoomNo { get; set; }
        public bool IsAllocated { get; set; }
    }

    // Custom Class - Customer
    public class Customer
    {
        public int CustomerNo { get; set; }
        public string CustomerName { get; set; }
    }

    // Custom Class - RoomAllocation
    public class RoomlAllocaltion
    {
        public int AllocatedRoomNo { get; set; }
        public Customer AllocatedCustomer { get; set; }
    }

    // Custom Main Class - Program
    internal class Program
    {
        // Variables declaration and initialization
        public static Room[] listofRooms;
        public static List<RoomlAllocaltion> listOfRoomlAllocaltions = new List<RoomlAllocaltion>();
        public static string filePath;
        public static int noOfRooms;

        // Main function
        static void Main(string[] args)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            filePath = Path.Combine(folderPath, "HotelManagement.txt");

            menu();
        }

        public static void menu()
        {
            try
            {
                char ans;
                do
                {
                    Console.Clear();
                    Console.WriteLine("***********************************************************************************");
                    Console.WriteLine("                 LANGHAM HOTEL MANAGEMENT SYSTEM                  ");
                    Console.WriteLine("                            MENU                                 ");
                    Console.WriteLine("***********************************************************************************");
                    Console.WriteLine("1. Add Rooms"); // Option to add rooms
                    Console.WriteLine("2. Display Rooms"); // Option to display rooms
                    Console.WriteLine("3. Allocate Rooms"); // Option to allocate rooms to customers
                    Console.WriteLine("4. De-Allocate Rooms"); // Option to deallocate rooms from customers
                    Console.WriteLine("5. Display Room Allocation Details"); // Option to display allocated room details
                    Console.WriteLine("6. Billing"); // Placeholder for a future feature
                    Console.WriteLine("7. Save the Room Allocations To a File"); // Option to save room allocations to a file
                    Console.WriteLine("8. Show the Room Allocations From a File"); // Option to show room allocations from a file
                    Console.WriteLine("9. Exit"); // Option to exit the application
                    // Add new option 0 for Backup 
                    Console.WriteLine("***********************************************************************************");
                    Console.Write("Enter Your Choice Number Here:");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            // adding Rooms function
                            add_rooms();
                            break;
                        case 2:
                            // display Rooms function;
                            display_rooms();
                            break;
                        case 3:
                            // allocate Room To Customer function
                            allocate_rooms();
                            break;
                        case 4:
                            // De-Allocate Room From Customer function
                            de_allocate_rooms();
                            break;
                        case 5:
                            // display Room Alocations function;
                            display_room_allocation();
                            break;
                        case 6:
                            //  Display "Billing Feature is Under Construction and will be added soon…!!!"
                            Console.WriteLine("Billing feature is under construction and will be added soon…!!!");
                            break;
                        case 7:
                            // SaveRoomAllocationsToFile
                            save_room_allocation();
                            break;
                        case 8:
                            //Show Room Allocations From File
                            show_room_allocation();
                            break;
                        case 9:
                            // Exit Application
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }

                    Console.Write("\nWould You Like To Continue(Y/N):");
                    ans = Convert.ToChar(Console.ReadLine());
                } while (ans == 'y' || ans == 'Y');
            }
            catch (FormatException ex)
            {
                // Handle format exception
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please try again");
                Console.ReadLine();
            }
            catch (InvalidOperationException ex)
            {
                // Handle invalid operation exception
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please try again");
                Console.ReadLine();
            }
            catch
            {
                // Handle other exceptions if needed
            }
            finally
            {
                // Continue to the menu after handling exceptions
                menu();
            }
            Console.ReadLine();
        }

        // Function to add rooms
        public static void add_rooms()
        {
            try
            {
                Console.WriteLine("Please enter the total number of rooms you want to add in the hotel:");
                noOfRooms = int.Parse(Console.ReadLine());
                Console.WriteLine($"Hotel has {noOfRooms} rooms in total");
                Console.WriteLine("***********************************************************************************");
                listofRooms = new Room[noOfRooms];
                for (int i = 0; i < listofRooms.Length; i++)
                {
                    Room room = new Room();
                    Console.WriteLine($"Please enter the room number of {i + 1} room");
                    room.RoomNo = int.Parse(Console.ReadLine());
                    room.IsAllocated = false;
                    listofRooms[i] = room;
                    if (i > 0)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            while (listofRooms[i].RoomNo == listofRooms[j].RoomNo)
                            {
                                Console.WriteLine($"The same room already exists m\"Please enter the room number of {i + 1} room");
                                room.RoomNo = int.Parse(Console.ReadLine());
                                room.IsAllocated = false;
                                listofRooms[i] = room;
                            }
                        }
                    }
                }
            }
            catch (FormatException ex)
            {
                // Handle format exception
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please try again");
                Console.ReadLine();
                add_rooms();
            }
        }

        // Function to display rooms
        public static void display_rooms()
        {
            if (listofRooms != null)
            {
                Console.WriteLine("Here are all the rooms!");

                foreach (Room room in listofRooms)
                {
                    Console.WriteLine($"Room Number: {room.RoomNo}");
                }
            }
            else
            {
                Console.WriteLine("No rooms to display...\nPlease add rooms first!");
            }
        }

        // Function to allocate rooms to customers
        public static void allocate_rooms()
        {
            try
            {
                Console.WriteLine("How many rooms would you like to allocate?");
                int allocated_room = int.Parse(Console.ReadLine());
                while (allocated_room > noOfRooms)
                {
                    Console.WriteLine("You can't allocate more rooms than the total number of rooms in the hotel...");
                    Console.WriteLine($"Please enter the number between 1 - {noOfRooms}: ");
                    allocated_room = int.Parse(Console.ReadLine());
                }
                Console.WriteLine($"You are allocating {allocated_room} room(s)");
                for (int i = 0; i < allocated_room; i++)
                {
                    Customer customer = new Customer();
                    RoomlAllocaltion roomlAllocaltion = new RoomlAllocaltion();
                    Console.WriteLine($"Room allocation : {i + 1} ");
                    Console.WriteLine("Search the room you want to allocate");
                    int search_room = int.Parse(Console.ReadLine());
                    for (int j = 0; j < noOfRooms; j++)
                    {
                        if (search_room == listofRooms[j].RoomNo)
                        {
                            Console.WriteLine("Room found!");
                            if (listofRooms[j].IsAllocated == false)
                            {
                                Console.WriteLine("Room is empty");

                                Console.WriteLine("Please enter the customers number");
                                customer.CustomerNo = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Please enter the customers name");
                                customer.CustomerName = Console.ReadLine();

                                listofRooms[j].IsAllocated = true;

                                roomlAllocaltion.AllocatedRoomNo = search_room;
                                roomlAllocaltion.AllocatedCustomer = customer;

                                listOfRoomlAllocaltions.Add(roomlAllocaltion);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("This room is already occupied");
                                i--;

                                Console.WriteLine("Return to Main Menu?");
                                string ans;
                                string y = "y"; // Initialize with the expected values
                                string Y = "Y"; // Initialize with the expected values
                                ans = Console.ReadLine();

                                if (ans == y || ans == Y)
                                {
                                    Console.WriteLine("Returning to Main Menu...");
                                    menu();
                                }
                            }
                        }
                        else
                        {
                            while (j == noOfRooms - 1)
                            {
                                Console.WriteLine("Unable to find specified room...");
                                Console.WriteLine("Return to Main Menu?");
                                string ans;
                                string y = "y"; // Initialize with the expected values
                                string Y = "Y"; // Initialize with the expected values
                                ans = Console.ReadLine();

                                if (ans == y || ans == Y)
                                {
                                    Console.WriteLine("Returning to Main Menu...");
                                    menu();
                                }
                            }
                        }
                    }
                }
            }
            catch (FormatException ex)
            {
                // Handle format exception
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please try again");
                Console.ReadLine();
                allocate_rooms();
            }
            catch (InvalidOperationException ex)
            {
                // Handle invalid operation exception
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please try again");
                Console.ReadLine();
                allocate_rooms();
            }
        }

        // Function to deallocate rooms from customers
        public static void de_allocate_rooms()
        {
            try
            {
                Console.WriteLine("How many rooms would you like to deallocate?");
                int de_allocated_room = int.Parse(Console.ReadLine());
                while (de_allocated_room > listOfRoomlAllocaltions.Count)
                {
                    Console.WriteLine("You can't deallocate more rooms than the total number of rooms in the hotel...");
                    Console.WriteLine($"Please enter the number between 1 - {listOfRoomlAllocaltions.Count}: ");
                    de_allocated_room = int.Parse(Console.ReadLine());
                }
                Console.WriteLine($"You are deallocating {de_allocated_room} room(s)");
                for (int i = 0; i < de_allocated_room; i++)
                {
                    Console.WriteLine($"Room deallocation : {i + 1} ");
                    Console.WriteLine("Search the room you want to deallocate");
                    int search_room = int.Parse(Console.ReadLine());
                    for (int j = 0; j < noOfRooms; j++)
                    {
                        if (search_room == listofRooms[j].RoomNo)
                        {
                            Console.WriteLine("Room found!");
                            if (listofRooms[j].IsAllocated == true)
                            {
                                Console.WriteLine($"Room {search_room} is occupied ");
                                listofRooms[j].IsAllocated = false;
                                RoomlAllocaltion roomlAllocaltion = listOfRoomlAllocaltions.Find(x => x.AllocatedRoomNo == search_room);
                                listOfRoomlAllocaltions.Remove(roomlAllocaltion);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("This room is already empty");
                                i--;
                                break;
                            }
                        }
                        else
                        {
                            while (j == noOfRooms - 1)
                            {
                                Console.WriteLine("Unable to find specified room...");
                                i--;
                                break;
                            }
                        }
                    }
                }
            }
            catch (FormatException ex)
            {
                // Handle format exception
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please try again");
                Console.ReadLine();
                allocate_rooms();
            }
            catch (InvalidOperationException ex)
            {
                // Handle invalid operation exception
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please try again");
                Console.ReadLine();
                allocate_rooms();
            }
        }

        // Function to display room allocation details
        public static void display_room_allocation()
        {
            if (listOfRoomlAllocaltions != null)
            {
                Console.WriteLine("Here are all the allocated rooms!");

                foreach (RoomlAllocaltion roomAllocatted in listOfRoomlAllocaltions)
                {
                    Console.WriteLine($"Room Number: {roomAllocatted.AllocatedRoomNo}");
                    Console.WriteLine($"Customer Number: {roomAllocatted.AllocatedCustomer.CustomerNo}");
                    Console.WriteLine($"Customer Name: {roomAllocatted.AllocatedCustomer.CustomerName}");
                }
            }
            else
            {
                Console.WriteLine("No rooms allocated rooms to display...\nPlease allocate rooms first!");
            }
        }

        // Function to save room allocation details to a file
        public static void save_room_allocation()
        {
            try
            {
                string folderPath = Path.Combine("C:\\Users\\pedri\\OneDrive\\Desktop", "Hotel Management");
                string filePath = Path.Combine(folderPath, "HotelManagement.txt");
                
                using (StreamWriter writer = new StreamWriter(filePath, true)) // Append to the existing file
                {
                    writer.WriteLine("Room Allocation Details:");
                    foreach (RoomlAllocaltion roomAllocation in listOfRoomlAllocaltions)
                    {
                        writer.WriteLine($"Room Number: {roomAllocation.AllocatedRoomNo}");
                        writer.WriteLine($"Customer Number: {roomAllocation.AllocatedCustomer.CustomerNo}");
                        writer.WriteLine($"Customer Name: {roomAllocation.AllocatedCustomer.CustomerName}");
                        writer.WriteLine("***********************************");
                    }
                }

                Console.WriteLine("Room allocation details saved to the file!");
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while saving to the file: " + e.Message);
            }
        }

        // Function to show room allocation details from a file
        public static void show_room_allocation()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        if ((line = reader.ReadLine()) == null)
                        {
                            Console.WriteLine("The file with room allocation details is empty.");
                        }
                        else
                        {
                            Console.WriteLine("Room Allocation Details from File:");
                            Console.WriteLine(line); // Print the first line
                            while ((line = reader.ReadLine()) != null)
                            {
                                Console.WriteLine(line);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("The file with room allocation details does not exist.");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while reading from the file: " + e.Message);
            }
        }
    }
}
