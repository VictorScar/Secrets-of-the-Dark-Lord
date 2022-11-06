using System;

namespace SODL.Utils
{
    public class Cached<T>
    {
        T cachedValue;
        Func<T> cachedDelegate;
        public Cached(Func<T> f)
        {
            cachedDelegate = f;
        }

        public T Value
        {
            get
            {
                if (cachedValue == null)
                {
                    cachedValue = cachedDelegate();
                }

                return cachedValue;
            }
        }
    }
}