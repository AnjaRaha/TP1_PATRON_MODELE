using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_JobSystem.Task
{
    public interface TaskCommand
    {
        void Execute();

        void Task(System.Action Notification);
    }
}
