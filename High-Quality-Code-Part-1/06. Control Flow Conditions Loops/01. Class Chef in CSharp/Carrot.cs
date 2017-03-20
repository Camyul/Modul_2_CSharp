using Class_Chef_in_CSharp.Contract;

namespace Class_Chef_in_CSharp
{
    public class Carrot : Vegetable, IVegetable
    {
        public Carrot(double weight) : base(weight)
        {
        }
    }
}