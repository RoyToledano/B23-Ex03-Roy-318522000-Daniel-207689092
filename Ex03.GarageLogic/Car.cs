﻿using System;

namespace Ex03.GarageLogic
{
    internal class Car<T> : Vechile<T>
    {
        internal enum eColor
        {
            White, Black, Yellow, Red
        }

        // Data Members:
        private eColor m_Color;
        private int m_NumOfDoors;


    }
}
