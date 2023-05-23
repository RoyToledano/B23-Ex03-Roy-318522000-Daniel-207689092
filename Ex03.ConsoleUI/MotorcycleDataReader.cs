using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class MotorcycleDataReader : DataReader
    {

        const float k_MaxFuelTank = (float)6.4;
        const eFuelType k_MotorcycleFuelType = eFuelType.Octan98;
        const float k_MaxBatteryVolume = (float)2.6;

        public override Object[] GetSpecificData()
        {
            int licenseTypeChoice;
            Object[] motorArguments = new Object[2];

            printLicenseTypeMenu();
            licenseTypeChoice = Utilities.GetSingleNumInRange(1, 4);
            motorArguments[0] = ConvertLicenseTypeToEnum(licenseTypeChoice);
            Console.WriteLine("Please enter the volume capacity of the motor (in CC - Cubic Centimeters)");
            motorArguments[1] = Utilities.GetInteger();

            return motorArguments;
        }

        public override Object[] GetEngineData(eEngineTypes i_EngineType)
        {
            Object[] engineArguments = null;

            if (i_EngineType == eEngineTypes.Fuel)
            {
                engineArguments = createFuelDataArray(k_MotorcycleFuelType, k_MaxFuelTank);
            }
            else
            {
                engineArguments = createElectricDataArray(k_MaxBatteryVolume);
            }

            return engineArguments;
        }

        private void printLicenseTypeMenu()
        {
            Console.WriteLine("Please select your license type by typing its number");
            Console.WriteLine("1 - A1");
            Console.WriteLine("2 - A2");
            Console.WriteLine("3 - AA");
            Console.WriteLine("4 - B1");
        }

        private static eLicenseType ConvertLicenseTypeToEnum(int i_LicenseTypeChoice)
        {
            eLicenseType licenseType;
            switch (i_LicenseTypeChoice)
            {
                case 1:
                    licenseType = eLicenseType.A1;
                    break;
                case 2:
                    licenseType = eLicenseType.A2;
                    break;
                case 3:
                    licenseType = eLicenseType.AA;
                    break;
                default:
                    licenseType = eLicenseType.B1;
                    break;
            }

            return licenseType;
        }
    }
}
