using System;

namespace Ex03.GarageLogic
{
    internal class Vechile<T>
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_CapacityStatus;
        private Wheel[] m_Wheels;
        private T Engine;
    }
}
