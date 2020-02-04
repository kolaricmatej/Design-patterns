namespace mkolaric1_zadaca_3.CoR
{
    public interface IAutentikacija
    {
        IAutentikacija SetNext(IAutentikacija autentikacija);
        bool isAuthorised(string password);
    }
}