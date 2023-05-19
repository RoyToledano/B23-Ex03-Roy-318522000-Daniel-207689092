using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class CarDataReader : DataReader
    {
        public override string[] GetSpecificData()
        {
            int colorChoice, numOfDoors;
            string[] carArguments = new string[2];

            printColorMenu();
            colorChoice = Utilities.GetSingleNumInRange(1, 4);
            carArguments[0] = ConvertColorTypeToString(colorChoice);
            Console.WriteLine("Please enter the num of doors in your vechile (2,3,4 or 5)");
            numOfDoors = Utilities.GetSingleNumInRange(2, 5);
            carArguments[1] = numOfDoors.ToString();

            return carArguments;
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
