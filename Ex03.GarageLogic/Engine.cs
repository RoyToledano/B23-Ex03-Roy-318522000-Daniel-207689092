using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class Engine<T> : Vechile where T : new()
    {
        protected T m_Engine = new T();
    }
}
