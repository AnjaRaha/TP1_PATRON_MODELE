using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1_JobSystem.Communication;

namespace TP1_JobSystem.Builder
{
    public interface Builder
    {
        void setNumThread(int nombreThreads);
        void setFluxProperty(Property _typeProtocol);

        void setProtocol(TypeCommunication _typeCommunication);
    }
}
