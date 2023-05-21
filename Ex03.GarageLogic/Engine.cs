using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class Engine
    {

        public abstract void SetEngineData(string[] i_Arguments);

        public abstract string getEngineDetailsAsString();
    }
}
