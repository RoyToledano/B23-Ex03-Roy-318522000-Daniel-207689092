using System;

namespace Ex03.GarageLogic
{

    internal class Electric : Engine
    {
        // Data Members:
        private float m_HoursLeftInBattery;
        private float m_MaxHoursInBattery;

        public float HoursLeftInBattery
        {
            get
            {
                return m_HoursLeftInBattery;
            }
        }

        public float MaxHoursInBattery
        {
            get
            {
                return m_MaxHoursInBattery;
            }
        }

        public override void SetEngineData(string[] i_Arguments)
        {
            m_MaxHoursInBattery = float.Parse(i_Arguments[0]);
            m_HoursLeftInBattery = float.Parse(i_Arguments[1]);
        }

        internal void ChargeBattery(float i_HoursToCharge)
        {
            float sumOfBatteryHours;
            float maxCurrentAmountToCharge = m_MaxHoursInBattery - m_HoursLeftInBattery;

            sumOfBatteryHours = i_HoursToCharge + m_HoursLeftInBattery;
            if (sumOfBatteryHours > m_MaxHoursInBattery)
            {
                throw new ValueOutOfRangeException(0, maxCurrentAmountToCharge);
            }

            m_HoursLeftInBattery = sumOfBatteryHours;
        }

        public override string getEngineDetailsAsString()
        {
            string formattedStr;

            formattedStr = string.Format("Battery Status: {0} hours left\n", m_HoursLeftInBattery);

            return formattedStr;
        }

        public override float GetEngineCapacityStatus()
        {
            return ((m_HoursLeftInBattery / m_MaxHoursInBattery) * 100);
        }
    }
}
