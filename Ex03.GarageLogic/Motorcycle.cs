using System;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vechile
    {
        internal enum eLicenseType
        {
            A1, A2, AA, B1
        }

        const int k_NumOfWheels = 2;
        //data members
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        public override void UpdateSpecificData(string[] i_Arguments, string[] i_WheelArguments, string[] i_EngineArguments)
        {
            m_Wheels = new Wheel[k_NumOfWheels];
            setWheelsData(i_WheelArguments[0], float.Parse(i_WheelArguments[1]), float.Parse(i_WheelArguments[2]));
            setLicenseTypeByName(i_Arguments[0]);
            m_EngineVolume = int.Parse(i_Arguments[1]);
            m_Engine.SetEngineData(i_EngineArguments);
        }

        private void setLicenseTypeByName(string i_LicenseTypeName)
        {
            switch (i_LicenseTypeName)
            {
                case "A1":
                    m_LicenseType = eLicenseType.A1;
                    break;
                case "A2":
                    m_LicenseType = eLicenseType.A2;
                    break;
                case "AA":
                    m_LicenseType = eLicenseType.AA;
                    break;
                case "B1":
                    m_LicenseType = eLicenseType.B1;
                    break;
            }
        }
    }
}
