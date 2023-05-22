﻿using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    /*  Arguments array explanation:
        In order to allow the option of add other vechiles to the system,
        the vechile's specific arguments (such as doors for cars or cargo volume for truck, etc.)
        sent to the Garage Manager in a string array.
        The wheels and engine arguments are also sent in this way.
        All 3 arrays are being used in 'UpdateSpecificData' which is reimplemented in every vechile type class.
        Here are the array's details for each object:

        Car:                                                       Fuel:
        [0] - Car's color.                                         [0] - The fuel's type.
        [1] - Number of the car's doors.                           [1] - The current fuel tank's volume.
                                                                   [2] - The maximum fuel tank's volume.
        
        Motorcycle:                                                Electric:
        [0] - Motorcycle's license type.                           [0] - The current battery hours left.
        [1] - Motorcycle's engine volume.                          [1] - The maximum hours in the battery.
        
        Truck:                                                     Fuel's given string arguments details:
        [0] - Has 'true' in charecters if the truck's              [0] - The wheel's manufacturer name.
        cargo contain toxic materials, has 'false' if not.         [1] - The wheel's current air pressure.
        [1] - Truck's cargo volume.                                [2] - The wheel's maximum air pressure.

    */

    public class GarageManager
    {
        // Data Members:
        private Dictionary<string, Customer> m_Customers;


        public GarageManager()
        {
            m_Customers = new Dictionary<string, Customer>();
        }

        // Option #1 methods:
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
            try
            {
                customer.Vechile.UpdateBasicData(i_ModelName, i_CapacityStatus);
                customer.Vechile.UpdateSpecificData(i_SpecificArguments, i_WheelArguments, i_EngineArguments);
            }
            catch(Exception e)
            {
                m_Customers.Remove(i_LicensePlate);
                throw; // throw this exception to the mangerUI.
            }
            
        }

        public bool IsCustomerExist(string i_LicensePlate)
        {
            Customer customer;
            bool v_IsExist = false;

            if (m_Customers.TryGetValue(i_LicensePlate, out customer))
            {
                customer.VechileState = eVechileState.Repairing;
                v_IsExist = true;
            }

            return v_IsExist;
        }


        // Option #2 method:
        public List<string> GetVechilesLicensePlatesAsString(bool v_IsFilter, eVechileState? i_StatusToFilter)
        {
            List<string> licensePlates = new List<string>();

            foreach (KeyValuePair<string, Customer> pair in m_Customers)
            {
                if (v_IsFilter)
                {
                    if (pair.Value.VechileState == i_StatusToFilter.Value)
                    {
                        licensePlates.Add(pair.Key);
                    }
                }
                else
                {
                    licensePlates.Add(pair.Key);
                }
            }

            return licensePlates;
        }


        // Option #3 method:
        public void UpdateVechileState(string i_LicensePlate, eVechileState i_WantedVechileState)
        {
            Customer customer;

            customer = getCustomerByLicensePlate(i_LicensePlate);
            customer.VechileState = i_WantedVechileState;
        }


        // Option #4 method:
        public void InflateAllWheelsToMax(string i_LicensePlate)
        {
            Customer customer;

            customer = getCustomerByLicensePlate(i_LicensePlate);
            foreach (Wheel wheel in customer.Vechile.Wheels)
            {
                wheel.PressureStatus = wheel.MaximumPressure;
            } 
        }


        // Option #5 method:
        public void RefuelVechile(string i_LicensePlate, eFuelType i_FuelType, float i_AmountToFill)
        {
            Customer customer;
            Fuel fuel;
            float currentEngineLevel, maxEngineLevel;

            customer = getCustomerByLicensePlate(i_LicensePlate);
            fuel = customer.Vechile.Engine as Fuel;
            if (fuel!=null)
            {
                fuel.Refuel(i_FuelType, i_AmountToFill);
                currentEngineLevel = fuel.VolumeStatusInLiters;
                maxEngineLevel = fuel.MaxVolumeInLiters;
                customer.Vechile.CapacityStatus = ((currentEngineLevel / maxEngineLevel) * 100);
            }
            else
            {
                throw new OwnArgumentException("engine type");
            }
        }


        // Option #6 method:
        public void ChargeVechile(string i_LicensePlate, int i_MinutesToFill)
        {
            Customer customer;
            Electric electric;
            float hoursToFill;
            float currentEngineLevel, maxEngineLevel;

            customer = getCustomerByLicensePlate(i_LicensePlate);
            electric = customer.Vechile.Engine as Electric;
            if (electric != null)
            {
                hoursToFill = (float)i_MinutesToFill / (float)60;
                electric.ChargeBattery(hoursToFill);
                currentEngineLevel = electric.HoursLeftInBattery;
                maxEngineLevel = electric.MaxHoursInBattery;
                customer.Vechile.CapacityStatus = ((currentEngineLevel / maxEngineLevel) * 100);
            }
            else
            {
                throw new OwnArgumentException("engine type");
            }
        }


        // Option #7 method:
        public string GetVechileDetailsAsString(string i_LicensePlate)
        {
            Customer customer;
            Vechile vechile;
            string detailedVechileDataStr;

            customer = getCustomerByLicensePlate(i_LicensePlate);
            vechile = customer.Vechile;
            detailedVechileDataStr = string.Format("Owner name: {0}\nVechile repairing state: {1}\n", customer.NameOfOwner,customer.VechileState.ToString());

            detailedVechileDataStr += vechile.getBasicVechileDetailsAsString() + vechile.Engine.getEngineDetailsAsString()
                + vechile.getSpecificVechileDetailsAsString() + vechile.Wheels[0].getDetailsAsString();

            return detailedVechileDataStr;

        }


        // General method:
        private Customer getCustomerByLicensePlate(string i_LicensePlate)
        {
            Customer customer;

            if (!m_Customers.TryGetValue(i_LicensePlate, out customer))
            {
                throw new OwnArgumentException("license plate");
            }

            return customer;
        }

    }
}
