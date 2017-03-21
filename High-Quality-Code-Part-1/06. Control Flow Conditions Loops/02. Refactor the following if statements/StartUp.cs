using System;

namespace Refactor_the_following_if_statements
{
    public class StartUp
    {
       public static void Main()
        {
            Potato potato = new Potato();

            if (potato != null)
            {
                if (!potato.IsRotten && potato.HasBeenPeeled)
                {
                    Cook(potato);
                }
            }
        }

        private static void Cook(Potato potato)
        {
            ////Запечени с пилешки бутчета
            throw new NotImplementedException();
        }
    }
}