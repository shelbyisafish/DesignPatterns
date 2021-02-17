using DesignPatternsLib.Creational.Builder.BoardBuilder;
using DesignPatternsLib.Creational.Singleton;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsConsole
{
    public static class CreationalExamples
    {
        #region Singleton Examples

        /// <summary>
        /// In its simplest form, the Singleton pattern ensures that there will
        /// never be more than one instance of an object.
        /// In this example situation, notice that the constructor is only called once and
        /// that the same Singleton object is used every time (see value1).
        /// </summary>
        public static void SingletonExample1()
        {
            Console.WriteLine("----------- Singleton 1 -----------\n");

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

            Console.WriteLine("\n----------- /Singleton 1 -----------");
        }

        /// <summary>
        /// You could also ensure a variable number of instances instead of 1.
        /// Here, the limit is set to 5.
        /// </summary>
        public static void SingletonExample2()
        {
            Console.WriteLine("----------- Singleton 2 -----------\n");

            // Calling GetSingleton() 6 times. Values are incremental.
            // Only 5 singletons should be created.
            Console.WriteLine("Calling GetSingleton() 6 times. Only 5 singletons should be created.\n");
            List<SingletonWithPool> singletons = new List<SingletonWithPool>();
            for (int i=1; i <= 6; i++)
            {
                SingletonWithPool singleton = SingletonWithPool.GetSingleton();
                if (string.IsNullOrWhiteSpace(singleton.value1))
                    singleton.value1 = i.ToString();
                singletons.Add(singleton);
            }

            // The sixth singleton should be a randomly-selected one from the pool. Which one is it?
            Console.WriteLine("\nThe sixth singleton should be a randomly-selected one from the pool. Which one is it?");
            Console.WriteLine($"singletons.Last().value1 is {singletons.Last().value1}");

            // Call GetSingleton() agan to get another random singleton.
            Console.WriteLine("\nCall GetSingleton() agan to get another random singleton.");
            Console.WriteLine($"SingletonWithPool.GetSingleton().value1 is {SingletonWithPool.GetSingleton().value1}");

            Console.WriteLine("\n----------- /Singleton 2 -----------");
        }

        /// <summary>
        /// Subclassing a singleton.
        /// </summary>
        public static void SingletonExample3()
        {
            Console.WriteLine("----------- Singleton 3 -----------\n");

            // Try to get SingletonWithRegistry and all subclasses once. Set values.
            Console.WriteLine("Try to get SingletonWithRegistry and all subclasses once, and set values.");
            Console.WriteLine("NOTE: It is expected that the SingletonWithRegistry constructor will run more than once here. That is how inheritance works.\n");
            SingletonWithRegistry singletonWithRegistry = SingletonWithRegistry.GetSingleton<SingletonWithRegistry>();
            singletonWithRegistry.value1 = "SingletonWithRegistry";
            SingletonSubclass1 singletonSubclass1 = SingletonWithRegistry.GetSingleton<SingletonSubclass1>();
            singletonSubclass1.value1 = "SingletonSubclass1";
            SingletonSubclass2 singletonSubclass2 = SingletonWithRegistry.GetSingleton<SingletonSubclass2>();
            singletonSubclass2.value1 = "SingletonSubclass2";

            // Try to get subclass1 again. It is the same object that was created before.
            Console.WriteLine("\nTry to get subclass1 again. It is the same object that was created before.");
            Console.WriteLine("(Constructors shouldn't run again, and value should already exist)");
            Console.WriteLine($"SingletonWithRegistry.GetSingleton<SingletonSubclass1>().value1 is {SingletonWithRegistry.GetSingleton<SingletonSubclass1>().value1}");

            Console.WriteLine("\n----------- /Singleton 3 -----------");
        }

        #endregion

        #region Builder Examples

        public static void BuilderExample1()
        {
            Console.WriteLine("----------- Builder 1 -----------\n");

            // Create a normal board.
            // This is the simplest form of the Builder pattern.
            Console.WriteLine("Create a normal board. This is the simplest form of the Builder pattern.\n");
            BoardBuilder boardBuilder = new BoardBuilder();
            Director director = new Director(boardBuilder);

            director.ConstructStandardBoard();
            Board board = boardBuilder.GetBoard();

            Console.WriteLine("Printing the pieces in the board:");
            int index = 0;
            foreach (BoardPiece piece in board.landMasses.First().pieces)   // Skip some steps. I already know there's 1 landmass.
            {
                Console.WriteLine($"\t[{index}]: {piece.resourceType}.");
                index++;
            }

            // Create an explanation.
            // In the Builder pattern, change the builder to build something else.
            Console.WriteLine("\nCreate an explanation. In the Builder pattern, change the builder to build something else.\n");
            ExplanationBuilder explanationBuilder = new ExplanationBuilder();
            director.SetBuilder(explanationBuilder);

            director.ConstructStandardExplanation();
            Explanation explanation = explanationBuilder.GetExplanations();

            Console.WriteLine("Printing the explanations:");
            index = 0;
            while (explanation.next != null)
            {
                Console.WriteLine($"\t[{index}]: {explanation.explanation}");
                explanation = explanation.next;
                index++;
            }

            Console.WriteLine("\n----------- /Builder 1 -----------");
        }

        public static void BuilderExample2()
        {
            Console.WriteLine("----------- Builder 2 -----------\n");

            // Validator should validate similar incoming data. If data does not have enough similarity, use a different pattern.
            // See README file for expected inputs.
            List<string> inputs = new List<string>();

            // Validate the first input.
            Console.WriteLine("Getting the first input...\n");


            Console.WriteLine("\n----------- /Builder 2 -----------");
        }

        private static List<string> CreateInputBuilderExample2()
        {
            List<string> examples = new List<string>();

            JObject input1 = new JObject();
            JObject input2 = new JObject();
            JObject input3 = new JObject();

            examples.Add(input1.ToString());
            examples.Add(input2.ToString());
            examples.Add(input3.ToString());
            examples.OrderBy(x => x.GetHashCode()); // "shuffle"
            return examples;
        }

        #endregion
    }
}
