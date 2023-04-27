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

namespace ClassLibraryHSE1course
{
    public class BinaryTree<T>: ICloneable where T : ICloneable, IComparable
    {
        private TreeNode<T>? root;
        public int Length { get; private set; }
        public int Height { get; private set; }
        public bool IsSearchTree { get; private set; }

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

        public void FormSearch(T val = default)
        {
            List<T> list = root.FormList();
            if (!EqualityComparer<T>.Default.Equals(val, default))
            {
                list.Add(val);
            }
            list.Sort();
            root.FormSearchTree(list);
            Height = (int)MathF.Ceiling(MathF.Log2(Length + 1));
            IsSearchTree = true;
        }

        public void FormNonSearch(T val = default)
        {
            IsSearchTree = false;
        }

        public void AddValue(T val)
        {
            if (IsSearchTree)
            {
                this.FormSearch(val);
            }
            else
            {
                if (root == null) root = new TreeNode<T>(val);
                else root.AddValue(val, Length);
            }
            Length += 1;
            Height = (int)MathF.Ceiling(MathF.Log2(Length + 1));
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
    }
}
