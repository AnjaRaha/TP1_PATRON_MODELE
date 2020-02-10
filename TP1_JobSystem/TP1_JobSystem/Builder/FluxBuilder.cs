using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1_JobSystem.Communication;
using TP1_JobSystem.Traffic;

namespace TP1_JobSystem.Builder
{
    public class FluxBuilder : Builder
    {
        private FlowDecorator _flowDecorator;
        private Flow flow;
        private int NumThread;
        private TypeCommunication _typeCom;
        private Property property;

        public FluxBuilder(int numThread, TypeCommunication typeCom, Property property)
        {
            setNumThread(numThread);
            setProtocol(typeCom);
            setFluxProperty(property);
            
        }

        public int getNumThread()
        {
            return NumThread;
        }

        public FlowDecorator getResult()
        {
            return _flowDecorator;
        }

        public void setNumThread(int nombreThreads)
        {
            NumThread = nombreThreads;
        }

        public void setFluxProperty(Property property)
        {
            this.property = property;

            if (property.Equals(Property.CLEAR))
            {
                Console.WriteLine("*******Propriété d'envoi : CLEAR -------> Création decorator CLEAR flow");
                Console.WriteLine();
                _flowDecorator = new ClearDecorator(this.flow); 
            }

            if (property.Equals(Property.COMPRESSED))
            {
                Console.WriteLine("*******Propriété d'envoi : COMPRESSED -------> Création decorator COMPRESSED flow");
                Console.WriteLine();
                _flowDecorator = new CompDecorator(this.flow);
            }
            if (property.Equals(Property.ENCRYPTED))
            {
                Console.WriteLine("*******Propriété d'envoi : ENCRYPTED -------> Création decorator ENCRYPTED flow");
                Console.WriteLine();
                _flowDecorator = new EncDecorator(this.flow);
            }
        }

      

        public void setProtocol(TypeCommunication _typeCommunication)
        {

            this._typeCom = _typeCommunication;

            if (_typeCommunication.Equals(TypeCommunication.UDP))
            {
                Console.WriteLine("*******Type de communication : UDP -------> Création flux UDP ");
                Console.WriteLine();
                UDPFactory udpFactory = new UDPFactory();
                this.flow = udpFactory.CreateFlux();
            }

            if (_typeCommunication.Equals(TypeCommunication.TCP))
            {
                Console.WriteLine("*******Type de communication : TCP -------> Création flux TCP ");
                Console.WriteLine();
                TCPFactory tcpFactory = new TCPFactory();
                this.flow = tcpFactory.CreateFlux();
            }



        }

        public Flow getFlow()
        {
            return this.flow;
        }
    }
}
