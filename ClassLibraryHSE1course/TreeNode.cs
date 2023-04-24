using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using lab;
using System.Threading.Tasks;
using System.Reflection;

namespace ClassLibraryHSE1course
{
    [ExcludeFromCodeCoverage]
    public class TreeNode<T> : ICloneable where T : ICloneable
    {
        public T Data { get; set; }
        public TreeNode<T>? Right { get; set; }
        public TreeNode<T>? Left { get; set; }
        public TreeNode()
        {
            Data = default(T);
            Left = null;
            Right = null;
        }

        public TreeNode(T data)
        {
            Data = data;
            Left = null;
            Right = null;
        }

        public TreeNode(int size)
        {
            if (size == 0)
            {
                Data = default(T);
                Left = null;
                Right = null;
            }
            Data = default(T);
            int leftSize = size/2;
            int rightSize = size - leftSize - 1;
            if (leftSize == 0) Left = null;
            else Left = new TreeNode<T>(leftSize);

            if (rightSize == 0) Right = null;
            else Right = new TreeNode<T>(rightSize);
        }

        public TreeNode(int size, int min, int max)
        {
            if (size == 0)
            {
                Data = default(T);
                Left = null;
                Right = null;
            }
            Data = BinaryTree<T>.randomT.Invoke(min, max);
            int leftSize = size/2;
            int rightSize = size - leftSize - 1;
            if (leftSize == 0)  Left = null;
            else Left = new TreeNode<T>(leftSize, min,max);

            if (rightSize == 0) Right = null;
            else Right = new TreeNode<T>(rightSize, min, max);
        }

        public override string ToString()
        {
            return Data.ToString();
        }

        public void Show(int len)
        {
            if (Left != null) Left.Show(len+3);
            for (int i = 0; i < len; i++)
            {
                Output.Print("");
            }
            MethodInfo methodInfo = Data.GetType().GetMethod("Show");
            if (methodInfo != null)
            {
                methodInfo.Invoke(Data, null);
            }
            else
            {
                throw new Exception("No showing method in data type");
            }
            Output.PrintLine("");
            if (Right != null) Right.Show(len+3);

        }

        public object Clone()
        {
            return new TreeNode<T>((T)Data.Clone());
        }
    }
}
