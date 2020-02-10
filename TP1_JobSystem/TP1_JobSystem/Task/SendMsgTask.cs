using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1_JobSystem.Traffic;

namespace TP1_JobSystem.Task
{
    public class SendMsgTask : TaskCommand
    {
        private System.Action notification;
        private String msg;
        //  private Flow flow;

        public void Execute()
        {
            notification = () => Console.WriteLine(this.msg + " --- > DONE ." + "\n \n");

            this.notification.Invoke();

            
            
        }

        public void Task(System.Action notification)
        {
            this.notification = notification;
        }

        public SendMsgTask(String msg, System.Action lambda)
        {
            this.notification = lambda;
            this.msg = msg;
          //  flow = new Flow(this);
        }

        public SendMsgTask(String msg)
        {
            this.msg = msg;
          //  flow = new Flow(this);
            
            notification = () => Console.WriteLine(msg + " : Message creation.");

        }

      /*  public Flow getFlow()
        {
            return flow;
        }*/
    }
}
