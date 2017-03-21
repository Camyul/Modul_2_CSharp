using Class_Chef_in_CSharp.Contract;

namespace Class_Chef_in_CSharp
{
    public class Chef
    {
        public static void Main()
        {
            Chef manchev = new Chef();
            manchev.Cook();
        }

        public void Cook()
        {
            Potato potato = GetPotato();
            Carrot carrot = GetCarrot();
            Bowl bowl;
            Peel(potato);

            Peel(carrot);
            bowl = GetBowl();
            Cut(potato);
            Cut(carrot);
            bowl.Add(carrot);

            bowl.Add(potato);
        }

        private Bowl GetBowl()
        {
            Bowl newCup = new Bowl();

            return newCup;
        }

        private Carrot GetCarrot()
        {
            Carrot newCarrot = new Carrot(300);

            return newCarrot;
        }

        private Potato GetPotato()
        {
            Potato newPatato = new Potato(800);

            return newPatato;
        }

        private void Cut(IVegetable potato)
        {
            potato.Weight -= 20;
        }

        private void Peel(IVegetable potato)
        {
            potato.Weight -= 50;
        }
    }
}
