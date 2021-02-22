using DesignPatternsLib.Creational.Builder.BoardBuilder;
using DesignPatternsLib.Creational.Builder.ValidationBuilder;
using DesignPatternsLib.Creational.Singleton;
using Newtonsoft.Json;
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
            List<string> inputs = CreateInputBuilderExample2();

            Console.WriteLine("Creating the director.\n");
            ValidationDirector validationDirector = new ValidationDirector();

            // Validate the first input.
            Console.WriteLine("Getting the first input...");
            string firstOrder = inputs[0];
            inputs.RemoveAt(0);

            // Tip: Instead of fiddling with the newtonsoft json objects (JToken, JObject, JProperty, etc.), just create a model to pass to the deserializer.
            //      To do this, all properties have to have get; and set;.
            OrderWrapper orderToPrint = JsonConvert.DeserializeObject<OrderWrapper>(firstOrder);
            Console.WriteLine(JsonConvert.SerializeObject(orderToPrint, Formatting.Indented));
            Order order = orderToPrint?.Order;

            // Choose and set builder.
            Console.WriteLine("\nChoosing a builder...");
            OrderValidationBuilder builder;
            if (order.Products != null)
            {
                builder = new ProductValidationBuilder();
                validationDirector.SetBuilder(builder);
                Console.WriteLine("Product builder\n");
            }
            else
            {
                builder = new ServiceValidationBuilder();
                validationDirector.SetBuilder(builder);
                Console.WriteLine("Service builder\n");
            }

            // Validation
            Console.WriteLine("Validating...");
            validationDirector.ValidateOrder(order);
            (bool success, string errorMessages) = builder.GetValidationResult();

            if (success)
            {
                Console.WriteLine("Success!");
            }    
            else
            {
                Console.WriteLine("Validation Failed");
                Console.WriteLine(errorMessages);
            }

            // Validate the rest of the inputs.
            //Console.WriteLine("\n\nValidate the remaining orders.");
            //foreach (string input in inputs)
            //{
            //    order = JObject.Parse(input);
            //}

            Console.WriteLine("\n----------- /Builder 2 -----------");
        }

        private static List<string> CreateInputBuilderExample2()
        {
            JObject[] users = new JObject[6];
            JObject[] pets = new JObject[6];
            dynamic payment;
            JToken[] products = new JToken[2];
            JToken[] services = new JToken[4];

            #region users
            // input is ideal
            dynamic user1 = new JObject();
            user1.Name = "Jane Doe";
            user1.Email = "JaneDoe@gmail.com";
            user1.Phone = "(800) 123-4567";
            users[0] = user1;

            // input correct, but fix format
            dynamic user2 = new JObject();
            user2.Name = "Ms. Alice Brown";
            user2.Email = "alicebrown@gmail.com";
            user2.Phone = "8009876543";
            users[1] = user2;

            // input correct, but fix format
            dynamic user3 = new JObject();
            user3.Name = "Dan Johnson";
            user3.Email = "danjohnson@gmail.com";
            user3.Phone = "1234567";
            users[2] = user3;

            // input rejected, email
            dynamic user4 = new JObject();
            user4.Name = "Bob Smith";
            user4.Email = "BobSmith@gmail.com@outlook.com";
            user4.Phone = "(800) 456-7890";
            users[3] = user4;

            // input rejected, phone
            dynamic user5 = new JObject();
            user5.Name = "Carol Sheryl";
            user5.Email = "Sharol@aol.com";
            user5.Phone = "111111111";
            users[4] = user5;

            // input rejected, name
            dynamic user6 = new JObject();
            user6.Name = "";
            user6.Email = "me@outlook.com";
            user6.Phone = "789-1234";
            users[5] = user6;
            #endregion

            #region pets

            // input is ideal
            dynamic pet1 = new JObject();
            pet1.Name = "Spot";
            pet1.Breed = "Greyhound";
            pet1.Sex = "M";
            pets[0] = pet1;

            // input is correct, fix format
            dynamic pet2 = new JObject();
            pet2.Name = "Lucky";
            pet2.Breed = "Golden Retreiver";
            pet2.Sex = "Female";
            pets[1] = pet2;

            // input rejected, name
            dynamic pet3 = new JObject();
            pet3.Name = "";
            pet3.Breed = "Golden Retreiver";
            pet3.Sex = "Female";
            pets[2] = pet3;

            // input rejected, breed
            dynamic pet4 = new JObject();
            pet4.Name = "Moose";
            pet4.Breed = "";
            pet4.Sex = "F";
            pets[3] = pet4;

            // input rejected, sex
            dynamic pet5 = new JObject();
            pet5.Name = "Kira";
            pet5.Breed = "Border Collie";
            pet5.Sex = "";
            pets[4] = pet5;

            // input rejected, sex
            dynamic pet6 = new JObject();
            pet6.Name = "Luna";
            pet6.Breed = "Husky";
            pet6.Sex = "MFMFMFMFMF";
            pets[5] = pet6;

            #endregion

            // Can only pretend validate this - everyone uses same payment.
            payment = new JObject();
            payment.CC = "1234 5678 9012 3456";
            payment.BillingAddress = "123 Main St.";

            #region products
            // input is ideal
            dynamic product1 = new JObject();
            product1.Name = "Dog Toy";
            product1.Id = "1005";
            product1.Price = "$8.56";
            products[0] = product1;

            // multiple products
            JArray product2 = new JArray();

            // input rejected, no Name
            dynamic product2_1 = new JObject();
            product2_1.Name = "";
            product2_1.Id = "1007";
            product2_1.Price = "$10.12";
            // input rejected, no Id
            dynamic product2_2 = new JObject();
            product2_2.Name = "Cat Toy";
            product2_2.Id = "";
            product2_2.Price = "$9.74";

            product2.Add(product2_1);
            product2.Add(product2_2);
            products[1] = product2;
            #endregion

            #region services
            // input is ideal
            dynamic service1 = new JObject();
            service1.Name = "Grooming";
            service1.Id = "2001";
            service1.Price = "$45.00";
            service1.StartDate = "01/24/2021";
            service1.EndDate = "01/24/2021";
            services[0] = service1;

            // input is correct, fix format
            dynamic service2 = new JObject();
            service2.Name = "Grooming";
            service2.Id = "2001";
            service2.Price = "$45.00";
            service2.StartDate = "2021-09-5";
            service2.EndDate = "2021-09-5";
            services[1] = service2;

            // input rejected, grooming should be one day
            dynamic service3 = new JObject();
            service3.Name = "Grooming";
            service3.Id = "2001";
            service3.Price = "$45.00";
            service3.StartDate = "2021-7-5";
            service3.EndDate = "2021-7-6";
            services[2] = service3;

            // multiple services
            JArray service4 = new JArray();

            // input rejected, no Name
            dynamic service4_1 = new JObject();
            service4_1.Name = "";
            service4_1.Id = "2002";
            service4_1.Price = "$76";
            service4_1.StartDate = "3/7/2021";
            service4_1.EndDate = "3/7/2021";
            // input rejected, invalid date range
            dynamic service4_2 = new JObject();
            service4_2.Name = "Boarding";
            service4_2.Id = "2002";
            service4_2.Price = "$105";
            service4_2.StartDate = "2/1/21";
            service4_2.EndDate = "1/29/21";

            service4.Add(service4_1);
            service4.Add(service4_2);
            services[3] = service4;
            #endregion

            
            users.OrderBy(x => x.GetHashCode());    // "shuffle"
            pets.OrderBy(x => x.GetHashCode());
            IEnumerable<Tuple<JObject, JObject>> usersAndPets = users.Zip(pets, (user, pet) => new Tuple<JObject, JObject>(user, pet));
            IOrderedEnumerable<Tuple<string, JToken>> productsAndServices = products.Select(x => new Tuple<string, JToken>("products", x))
                .Concat(services.Select(x => new Tuple<string, JToken>("services", x)))
                .OrderBy(x => x.GetHashCode());

            IEnumerable<JObject> examples = usersAndPets.Zip(productsAndServices, (userAndPet, purchaseItem) => 
                new JObject(
                    new JProperty("order",
                        new JObject(
                            new JProperty("pet", userAndPet.Item2),
                            new JProperty("user", userAndPet.Item1),
                            new JProperty("payment", payment),
                            new JProperty(purchaseItem.Item1, purchaseItem.Item2)
                            )
                        )
                    )
            );

            examples.OrderBy(x => x.GetHashCode());
            return examples.Select(x => x.ToString()).ToList();
        }

        #endregion
    }
}
