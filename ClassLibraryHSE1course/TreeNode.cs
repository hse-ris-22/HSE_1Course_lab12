using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using lab;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections;
using System.Drawing;

namespace ClassLibraryHSE1course
{
    [ExcludeFromCodeCoverage]
    public class TreeNode<T> : ICloneable where T : ICloneable,IComparable
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

        public TreeNode(int size, int ind)
        {
            if (size == 0)
            {
                Data = default(T);
                Left = null;
                Right = null;
            }
            Data = BinaryTree<T>.keyboardT.Invoke(ind);
            int leftSize = size/2;
            int rightSize = size - leftSize - 1;
            if (leftSize == 0) Left = null;
            else Left = new TreeNode<T>(leftSize, ind + 1);

            if (rightSize == 0) Right = null;
            else Right = new TreeNode<T>(rightSize, size/2+ind+1);
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

        public void Show(int len=0)
        {
            if (Right != null) Right.Show(len+5);
            MethodInfo methodInfo = Data.GetType().GetMethod("Show");
            if (methodInfo != null)
            {
                methodInfo.Invoke(Data, new object[] { len});
            }
            else
            {
                throw new Exception("No showing method in data type");
            }
            Output.PrintLine("");
            if (Left != null) Left.Show(len+5);
        }

        public T MinElement()
        {
            if (this != null)
            {
                T? lmin = default;
                T? rmin = default;
                T? min = default;
                if (this.Data == null)
                {
                    return min;
                }
                else
                {
                    min = this.Data;
                }
                if (this.Left != null)
                {
                    lmin = this.Left.MinElement();
                    if (lmin.CompareTo(min) < 0) min = lmin;
                }
                if (this.Right != null)
                {
                    rmin = this.Right.MinElement();
                    if (rmin.CompareTo(min) < 0) min = rmin;
                }
                return min;
            }
            return default;
        }

        public List<T> FormList()
        {
            if (this != null)
            {
                List<T> list = new List<T>();
                if (this.Data != null)
                {
                    list.Add((T)this.Data.Clone());
                }
                if (this.Left != null)
                {
                    List<T> llist = this.Left.FormList();
                    foreach (T i in llist) 
                    {
                        list.Add(i);
                    }
                }
                if (this.Right != null)
                {
                    List<T> rlist = this.Right.FormList();
                    foreach (T i in rlist)
                    {
                        list.Add(i);
                    }
                }
                return list;
            }
            return new List<T>();
        }

        public void FormSearchTree(List<T> list)
        {
            int len = list.Count;
            if (len == 0) 
            {
                Data = default;
                Left = null;
                Right = null;
            }
            Data = list[len/2];
            List<T> leftlist = list.GetRange(0, len/2);
            List<T> rightlist = list.GetRange(len/2+1,(len-1)/2);
            if (leftlist.Count == 0) Left = null;
            else Left?.FormSearchTree(leftlist);

            if (rightlist.Count == 0) Right = null;
            else Right?.FormSearchTree(rightlist);
        }

        public object Clone()
        {
            return new TreeNode<T>((T)Data.Clone());
        }
    }
}
