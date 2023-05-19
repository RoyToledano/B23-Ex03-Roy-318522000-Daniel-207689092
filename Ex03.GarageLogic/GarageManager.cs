using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Ex03.GarageLogic
{
    public enum eVechilesTypes
    {
        FueledCar, FueledMotorcycle, FueledTruck, ElectricCar, ElectricMotorcycle
    }

    public class GarageManager
    {
        

        // Data Members:
        private Dictionary<string, Customer> m_Customers;

        private void addNewCustomer(string i_CustomerName, string i_CustomerPhoneNumber, eVechilesTypes i_VechileType)
        {
            Customer customer = new Customer(i_CustomerName,i_CustomerPhoneNumber);
            Vechile vechile= getVechileByType(i_VechileType);



        }

        private Vechile getVechileByType(eVechilesTypes i_VechileType)
        {
            Vechile vechile=null;
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

            return vechile;
        }

    }
}
