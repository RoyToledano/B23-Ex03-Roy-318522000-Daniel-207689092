using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{

    public class ManageUI
    {
        private GarageManager m_Garage;

        public void StartProgram()
        {
            int userChoice;
            bool v_IsRunning = true;

            printWelcomeMessage();
            while(v_IsRunning)
            {
                printMenu();
                userChoice = Utilities.GetSingleNumInRange(1, 8);

            }
        }

        private void executeChoice(int i_Choice,ref bool io_IsRunning)
        {
            switch (i_Choice)
            {
                case 1:
                    ManageDataReader();
                    break;
                    //add cases
            }
        }

        private void ManageDataReader()
        {
            string customerName, customerPhoneNumber, licensePlate;
            int vechileTypeChoice;
            eVechilesTypes eVechileType;

            Console.WriteLine("Please enter licencse plate number, note that a valid license plate number is 7 or 8 digits long");
            licensePlate = Utilities.GetNumberAsString(7, 8);
            //call method to check if exists, if exists - no need to keep getting data but need to change status to "repaired"
            Console.WriteLine("Please enter your name");
            customerName = Utilities.GetAlphabeticString();
            Console.WriteLine("Please enter your phone number, note that a valid phone number is 9 or 10 digits long");
            customerPhoneNumber = Utilities.GetNumberAsString(9,10);
            printVechileTypesMenu();
            vechileTypeChoice = Utilities.GetSingleNumInRange(1, 5);
            eVechileType = Utilities.ConvertVechileTypeToEnum(vechileTypeChoice);
            m_Garage.AddNewCustomer(customerName, customerPhoneNumber, licensePlate, eVechileType);


        }

        private void printVechileTypesMenu()
        {
            Console.WriteLine("Please select the prefered option by typing its number");
            Console.WriteLine("1 - Fueled Car");
            Console.WriteLine("2 - Fueled Motorcycle");
            Console.WriteLine("3 - Fueled Truck");
            Console.WriteLine("4 - Electric Car");
            Console.WriteLine("5 - Electric Motorcycle");
        }

        private void printWelcomeMessage()
        {
            string welcomeMessage = @" _____ _            _____                            
|_   _| |          |  __ \                           
  | | | |__   ___  | |  \/ __ _ _ __ __ _  __ _  ___ 
  | | | '_ \ / _ \ | | __ / _` | '__/ _` |/ _` |/ _ \
  | | | | | |  __/ | |_\ \ (_| | | | (_| | (_| |  __/
  \_/ |_| |_|\___|  \____/\__,_|_|  \__,_|\__, |\___|
                                           __/ |     
                                          |___/      ";
            string test = @"████████╗██╗  ██╗███████╗     ██████╗  █████╗ ██████╗  █████╗  ██████╗ ███████╗
╚══██╔══╝██║  ██║██╔════╝    ██╔════╝ ██╔══██╗██╔══██╗██╔══██╗██╔════╝ ██╔════╝
   ██║   ███████║█████╗      ██║  ███╗███████║██████╔╝███████║██║  ███╗█████╗  
   ██║   ██╔══██║██╔══╝      ██║   ██║██╔══██║██╔══██╗██╔══██║██║   ██║██╔══╝  
   ██║   ██║  ██║███████╗    ╚██████╔╝██║  ██║██║  ██║██║  ██║╚██████╔╝███████╗
   ╚═╝   ╚═╝  ╚═╝╚══════╝     ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝ ╚══════╝
                                                                               ";
            Console.WriteLine(test);
        }

        private void printMenu()
        {
            Console.WriteLine("Please select the prefered option by typing its number");
            Console.WriteLine("1 - Put a vechile for repair in the garage");
            Console.WriteLine("2 - Print vechiles license plates");
            Console.WriteLine("3 - Update vechile state in garage");
            Console.WriteLine("4 - Inflate all wheels of a vechile to maximum");
            Console.WriteLine("5 - Refuel a vechile's tank");
            Console.WriteLine("6 - Charge a vechile's battery");
            Console.WriteLine("7 - Print vechile's full data");
            Console.WriteLine("8 - Exit");
        }

    }


}
