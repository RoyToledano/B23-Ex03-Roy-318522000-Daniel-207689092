using System;

namespace Ex03.GarageLogic
{
    internal class Car<T> : Engine<T> where T : new()
    {
        internal enum eColor
        {
            White, Black, Yellow, Red
        }

        const int k_NumOfWheels = 5;
        private eColor m_Color;
        private int m_NumOfDoors;

        public override void UpdateSpecificData(string[] i_Arguments, string[] i_WheelArguments, string[] i_EngineArguments)
        {
            m_Wheels = new Wheel[k_NumOfWheels];
            setWheelsData(i_WheelArguments[0], float.Parse(i_WheelArguments[1]), float.Parse(i_WheelArguments[2]));
            setColorByName(i_Arguments[0]);
            m_NumOfDoors= int.Parse(i_Arguments[1]);
            m_Engine = new T();
            callSetEngineData(m_Engine, i_EngineArguments);
        }

        private void setColorByName(string i_ColorName)
        {
            switch (i_ColorName)
            {
                case "Red":
                    m_Color = eColor.Red;
                    break;
                case "Black":
                    m_Color = eColor.Black;
                    break;
                case "Yellow":
                    m_Color = eColor.Yellow;
                    break;
                case "White":
                    m_Color = eColor.White;
                    break;
            }
        }

    }
}
