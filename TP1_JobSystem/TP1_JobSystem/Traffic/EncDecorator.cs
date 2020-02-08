using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_JobSystem.Traffic
{
    public class EncDecorator : FlowDecorator
    {
        public EncDecorator(Flow _data) : base(_data)
        {

        }

        public void encrypt(Flow _flow)
        {
            Console.WriteLine("***** ENCRYPTION ******");
        }


    }
}
