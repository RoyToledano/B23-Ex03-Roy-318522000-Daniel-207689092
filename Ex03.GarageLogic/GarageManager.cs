using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        public enum eVechilesTypes
        {
            FueledCar,FueledMotorcycle,FueledTruck,ElectricCar,ElectricMotorcycle
        }

        // Data Members:
        private Dictionary<string, Customer> m_Customers;

        private void addNewCustomer(string i_CustomerName, string i_CustomerPhoneNumber,eVechilesTypes i_VechileType)
        {
            Customer customer = new Customer(i_CustomerName,i_CustomerPhoneNumber);
            Vechile vechile;

            switch (i_VechileType)
            {
                case eVechilesTypes.FueledCar:
                    vechile = new Car<Fuel>();
                    customer.Vechile = vechile;
                    break;
                case eVechilesTypes.FueledMotorcycle:
                    vechile = new Motorcycle<Fuel>();
                    customer.Vechile = vechile;
                    break;
                case eVechilesTypes.FueledTruck:
                    vechile = new Truck<Fuel>();
                    customer.Vechile = vechile;
                    break;
                case eVechilesTypes.ElectricCar:
                    vechile = new Car<Electric>();
                    customer.Vechile = vechile;
                    break;
                case eVechilesTypes.ElectricMotorcycle:
                    vechile = new Motorcycle<Electric>();
                    customer.Vechile = vechile;
                    break;
            }
        }

    }
}
