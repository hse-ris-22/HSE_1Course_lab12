using lab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryHSE1course
{
    [ExcludeFromCodeCoverage]
    public class HashTable<V> : ICloneable where V : ICloneable
    {
        private HashNode<V>[] list;
        public int Size { get; private set; }
        public int Capacity
        {
            get
            {
                return list.Length;
            }
        }
        public float LoadFactor { get; private set; }
        private const float maxLoadFactor = 0.7f;

        public delegate V RandomT(int min, int max);
        public static RandomT? randomT;
        public delegate V KeyboardT(int i);
        public static KeyboardT? keyboardT;

        [ExcludeFromCodeCoverage]
        public HashTable()
        {
            list = new HashNode<V>[1];
            Size = 0;
            LoadFactor = 0;
        }

        [ExcludeFromCodeCoverage]
        public HashTable(int size) // keyboard
        {
            if (size == 0)
            {
                list = new HashNode<V>[1];
                Size = 0;
                LoadFactor = 0;
            }
            else if (size == 1)
            {
                list = new HashNode<V>[2];
                Size = 1;
                LoadFactor = 0.5f;
                V val = keyboardT.Invoke(0);
                list[Math.Abs(val.GetHashCode() % Capacity)] = new HashNode<V>(val.GetHashCode(), val);
            }
            else
            {
                list = new HashNode<V>[size * 2];
                Size = 0;
                for (int i = 0; i < size; i++)
                {
                    V val = keyboardT.Invoke(0);
                    Add(val);
                }
            }
        }

        [ExcludeFromCodeCoverage]
        public HashTable(int size, int min, int max) // random
        {
            if (size == 0)
            {
                list = new HashNode<V>[1];
                Size = 0;
                LoadFactor = 0;
            }
            else if (size == 1)
            {
                list = new HashNode<V>[2];
                Size = 1;
                LoadFactor = 0.5f;
                V val = randomT.Invoke(min, max);
                list[Math.Abs(val.GetHashCode() % Capacity)] = new HashNode<V>(val.GetHashCode(), val);
            }
            else
            {
                list = new HashNode<V>[size * 2];
                Size = 0;
                for (int i = 0; i < size; i++)
                {
                    V val = randomT.Invoke(min,max);
                    Add(val);
                }
            }
        }

        public void Add(V val)
        {
            Size += 1;
            LoadFactor = Size / Capacity;
            do //
            {
                List<V> tempList = new List<V>();
                if (LoadFactor > maxLoadFactor)
                {
                    for (int i = 0; i < Capacity; i++)
                    {
                        if (list[i] != null)
                        {
                            tempList.Add(list[i].value);
                        }
                    }
                    list = new HashNode<V>[Capacity * 2];
                    LoadFactor = Size / Capacity;
                }
                tempList.Add(val); //
                Console.WriteLine(); 
                // place 1/all value(s)
                for (int j = 0; j < tempList.Count; j++)
                {
                    // from hash to end
                    bool isPlased = false;
                    for (int i = Math.Abs(val.GetHashCode() % Capacity); i < Capacity; i++)
                    {
                        if (list[i] == null)
                        {
                            list[i] = new HashNode<V>(tempList[j].GetHashCode(), tempList[j]);
                            isPlased = true;
                            break;
                        }
                    }
                    //from start to hash
                    if (!isPlased)
                    {
                        for (int i = 0; i < Capacity; i++)
                        {
                            if (list[i] == null)
                            {
                                list[i] = new HashNode<V>(tempList[j].GetHashCode(), tempList[j]);
                                break;
                            }
                        }
                    }
                }
            } while (LoadFactor > maxLoadFactor);
        }

        public void Show()
        {
            if (list == null || Capacity == 0)
            {
                Output.PrintLine("Empty list");
            }
            else
            {
                Output.PrintLine("Hashtable: ");
                for (int i = 0; i < Capacity; i++)
                {
                    if (list[i] == null || list[i].key == null || list[i].value == null)
                    {
                        Output.PrintLine($"{i+1}) no value");
                    }
                    else
                    {
                        Output.Print($"{i+1}) key = {list[i].key}: ");
                        MethodInfo methodInfo = list[i].value.GetType().GetMethod("Show");
                        if (methodInfo != null)
                        {
                            methodInfo.Invoke(list[i].value, new object[] { 0 });
                        }
                    }
                    
                }
            }
            
        }


        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
