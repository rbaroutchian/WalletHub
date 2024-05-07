namespace WalletHub.Interfaces
{
    public interface ILoginService
    {
        bool Authenticate(string username);
        string GenerateToken(string username);
        bool ValidateToken(string token);
    }
}
