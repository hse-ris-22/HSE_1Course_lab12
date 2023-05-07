using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using lab;
using static lab.Output;
using System.Drawing;
using System.Collections;

namespace ClassLibraryHSE1course
{
    public class BinaryTree<T>: ICloneable, IEnumerable<T>, ICollection<T> where T : ICloneable, IComparable
    {
        private TreeNode<T>? root;
        public int Length { get; private set; }
        public int Height { get; private set; }
        public bool IsSearchTree { get; private set; }

        public int Count => Length;

        public bool IsReadOnly => false;

        public delegate T RandomT(int min, int max);
        public static RandomT? randomT;
        public delegate T KeyboardT(int i);
        public static KeyboardT? keyboardT;

        public BinaryTree()
        {
            root = null;
            Length = 0;
            Height = 0;
            IsSearchTree = false;
        }

        [ExcludeFromCodeCoverage]
        // zero vehicles constructor
        public BinaryTree(int size) // keyboard
        {
            Length = size;
            Height = (int)MathF.Ceiling(MathF.Log2(size + 1));
            IsSearchTree = false;
            if (size == 0)
            {
                root = null;
                return;
            }
            // size > 1
            root = new TreeNode<T>(size, 1);
        }

        [ExcludeFromCodeCoverage]
        // Random vehicle constructor
        public BinaryTree(int size, int min, int max)
        {
            Length = size;
            Height = (int)MathF.Ceiling(MathF.Log2(size + 1));
            IsSearchTree = false;
            if (size == 0)
            {
                root = null;
                return;
            }
            // size > 1
            root = new TreeNode<T>(size, min, max);
        }

        [ExcludeFromCodeCoverage]
        public BinaryTree(BinaryTree<T> tree) // copy
        {
            BinaryTree<T> tr = (BinaryTree<T>)tree.Clone();
            root = tr.root;
            Length = tr.Length;
            Height = tr.Height;
            IsSearchTree = tr.IsSearchTree;
        }

        [ExcludeFromCodeCoverage]
        public void Show()
        {
            if (root == null)
            {
                Output.PrintLine("Empty Tree");
            }
            else
            {
                root.Show();
            }
        }

        [ExcludeFromCodeCoverage]
        public void ShowWithIndex()
        {
            if (root == null)
            {
                Output.PrintLine("Empty Tree");
            }
            else
            {
                root.Show(1, Length, 0);
            }
        }

        public T MinElement()
        {
            if (IsSearchTree)
            {
                TreeNode<T>? tempRoot;
                if (root != null) tempRoot = root;
                else tempRoot = null;
                while (tempRoot.Left != null)
                {
                    tempRoot = tempRoot.Left;
                }
                return tempRoot.Data;
            }
            else
            {
                return root.MinElement();
            }
            
        }

        public void FormSearch(int addType = 0,T val = default) // 0 - no adding, 1 - add, 2 - remove
        {
            List<T> list = root.FormList();
            if (addType == 1)
            {
                if (!EqualityComparer<T>.Default.Equals(val, default))
                {
                    list.Add(val);
                }
            }
            if (addType == 2)
            {
                if (!EqualityComparer<T>.Default.Equals(val, default))
                {
                    if (list.Contains(val))
                    {
                        list.Remove(val);
                    }
                }
            }

            list.Sort();

            // Remove all duplicate elements 
            T temp = list[0];
            List<T> delList = new List<T>();
            for (int i = 1; i < list.Count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(temp, list[i]))
                {
                    delList.Add(temp);
                }
                else
                {
                    temp = list[i];
                }
            }
            foreach (T del in delList)
            {
                list.Remove(del);
            }

            root.FormTree(list);
            Height = (int)MathF.Ceiling(MathF.Log2(Length + 1));
            IsSearchTree = true;
        }

        public void FormNonSearch(T val = default)
        {
            IsSearchTree = false;
        }

        public void Add(T val)
        {
            if (IsSearchTree)
            {
                if (Contains(val))
                {
                    PrintLine("Unable to add duplicate element to search tree");
                    return;
                }
                else
                {
                    FormSearch(1, val);

                }
            }
            else
            {
                if (root == null) root = new TreeNode<T>(val);
                else root.Add(val, Length);

            }
            Length += 1;
            Height = (int)MathF.Ceiling(MathF.Log2(Length + 1));
            PrintLine("Value successfully added in tree");
        }

        public object ShallowCopy()
        {
            if (this == null)
            {
                return null;
            }
            BinaryTree<T> tree = new BinaryTree<T>();
            tree.Height = this.Height;
            tree.Length = this.Length;
            tree.root = (TreeNode<T>)this.root.ShallowCopy();
            tree.IsSearchTree = this.IsSearchTree;
            return tree;
        }

        public object Clone()
        {
            if (this == null)
            {
                return null;
            }
            BinaryTree<T> tree = new BinaryTree<T>();
            tree.Height = this.Height;
            tree.Length = this.Length;
            tree.IsSearchTree = this.IsSearchTree;
            if (this.root != null) tree.root = (TreeNode<T>)this.root.Clone();
            else this.root = null;
            return tree;
        }

        public IEnumerator<T> GetEnumerator()
        {
            List<T> list = root.FormList();
            foreach (T i in list)
            {
                yield return i;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            root = new TreeNode<T>();
        }

        public bool Contains(T item)
        {
            if (root.Contains(item))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("The array cannot be null");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("The starting array index cannot be negative");
            if (Count > array.Length - arrayIndex)
                throw new ArgumentException("The destination array has fewer elements than the collection");

            List<T> list = root.FormList();
            for (int i = 0; i < list.Count; i++)
            {
                array[i + arrayIndex] = list[i];
            }
        }

        public bool Remove(T item)
        {
            if (IsSearchTree)
            {
                if (!Contains(item))
                {
                    return false;
                }
                else
                {
                    FormSearch(2, item);
                }
            }
            else
            {
                if (root == null || !Contains(item)) return false;
                else
                {
                    if (Length == 1 && EqualityComparer<T>.Default.Equals(root.Data, item))
                    {
                        root = new TreeNode<T>();
                    }
                    else
                    {


                        bool isDeleted = false;
                        List<T> list = root.FormList();
                        if (!EqualityComparer<T>.Default.Equals(item, default))
                        {
                            if (list.Contains(item))
                            {
                                isDeleted = list.Remove(item);
                            }
                        }
                        root.FormTree(list);
                        if (!isDeleted) return false;
                    }
                }

            }
            Length -= 1;
            Height = (int)MathF.Ceiling(MathF.Log2(Length + 1));
            return true;
        }
    }
}
