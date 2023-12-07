using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    public sealed class SingletonWithoutLockAndLazy
    {
        private static readonly SingletonWithoutLockAndLazy instance = new SingletonWithoutLockAndLazy();
        static SingletonWithoutLockAndLazy()
        {
        }
        private SingletonWithoutLockAndLazy()
        {
        }
        public static SingletonWithoutLockAndLazy Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
