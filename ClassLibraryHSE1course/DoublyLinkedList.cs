
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using lab;
using static lab.Output;

namespace ClassLibraryHSE1course
{
    public class DoublyLinkedList<T>
    {
        static Random rnd = new Random();
        private DoublyLinkedNode<T>? firstNode;
        private DoublyLinkedNode<T>? lastNode;
        public int Length { get; private set; }
        public delegate T RandomT(int min, int max);
        public static RandomT randomT;
        public void AssignRandomT(RandomT rnd)
        {
            randomT = rnd;
        }
        public void ClearRandomT(RandomT rnd)
        {
            randomT = null;
        }

        public DoublyLinkedList()
        {
            firstNode = null;
            lastNode = null;
        }

        [ExcludeFromCodeCoverage]
        // zero vehicles constructor
        public DoublyLinkedList(int size)
        {
            if (size == 0)
            {
                firstNode = null;
                lastNode = null;
            }
            if (size == 1)
            {
                firstNode = new DoublyLinkedNode<T>();
                lastNode = firstNode;
                Length = size;
                return;
            }
            // size > 1
            firstNode = new DoublyLinkedNode<T>();
            DoublyLinkedNode<T>? pastNode = firstNode;
            DoublyLinkedNode<T>? nextNode = null;
            for (int i = 1; i < size; i++)
            {
                nextNode = new DoublyLinkedNode<T>();
                pastNode.Next = nextNode;
                nextNode.Past = pastNode;
                pastNode = nextNode;
            }
            lastNode = nextNode;
            Length = size;
        }

        [ExcludeFromCodeCoverage]
        // Random vehicle constructor
        public DoublyLinkedList(int size, int min, int max)
        {
            if (size == 0)
            {
                firstNode = null;
                lastNode = null;
            }
            if (size == 1)
            {
                firstNode = new DoublyLinkedNode<T>();
                // Randomly choose one of 3 vehicles
                firstNode.Data = randomT.Invoke(min, max);
                lastNode = firstNode;
                Length = size;
                return;
            }
            // size > 1
            firstNode = new DoublyLinkedNode<T>(randomT.Invoke(min, max));

            DoublyLinkedNode<T>? pastNode = firstNode;
            DoublyLinkedNode<T>? nextNode = null;
            for (int i = 1; i < size; i++)
            {
                nextNode = new DoublyLinkedNode<T>();
                // Randomly init one of 3 vehicles
                nextNode.Data = randomT.Invoke(min, max);
                pastNode.Next = nextNode;
                nextNode.Past = pastNode;
                pastNode = nextNode;
            }
            lastNode = nextNode;
            Length = size;
        }

        [ExcludeFromCodeCoverage]
        public void Show(bool isFromStart = true)
        {
            if (Length == 0)
            {
                Output.PrintLine("Empty list");
            }
            else
            {
                Output.PrintLine("Doubly linked list: ");
                DoublyLinkedNode<T>? currentNode;
                if (isFromStart) // start from the first
                {
                    currentNode = firstNode;
                }
                else // start from the last
                {
                    currentNode = lastNode;
                }
                for (int i = 0; i < Length; i++)
                {
                    Output.Print($"{i+1}) ");
                    if (currentNode == null)
                    {
                        Output.PrintLine("Empty Node");
                    }
                    else
                    {
                        MethodInfo methodInfo = currentNode.Data.GetType().GetMethod("Show");
                        if (methodInfo != null)
                        {
                            methodInfo.Invoke(currentNode.Data, null);
                        }
                        else
                        {
                            throw new Exception("No showing method in data type");
                        }
                    }

                    if (isFromStart)
                    {
                        if (currentNode?.Next != null)
                        {
                            currentNode = currentNode.Next;
                        }
                    }
                    else
                    {
                        if (currentNode?.Past != null)
                        {
                            currentNode = currentNode.Past;
                        }
                    }
                    Output.PrintLine("");
                }
            }
        }

        // Add the item with the given number to the list
        // num = 0 - in first element
        // num >= length - in last element
        public void AddRandomByNumber(int num, int min = 0, int max = 0)
        {
            if (Length == 0) // empty
            {
                firstNode = new DoublyLinkedNode<T>(randomT.Invoke(min, max));
                lastNode = firstNode;
            }
            else if (num >= Length) // last
            {
                DoublyLinkedNode<T> addedNode = new DoublyLinkedNode<T>(randomT.Invoke(min, max));
                addedNode.Past = lastNode;
                lastNode.Next = addedNode;
                lastNode = addedNode;
            }
            else if (num == 0) // first
            {
                DoublyLinkedNode<T> addedNode = new DoublyLinkedNode<T>(randomT.Invoke(min, max));
                addedNode.Next = firstNode;
                firstNode.Past = addedNode;
                firstNode = addedNode;
            }
            else
            {
                DoublyLinkedNode<T>? currentNode = firstNode;
                for (int i = 1; i < Length; i++)
                {

                    if (i == num)
                    {
                        DoublyLinkedNode<T> node = new DoublyLinkedNode<T>(randomT.Invoke(min, max));
                        if (currentNode.Next != null)
                        {
                            node.Next = currentNode.Next;
                            currentNode.Next.Past = node;
                        }
                        node.Past = currentNode;
                        currentNode.Next = node;
                        
                        break;
                    }

                    if (currentNode.Next != null)
                    {
                        currentNode = currentNode.Next;
                    }
                }
            }
            Length += 1;

        }

        /*public DoublyLinkedList DeepCopy()
        {
            DoublyLinkedList list = new DoublyLinkedList();
            return list;
        }*/


       
    }
}
