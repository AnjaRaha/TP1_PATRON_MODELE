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
        public void compress(Flow _flow)
        {
            Console.WriteLine("***** COMPRESSION ******");
        }
    }
}
