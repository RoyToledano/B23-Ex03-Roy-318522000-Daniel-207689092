using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eVechilesTypes
    {
        FueledCar, FueledMotorcycle, FueledTruck, ElectricCar, ElectricMotorcycle
    }

    class VechileCreator
    {
        public static Vechile GetVechileByType(eVechilesTypes i_VechileType, string i_LicenseNumber)
        {
            Vechile vechile = null;
            switch (i_VechileType)
            {
                case eVechilesTypes.FueledCar:
                    vechile = new Car<Fuel>();
                    break;
                case eVechilesTypes.FueledMotorcycle:
                    vechile = new Motorcycle<Fuel>();
                    break;
                case eVechilesTypes.FueledTruck:
                    vechile = new Truck<Fuel>();
                    break;
                case eVechilesTypes.ElectricCar:
                    vechile = new Car<Electric>();
                    break;
                case eVechilesTypes.ElectricMotorcycle:
                    vechile = new Motorcycle<Electric>();
                    break;
            }

            vechile.LicensePlateNumber = i_LicenseNumber;
            return vechile;
        }
    }
}
