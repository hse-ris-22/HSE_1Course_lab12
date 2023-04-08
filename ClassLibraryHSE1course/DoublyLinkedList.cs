
using System.Diagnostics.CodeAnalysis;
using lab;

namespace ClassLibraryHSE1course
{
    public class DoublyLinkedList
    {
        static Random rnd = new Random();
        private DoublyLinkedNode ?firstNode;
        private DoublyLinkedNode ?lastNode;

        private int length = 0;
        public int Length { get; }

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
                firstNode = new DoublyLinkedNode();
                lastNode = firstNode;
                Length = size;
                return;
            }
            // size > 1
            firstNode = new DoublyLinkedNode();
            DoublyLinkedNode ?pastNode = firstNode;
            DoublyLinkedNode ?nextNode = null;
            for (int i = 1; i < size; i++)
            {
                nextNode = new DoublyLinkedNode();
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
            int vehicleType;
            if (size == 0)
            {
                firstNode = null;
                lastNode = null;
            }
            if (size == 1)
            {
                firstNode = new DoublyLinkedNode();
                // Randomly choose one of 3 vehicles
                vehicleType = rnd.Next(1, 4);
                switch (vehicleType)
                {
                    case 1: // car
                        Car car = new Car();
                        car.RandomInit(min, max);
                        firstNode.Data = car;
                        break;
                    case 2: // train
                        Train train = new Train();
                        train.RandomInit(min, max);
                        firstNode.Data = train;
                        break;
                    case 3: // express
                        Express express = new Express();
                        express.RandomInit(min, max);
                        firstNode.Data = express;
                        break;
                }
                lastNode = firstNode;
                Length = size;
                return;
            }
            // size > 1
            firstNode = new DoublyLinkedNode();

            // Randomly init one of 3 vehicles
            vehicleType = rnd.Next(1, 4);
            switch (vehicleType)
            {
                case 1: // car
                    Car car = new Car();
                    car.RandomInit(min, max);
                    firstNode.Data = car;
                    break;
                case 2: // train
                    Train train = new Train();
                    train.RandomInit(min, max);
                    firstNode.Data = train;
                    break;
                case 3: // express
                    Express express = new Express();
                    express.RandomInit(min, max);
                    firstNode.Data = express;
                    break;
            }

            DoublyLinkedNode? pastNode = firstNode;
            DoublyLinkedNode? nextNode = null;
            for (int i = 0; i < size; i++)
            {
                nextNode = new DoublyLinkedNode();
                // Randomly init one of 3 vehicles
                vehicleType = rnd.Next(1, 4);
                switch (vehicleType)
                {
                    case 1: // car
                        Car car = new Car();
                        car.RandomInit(min, max);
                        nextNode.Data = car;
                        break;
                    case 2: // train
                        Train train = new Train();
                        train.RandomInit(min, max);
                        nextNode.Data = train;
                        break;
                    case 3: // express
                        Express express = new Express();
                        express.RandomInit(min, max);
                        nextNode.Data = express;
                        break;
                }
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
                Output.PrintLine("Necessary to form list before showing");
            }
            else
            {
                Output.PrintLine("Doubly linked list: ");
                DoublyLinkedNode? currentNode;
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
                    Output.Print($"{i+1}: ");
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
    } 
}
