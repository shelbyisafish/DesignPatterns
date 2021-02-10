using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLib
{
    public class PatternsEnum
    {
        public enum DesignPattern
        {
            Quit,
            // Creational
            AbstractFactory,
            Builder,
            FactoryMethod,
            Prototype,
            Singleton,
            // Structural
            Adapter,
            Bridge,
            Composite,
            Decorator,
            Facade,
            Flyweight,
            Proxy,
            // Behavioral
            ChainOfResponsibility,
            Command,
            Interpreter,
            Iterator,
            Mediator,
            Memento,
            Observer,
            State,
            Strategy,
            TemplateMethod,
            Visitor
        }
    }
}
