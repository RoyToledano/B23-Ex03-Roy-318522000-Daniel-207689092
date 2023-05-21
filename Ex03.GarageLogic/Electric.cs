using System;

namespace Ex03.GarageLogic
{
    internal class Electric : Engine
    {
        private float m_HoursLeftInBattery;
        private float m_MaxHoursInBattery;



        public override void SetEngineData(string[] i_Arguments)
        {
            m_HoursLeftInBattery = float.Parse(i_Arguments[0]);
            m_MaxHoursInBattery = float.Parse(i_Arguments[1]);
        }

        public void ChargeBattery(float i_HoursToCharge)
        {
            float sumOfBatteryHours;

            sumOfBatteryHours = i_HoursToCharge + m_HoursLeftInBattery;
            if (sumOfBatteryHours > m_MaxHoursInBattery)
            {
                throw new ValueOutOfRangeException(0, m_MaxHoursInBattery);
            }

            m_HoursLeftInBattery = sumOfBatteryHours;
        }

        public override string getEngineDetailsAsString()
        {
            string formattedStr;

            formattedStr = string.Format("Current Volume: {0}\n", m_HoursLeftInBattery);

            return formattedStr;
        }
    }
}
