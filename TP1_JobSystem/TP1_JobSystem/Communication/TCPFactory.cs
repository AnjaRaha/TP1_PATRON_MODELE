using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1_JobSystem.Traffic;

namespace TP1_JobSystem.Communication
{
    class TCPFactory : ComFactory
    {
        public Flow CreateFlux()
        {        
                return  new TCPFlux();
          
        }
    }
}
