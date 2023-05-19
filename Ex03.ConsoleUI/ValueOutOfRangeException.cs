using System;

namespace Ex03.ConsoleUI
{
    public class ValueOutOfRangeException : Exception
    {
        private float MaxValue;
        private float MinValue;
    }
}
