using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class Engine<T> : Vechile 
    {
        protected T m_Engine;

        protected void callSetEngineData(T i_Engine, string[] i_Arguments)
        {
            var methodInfo = i_Engine.GetType().GetMethod("SetEngineData");
            methodInfo?.Invoke(i_Engine, new object[] { i_Arguments });
        }
    }
}
