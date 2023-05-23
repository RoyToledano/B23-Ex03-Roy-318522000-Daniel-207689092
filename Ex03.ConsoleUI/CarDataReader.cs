using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class CarDataReader : DataReader
    {
        const float k_MaxFuelTank = 46;
        const eFuelType k_CarFuelType = eFuelType.Octan95;
        const float k_MaxBatteryVolume = (float)5.2;

        public override string[] GetSpecificData()
        {
            int colorChoice, numOfDoors;
            string[] carArguments = new string[2];

            printColorMenu();
            colorChoice = Utilities.GetSingleNumInRange(1, 4);
            carArguments[0] = ConvertColorTypeToString(colorChoice);
            Console.WriteLine("Please enter the number of doors in your vechile (2,3,4 or 5)");
            numOfDoors = Utilities.GetSingleNumInRange(2, 5);
            carArguments[1] = numOfDoors.ToString();

            return carArguments;
        }

        public override string[] GetEngineData(eEngineTypes i_EngineType)
        {
            string[] engineArguments = null;

            if (i_EngineType == eEngineTypes.Fuel)
            {
                engineArguments = createFuelDataArray(k_CarFuelType, k_MaxFuelTank);
            }
            else
            {
                engineArguments = createElectricDataArray(k_MaxBatteryVolume);
            }

            return engineArguments;
        }


        private void printColorMenu()
        {
            Console.WriteLine("Please select the prefered option by typing its number");
            Console.WriteLine("1 - Red");
            Console.WriteLine("2 - Black");
            Console.WriteLine("3 - Yellow");
            Console.WriteLine("4 - White");
        }

        private static string ConvertColorTypeToString(int i_ColorChoice)
        {
            string color;
            switch (i_ColorChoice)
            {
                case 1:
                    color = "Red";
                    break;
                case 2:
                    color = "Black";
                    break;
                case 3:
                    color = "Yellow";
                    break;
                default:
                    color = "White";
                    break;
            }

            return color;
        }
    }
}
