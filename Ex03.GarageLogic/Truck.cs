﻿using System;

namespace Ex03.GarageLogic
{
    internal class Truck : Vechile
    {
        const float k_MaxAirPressure = 26;
        const int k_NumOfWheels = 14;
        // Data Members
        private bool m_IsContainToxicMaterial;
        private float m_CargoVolume;


        public override void UpdateSpecificData(string[] i_Arguments, string[] i_WheelArguments, string[] i_EngineArguments)
        {
            m_Wheels = new Wheel[k_NumOfWheels];
            setWheelsData(i_WheelArguments[0], float.Parse(i_WheelArguments[1]), k_MaxAirPressure);
            setIsContainToxicMaterial(i_Arguments[0]);
            m_CargoVolume = float.Parse(i_Arguments[1]);
            m_Engine.SetEngineData(i_EngineArguments);
        }
       

        private void setIsContainToxicMaterial(string i_IsContainToxicMaterial)
        {
            if (i_IsContainToxicMaterial=="True")
            {
                m_IsContainToxicMaterial = true;
            }
            else
            {
                m_IsContainToxicMaterial = false;
            }    
        }
    }
}
