using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public abstract class DataReader
    {
        public abstract Object[] GetSpecificData();

        public abstract Object[] GetEngineData(eEngineTypes i_EngineType);

        protected Object[] createFuelDataArray(eFuelType i_FuelType, float i_MaxFuelTank)
        {
            Object[] engineArguments = new Object[3];
            float currentTankVolume;

            engineArguments[0] = i_FuelType;
            engineArguments[1] = i_MaxFuelTank;
            Console.WriteLine("Please enter the current fuel status in liters");
            currentTankVolume = Utilities.GetFloatNumber();
            engineArguments[2] = currentTankVolume;
            return engineArguments;
        }

        protected Object[] createElectricDataArray(float i_MaxBatteryVolume)
        {
            Object[] engineArguments = new Object[2];
            float currentBatteryHours;

            engineArguments[0] = i_MaxBatteryVolume;
            Console.WriteLine("Pleas enter the amount of hours left in the battery");
            currentBatteryHours = Utilities.GetFloatNumber();
            engineArguments[1] = currentBatteryHours;
            return engineArguments;
        }
    }
}
