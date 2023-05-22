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
                customer.VechileState = eVechileState.Repairing;
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
                throw new MyArgumentException();
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
                throw new MyArgumentException();
            }
        }

        public void ChargeVechile(string i_LicensePlate, int i_MinutesToFill)
        {
            Customer customer;
            Electric electric;
            float hoursToFill;

            customer = getCustomerByLicensePlate(i_LicensePlate);
            electric = customer.Vechile.Engine as Electric;
            if (electric != null)
            {
                hoursToFill = (float)i_MinutesToFill / (float)60;
                electric.ChargeBattery(hoursToFill);
            }
            else
            {
                throw new MyArgumentException();
            }
        }

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

        public List<string> GetVechilesLicensePlatesAsString(bool v_IsFilter, eVechileState? i_StatusToFilter)
        {
            List<string> licensePlates = new List<string>();

            foreach (KeyValuePair<string,Customer> pair in m_Customers)
            {
                if (v_IsFilter)
                {
                    if (pair.Value.VechileState==i_StatusToFilter.Value)
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
    }
}
