using System;

namespace Ex03.ConsoleUI
{
    class MotorcycleDataReader : DataReader
    {

        public override string[] GetSpecificData()
        {
            int licenseTypeChoice;
            string[] motorArguments = new string[2];

            printLicenseTypeMenu();
            licenseTypeChoice = Utilities.GetSingleNumInRange(1, 4);
            motorArguments[0] = ConvertLicenseTypeToString(licenseTypeChoice);
            Console.WriteLine("Please enter the volume capacity of the motor (in CC - Cubic Centimeters)");
            motorArguments[1] = Utilities.GetNumberAsString(2, 5);

            return motorArguments;
        }


        private void printLicenseTypeMenu()
        {
            Console.WriteLine("Please select your license type by typing its number");
            Console.WriteLine("1 - A1");
            Console.WriteLine("2 - A2");
            Console.WriteLine("3 - AA");
            Console.WriteLine("4 - B1");
        }

        private static string ConvertLicenseTypeToString(int i_LicenseTypeChoice)
        {
            string licenseType;
            switch (i_LicenseTypeChoice)
            {
                case 1:
                    licenseType = "A1";
                    break;
                case 2:
                    licenseType = "A2";
                    break;
                case 3:
                    licenseType = "AA";
                    break;
                default:
                    licenseType = "B1";
                    break;
            }

            return licenseType;
        }
    }
}
