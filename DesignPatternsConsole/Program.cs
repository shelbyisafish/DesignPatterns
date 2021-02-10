using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DesignPatternsLib.PatternsEnum;

namespace DesignPatternsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                bool cont = true;
                while (cont)
                {
                    switch (Menu())
                    {
                        case DesignPattern.Quit:
                            cont = false;
                            continue;
                        case DesignPattern.AbstractFactory:
                            break;
                        case DesignPattern.Builder:
                            break;
                        case DesignPattern.FactoryMethod:
                            break;
                        case DesignPattern.Prototype:
                            break;
                        case DesignPattern.Singleton:
                            CreationalExamples.SingletonExample1();
                            Console.WriteLine("\n\n");
                            CreationalExamples.SingletonExample2();
                            Console.WriteLine("\n\n");
                            CreationalExamples.SingletonExample3();
                            break;
                        case DesignPattern.Adapter:
                            break;
                        case DesignPattern.Bridge:
                            break;
                        case DesignPattern.Composite:
                            break;
                        case DesignPattern.Decorator:
                            break;
                        case DesignPattern.Facade:
                            break;
                        case DesignPattern.Flyweight:
                            break;
                        case DesignPattern.Proxy:
                            break;
                        case DesignPattern.ChainOfResponsibility:
                            break;
                        case DesignPattern.Command:
                            break;
                        case DesignPattern.Interpreter:
                            break;
                        case DesignPattern.Iterator:
                            break;
                        case DesignPattern.Mediator:
                            break;
                        case DesignPattern.Memento:
                            break;
                        case DesignPattern.Observer:
                            break;
                        case DesignPattern.State:
                            break;
                        case DesignPattern.Strategy:
                            break;
                        case DesignPattern.TemplateMethod:
                            break;
                        case DesignPattern.Visitor:
                            break;
                        default:
                            Console.WriteLine("Input not recognized. Quitting...");
                            cont = false;
                            continue;
                    }

                    Console.WriteLine("Design pattern completed. Continue? y/n");
                    string choice = Console.ReadLine();
                    if (choice.ToLower() != "y")
                        cont = false;
                    Console.WriteLine();
                }
                Console.WriteLine("Quitting...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exiting program...");
            }
        }

        private static DesignPattern Menu()
        {
            Console.WriteLine("Choose the design pattern you want to run, or Quit to exit.");
            int index = 0;
            foreach (string patternName in Enum.GetNames(typeof(DesignPattern)))
            {
                Console.WriteLine($"{index} - {patternName}");
                index++;
            }
            Console.WriteLine();

            string choice = Console.ReadLine();
            if (Enum.TryParse(choice, out DesignPattern result))
                return result;
            else
                throw new InvalidCastException($"That is not a valid choice: {choice}");
        }
    }
}
