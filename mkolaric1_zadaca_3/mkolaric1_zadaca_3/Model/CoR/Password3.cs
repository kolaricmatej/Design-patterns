using System;

namespace mkolaric1_zadaca_3.CoR
{
    public class Password3:AbstractHandler
    {
        public override bool isAuthorised(string password)
        {
            if (password == "000000")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine();
                Console.WriteLine("Lozinka je ispravna");
                Console.ResetColor();
                return true;
            }
            else
            {
                return base.isAuthorised(password);
            }
        }
    }
}