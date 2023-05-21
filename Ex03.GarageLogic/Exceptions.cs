using System;

namespace Ex03.GarageLogic
{
    public class Exceptions : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public Exceptions(float i_MinValue, float i_MaxValue)
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }

        public override string Message
        {
            get
            {
                return "The argument entered is out of the range " + m_MinValue + " to " + m_MaxValue+".";
            }
        }
    }

    public class MyFormatException : FormatException
    {
        public override string Message
        {
            get
            {
                return "Data received in the wrong format.";
            }
        }
    }

    public class MyArgumentException : ArgumentException
    {
        public override string Message
        {
            get
            {
                return "This action is forbidden due to incompabaility of the argument with the procedure requested.";
            }
        }
    }
}
