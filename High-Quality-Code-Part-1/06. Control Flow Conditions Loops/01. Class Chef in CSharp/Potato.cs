using Class_Chef_in_CSharp.Contract;

namespace Class_Chef_in_CSharp
{
    public class Potato : Vegetable, IVegetable
    {
        public Potato(double weight) : base(weight)
        {
        }
    }
}