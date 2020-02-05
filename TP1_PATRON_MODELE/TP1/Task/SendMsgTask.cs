using System;
using System.Linq.Expressions;

namespace TP1.Task
{
    public class SendMsgTask : Task
    {
        private System.Action lambda;
        private String msg;
        public void Execute()
        {
            Console.WriteLine("Sending message...");
        }

        public void Task(System.Action lambda)
        {
            this.lambda = lambda;
        }

        public SendMsgTask(String msg , System.Action lambda)
        {
            this.lambda = lambda;
            this.msg = msg;
        }
    }
}