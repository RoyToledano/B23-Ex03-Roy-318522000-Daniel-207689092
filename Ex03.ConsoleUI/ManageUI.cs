﻿using System;
using System.Collections.Generic;
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
            m_Garage = new GarageManager();

            printWelcomeMessage();
            while(v_IsRunning)
            {
                printMenu();
                userChoice = Utilities.GetSingleNumInRange(1, 8);
                executeChoice(userChoice, ref v_IsRunning);

            }
        }

        private void executeChoice(int i_Choice,ref bool io_IsRunning)
        {
            switch (i_Choice)
            {
                case 1:
                    manageDataReader();
                    break;
                case 7:
                    printFullVechileData();
                    break;
                    //add cases
            }
        }

        private void printFullVechileData()
        {
            string licensePlate, vechileDetails;

            licensePlate = getLicenseNumber();
            vechileDetails = m_Garage.GetVechileDetailsAsString(licensePlate);
            Console.WriteLine("\nVechile's info:");
            Console.WriteLine(vechileDetails);

        }

        private void manageDataReader()
        {
            string licensePlate;
            eVechilesTypes eVechileType;
            eEngineTypes eEngineType;
            
            licensePlate = getLicenseNumber();
            if (!m_Garage.IsCustomerExist(licensePlate))
            {
                readCustomerData(licensePlate, out eVechileType, out eEngineType);
                readVechileData(licensePlate, eVechileType, eEngineType);
            }
            else
            {
                Console.WriteLine("This vechile is already registered. Now its status is updated to 'in repair'");
            }
        }

        private void readCustomerData(string i_LicensePlate, out eVechilesTypes o_VechileType, out eEngineTypes o_EngineType)
        {
            string customerName, customerPhoneNumber;
            int vechileTypeChoice;
            
            
            Console.WriteLine("Please enter your name");
            customerName = Utilities.GetAlphabeticString();
            Console.WriteLine("Please enter your phone number, note that a valid phone number is 9 or 10 digits long");
            customerPhoneNumber = Utilities.GetNumberAsString(9, 10);
            printVechileTypesMenu();
            vechileTypeChoice = Utilities.GetSingleNumInRange(1, 5);
            o_VechileType = Utilities.ConvertVechileTypeToEnum(out o_EngineType, vechileTypeChoice);
            m_Garage.AddNewCustomer(customerName, customerPhoneNumber, i_LicensePlate, o_VechileType, o_EngineType);
        }

        private void readVechileData(string i_LicensePlate ,eVechilesTypes i_VechilesType, eEngineTypes i_EngineType)
        {
            string modelName;
            string[] engineArguments, wheelsArguments, vechileSpecificArguments;
            float engineCapacityStatus;

            Console.WriteLine("Please enter the vechile's model name");
            modelName = Utilities.GetAlphabeticString();
            engineArguments = readEngineData(out engineCapacityStatus, i_EngineType);
            wheelsArguments = readWheelsData();
            vechileSpecificArguments = Utilities.GetSpecificData(i_VechilesType);
            m_Garage.SetVechileDataToCustomer(i_LicensePlate,modelName,engineCapacityStatus,vechileSpecificArguments,wheelsArguments,engineArguments);
        }

        private string[] readEngineData(out float o_EngineCapacityStatus, eEngineTypes i_EngineType)
        {
            string[] engineArguments;

            if(i_EngineType == eEngineTypes.Fuel)
            {
                engineArguments = readFuelData(out o_EngineCapacityStatus);
            }
            else
            {
                engineArguments = readElectricData(out o_EngineCapacityStatus);
            }

            return engineArguments;
        }

        private string[] readFuelData(out float o_EngineCapacityStatus)
        {
            float currentEngineLevel, maxEngineLevel;
            string[] engineArgument = new string[3];
            int fuelTypeChoice;
            eFuelType fuelType;

            printFuelTypes();
            fuelTypeChoice = Utilities.GetSingleNumInRange(1, 4);
            fuelType = Utilities.ConvertFuelTypeToEnum(fuelTypeChoice);
            Console.WriteLine("Please enter the fuel tank maximum capacity");
            maxEngineLevel = Utilities.GetFloatNumber();
            Console.WriteLine("Please enter the current fuel level(in liters)");
            currentEngineLevel = Utilities.GetFloatNumber();
            engineArgument[0] = fuelType.ToString();
            engineArgument[1] = currentEngineLevel.ToString();
            engineArgument[2] = maxEngineLevel.ToString();
            o_EngineCapacityStatus = ((currentEngineLevel / maxEngineLevel) * 100);

            return engineArgument;
        }

        private string[] readElectricData(out float o_EngineCapacityStatus)
        {
            float maxBatteryHours, currentBatteryHours;
            string[] engineArgument = new string[2];

            Console.WriteLine("Please enter the battery maximum capacity (in hours)");
            maxBatteryHours = Utilities.GetFloatNumber();
            Console.WriteLine("Pleas enter the amount of hours left in the battery");
            currentBatteryHours = Utilities.GetFloatNumber();
            engineArgument[0] = currentBatteryHours.ToString();
            engineArgument[1] = maxBatteryHours.ToString();
            o_EngineCapacityStatus = ((currentBatteryHours / maxBatteryHours) * 100);
            return engineArgument;
        }

        private string[] readWheelsData()
        {
            string[] wheelsArguments = new string[2];

            Console.WriteLine("Please enter wheels manufacture name");
            wheelsArguments[0] = Utilities.GetAlphabeticString();
            Console.WriteLine("Please enter wheels current air pressure");
            wheelsArguments[1] = Utilities.GetFloatNumber().ToString();
            return wheelsArguments;
        }

        private string getLicenseNumber()
        {
            string licensePlate;

            Console.WriteLine("Please enter licencse plate number, note that a valid license plate number is 7 or 8 digits long");
            licensePlate = Utilities.GetNumberAsString(7, 8);

            return licensePlate;
        }

        private void printFuelTypes()
        {
            Console.WriteLine("Please enter the fuel type");
            Console.WriteLine("1 - Soler");
            Console.WriteLine("2 - Octan95");
            Console.WriteLine("3 - Octan96");
            Console.WriteLine("4 - Octan98");
        }

        private void printVechileTypesMenu()
        {
            Console.WriteLine("Please select the vechile type by typing its number");
            Console.WriteLine("1 - Fueled Car");
            Console.WriteLine("2 - Fueled Motorcycle");
            Console.WriteLine("3 - Fueled Truck");
            Console.WriteLine("4 - Electric Car");
            Console.WriteLine("5 - Electric Motorcycle");
        }

        private void printWelcomeMessage()
        {
            string welcomeMessage = @"
████████╗██╗  ██╗███████╗     ██████╗  █████╗ ██████╗  █████╗  ██████╗ ███████╗
╚══██╔══╝██║  ██║██╔════╝    ██╔════╝ ██╔══██╗██╔══██╗██╔══██╗██╔════╝ ██╔════╝
   ██║   ███████║█████╗      ██║  ███╗███████║██████╔╝███████║██║  ███╗█████╗  
   ██║   ██╔══██║██╔══╝      ██║   ██║██╔══██║██╔══██╗██╔══██║██║   ██║██╔══╝  
   ██║   ██║  ██║███████╗    ╚██████╔╝██║  ██║██║  ██║██║  ██║╚██████╔╝███████╗
   ╚═╝   ╚═╝  ╚═╝╚══════╝     ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝ ╚══════╝
                                                                               ";
            Console.WriteLine(welcomeMessage);
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
