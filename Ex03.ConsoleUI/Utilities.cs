using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class Utilities
    {
        public static int GetSingleNumInRange(int i_Start, int i_End)
        {
            string strNum = Console.ReadLine();
            int num;

            if (int.TryParse(strNum,out num))
            {
                if (!(num >= i_Start && num <= i_End))
                {
                    throw new ValueOutOfRangeException();
                }
            }
            else
            {
                throw new FormatException();
            }

            return num;
        }

        public static string GetAlphabeticString()
        {
            string str=Console.ReadLine();
            bool v_isAlphaExist = false; //to make sure that a blank string won't be accepted

            foreach (char ch in str)
            {
                if ( (ch != ' ') && !char.IsLetter(ch))
                {
                    throw new FormatException();
                }
                else if (!v_isAlphaExist && char.IsLetter(ch))
                {
                    v_isAlphaExist = true;
                }
            }
            if (!v_isAlphaExist)
            {
                throw new FormatException();
            }

            return str;
        }

        public static string GetNumberAsString(int i_MinNumOfDigits,int i_MaxNumOfDigits)
        {
            string strNumber=Console.ReadLine();
            int strLength = strNumber.Length;

            if (strLength >= i_MinNumOfDigits && strLength <= i_MaxNumOfDigits)
            {
                foreach (char ch in strNumber)
                {
                    if (!char.IsDigit(ch))
                    {
                        throw new FormatException();
                    }
                }
            }
            else
            {
                throw new ValueOutOfRangeException();
            }

            return strNumber;
        }

        public static eVechilesTypes ConvertVechileTypeToEnum(out eEngineTypes o_EngineType, int i_VechileChoice)
        {
            eVechilesTypes vechileType;
            switch (i_VechileChoice)
            {
                case 1:
                    vechileType = eVechilesTypes.Car;
                    o_EngineType = eEngineTypes.Fuel;
                    break;
                case 2:
                    vechileType = eVechilesTypes.Motorcycle;
                    o_EngineType = eEngineTypes.Fuel;
                    break;
                case 3:
                    vechileType = eVechilesTypes.Truck;
                    o_EngineType = eEngineTypes.Fuel;
                    break;
                case 4:
                    vechileType = eVechilesTypes.Car;
                    o_EngineType = eEngineTypes.Electric;
                    break;
                default:
                    vechileType = eVechilesTypes.Motorcycle;
                    o_EngineType = eEngineTypes.Electric;
                    break;
            }

            return vechileType;
        }

        public static float GetFloatNumber()
        {
            string strFloatNum=Console.ReadLine();
            float num;
           
            if (!float.TryParse(strFloatNum,out num))
            {
                throw new FormatException();
            }

            return num;
        }


        public static string[] GetSpecificData(eVechilesTypes i_VechileType)
        {
            DataReader readData;
            string[] specficArguments;

            switch(i_VechileType)
            {
                case eVechilesTypes.Car:
                    readData = new CarDataReader();
                    break;
                case eVechilesTypes.Motorcycle:
                    readData = new MotorcycleDataReader();
                    break;
                default:
                    readData = new TruckDataReader();
                    break;
            }

            specficArguments=readData.GetSpecificData();
            return specficArguments;
        }
    }

}
