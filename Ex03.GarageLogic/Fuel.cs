using System;

namespace Ex03.GarageLogic
{
    public enum eFuelType
    {
        Soler, Octan95, Octan96, Octan98
    }
    internal class Fuel : Engine
    {

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


        public void Refuel(eFuelType i_FuelType, float i_AmountToFill)
        {
            float sumOfFuels;

           if (i_FuelType != m_FuelType)
            {
                throw new MyArgumentException();
            }

            sumOfFuels = i_AmountToFill + m_VolumeStatusInLiters;
            if (sumOfFuels>m_MaxVolumeInLiters)
            {
                throw new Exceptions(0,m_MaxVolumeInLiters);
            }

            m_VolumeStatusInLiters= sumOfFuels;
        }

        public override string getEngineDetailsAsString()
        {
            string formattedStr;

            formattedStr = string.Format("Fuel type: {0}\nCurrent Volume: {1} liters\n", m_FuelType.ToString(), m_VolumeStatusInLiters);

            return formattedStr;
        }
    }
}
