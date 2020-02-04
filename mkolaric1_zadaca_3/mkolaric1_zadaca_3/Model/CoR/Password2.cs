using System;

namespace mkolaric1_zadaca_3.CoR
{
    public class Password2:AbstractHandler
    {
        public override bool isAuthorised(string password)
        {
            if (password == "654321")
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