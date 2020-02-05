using TP1.Communication;

namespace TP1.Builder
{
    public interface Builder
    {
        void setNumThread(int nombreThreads);
        void setProtocol(TypeProtocol _typeProtocol);

        void setFluxProperty(TypeCommunication _typeCommunication);
    }
}