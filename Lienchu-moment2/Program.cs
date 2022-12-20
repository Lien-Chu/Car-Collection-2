using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LienChuHuangMoment2
{
    internal class VehicleProgram
    {
        // Create an List to store the values.
        static List<Vehicle> vehicles = new List<Vehicle>();
        static void Main(string[] args)
        {         
            // Create and set parameters for 5 new lists.
            vehicles.Add(new Vehicle("1", "Audi", "A6", "Red", "2020"));
            vehicles.Add(new Vehicle("2", "BMW", "6-Series GT", "Silver", "2018", 122000));
            vehicles.Add(new Vehicle("3", "Lexus", "LS", "Black", "2019", 160000));
            vehicles.Add(new Vehicle("4", "Land Rover", "Discovery", "White", "2016", 66000));
            vehicles.Add(new Vehicle("5", "Maserati", "GranCabrio", "Black", "2020", 658000));
            //Creates the character input to be used with the switch-case below.

            Console.WriteLine(vehicles.Count);
            Console.WriteLine(Vehicle.indexOFMakeId());
            Char input = ' ';
            while (true)
            {               
                try
                {   //Create an interface for users to choose the options. 
                    Console.WriteLine("\n\n\n\t\t\tList of My Vehicles collection\n\n");
                    Console.WriteLine("\t{0,-8}\t{1,-13}\t{2,-13}\t{3,-8}   {4,-9}", " Car:", "    Make", "   Model", "  Color", "   Year");
                    Console.WriteLine("\t{0,-8}\t{1,-13}\t{2,-13}\t{3,-8}   {4,-9}", "-----------", "-------------", "-------------", "----------", "-------");
                    Console.WriteLine("\t{0,-8}\t{1,-13}\t{2,-13}\t{3,-8}   {4,-9}", "-----------", "-------------", "-------------", "----------", "-------");
                    foreach (Vehicle vehicle in vehicles)
                    {
                        Console.WriteLine("\tID No.: {0,-8} {1,-13}\t {2,-13}\t {3,-8}     {4,-9}\t", vehicle.id, vehicle.make, vehicle.model, vehicle.color, vehicle.year);
                    }
                    Console.Write("\n\n\t( + ) : Add a Vehicle\n\t( - ) : Remove a Vehicle\n\t( R ) : Reset a Vehicle\n\t( $ ) : Check The Price of a Vehicle\n\t( 0 ) : Exit The Application\n\tPlease enter your choice : ");
                    input = Console.ReadLine()[0];
                }
                //Catch Exception like if the input line is empty, then ask the users for some input.
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("\n\tThis input is not available! Please try again!.\n\tHit any key to continue.");
                    Console.ReadLine();
                }
                //  If the input character dose not match, ask user for a new input.
                if (input != '0' && input != '+' && input != '-' && input != 'r' && input != 'R' && input != '$')
                {
                    Console.WriteLine("\n\tThis input is not available! Please try again!\n\tHit any key to continue.");
                    Console.ReadLine();
                }
                // IF the input character is match, execute method below.

                else
                {  // Switch case for execution according to the input character.
                    switch (input)
                    {
                        case '+':  // Nav to method Add().
                            Add();
                            break;

                        case '-': // Nav to method Remove().
                            Remove();
                            break;

                        case 'r': // Nav to method ShowPrice().
                            Reset();
                            break;

                        case 'R': // Nav to method ShowPrice().
                            Reset();
                            break;

                        case '$': // Nav to method ShowPrice().
                            ShowPrice();

                            break;
                        case '0': // Nav to method Add().
                            return;

                        default:
                            Console.WriteLine("\nThis input is not available! Please try again!\n\tHit any key to continue.");
                            break;
                    }
                }
            }
        }

        #region 1. Add Vehicle
        static void Add() // Method for add a vehicle to list.
        { // Ask the user for the new parameter value for the new list.
            Console.Write("\n\tPlease Enter vehicle's ID: ");
            string vehicleId = Console.ReadLine();
            Console.Write("\n\tPlease Enter vehicle's Name: ");
            string makeName = Console.ReadLine();
            Console.Write("\n\tPlease Enter vehicle's Model: ");
            string makeModel = Console.ReadLine();
            Console.Write("\n\tPlease Enter vehicle's Color: ");
            string makeColor = Console.ReadLine();
            Console.Write("\n\tPlease Enter Vehicle's Make Year: ");
            string makeYear = Console.ReadLine();
            // Assign new parameter values as arguments of the new list.
            vehicles.Add(new Vehicle(vehicleId, makeName, makeModel, makeColor, makeYear));
            Console.WriteLine("\n\n\tNow you have " + vehicles.Count + " vehicles. Hit any key to continue.");
            Console.ReadLine();
        }
        #endregion

        #region 2. Remove Vehicle 
        static void Remove() //Method for remove a vehicle.
        {
            // Ask the user the specified vehicle's ID.          
            Console.Write("\tWhich car do you want to remove? Please enter the ID no.: ");
            string removeNumber = Console.ReadLine();
            // Search if id exists in list.
            Vehicle existingVehicle = vehicles.Find(vehicle => vehicle.id == removeNumber);
            //If the Id is not exesist, then ask the users to enter again.
            if (existingVehicle == null)
            {
                Console.WriteLine("\n\tThis input is not available. Please try again!");
            }
            // Remove the vehicle that the user has chosen.
            vehicles.Remove(existingVehicle);
            Console.WriteLine("\n\n\tNow you have " + vehicles.Count + " vehicles. Hit any key to continue.");
            Console.ReadLine();
        }
        #endregion

        #region 3. Reset Vehicle
        static void Reset() //Method for resets parameters in the specified vehicle.
        {
            // Ask the user the specified vehicle's ID.  
            Console.Write("\n\tWhich vehicle do you want to reset? Please enter the ID no.: ");
            string resetNumber = Console.ReadLine();
            // Search if the id exists in list.
            Vehicle existingVehicle = vehicles.Find(vehicle => vehicle.id == resetNumber);
            // Search the ID's index number.
            int i = vehicles.IndexOf(existingVehicle);
            //  If the ID does not exist in the list return the massage.
            if (existingVehicle == null)
            {
                Console.WriteLine("\n\tThis ID does not exist. Please try again!");
                Console.ReadLine();
            }
            else
            {  // Create an interface for the user to select the reset parameters.
                Console.Write("\n\t( 1 ) :  ID\n\t( 2 ) : tMake\n\t( 3 ) : Model\n\t( 4 ) : Colo\n\t( 5 ) : Year\n\tWhich element do you want to reset? ");
                string resetElement = Console.ReadLine();
                //  If the input number dose not match, ask user for a new input number.
                if (resetElement == null)
                {
                    Console.WriteLine("\n\tThis input is not available! Please try again!\n\tHit any key to continue.");
                    Console.ReadLine();
                }
                else
                {
                    // Switch case for execution according to the input .
                    switch (resetElement)
                    {
                        case "1":
                            // Ask the user the specified vehicle's new ID.  
                            Console.Write("\n\tPlease Enter vehicle's ID: ");
                            // Assign new ID as new arguments for vehicle.
                            vehicles[i].id = Console.ReadLine();
                            break;

                        case "2":
                            // Ask the user the specified vehicle's new makeName. 
                            Console.Write("\n\tPlease Enter vehicle's Name: ");
                            // Assign new makeName as new arguments for vehicle.
                            vehicles[i].make = Console.ReadLine();
                            break;

                        case "3":
                            // Ask the user the specified vehicle's new Model.
                            Console.Write("\n\tPlease Enter vehicle's Model: ");
                            // Assign new model as new arguments for vehicle.
                            vehicles[i].model = Console.ReadLine();
                            break;

                        case "4":
                            // Ask the user the specified vehicle's new Color.
                            Console.Write("\n\tPlease Enter vehicle's Color: ");
                            // Assign new color as new arguments for vehicle.
                            vehicles[i].color = Console.ReadLine();
                            break;

                        case "5":
                            // Ask the user the specified vehicle's new make Year.
                            Console.Write("\n\tPlease Enter vehicle's Year: ");
                            // Assign new year as new arguments for vehicle.
                            vehicles[i].year = Console.ReadLine();
                            break;

                        // If the selected number does not exist, then ask the users to enter again. 
                        default:
                            Console.WriteLine("\n\tThis input is not available! Please try again!");
                            break;
                    }
                }
            }
            Console.WriteLine("\n\n\tHit any key to continue.");
            Console.ReadLine();
        }
        #endregion

        #region 4. Check Vehicle's Price
        static void ShowPrice() ///Method for getting and returning the private parameters in the constructor.
        {
            // Ask the user the specified vehicle's ID.
            Console.Write("\tWhich vehicle do you want to check its price? Please enter the ID No.: ");
            string checkPriceNumber = Console.ReadLine();
            // Search if the id exists in list.
            Vehicle existingVehicle = vehicles.Find(vehicle => vehicle.id == checkPriceNumber);
            // Search the ID's index number.
            int i = vehicles.IndexOf(existingVehicle);
            //  If the ID does not exist in the list return the massage.
            if (existingVehicle == null)
            {
                Console.WriteLine("\n\tThis ID does not exist. Please try again!");
            }
            // Returning the value's parameters set in the constructor.
            else if (vehicles[i].price != 0)
            {
                Console.WriteLine("\n\tID No." + vehicles[i].id + " Price : $" + vehicles[i].price + "\n\tID No." + vehicles[i].id + "  Cost : $" + vehicles[i].cost);
            }
            // If the price does not exist in the list return the massage.
            else
            {
                Console.WriteLine("\n\tThe price of ID No." + vehicles[i].id + " is undefined.");
            }
            Console.WriteLine("\n\tHit any key to continue.");
            Console.ReadLine();
        }
        #endregion
    }
}




