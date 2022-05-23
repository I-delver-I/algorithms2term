namespace Labwork_5
{
    public class DoubleTierNode<T>
    {
        public T Data { get; set; }
        public DoubleTierNode<T>? Previous { get; set; }
        public DoubleTierNode<T>? Next { get; set; }

        public DoubleTierNode(T data)
        {
            Data = data;
        }
    }
}