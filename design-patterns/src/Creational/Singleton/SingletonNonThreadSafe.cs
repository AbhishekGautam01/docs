using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{

    public sealed class SingletonNonThreadSafe
    {
        private SingletonNonThreadSafe() { }
        private static SingletonNonThreadSafe instance = null;
        public static SingletonNonThreadSafe Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonNonThreadSafe();
                }
                return instance;
            }
        }
    }
}