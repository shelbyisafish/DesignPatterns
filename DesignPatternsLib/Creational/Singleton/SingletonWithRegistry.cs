using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLib.Creational.Singleton
{
    /// <summary>
    /// In this example, we're ensuring one singleton per *subtype* of SingletonWithRegistry.
    /// Of course, you could change that limit (from one) by changing the type of registry.
    /// 
    /// See also: Multition pattern
    /// https://en.wikipedia.org/wiki/Multiton_pattern
    /// </summary>
    public class SingletonWithRegistry
    {
        // Changing access level from private to protected for subclasses.
        protected SingletonWithRegistry()
        {
            Console.WriteLine("SingletonWithRegistry is instantiated");
        }

        //private static SingletonWithRegistry instance;    // replacing instance with registry
        public string value1;

        // Changes to add a singleton registry:

        /// <summary>
        /// The registry keeps track of which singleton instances we have.
        /// Note: This could be a list or whatever.
        /// </summary>
        private static Dictionary<Type, SingletonWithRegistry> registry = new Dictionary<Type, SingletonWithRegistry>();

        /// <summary>
        /// To add a singleton to the registry, use RegisterSingleton().
        /// </summary>
        /// <param name="name"></param>
        /// <param name="singleton"></param>
        protected static void RegisterSingleton(Type singletonType, SingletonWithRegistry singleton)
        {
            if (!registry.ContainsKey(singletonType))
                registry.Add(singletonType, singleton);
        }

        /// <summary>
        /// Edit GetSingleton() to use the registry.
        /// Can also limit the number of singletons allowed. If number is limited, returns null when limit is reached. Also, possibly needs Unregister() depending on the situation.
        /// Note: Unique type doesn't have to be passed as a generic. Could use a parameter, environment variable, or something else.
        /// </summary>
        /// <returns></returns>
        public static T GetSingleton<T>() where T : SingletonWithRegistry
        {
            if (registry.TryGetValue(typeof(T), out SingletonWithRegistry singleton))
            {
                return singleton as T;
            }
            else
            {
                T newSingleton = Activator.CreateInstance(typeof(T), true) as T;        // Use reflection to call the subclass constructor, even when it's private!
                RegisterSingleton(typeof(T), newSingleton);
                return newSingleton;
            }
        }
    }

    public class SingletonSubclass1 : SingletonWithRegistry
    {
        private SingletonSubclass1()
        {
            Console.WriteLine("SingletonSubclass1 is instantiated");
        }
    }

    public class SingletonSubclass2 : SingletonWithRegistry
    {
        private SingletonSubclass2()
        {
            Console.WriteLine("SingletonSubclass2 is instantiated");
        }
    }
}
