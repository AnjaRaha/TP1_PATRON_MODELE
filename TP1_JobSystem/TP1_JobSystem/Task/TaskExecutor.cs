using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TP1_JobSystem.Builder;
using TP1_JobSystem.Communication;


namespace TP1_JobSystem.Task
{
    public class TaskExecutor
    {
        private List<TaskCommand> queue { get; set; }
        private List<Thread> threads { get; set; }

        private ComFactory modeCommunication;
        private FluxBuilder builder;




        public TaskExecutor(List<TaskCommand> tasks, List<Thread> threads)
        {
            queue = tasks;
            this.threads = threads;
         
        }
        
      

        public TaskExecutor(FluxBuilder builder)
        {
            threads = new List<Thread>(builder.getNumThread());
            queue = new List<TaskCommand>();
           
            int nbThreads = builder.getNumThread();
            for (int iterateurThread = 0; iterateurThread < nbThreads; iterateurThread++)
            {
                Thread newThread = new Thread(new ThreadStart(Work)) { Name = "Thread " + iterateurThread.ToString() };
                newThread.Start();
                threads.Add(newThread);
            }

            //Console.WriteLine("COUNT " +  threads.Count);
            
        }

        public TaskExecutor()
        {
        }

        public void Start()
        {
            Work();
        }
        public void Stop()
        {
            foreach (Thread thr in threads)
            {
                thr.Abort();
            }
        }

        public async void Work()
        {

            while (queue.Count >= 0)
            {


                 if (queue.Count >= 1)
                  {


                
                TaskCommand taskTemplate = (TaskCommand)queue.First();                    
                queue.Remove(taskTemplate);

                //builder.getFlow().setTask(taskTemplate);

                Console.WriteLine(String.Concat("Thread Name = ", Thread.CurrentThread.Name));
                    taskTemplate.Execute();

                // test de l'affichage

                await System.Threading.Tasks.Task.Delay(500);



                   }
                
                    
            

            }
            //on met le thread courant à la fin de la liste de threads
            Thread currentThread = threads.First();
            threads.Remove(currentThread);
          


            Thread.Sleep(500);
            threads.Add(currentThread);

        }

           

        

       
        public void enqueue(TaskCommand _task)
        {
            queue.Add(_task);
        }

        public int getNumThread()
        {
            return threads.Count;
        }



    }
}
