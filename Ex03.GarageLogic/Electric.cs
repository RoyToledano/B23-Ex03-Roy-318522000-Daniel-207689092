using System;

namespace Ex03.GarageLogic
{
    internal class Electric
    {
        private float m_HoursLeftInBattery;
        private float m_MaxHoursInBattery;



        public void SetEngineData(string[] i_Arguments)
        {
            m_HoursLeftInBattery = float.Parse(i_Arguments[0]);
            m_MaxHoursInBattery = float.Parse(i_Arguments[1]);
        }

        public void chargeBattery(float i_HoursToCharge)
        {
            //to implement
        }
    }
}
