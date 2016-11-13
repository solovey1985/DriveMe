namespace Bigly.Infrastructure.DomainBase
{
    public interface IDriveMeUser
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Phone { get; set; }
        string Login { get; set; }
        string Email { get; set; }

    }
}
