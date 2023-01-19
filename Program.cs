using System;

namespace RefactoringGuru.DesignPatterns.Mediator.Conceptual
{
    //declara un método utilizado por los componentes
    //para notificar al mediador sobre varios eventos.
    public interface IMediator
    {
        void Notify(object sender, string ev);
    }

    //La clase ConcreteMediator es la implementación concreta del mediador. 
    class ConcreteMediator : IMediator
    {
        private Component1 _component1;

        private Component2 _component2;

        public ConcreteMediator(Component1 component1, Component2 component2)
        {
            this._component1 = component1;
            this._component1.SetMediator(this);
            this._component2 = component2;
            this._component2.SetMediator(this);
        }

        public void Notify(object sender, string ev)
        {
            if (ev == "A")
            {
                Console.WriteLine("Mediator reacciona sobre A y desencadena las siguientes operaciones:");
                this._component2.DoC();
            }
            if (ev == "D")
            {
                Console.WriteLine("Mediador reacciona sobre D y activa las siguientes operaciones:");
                this._component1.DoB();
                this._component2.DoC();
            }
        }
    }

    // La clase BaseComponent proporciona
    //la funcionalidad básica de almacenar.
    class BaseComponent
    {
        protected IMediator _mediator;

        public BaseComponent(IMediator mediator = null)
        {
            this._mediator = mediator;
        }

        public void SetMediator(IMediator mediator)
        {
            this._mediator = mediator;
        }
    }

    // Las clases Component1 y Component2 son ejemplos de componentes
    // concretos que implementan varias funcionalidades.
    class Component1 : BaseComponent
    {
        public void DoA()
        {
            Console.WriteLine("El componente 1 hace A.");
            this._mediator.Notify(this, "A");
        }

        public void DoB()
        {
            Console.WriteLine("El componente 1 hace B.");

            this._mediator.Notify(this, "B");
        }
    }

    class Component2 : BaseComponent
    {
        public void DoC()
        {
            Console.WriteLine("El componente 2 realiza la operación C.");

            this._mediator.Notify(this, "C");
        }

        public void DoD()
        {
            Console.WriteLine("El componente 2 hace D.");

            this._mediator.Notify(this, "D");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // codigo del cliente
            Component1 component1 = new Component1();
            Component2 component2 = new Component2();
            new ConcreteMediator(component1, component2);

            Console.WriteLine("El cliente activa la operación A.");
            component1.DoA();

            Console.WriteLine();

            Console.WriteLine("El cliente desencadena la operación D.");
            component2.DoD();
        }
    }
}
