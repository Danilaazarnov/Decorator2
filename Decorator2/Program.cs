using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Computer computer1 = new StrongComputer();
            computer1 = new SSDComputer(computer1); // сильный по характеристикам компьютер с SSD
            Console.WriteLine("Название: {0}", computer1.Name);
            Console.WriteLine("Цена: {0}", computer1.GetCost());

            Computer computer2 = new StrongComputer();
            computer2 = new CPUComputer(computer2);// сильный по характеристикам компьютер с допольнительным CPU
            Console.WriteLine("Название: {0}", computer2.Name);
            Console.WriteLine("Цена: {0}", computer2.GetCost());

            Computer computer3 = new MidComputer();
            computer3 = new SSDComputer(computer3);
            computer3 = new CPUComputer(computer3);// средний по характеристикам компьютер с допольнительным CPU и с SSD
            Console.WriteLine("Название: {0}", computer3.Name);
            Console.WriteLine("Цена: {0}", computer3.GetCost());

            Console.ReadLine();
        }
    }

    abstract class Computer
    {
        public Computer(string n)
        {
            this.Name = n;
        }
        public string Name { get; protected set; }
        public abstract int GetCost();
    }

    class StrongComputer : Computer
    {
        public StrongComputer() : base("сильный по характеристикам компьютер")
        { }
        public override int GetCost()
        {
            return 60000;
        }
    }
    class MidComputer : Computer
    {
        public MidComputer()
            : base("средний по характеристикам компьютер ")
        { }
        public override int GetCost()
        {
            return 40000;
        }
    }

    abstract class ComputerDecorator : Computer
    {
        protected Computer computer;
        public ComputerDecorator(string n, Computer computer) : base(n)
        {
            this.computer = computer;
        }
    }

    class SSDComputer : ComputerDecorator
    {
        public SSDComputer(Computer p)
            : base(p.Name + ", с SSD", p)
        { }

        public override int GetCost()
        {
            return computer.GetCost() + 6000;
        }
    }

    class CPUComputer : ComputerDecorator
    {
        public CPUComputer(Computer p)
            : base(p.Name + ", с дополнительным CPU", p)
        { }

        public override int GetCost()
        {
            return computer.GetCost() + 4000;
        }
    }
}