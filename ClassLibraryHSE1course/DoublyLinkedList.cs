
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using lab;
using static lab.Output;

namespace ClassLibraryHSE1course
{
    public class DoublyLinkedList<T>: ICloneable where T:ICloneable
    {
        static Random rnd = new Random();
        private DoublyLinkedNode<T>? firstNode;
        private DoublyLinkedNode<T>? lastNode;
        public int Length { get; private set; }
        public delegate T RandomT(int min, int max);
        public static RandomT? randomT;
        public delegate T KeyboardT(int i);
        public static KeyboardT? keyboardT;

        [ExcludeFromCodeCoverage]
        public DoublyLinkedList()
        {
            firstNode = null;
            lastNode = null;
        }

        [ExcludeFromCodeCoverage]
        // zero vehicles constructor
        public DoublyLinkedList(int size) // keyboard
        {
            if (size == 0)
            {
                firstNode = null;
                lastNode = null;
                return;
            }
            if (size == 1)
            {
                firstNode = new DoublyLinkedNode<T>();
                // Randomly choose one of 3 vehicles
                firstNode.Data = keyboardT.Invoke(0);
                lastNode = firstNode;
                Length = size;
                return;
            }
            // size > 1
            firstNode = new DoublyLinkedNode<T>(keyboardT.Invoke(1));

            DoublyLinkedNode<T>? pastNode = firstNode;
            DoublyLinkedNode<T>? nextNode = null;
            for (int i = 1; i < size; i++)
            {
                nextNode = new DoublyLinkedNode<T>();
                // Randomly init one of 3 vehicles
                nextNode.Data = keyboardT.Invoke(i+1);
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
                return;
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
                            methodInfo.Invoke(currentNode.Data, new object[] { 0 });
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
        public void AddByNumber(int num, T value)
        {
            if (Length == 0) // empty
            {
                firstNode = new DoublyLinkedNode<T>(value);
                lastNode = firstNode;
            }
            else if (num >= Length) // last
            {
                DoublyLinkedNode<T> addedNode = new DoublyLinkedNode<T>(value);
                addedNode.Past = lastNode;
                lastNode.Next = addedNode;
                lastNode = addedNode;
            }
            else if (num == 0) // first
            {
                DoublyLinkedNode<T> addedNode = new DoublyLinkedNode<T>(value);
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
                        DoublyLinkedNode<T> node = new DoublyLinkedNode<T>(value);
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

        public object ShallowCopy()
        {
            DoublyLinkedList<T> newList = new DoublyLinkedList<T>();
            DoublyLinkedNode<T>? tempNode = firstNode;
            for (int i = 0; i < Length; i++)
            {
                newList.AddByNumber(Length, tempNode.Data);
                if (tempNode.Next != null)
                {
                    tempNode = tempNode.Next;
                }

            }
            return newList;
        }

        public object Clone()
        {
            DoublyLinkedList<T> newList = new DoublyLinkedList<T>();
            DoublyLinkedNode<T>? tempNode = firstNode;
            for (int i = 0; i < Length; i++)
            {
                newList.AddByNumber(Length, (T)tempNode.Data.Clone()); // remove .Clone() to make shallow copy
                if (tempNode.Next != null)
                {
                    tempNode = tempNode.Next;
                }

            }
            return newList;
        }
    }
}
