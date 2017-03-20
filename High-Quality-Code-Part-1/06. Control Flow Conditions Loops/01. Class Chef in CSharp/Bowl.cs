using Class_Chef_in_CSharp.Contract;

namespace Class_Chef_in_CSharp
{
    public class Bowl
    {
        private double salataWeight;

        public double SalataWeight { get; set; }

        internal void Add(IVegetable product)
        {
            this.SalataWeight += product.Weight;
        }
    }
}