namespace TP1.Task
{
    public interface Task
    {
        void Execute();

        void Task(System.Action lambda);
    }
}