using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1_JobSystem.Traffic;

namespace TP1_JobSystem.Communication
{
    public class ComFactory
    {
     

        private Flow CreateFlux()
        {
            return new Flow();
        }
    }
}
