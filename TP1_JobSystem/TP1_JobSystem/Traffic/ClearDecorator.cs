using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_JobSystem.Traffic
{
    class ClearDecorator: FlowDecorator
    {
        public ClearDecorator(Flow _data) : base(_data)
        {

        }
        public void SendClear(Flow _flow)
        {
            Console.WriteLine("***** SENDING CLEAR ******");
           this.send(_flow);
        }
    }
}
