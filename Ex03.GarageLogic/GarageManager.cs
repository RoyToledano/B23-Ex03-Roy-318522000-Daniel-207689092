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
            Vechile vechile;

            switch (i_VechileType)
            {
                case eVechilesTypes.Car:
                    vechile = new Car<Fuel>();
                    customer.Vechile = vechile;
                    break;
                case eVechilesTypes.Motorcycle:
                    vechile = new Motorcycle<Fuel>();
                    customer.Vechile = vechile;
                    break;
                case eVechilesTypes.Truck:
                    vechile = new Truck<Fuel>();
                    customer.Vechile = vechile;
                    break;
                
            }
        }

        private 

    }
}
