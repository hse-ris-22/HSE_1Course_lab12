
using System.Diagnostics.CodeAnalysis;
using lab;

namespace ClassLibraryHSE1course
{
    public class DoublyLinkedList
    {
        static Random rnd = new Random();
        private DoublyLinkedNode<Vehicle> ?firstNode;
        private DoublyLinkedNode<Vehicle>? lastNode;
        public int Length { get; private set; }

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
                firstNode = new DoublyLinkedNode<Vehicle>();
                lastNode = firstNode;
                Length = size;
                return;
            }
            // size > 1
            firstNode = new DoublyLinkedNode<Vehicle>();
            DoublyLinkedNode<Vehicle>? pastNode = firstNode;
            DoublyLinkedNode<Vehicle>? nextNode = null;
            for (int i = 1; i < size; i++)
            {
                nextNode = new DoublyLinkedNode<Vehicle>();
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
                firstNode = new DoublyLinkedNode<Vehicle>();
                // Randomly choose one of 3 vehicles
                firstNode.Data = RandomVehicle(min, max);
                lastNode = firstNode;
                Length = size;
                return;
            }
            // size > 1
            firstNode = new DoublyLinkedNode<Vehicle>(RandomVehicle(min, max));

            DoublyLinkedNode<Vehicle>? pastNode = firstNode;
            DoublyLinkedNode<Vehicle>? nextNode = null;
            for (int i = 1; i < size; i++)
            {
                nextNode = new DoublyLinkedNode<Vehicle>();
                // Randomly init one of 3 vehicles
                nextNode.Data = RandomVehicle(min, max);
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
                DoublyLinkedNode<Vehicle>? currentNode;
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
                        currentNode.Data.Show();
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
                firstNode = new DoublyLinkedNode<Vehicle>(RandomVehicle(min, max));
                lastNode = firstNode;
            }
            else if (num >= Length) // last
            {
                DoublyLinkedNode<Vehicle> addedNode = new DoublyLinkedNode<Vehicle>(RandomVehicle(min, max));
                addedNode.Past = lastNode;
                lastNode.Next = addedNode;
                lastNode = addedNode;
            }
            else if (num == 0) // first
            {
                DoublyLinkedNode<Vehicle> addedNode = new DoublyLinkedNode<Vehicle>(RandomVehicle(min, max));
                addedNode.Next = firstNode;
                firstNode.Past = addedNode;
                firstNode = addedNode;
            }
            else
            {
                DoublyLinkedNode<Vehicle>? currentNode = firstNode;
                for (int i = 1; i < Length; i++)
                {

                    if (i == num)
                    {
                        DoublyLinkedNode<Vehicle> node = new DoublyLinkedNode<Vehicle>(RandomVehicle(min, max));
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

        public DoublyLinkedList DeepCopy()
        {
            DoublyLinkedList list = new DoublyLinkedList();
            return list;
        }


        private Vehicle RandomVehicle(int min, int max)
        {
            Vehicle vehicle = new Vehicle();
            int vehicleType = rnd.Next(1, 4);
            switch (vehicleType)
            {
                case 1: // car
                    Car car = new Car();
                    car.RandomInit(min, max);
                    vehicle = car;
                    break;
                case 2: // train
                    Train train = new Train();
                    train.RandomInit(min, max);
                    vehicle = train;
                    break;
                case 3: // express
                    Express express = new Express();
                    express.RandomInit(min, max);
                    vehicle = express;
                    break;
            }
            return vehicle;
        }
    }
}
