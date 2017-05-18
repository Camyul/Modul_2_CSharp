using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory.New
{
    public class NewPizza
    {
        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public virtual int CalculatePrice()
        {
            return 5;
        }

        public void Print()
        {
            Console.WriteLine("{0} {1}", this.Name, this.CalculatePrice());
        }
    }

    public class CheesePizza : NewPizza
    {
        private readonly NewPizza pizza;

        public override int CalculatePrice()
        {
            return 5;
        }
    }

    public class TommatoPizza : NewPizza
    {
        public override int CalculatePrice()
        {
            return 10;
        }
    }
    public class SalamiPizza : NewPizza
    {
        public override int CalculatePrice()
        {
            return 12;
        }
    }

    public class CheezeSalamiPizza : CheesePizza
    {
        public override int CalculatePrice()
        {
            return base.CalculatePrice() + 12;
        }
    }

    public class TomatoCheezePizza : CheesePizza
    {
        public override int CalculatePrice()
        {
            return base.CalculatePrice() + 5;
        }
    }

    public class SalamiTomatoCheezePizza : TomatoCheezePizza
    {
        public override int CalculatePrice()
        {
            return base.CalculatePrice() + 12;
        }
    }
}
