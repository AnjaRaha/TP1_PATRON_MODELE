using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1_JobSystem.Task;

namespace TP1_JobSystem.Traffic
{
    public class Flow

    {
        private TaskCommand task;

        public void Send()
        {
            this.task.Execute();
           
        }

        public void Receive(TaskCommand task)
        {

        }

        public Flow(TaskCommand task)
        {
            this.task = task;
        }

        public Flow()
        {

        }

        public void setTask(TaskCommand task)
        {
            this.task = task;
            task.Execute();
        }

        public TaskCommand getTask()
        {
            return this.task;

        }


    }
}
