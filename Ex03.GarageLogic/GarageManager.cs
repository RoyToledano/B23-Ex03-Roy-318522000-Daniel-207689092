using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Ex03.GarageLogic
{
   

    public class GarageManager
    {
        

        // Data Members:
        private Dictionary<string, Customer> m_Customers;

        public GarageManager()
        {
            m_Customers = new Dictionary<string, Customer>();
        }


        public void AddNewCustomer(string i_CustomerName, string i_CustomerPhoneNumber,
                                   string i_LicensePlateNumber, eVechilesTypes i_VechileType,
                                   eEngineTypes i_EngineType)
        {
            Customer customer = new Customer(i_CustomerName,i_CustomerPhoneNumber);
            Vechile vechile = VechileCreator.GetVechileByType(i_VechileType, i_LicensePlateNumber, i_EngineType);
            customer.Vechile = vechile;
            m_Customers.Add(i_LicensePlateNumber,customer);
        }

        public void SetVechileDataToCustomer(string i_LicensePlate, string i_ModelName,float i_CapacityStatus,string[] i_SpecificArguments,
            string[] i_WheelArguments, string[] i_EngineArguments)
        {
            Customer customer = m_Customers[i_LicensePlate];

            customer.Vechile.UpdateBasicData(i_ModelName, i_CapacityStatus);
            customer.Vechile.UpdateSpecificData(i_SpecificArguments, i_WheelArguments,i_EngineArguments);
            //find a way to make engine arguments added to the database
        }

        public bool IsCustomerExist(string i_LicensePlate)
        {
            Customer customer;
            bool v_IsExist=false;

            if (m_Customers.TryGetValue(i_LicensePlate,out customer))
            {
                customer.VechileState = eVechileState.InRepair;
                v_IsExist = true;
            }

            return v_IsExist;
        }

        public void UpdateVechileState(string i_LicensePlate, eVechileState i_WantedVechileState)
        {
            Customer customer;

            customer = getCustomerByLicensePlate(i_LicensePlate);
            customer.VechileState = i_WantedVechileState;
        }

        public void InflateAllWheelsToMax(string i_LicensePlate)
        {
            Customer customer;

            customer = getCustomerByLicensePlate(i_LicensePlate);
            foreach (Wheel wheel in customer.Vechile.Wheels)
            {
                wheel.PressureStatus = wheel.MaximumPressure;
            } 
        }

        private Customer getCustomerByLicensePlate(string i_LicensePlate)
        {
            Customer customer;

            if (!m_Customers.TryGetValue(i_LicensePlate, out customer))
            { 
                throw new ArgumentException();
            }

            return customer;
        }

        public void RefuelVechile(string i_LicensePlate, eFuelType i_FuelType, float i_AmountToFill)
        {
            Customer customer;
            Fuel fuel;

            customer = getCustomerByLicensePlate(i_LicensePlate);
            fuel = customer.Vechile.Engine as Fuel;
            if (fuel!=null)
            {
                fuel.Refuel(i_FuelType, i_AmountToFill);
            }
            else
            {
                throw new ArgumentException();
            }

        }

        
    }
}
