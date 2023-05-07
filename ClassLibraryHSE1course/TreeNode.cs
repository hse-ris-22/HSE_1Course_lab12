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
        public TreeNode(TreeNode<T> node)
        {
            Data = (T)node.Data.Clone();
            Left = null;
            Right = null;
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

        public void Show(int ind, int size, int len = 0)
        {
            if (Right != null) Right.Show(size/2+ind+1, size - size/2 - 1, len+5);
            MethodInfo methodInfo = Data.GetType().GetMethod("Show");
            if (methodInfo != null)
            {
                Output.Print($"{ind})");
                methodInfo.Invoke(Data, new object[] { len });
            }
            else
            {
                throw new Exception("No showing method in data type");
            }
            Output.PrintLine("");
            if (Left != null) Left.Show(ind + 1, size/2, len+5);
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

        public void FormTree(List<T> list)
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
            List<T> rightlist = list.GetRange(len/2+1, (len-1)/2);
            if (leftlist.Count == 0) Left = null;
            else
            {
                Left = new TreeNode<T>();
                Left.FormTree(leftlist);
            }
            if (rightlist.Count == 0) Right = null;
            else
            {
                Right = new TreeNode<T>();
                Right.FormTree(rightlist);
            }
        }

        public void Add(T val, int len)
        {
            if (len == 0)
            {
                Data = val;
                Left = null;
                Right = null;
            }
            else if (len == 1)
            {
                Left = new TreeNode<T>(val);
            }
            else if (len == 2)
            {
                Right = new TreeNode<T>(val);
            }
            else
            {
                int llen = len / 2;
                int rlen = len - llen - 1;
                if (llen <= rlen)
                {
                    Left.Add(val,llen);
                }
                else
                {
                    Right.Add(val, rlen);
                }
            }
        }

        public T Find(T val)
        {
            if (Data == null) return default;
            T lv = default;
            T rv = default;
            if (val.CompareTo(Data) == 0) return Data;

            if (Left != null) lv = Left.Find(val);
            if (lv is not null && val.CompareTo(lv) == 0) return lv;

            if (Right != null) rv = Right.Find(val);
            if (rv is not null && val.CompareTo(rv) == 0) return rv;
            return default;
        }

        public bool Remove(T val, int len)
        {
            if (this != null)
            {
                return true;
            }
            return true;
        }

        public object ShallowCopy()
        {
            if (this == null)
            {
                return null;
            }
            TreeNode<T> treeClone = new TreeNode<T>(this.Data);
            if (this.Left != null) treeClone.Left = (TreeNode<T>)this.Left.ShallowCopy();
            if (this.Right != null) treeClone.Right = (TreeNode<T>)this.Right.ShallowCopy();
            return treeClone;
        }

        public object Clone()
        {
            if (this == null)
            {
                return null;
            }
            TreeNode<T> treeClone = new TreeNode<T>((T)this.Data.Clone());
            if (this.Left != null) treeClone.Left = (TreeNode<T>)this.Left.Clone();
            if (this.Right != null) treeClone.Right = (TreeNode<T>)this.Right.Clone();
            return treeClone;
        }

        public bool Contains(T item)
        {
            if (this == null)
            {
                return false;
            }
            bool isLeftContains = false;
            bool isRightContains = false;
            if (Left != null) isLeftContains = Left.Contains(item);
            if (Right != null) isRightContains = Right.Contains(item);
            if (EqualityComparer<T>.Default.Equals(this.Data, item) || isLeftContains || isRightContains) return true;
            else return false;
        }
    }
}
