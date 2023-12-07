using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    public sealed class SingletonLazy
    {
        private SingletonLazy()
        {
        }
        private static readonly Lazy<SingletonLazy> lazy = new Lazy<SingletonLazy>(() => new SingletonLazy());
        public static SingletonLazy Instance
        {
            get
            {
                return lazy.Value;
            }
        }
    }
}
