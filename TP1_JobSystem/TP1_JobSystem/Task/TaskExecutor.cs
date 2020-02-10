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
      
        static SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(0);




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



        /************ SECOURS ************/
       /* public async void Work()
        {
            while (true)
            {
                while (queue.Count > 1)
                {


                    lock (queue.First())
                    {

                        TaskCommand taskTemplate = (TaskCommand)queue.First();
                        queue.Remove(taskTemplate);

                        //builder.getFlow().setTask(taskTemplate);

                        Console.WriteLine(String.Concat("Thread Name = ", Thread.CurrentThread.Name));
                        taskTemplate.Execute();

                   }
                    Thread currentThread = threads.First();
                    threads.Remove(currentThread);



                    Thread.Sleep(500);
                    threads.Add(currentThread);


                }
            }
        }
        */

        /*********** SEMAPHORE ASYNCRONE *******/
        public async void Work()
        {
           /// Console.WriteLine(queue.Count + "= TAILLE INITIALE" );
            while (true)
            {

                while (queue.Count > 0)
                {
                   

                    if (queue.Count >= 1)
                    {
                        

                        TaskCommand taskTemplate = (TaskCommand)queue.First();
                        
                        queue.Remove(taskTemplate);

                        Console.WriteLine(String.Concat("Thread Name = ", Thread.CurrentThread.Name));
                        taskTemplate.Execute();


                        

                        //builder.getFlow().setTask(taskTemplate);

                        try
                        {

                            await _semaphoreSlim.WaitAsync();

                        }

                        finally
                        {

                            _semaphoreSlim.Release();
                        }




                    }





                    // await System.Threading.Tasks.Task.Delay(500);

                    if (threads.Count > 1)
                    {
                        Thread currentThread = threads.First();
                       threads.Remove(currentThread);



                      //  Thread.Sleep(500);
                        threads.Add(currentThread);
                       

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

        public int getNumThread()
        {
            return threads.Count;
        }



    }
}
