namespace Domain.Interfaces;

public interface IUser
{
    Task<bool> AddUser(string email, string password, int age, string phoneNumber);

}