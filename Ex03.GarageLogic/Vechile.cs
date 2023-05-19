using System;

namespace Ex03.GarageLogic
{
    internal class Vechile
    {
        //add defins to num of wheels in "Createwheels'"...
        private string m_ModelName;
        private string m_LicensePlateNumber;
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

        public string LicensePlateNumber 
        {
            get
            {
                return m_LicensePlateNumber;
            }

            set
            {
                m_LicensePlateNumber = value;
            }
        }

        public float CapacityStatus
        {
            get
            {
                 return m_CapacityStatus;
            }

            set
            {
                m_CapacityStatus = value;
            }
        }

        public void updateBasicData(string i_ModelName, float i_CapacityStatus, float i_WheelPressure)
        {
            m_ModelName = i_ModelName;
            m_CapacityStatus = i_CapacityStatus;
        }
    }

    
}
