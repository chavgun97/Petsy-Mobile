using System;
using System.Collections.Generic;
using System.Text;

namespace Petsy.Cache
{
    interface ICache<T>
    {
        T Get();

        void Update(T cache);
    }
}
