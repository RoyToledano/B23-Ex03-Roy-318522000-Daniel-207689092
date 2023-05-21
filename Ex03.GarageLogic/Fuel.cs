using System;

namespace Ex03.GarageLogic
{
    internal class Fuel : Engine
    {
        internal enum eFuelType
        {
            Soler, Octan95, Octan96, Octan98
        }

        private eFuelType m_FuelType;
        private float m_VolumeStatusInLiters;
        private float m_MaxVolumeInLiters;

        public override void SetEngineData(string[] i_Arguments)
        {
            string fuelType = i_Arguments[0];

            setFuelTypeByName(fuelType);
            m_VolumeStatusInLiters = float.Parse(i_Arguments[1]);
            m_MaxVolumeInLiters = float.Parse(i_Arguments[2]);
        }

        private void setFuelTypeByName(string i_FuelTypeName)
        {
            switch (i_FuelTypeName)
            {
                case "Soler":
                    m_FuelType = eFuelType.Soler;
                    break;
                case "Octan95":
                    m_FuelType = eFuelType.Octan95;
                    break;
                case "Octan96":
                    m_FuelType = eFuelType.Octan96;
                    break;
                case "Octan98":
                    m_FuelType = eFuelType.Octan98;
                    break;
            }
        }

        public bool refuel(eFuelType i_FuelType, float i_LittersToFill)
        {
            return false; // to implement
        }
    }
}
