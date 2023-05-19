using System;

namespace Ex03.GarageLogic
{
    internal abstract class Vechile 
    {
        //add defins to num of wheels in "Createwheels'"...
        protected string m_ModelName;
        protected string m_LicensePlateNumber;
        protected float m_CapacityStatus;
        protected Wheel[] m_Wheels;

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

        public void UpdateBasicData(string i_ModelName, float i_CapacityStatus)
        {
            m_ModelName = i_ModelName;
            m_CapacityStatus = i_CapacityStatus;
        }

        public abstract void UpdateSpecificData(string[] i_Arguments, string[] i_WheelArguments,string[] i_EngineArguments);

        protected void setWheelsData(string i_ManufacturerName, float i_CurrentWheelPressure,
            float i_MaximumWheelPressure)
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.ManufacturerName = i_ManufacturerName;
                wheel.MaximumPressure = i_MaximumWheelPressure;
                wheel.PressureStatus = i_CurrentWheelPressure;
            }
        }


    }

    
}
