using DesignPatternsLib.Creational.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsConsole
{
    public static class CreationalInstances
    {
        /// <summary>
        /// In its simplest form, the Singleton pattern ensures that there will
        /// never be more than one instance of an object.
        /// In this example situation, notice that the constructor is only called once and
        /// that the same Singleton object is used every time (see value1).
        /// </summary>
        public static void SingletonExample1()
        {
            Console.WriteLine("----------- Singleton -----------\n");
            // 'new' keyword is blocked. Cannot create more than one instance of Singleton.
            //Singleton s = new Singleton();

            // Only the first call to GetSingleton() should call the constructor.
            Console.WriteLine("Creating two objects (singleton1 and singleton2) by calling GetSingleton() twice. \nSingleton instantiation should only happen once.\n");
            Singleton singleton1 = Singleton.GetSingleton();
            Singleton singleton2 = Singleton.GetSingleton();

            // To prove that there is only one instance of the Singleton class, show that
            // GetSingleton() always returns the same object. I.e. singleton1 is the same
            // object as singleton2.
            Console.WriteLine("\nTo prove that there is only one instance of the Singleton class, show that GetSingleton() always \nreturns the same object. I.e. singleton1 is the same object as singleton2.\n");

            singleton1.value1 = "Changed value via singleton1";
            Console.WriteLine("singleton1.value1 = \"Changed value via singleton1\";");

            Console.WriteLine($"Printing the value of singleton2: {singleton2.value1}");

            Console.WriteLine("\n----------- /Singleton -----------");
        }
    }
}
