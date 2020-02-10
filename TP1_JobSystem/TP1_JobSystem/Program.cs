using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

            /************************ INITIALISATION API - PARAMETRES  ********************/
            Console.WriteLine("/************************ INITIALISATION API ********************/");


            //construction : entrez les paramétres 
            /* Parametre 1 = nombre threads
             * Parametre 2 = Protocole communication
             * Parametre 3 = propriété flux
             */

            TypeCommunication typeCom = TypeCommunication.UDP; // enum UDP, TCP
            Property property = Property.COMPRESSED; // enum COMPRESSED, CLEAR, ENCRYPTED

            FluxBuilder builder = new FluxBuilder(3 ,typeCom, property);


            /************************ INITIALISATION API -  CONSOLE ********************/
           

            //création flow decorator
            FlowDecorator flowDecorator = builder.getResult();
         
            // Création task executor
            TaskExecutor executor = new TaskExecutor(builder);
            flowDecorator.Executor = executor;


            //simulation de taches et de leur traitement

            int iterateurTaches = 0;
            Console.WriteLine("Press ESC key to stop simulation");
            Console.WriteLine();

            do
            {
                
                while (!Console.KeyAvailable)
                {
                   

                    SendMsgTask tacheX = new SendMsgTask("tache" + iterateurTaches); flowDecorator.send(new Flow(tacheX));
                    iterateurTaches++;
                   
                    Console.WriteLine("*********Nombre de taches courant : " + iterateurTaches);
                    
                    //on simule un laps de temps avant de recevoir d'autres atches
                    Thread.Sleep(500);
                    

                }
                
                
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
           
            executor.Stop();
            Console.WriteLine("Envoi des taches effectués");    

        }
    }
}
