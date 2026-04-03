using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Iterator.Example
{
    public interface ISocialCollection
    {
        IIterator<Profile> CreateIterator();
    }
}
