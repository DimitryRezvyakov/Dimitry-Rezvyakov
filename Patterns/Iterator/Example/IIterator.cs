using System;
using System.Collections.Generic;
using System.Text;

namespace Iterator.Example
{
    public interface IIterator<T>
    {
        bool HasNext();
        T Next();
        void Reset();
    }
}
