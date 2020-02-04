using System;
using System.Runtime.Serialization.Formatters;

namespace mkolaric1_zadaca_3.CoR
{
    public class Password1:AbstractHandler
    {
        public override bool isAuthorised(string password)
        {
            if (password == "123456")
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