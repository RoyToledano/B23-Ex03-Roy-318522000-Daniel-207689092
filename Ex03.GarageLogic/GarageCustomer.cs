using System;

namespace Ex03.GarageLogic
{
    public class GarageCustomer
    {
        internal enum eVechileState
        {
            InRepair, Repaired, Paid
        }

        private string m_NameOfOwner;
        private string m_PhoneNumberOfOwner;
        private eVechileState m_VechileState;
    }
}
