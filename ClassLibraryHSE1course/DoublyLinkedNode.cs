using System.Diagnostics.CodeAnalysis;
using lab;

namespace ClassLibraryHSE1course
{
    [ExcludeFromCodeCoverage]
    public class DoublyLinkedNode
    {
        public Vehicle Data { get; set; }
        public DoublyLinkedNode ?Next { get; set; }
        public DoublyLinkedNode ?Past { get; set; }
        public DoublyLinkedNode()
        {
            Data = new Vehicle();
            Next = null;
            Past = null;
        }
        public DoublyLinkedNode(Vehicle data)
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
