﻿using System;


namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vechile
    {
        internal enum eLicenseType
        {
            A1, A2, AA, B1
        }

        // Data Members:
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

    }
}
