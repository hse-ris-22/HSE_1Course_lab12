using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ClassLibraryHSE1course
{
    public class HashNode<V>: ICloneable where V : ICloneable
    {
        public int ?key;
        public V ?value;
        public HashNode()
        {
            key = null;
            value = default(V);
        }
        [ExcludeFromCodeCoverage]
        public HashNode(int ?key, V ?value)
        {
            this.key = key;
            this.value = value;
        }
        [ExcludeFromCodeCoverage]
        public HashNode(HashNode<V> node)
        {
            key = node.key;
            value = (V)node.value.Clone();
        }

        public override string ToString()
        {
            return key.ToString() + ": " + value.ToString();
        }

        public object Clone()
        {
            return new HashNode<V>(key, (V)value.Clone());
        }

        public override int GetHashCode()
        {
            if (value != null)
            {
                return value.GetHashCode(); 
            }
            else
            {
                return 0;
            }
        }
    }
}
