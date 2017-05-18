using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory.Old
{
    public abstract class BasePizza
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

        public abstract int CalculatePrice();
    }

    public class CheesePizza : BasePizza
    {
        public override int CalculatePrice()
        {
            return 5;
        }
    }

    public class TommatoPizza : BasePizza
    {
        public override int CalculatePrice()
        {
            return 10;
        }
    }
    public class SalamiPizza : BasePizza
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
