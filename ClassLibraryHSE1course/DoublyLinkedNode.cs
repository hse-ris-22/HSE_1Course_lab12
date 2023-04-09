using System.Diagnostics.CodeAnalysis;
using lab;

namespace ClassLibraryHSE1course
{
    [ExcludeFromCodeCoverage]
    public class DoublyLinkedNode<T>
    {
        public T Data { get; set; }
        public DoublyLinkedNode<T> ?Next { get; set; }
        public DoublyLinkedNode<T> ?Past { get; set; }
        public DoublyLinkedNode()
        {
            Data = default(T);
            Next = null;
            Past = null;
        }
        public DoublyLinkedNode(T data)
        {
            Data = data;
            Next = null;
            Past = null;
        }
        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
