using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    public sealed class SingletonDoubleCheckLocking
    {
        SingletonDoubleCheckLocking() { }
        private static readonly object objLock = new object ();
    private static SingletonDoubleCheckLocking instance = null;
        public static SingletonDoubleCheckLocking Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (objLock)
                    {
                        if (instance == null)
                        {
                            instance = new SingletonDoubleCheckLocking();
                        }
                    }
                   
                }
                return instance;
            }
        }
    }
}
