using MyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_12
{
    public class MyCollection<TKey, TValue> : MyRBTree<TKey, TValue>, IDictionaryEnumerator where TKey : IInit, ICloneable, IComparable<TKey>, new()
    {
        public MyCollection() : base() { }

        //public MyCollection(int size) : base(size) { }
        //public MyCollection(<TKey, TValue>[] collection) : base(collection) { }

        public DictionaryEntry Entry => throw new NotImplementedException();

        public object Key => throw new NotImplementedException();

        public object? Value => throw new NotImplementedException();

        public object Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
