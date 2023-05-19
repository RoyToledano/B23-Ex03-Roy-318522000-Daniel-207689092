using System;

namespace Ex03.ConsoleUI
{
    class TruckDataReader : DataReader
    {
        public override string[] GetSpecificData()
        {
            int isToxic;
            string isToxicStr;
            string[] truckArguments = new string[2];

            Console.WriteLine("If the truck carries dangerous material, type 1, else - type 0");
            isToxic = Utilities.GetSingleNumInRange(0, 1);
            if (isToxic==1)
            {
                isToxicStr = "True";
            }
            else
            {
                isToxicStr = "False";
            }
            truckArguments[0] = isToxicStr;
            Console.WriteLine("Please enter the cargo volume");
            truckArguments[1] = Utilities.GetFloatNumber().ToString();

            return truckArguments;
        }
    }
}
