using TP1.Traffic;

namespace TP1.Communication
{
    public class ComFactory
    {
        private TypeCommunication _type;

        private Flow CreateFlux(TypeCommunication _type)
        {
            return new Flow();
        }
    }
}