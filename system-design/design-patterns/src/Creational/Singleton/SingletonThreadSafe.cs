using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    public sealed class SingletonThreadSafe
    {
        SingletonThreadSafe() { }
        private static readonly object objLock = new object();
    private static SingletonThreadSafe instance = null;
        public static SingletonThreadSafe Instance
        {
            get
            {
                lock (objLock)
                    {
                        if (instance == null)
                        {
                            instance = new SingletonThreadSafe();
                        }
                        return instance;
                    }
            }
        }
    }
}
