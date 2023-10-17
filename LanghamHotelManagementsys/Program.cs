/*
* Project Name: Hotel Management System
* Author Name:Ho Ching Elvis Chan
* Date:10/10/2023
* Application Purpose:System to manage the hotel
*
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LanghamHotelManagementsys
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
        public static int noOfrooms;

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
                        Console.WriteLine("1. Add Rooms");
                        Console.WriteLine("2. Display Rooms");
                        Console.WriteLine("3. Allocate Rooms");
                        Console.WriteLine("4. De-Allocate Rooms");
                        Console.WriteLine("5. Display Room Allocation Details");
                        Console.WriteLine("6. Billing");
                        Console.WriteLine("7. Save the Room Allocations To a File");
                        Console.WriteLine("8. Show the Room Allocations From a File");
                        Console.WriteLine("9. Exit");
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
                                display_rooms();
                                // display Rooms function;
                                break;
                            case 3:
                                allocate_rooms();
                                // allocate Room To Customer function
                                break;
                            case 4:
                                de_allocate_rooms();
                                // De-Allocate Room From Customer function
                                break;
                            case 5:
                                // display Room Alocations function;
                                break;
                            case 6:
                                Console.WriteLine("Billing Feature is Under Construction and will be added soon…!!!");
                                //  Display "Billing Feature is Under Construction and will be added soon…!!!"
                                break;
                            case 7:
                                Save_room_allocations();
                                // SaveRoomAllocationsToFile
                                break;
                            case 8:
                                Show_allocation_rooms();
                                //Show Room Allocations From File
                                break;
                            case 9:
                                Environment.Exit(0);
                                // Exit Application
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
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please Try Again");
                Console.ReadLine();
                }
                finally
                {
                    menu();
                }
            }
        public static void add_rooms()
        {
            try
            {
                Console.WriteLine("You've selected Add Room");
                Console.WriteLine("Please enter the number of rooms you want to add in hotel");
                noOfrooms = int.Parse(Console.ReadLine());
                Console.WriteLine($"Hotel has {noOfrooms} rooms in total");
                Console.WriteLine("***********************************************************************************");
                listofRooms = new Room[noOfrooms];
                for (int i = 0; i < noOfrooms; i++)
                {
                    Room room = new Room();
                    Console.WriteLine($"Please enter the room number of {i + 1} room");
                    room.RoomNo =  int.Parse(Console.ReadLine());
                    room.IsAllocated = false;
                    listofRooms[i] = room;

                    if (i > 0)
                        {
                    for(int j=0; j < i; j++)
                        {
                            while (listofRooms[i].RoomNo == listofRooms[j].RoomNo)
                            {
                                Console.WriteLine($"Same room number already type in");
                            }
                        }
                }
                }
            }
            catch (FormatException ex) 
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please try again");
                Console.ReadLine();
                add_rooms();
            }
        }
        public static void display_rooms()
        {
            if(listofRooms != null)
            {
                foreach (Room room in listofRooms)
                {
                    Console.WriteLine($"Room Number:{room.RoomNo}");
                }
            }
            else 
            {
                Console.WriteLine("No rooms to display");
            }
        }
        public static void allocate_rooms()
        {
            try
            {
                Console.WriteLine("You've selected Allocate Rooms");
                Console.WriteLine("How many rooms would you like to allocate?");
                int allocated_rooms = int.Parse(Console.ReadLine());
                if (allocated_rooms > noOfrooms)
                {
                    Console.Write("You can't allocate more rooms than total number of rooms in the hotel");
                    Console.WriteLine($"Please enter the number bewteen 1- {noOfrooms}:");
                    allocated_rooms = int.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine($"You are allocating {allocated_rooms} rooms");
                    for (int i = 0; i < allocated_rooms; i++)
                    {
                        Customer customer = new Customer();
                        RoomlAllocaltion roomlAllcation = new RoomlAllocaltion();
                        Console.WriteLine($"Room allocation: {i + 1}");
                        Console.WriteLine("Search the room you want to allocate");
                        int search_room = int.Parse(Console.ReadLine());
                        for (int j = 0; j < noOfrooms; j++)
                        {
                            Console.WriteLine("Room found");
                            if (search_room == listofRooms[j].RoomNo)
                            {
                                if (listofRooms[j].IsAllocated == false)
                                {
                                    Console.WriteLine("Room is empty");
                                    Console.WriteLine("Please enter the customer number");
                                    customer.CustomerNo = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Please enter the customer name");
                                    customer.CustomerName = Convert.ToString(Console.ReadLine());
                                }
                                else
                                {
                                    Console.WriteLine("This rooms is already occupied"); 
                                }
                            }
                        }
                    }
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please try again");
                Console.ReadLine();
                allocate_rooms();
            }
        }
        public static void de_allocate_rooms()
        {
        }
        public static void Save_room_allocations()
        {
        }
        public static void Show_allocation_rooms()
        {
        }
    }
}

    

