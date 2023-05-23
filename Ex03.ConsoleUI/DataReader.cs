using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public abstract class DataReader
    {
        public abstract string[] GetSpecificData();

        public abstract string[] GetEngineData(eEngineTypes i_EngineType);

        protected string[] createFuelDataArray(eFuelType i_FuelType, float i_MaxFuelTank)
        {
            string[] engineArguments = new string[3];
            float currentTankVolume;

            engineArguments[0] = i_FuelType.ToString();
            engineArguments[1] = i_MaxFuelTank.ToString();
            Console.WriteLine("Please enter the current fuel status in liters");
            currentTankVolume = Utilities.GetFloatNumber();
            engineArguments[2] = currentTankVolume.ToString();
            return engineArguments;
        }

        protected string[] createElectricDataArray(float i_MaxBatteryVolume)
        {
            string[] engineArguments = new string[2];
            float currentBatteryHours;

            engineArguments[0] = i_MaxBatteryVolume.ToString();
            Console.WriteLine("Pleas enter the amount of hours left in the battery");
            currentBatteryHours = Utilities.GetFloatNumber();
            engineArguments[1] = currentBatteryHours.ToString();
            return engineArguments;
        }
    }
}
