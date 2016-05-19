namespace DriveMe.Infrastructure
{
    public interface IUnitOfWork
    {
        bool Commit();
    }
}
