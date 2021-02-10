using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLib.Creational.Singleton
{
    // Note: Not creating a static class because static
    //       classes cannot be instantiated.
    public class Singleton
    {
        /// <summary>
        /// Singleton constructor is private.
        /// Cannot do Singleton s = new Singleton();
        /// </summary>
        private Singleton()
        {
            Console.WriteLine("Singleton is instantiated");
        }

        /// <summary>
        /// Static - there is only one Singleton object among all
        /// instances of the Singleton class.
        /// </summary>
        private static Singleton instance;

        /// <summary>
        /// The only way to get an instance of Singleton is through GetSingleton().
        /// Note: Could pass parameters here if Singleton constructor needed them.
        /// </summary>
        /// <returns></returns>
        public static Singleton GetSingleton()
        {
            if (instance == null)
                instance = new Singleton();
            return instance;
        }

        /// <summary>
        /// Simulates Singleton's fields/properties.
        /// Since there's only one Singleton, changing value1 should
        /// change the same instance of value1.
        /// </summary>
        public string value1;
    }
}
