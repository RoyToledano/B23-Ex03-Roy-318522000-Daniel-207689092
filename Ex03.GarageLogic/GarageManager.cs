using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Ex03.GarageLogic
{
   

    public class GarageManager
    {
        

        // Data Members:
        private Dictionary<string, Customer> m_Customers;

        public void addNewCustomer(string i_CustomerName, string i_CustomerPhoneNumber, string i_LicensePlateNumber, eVechilesTypes i_VechileType)
        {
            Customer customer = new Customer(i_CustomerName,i_CustomerPhoneNumber);
            Vechile vechile= VechileCreator.GetVechileByType(i_VechileType, i_LicensePlateNumber);
            customer.Vechile = vechile;
            m_Customers.Add(i_LicensePlateNumber,customer);
        }



       

    }
}
