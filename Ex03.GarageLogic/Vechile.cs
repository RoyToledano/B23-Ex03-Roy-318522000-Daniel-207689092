using System;

namespace Ex03.GarageLogic
{
    internal class Vechile
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_CapacityStatus;
        private Wheel[] m_Wheels;

        public Wheel[] Wheels
        {
            get
            {
                return m_Wheels;
            }

            set
            {
                m_Wheels = value;
            }
        }


        public void updateData(string i_ModelName, string i_LicenseNumber,
        float i_CapacityStatus, float i_WheelPressure)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            m_CapacityStatus = i_CapacityStatus;
        }
    }

    
}
