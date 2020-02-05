using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TP1.Builder;
using TP1.Communication;

namespace TP1.Task
{
    public class TaskExecutor
    {
        private List <Task> queue { get; set; }
        private List<Thread> threads { get; set; }
        
        private ComFactory modeCommunication;

        private object queueLock;
        
        public TaskExecutor(List<Task> tasks, List<Thread> threads)
        {
            queue = tasks;
            this.threads = threads;
            queueLock = new object();
        }

        public TaskExecutor(FluxBuilder _builder)
        {
            threads= new List<Thread>(_builder.getNumThread());
            queue = new List<Task>();
            queueLock = new object();
            int nbThreads = threads.Count;
            for(int iterateurThread=0; iterateurThread < nbThreads; iterateurThread++)
            {
                Thread newThread = new Thread(new ThreadStart(Work)) { Name = "Thread " + (iterateurThread)};
                newThread.Start();
                threads.Add(newThread);
            }
        }
        public void Start()
        {
            Work();
        }
        public void Stop()
        {
            foreach (Thread thr  in threads )
            {
                thr.Abort();   
            }
        }

        public void Work()
        {
            lock (queueLock)
            {
                 Task taskTemplate =(Task) queue.First();
                 queue.Remove(queue.First());
                 taskTemplate.Execute();
            }
        }

        public void enqueue(Task _task)
        {
            queue.Add(_task);
        }

        

    }
}