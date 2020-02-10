using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_JobSystem.Traffic
{
    public class CompDecorator : FlowDecorator
    {
        public CompDecorator(Flow _data) : base(_data)
        {

        }
        public override void send(Flow _flow)
        {
            Console.WriteLine("***** COMPRESSION ******");
            Console.WriteLine("Sending task to executor");
            this.executor.enqueue(_flow.getTask());
            //this.send(_flow);
        }
    }
}
