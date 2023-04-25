using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using lab;
using static lab.Output;

namespace ClassLibraryHSE1course
{
    public class BinaryTree<T>: ICloneable where T : ICloneable
    {
        static Random rnd = new Random();
        private TreeNode<T>? root;
        public int Length { get; private set; }
        public int Height { get; private set; }

        public delegate T RandomT(int min, int max);
        public static RandomT? randomT;
        public delegate T KeyboardT(int i);
        public static KeyboardT? keyboardT;

        public BinaryTree()
        {
            root = null;
            Length = 0;
            Height = 0;
        }

        [ExcludeFromCodeCoverage]
        // zero vehicles constructor
        public BinaryTree(int size) // keyboard
        {
            Length = size;
            Height = (int)MathF.Ceiling(MathF.Log2(size + 1));
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
            if (size == 0)
            {
                root = null;
                return;
            }
            // size > 1
            root = new TreeNode<T>(size,min,max);
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

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
