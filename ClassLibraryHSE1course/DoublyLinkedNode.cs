using System.Diagnostics.CodeAnalysis;
using lab;

namespace ClassLibraryHSE1course
{
    public class DoublyLinkedNode<T>: ICloneable where T:ICloneable
    {
        public T Data { get; set; }
        public DoublyLinkedNode<T> ?Next { get; set; }
        public DoublyLinkedNode<T> ?Past { get; set; }
        [ExcludeFromCodeCoverage]
        public DoublyLinkedNode()
        {
            Data = default(T);
            Next = null;
            Past = null;
        }
        [ExcludeFromCodeCoverage]
        public DoublyLinkedNode(T data)
        {
            Data = data;
            Next = null;
            Past = null;
        }
        [ExcludeFromCodeCoverage]
        public DoublyLinkedNode(DoublyLinkedNode<T> node)
        {
            Data = (T)node.Data.Clone();
            Next = null;
            Past = null;
        }
        public override string ToString()
        {
            return Data.ToString();
        }

        public object Clone()
        {
            return new DoublyLinkedNode<T>((T)Data.Clone());
        }
    }
}
