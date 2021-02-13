namespace SecretMessages_Library.Routines
{
    public interface ILoginRoutine
    {
        (bool, int) SignIn(string userName, string password);
        bool SignUp(string userName, string password);
    }
}