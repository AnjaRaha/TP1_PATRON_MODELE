using System;
using TP1.Communication;
using TP1.Task;
using TP1.Traffic;

namespace TP1.Builder
{
    public class FluxBuilder:Builder
    {
        private FlowDecorator _flowDecorator;
        private int NumThread;
        private TypeCommunication _typeCom;
        private TypeProtocol _typeProtocol;

        public int getNumThread()
        {
            return NumThread;
        }
        
        public FlowDecorator getResult()
        {
            return new FlowDecorator(new Flow());
        }
    
        public void setNumThread(int nombreThreads)
        {
            NumThread = nombreThreads;
        }

        public void setProtocol(TypeProtocol _typeProtocol)
        {
            if (_typeProtocol.Equals(_typeProtocol == TypeProtocol.TCP))
            {
                Console.WriteLine("création de protocol TCP");
            }

            if (_typeProtocol.Equals(_typeProtocol == TypeProtocol.UDP))
            {
                Console.WriteLine("création de protocol TCP");
            }
        }

        public void setFluxProperty(TypeCommunication _typeCommunication)
        {
            if (_typeCommunication.Equals(_typeCommunication == TypeCommunication.TCP))
            {
                Console.WriteLine("création de flux TCP");
            }

            if (_typeCommunication.Equals(_typeCommunication == TypeCommunication.UDP))
            {
                Console.WriteLine("création de flux TCP");
            }
        }
    }
}