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
        static SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(2);




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
            Console.WriteLine("*******Taille de la Pool : "+ nbThreads + " threads ");
            Console.WriteLine();
            for (int iterateurThread = 0; iterateurThread < nbThreads; iterateurThread++)
            {
                Thread newThread = new Thread(new ThreadStart(Work)) { Name = "Thread " + iterateurThread.ToString() };
                newThread.Start();
                threads.Add(newThread);
            }

    
            
        }

        public TaskExecutor()
        {
        }

        public void Start()
        {
            Work();
          /* foreach(Thread thread in threads){
                thread.Start();
            }*/
        }
        public void Stop()
        {
            var fixedSize = threads.ToArray();
            foreach (Thread thread in fixedSize)
            {
                thread.Abort();
                Console.WriteLine("Arret de " + thread.Name);
            }

            Console.WriteLine();
           Console.WriteLine("Execution terminée");
           
        }




        /*********** FONCTION EFFECTUE ¨PAR LES THREADS ASYNCRONE *******/
        public async void Work()
        {
            /// Console.WriteLine(queue.Count + "= TAILLE INITIALE" );
            while (true)
            {

                while (queue.Count >= 1)
                {
                    if (this.threads.First().Equals(Thread.CurrentThread))
                    {
                        TaskCommand taskTemplate = (TaskCommand)queue.First();

                        try
                        {
                            this.RemoveTask(taskTemplate);
                            Console.WriteLine(String.Concat(" ********* Executed by ", Thread.CurrentThread.Name));
                            taskTemplate.Execute();
                            await _semaphoreSlim.WaitAsync();

                        }

                        finally
                        {

                            _semaphoreSlim.Release();
                            Thread currentThread = threads.First();
                            threads.Remove(currentThread);

                            Thread.Sleep(500);
                            threads.Add(currentThread);
                        }


                    }

                }

            }
        }

       
        public void enqueue(TaskCommand _task)
        {
            lock (queue)
            {
                queue.Add(_task);
            }
           
        }

        public void RemoveTask(TaskCommand _task)
        {
            lock (queue)
            {
                queue.Remove(_task);
            }
        }

        public int getNumThread()
        {
            return threads.Count;
        }

        public TaskCommand getFirst()
        {
            TaskCommand firstTask = null;
            lock (queue)
            {
                if (queue.Count > 0)
                {
                    firstTask = queue.First();
                }
              
            }
            return firstTask;
        }


    }
}
