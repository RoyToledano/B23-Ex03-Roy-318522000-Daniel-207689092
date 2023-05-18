using System;

namespace Ex03.GarageLogic
{
    public class Customer
    {
        internal enum eVechileState
        {
            InRepair, Repaired, Paid
        }

        private string m_NameOfOwner;
        private string m_PhoneNumberOfOwner;
        private eVechileState m_VechileState;
        private Vechile m_Vechile = null;

        internal Vechile Vechile
        {
            set
            {
                m_Vechile = value;
            }

            get
            {
                return m_Vechile;
            }
        }


        public Customer(string i_Name, string i_PhoneNumber)
        {
            m_NameOfOwner=i_Name;
            m_PhoneNumberOfOwner = i_PhoneNumber;
            m_VechileState = eVechileState.InRepair;
        }
    }
}
