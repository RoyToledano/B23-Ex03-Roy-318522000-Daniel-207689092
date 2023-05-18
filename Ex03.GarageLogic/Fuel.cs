using System;

namespace Ex03.GarageLogic
{
    internal class Fuel
    {
        internal enum eFuelType
        {
            Soler, Octan95, Octan96, Octan98
        }

        private eFuelType m_FuelType;
        private float m_VolumeStatusInLiters;
        private float m_MaxVolumeInLiters;

        private bool refuel(eFuelType i_FuelType, float i_LittersToFill)
        {
            return false; // to implement
        }
    }
}
