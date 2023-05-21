using System;

namespace Ex03.GarageLogic
{
    public enum eVechileState
    {
        Repairing, Repaired, Paid
    }
    public class Customer
    {
        private string m_NameOfOwner;
        private string m_PhoneNumberOfOwner;
        private eVechileState m_VechileState;
        private Vechile m_Vechile = null;

        internal string NameOfOwner
        {
            get
            {
                return m_NameOfOwner;
            }
        }

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

        internal eVechileState VechileState
        {
            get
            {
                return m_VechileState;
            }

            set
            {
                m_VechileState = value;
            }
        }

        public Customer(string i_Name, string i_PhoneNumber)
        {
            m_NameOfOwner=i_Name;
            m_PhoneNumberOfOwner = i_PhoneNumber;
            VechileState = eVechileState.Repairing;
        }
    }
}
