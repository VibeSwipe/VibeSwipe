namespace VibeSwipe.Domain.Contracts
{
    public interface IPaswordHashingService
    {
        string HashPassword(string password);
    }
}
