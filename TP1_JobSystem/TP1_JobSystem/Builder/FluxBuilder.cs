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
                Console.WriteLine("Création decorator CLEAR flow");
                _flowDecorator = new ClearDecorator(this.flow); 
            }

            if (property.Equals(Property.COMPRESSED))
            {
                Console.WriteLine("Création decorator COMPRESSED flow");
                _flowDecorator = new CompDecorator(this.flow);
            }
            if (property.Equals(Property.ENCRYPTED))
            {
                Console.WriteLine("Création decorator ENCRYPTED flow");
                _flowDecorator = new EncDecorator(this.flow);
            }
        }

      

        public void setProtocol(TypeCommunication _typeCommunication)
        {

            this._typeCom = _typeCommunication;

            if (_typeCommunication.Equals(TypeCommunication.UDP))
            {

                Console.WriteLine("Création Flux UDP ");
                UDPFactory udpFactory = new UDPFactory();
                this.flow = udpFactory.CreateFlux();
            }

            if (_typeCommunication.Equals(TypeCommunication.TCP))
            {
                Console.WriteLine("Création Flux TCP ");
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
