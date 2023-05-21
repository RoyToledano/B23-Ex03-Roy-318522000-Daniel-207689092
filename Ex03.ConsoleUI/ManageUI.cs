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
            m_Garage = new GarageManager();

            printWelcomeMessage();
            while(v_IsRunning)
            {
                printMenu();
                userChoice = manageUserChoice();
                executeChoice(userChoice, ref v_IsRunning);

            }
        }

        private int manageUserChoice()
        {
            int userChoice=8; //fix logic
            bool v_IsRunning = true;

            while (v_IsRunning)
            {
                try
                {
                    userChoice = Utilities.GetSingleNumInRange(1, 8);
                    v_IsRunning = false;
                }
                catch(Exception i_Exception)
                {
                    Console.WriteLine(i_Exception.Message+" Please Try Again\n");
                }
            }

            return userChoice;
        }

        private void executeChoice(int i_Choice,ref bool io_IsRunning)
        {
            string licensePlateNumber = getLicensePlateNumber();
            switch (i_Choice)
            {
                case 1:
                    manageDataReading(licensePlateNumber);
                    break;
                case 3:
                    updateVechileState(licensePlateNumber);
                    break;
                case 4:
                    inflateAllWheelsToMax(licensePlateNumber);
                    break;
                case 5:
                    refuelVechile(licensePlateNumber);
                    break;
                case 6:
                    chargeVechile(licensePlateNumber);
                    break;

                case 7:
                    printFullVechileData(licensePlateNumber);
                    break;
                    //add cases
            }
        }

        private void printFullVechileData(string i_LicensePlateNumber)
        {
            string vechileDetails=null;
            bool v_IsRunning = true;

            while (v_IsRunning)
            {
                try
                {
                    vechileDetails = m_Garage.GetVechileDetailsAsString(i_LicensePlateNumber);
                    v_IsRunning = false;

                }
                catch (Exception i_Exception)
                {
                    Console.WriteLine(i_Exception.Message + " Please Try Again\n");
                }
            }

            Console.WriteLine("\nVechile's info:");
            Console.WriteLine(vechileDetails);
        }

        private void updateVechileState(string i_LicensePlate)
        {
            bool v_IsRunning = true;
            int userChoice;
            eVechileState newState;

            while (v_IsRunning)
            {
                try
                {
                    printVechileStatuses();
                    userChoice =Utilities.GetSingleNumInRange(1, 3);
                    newState = Utilities.ConvertVechileStatusToEnum(userChoice);
                    m_Garage.UpdateVechileState(i_LicensePlate, newState);
                    v_IsRunning = false;
                }
                catch (Exception i_Exception)
                {
                    Console.WriteLine(i_Exception.Message + " Please Try Again\n");
                }
            }


        }

        private void inflateAllWheelsToMax(string i_LicensePlate)
        {
            string vechileDetails = null;
            bool v_IsRunning = true;

            while (v_IsRunning)
            {
                try
                {
                    m_Garage.InflateAllWheelsToMax(i_LicensePlate);
                    v_IsRunning = false;
                }
                catch (Exception i_Exception)
                {
                    Console.WriteLine(i_Exception.Message + " Please Try Again\n");
                }
            }

            Console.WriteLine("The air pressure for each wheel is set to maximum");
        }

        private void refuelVechile(string i_LicensePlate)
        {
            bool v_IsRunning = true;
            float litersToFill;
            int userChoiceOfFuel;
            eFuelType fuelType;

            while (v_IsRunning)
            {
                try
                {
                    printFuelTypes();
                    userChoiceOfFuel = Utilities.GetSingleNumInRange(1, 4);
                    fuelType = Utilities.ConvertFuelTypeToEnum(userChoiceOfFuel);
                    Console.WriteLine("Please type the amount of liters you would like to fill");
                    litersToFill = Utilities.GetFloatNumber();
                    m_Garage.RefuelVechile(i_LicensePlate, fuelType, litersToFill);
                    v_IsRunning = false;
                }
                catch (Exception i_Exception)
                {
                    Console.WriteLine(i_Exception.Message + " Please Try Again\n");
                }
            }

            Console.WriteLine("The tank has been filled with the amount requested");
        }

        private void chargeVechile(string i_LicensePlate)
        {
            bool v_IsRunning = true;
            int minutesToCharge;

            while (v_IsRunning)
            {
                try
                {
                    Console.WriteLine("Please type the amount of minutes you would like to charge (as integer)");
                    minutesToCharge = int.Parse(Utilities.GetNumberAsString(1,8)); //fix logic of how big can minutes be
                    m_Garage.ChargeVechile(i_LicensePlate,minutesToCharge);
                    v_IsRunning = false;
                }
                catch (Exception i_Exception)
                {
                    Console.WriteLine(i_Exception.Message + " Please Try Again\n");
                }
            }

            Console.WriteLine("The battery has been charged with the amount of minutes requested");
        }

        private void readData(string i_LicensePlateNumber)
        {
            string licensePlate;
            eVechilesTypes eVechileType;
            eEngineTypes eEngineType;
            
            if (!m_Garage.IsCustomerExist(i_LicensePlateNumber))
            {
                    readCustomerData(i_LicensePlateNumber, out eVechileType, out eEngineType);
                    readVechileData(i_LicensePlateNumber, eVechileType, eEngineType);
                
            }
            else
            {
                Console.WriteLine("This vechile is already registered. Now its status is updated to 'repairing'");
            }
        }

        private void manageDataReading(string i_LicensePlateNumber)
        {
            bool v_IsRunning = true;

            while (v_IsRunning)
            {
                try
                {
                    readData(i_LicensePlateNumber);
                    v_IsRunning = false;
                }
                catch (Exception i_Exception)
                {
                    Console.WriteLine(i_Exception.Message + " Please Try Again\n");
                }
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
            Console.WriteLine("Please enter the maximum capacity of the fuel tank maximum in liters");
            maxEngineLevel = Utilities.GetFloatNumber();
            Console.WriteLine("Please enter the current fuel status in liters");
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

            Console.WriteLine("Please enter the battery maximum capacity in hours");
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

            Console.WriteLine("Please enter the wheels manufacturer name");
            wheelsArguments[0] = Utilities.GetAlphabeticString();
            Console.WriteLine("Please enter the wheels current air pressure");
            wheelsArguments[1] = Utilities.GetFloatNumber().ToString();
            return wheelsArguments;
        }

        private string getLicensePlateNumber()
        {
            string licensePlate=null;
            bool v_IsRunning = true;

            while (v_IsRunning)
            {
                Console.WriteLine("Please enter licencse plate number, note that a valid license plate number is 7 or 8 digits long");
                try
                {
                    licensePlate = Utilities.GetNumberAsString(7, 8);
                    v_IsRunning = false;
                }
                catch (Exception i_Exception)
                {
                    Console.WriteLine(i_Exception.Message + " Please Try Again\n");
                }
            }

            return licensePlate;
        }

        private void printFuelTypes()
        {
            Console.WriteLine("Please select the fuel type by typing its number");
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

        private void printVechileStatuses()
        {
            Console.WriteLine("Please select new status type for your vechile by typing its number");
            Console.WriteLine("1 - Repairing");
            Console.WriteLine("2 - Repaired");
            Console.WriteLine("3 - Paid");
        }

    }


}
