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

        public static eVechilesTypes ConvertVechileTypeToEnum(int i_VechileChoice)
        {
            eVechilesTypes vechileType;
            switch (i_VechileChoice)
            {
                case 1:
                    vechileType = eVechilesTypes.FueledCar;
                    break;
                case 2:
                    vechileType = eVechilesTypes.FueledMotorcycle;
                    break;
                case 3:
                    vechileType = eVechilesTypes.FueledTruck;
                    break;
                case 4:
                    vechileType = eVechilesTypes.ElectricCar;
                    break;
                default:
                    vechileType = eVechilesTypes.ElectricMotorcycle;
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

            if (i_VechileType == eVechilesTypes.ElectricCar || i_VechileType == eVechilesTypes.FueledCar)
            {
                readData = new CarDataReader();
            }
            else if (i_VechileType == eVechilesTypes.ElectricMotorcycle || i_VechileType == eVechilesTypes.FueledMotorcycle)
            {
                readData = new MotorcycleDataReader();
            }
            else
            {
                readData = new TruckDataReader();
            }
            specficArguments=readData.GetSpecificData();

            return specficArguments;
        }
    }

}
