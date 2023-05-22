using System;

namespace Ex03.GarageLogic
{
    public enum eColor
    {
        White, Black, Yellow, Red
    }

    internal class Car : Vechile
    {
        // Const Members:
        const float k_MaxAirPressure = 33;
        const int k_NumOfWheels = 5;

        // Data Members:
        private eColor m_Color;
        private int m_NumOfDoors;

        public override void UpdateSpecificData(string[] i_Arguments, string[] i_WheelArguments, string[] i_EngineArguments)
        {
            m_Wheels = new Wheel[k_NumOfWheels];
            setWheelsData(i_WheelArguments[0], float.Parse(i_WheelArguments[1]), k_MaxAirPressure);
            setColorByName(i_Arguments[0]);
            m_NumOfDoors= int.Parse(i_Arguments[1]);
            m_Engine.SetEngineData(i_EngineArguments);
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

        public override string getSpecificVechileDetailsAsString()
        {
            string formattedStr;

            formattedStr = string.Format("Car Color: {0}\nNum of Doors: {1}\n", m_Color.ToString(), m_NumOfDoors);

            return formattedStr;
        }
    }
}
