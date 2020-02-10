using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1_JobSystem.Builder;
using TP1_JobSystem.Communication;
using TP1_JobSystem.Task;
using TP1_JobSystem.Traffic;

namespace TP1_JobSystem
{
    class Program
    {
        static void Main(string[] args)
        {
          

            //creéation propriétés communications 
            TypeCommunication typeCom = TypeCommunication.UDP;
            Property property = Property.COMPRESSED;

            //création flow builder
            FluxBuilder builder = 
                new FluxBuilder(6 ,typeCom, property);

            //création flow decorator
            FlowDecorator flowDecorator = builder.getResult();
            Console.WriteLine(flowDecorator.GetType().Name);


            // Création task executor
            TaskExecutor executor = new TaskExecutor(builder);
            flowDecorator.Executor = executor;

           

            //création de 2 taches
            SendMsgTask tache1 = new SendMsgTask("tache1"); flowDecorator.send(new Flow(tache1));
            SendMsgTask tache2 = new SendMsgTask("tache2"); flowDecorator.send(new Flow(tache2));
            SendMsgTask tache3 = new SendMsgTask("tache3"); flowDecorator.send(new Flow(tache3));
            SendMsgTask tache4 = new SendMsgTask("tache4"); flowDecorator.send(new Flow(tache4));
            SendMsgTask tache5 = new SendMsgTask("tache5"); flowDecorator.send(new Flow(tache5));
            Console.WriteLine("euh");

           /* executor.enqueue(tache1);
            executor.enqueue(tache2);
            executor.enqueue(tache3);
            executor.enqueue(tache4);
            executor.enqueue(tache5);*/

            executor.Start();
        
        }
    }
}
