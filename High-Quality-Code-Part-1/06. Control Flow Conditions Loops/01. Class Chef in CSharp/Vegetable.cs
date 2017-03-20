using Class_Chef_in_CSharp.Contract;
using System;

namespace Class_Chef_in_CSharp
{
    public abstract class Vegetable : IVegetable
    {
        private double weight;

        protected Vegetable(double weight)
        {
            if (weight <= 0)
            {
                throw new ArgumentOutOfRangeException("Weight cannot be zero or negative");
            }

            this.weight = weight;
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }

            set
            {
                this.weight = value;
            }
        }
    }
}