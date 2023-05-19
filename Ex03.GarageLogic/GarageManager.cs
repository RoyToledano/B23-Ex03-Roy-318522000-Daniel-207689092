using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Ex03.GarageLogic
{
   

    public class GarageManager
    {
        

        // Data Members:
        private Dictionary<string, Customer> m_Customers;

        public void AddNewCustomer(string i_CustomerName, string i_CustomerPhoneNumber, string i_LicensePlateNumber, eVechilesTypes i_VechileType)
        {
            Customer customer = new Customer(i_CustomerName,i_CustomerPhoneNumber);
            Vechile vechile= VechileCreator.GetVechileByType(i_VechileType, i_LicensePlateNumber);
            customer.Vechile = vechile;
            m_Customers.Add(i_LicensePlateNumber,customer);
        }

        public void SetVechileDataToCustomer(string i_LicensePlate, string i_ModelName,float i_CapacityStatus,string[] i_SpecificArguments,
            string[] i_WheelArguments, string[] i_EngineArguments)
        {
            Customer customer = m_Customers[i_LicensePlate];

            customer.Vechile.UpdateBasicData(i_ModelName, i_CapacityStatus);
            customer.Vechile.UpdateSpecificData(i_SpecificArguments, i_WheelArguments);
            //find a way to make engine arguments added to the database
        }
    }
}
