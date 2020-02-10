using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1_JobSystem.Task;

namespace TP1_JobSystem.Traffic
{
    public class FlowDecorator
    {
        private Flow data;
        protected TaskExecutor executor;

        public TaskExecutor Executor { get => executor; set => executor = value; }

        public FlowDecorator(Flow _data)
        {
            this.data = _data;
           
        }

        public FlowDecorator()
        {
            //data = new Flow();
            this.executor = new TaskExecutor();
        }

       
       public virtual void send(Flow flow)
        {
            Console.WriteLine("Sending task to executor");
            this.executor.enqueue(flow.getTask());

        }

        public void receive()
        {

        }
    }
}
