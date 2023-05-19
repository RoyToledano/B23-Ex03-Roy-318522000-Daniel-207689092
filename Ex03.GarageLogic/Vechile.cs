using System;

namespace Ex03.GarageLogic
{
    internal class Vechile
    {
        //add defins to num of wheels in "Createwheels'"...
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

        public void CreateWheelsByType(eVechilesTypes i_VechileType)
        {
            if (i_VechileType == eVechilesTypes.ElectricCar || i_VechileType == eVechilesTypes.FueledCar)
            {
                m_Wheels = new Wheel[5];
            }
            else if (i_VechileType == eVechilesTypes.ElectricMotorcycle || i_VechileType == eVechilesTypes.FueledMotorcycle)
            {
                m_Wheels = new Wheel[2];
            }
            else
            {

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
