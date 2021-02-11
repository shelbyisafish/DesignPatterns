using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLib.Creational.Singleton
{
    public class SingletonWithPool
    {
        // Same basic Singleton setup here:

        private SingletonWithPool()
        {
            Console.WriteLine("SingletonPool is instantiated");
        }

        //private static SingletonWithRegistry instance;    // replacing instance with pool
        public string value1;

        // Changes to add a singleton pool:

        /// <summary>
        /// The registry keeps track of which singleton instances we have.
        /// Note: This could be a list or whatever.
        /// </summary>
        private static List<SingletonWithPool> pool = new List<SingletonWithPool>();

        /// <summary>
        /// Edit GetSingleton() to use the pool.
        /// Can also limit the number of singletons allowed.
        /// </summary>
        /// <returns></returns>
        public static SingletonWithPool GetSingleton()
        {
            // Limit number of instances. Hard-coding the limit here for simplicity.
            if (pool.Count < 5)
            {
                SingletonWithPool newSingleton = new SingletonWithPool();
                pool.Add(newSingleton);
                return newSingleton;
            }
            // If pool is full, return a random singleton. (or whatever strategy you want)
            else
            {
                int index = random.Next(0, 5);
                return pool[index];
            }
        }
        private static Random random = new Random();
    }
}
