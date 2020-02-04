namespace mkolaric1_zadaca_3.CoR
{
    public abstract class AbstractHandler:IAutentikacija
    {
        private IAutentikacija autentikacija;
        public IAutentikacija SetNext(IAutentikacija autentikacija)
        {
            this.autentikacija = autentikacija;
            return this.autentikacija;
        }

        public virtual bool isAuthorised(string password)
        {
            if (this.autentikacija != null)
            {
                return this.autentikacija.isAuthorised(password);
            }
            else
            {
                return false;
            }
        }
    }
}