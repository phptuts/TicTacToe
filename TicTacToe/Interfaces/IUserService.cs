using TicTacToe.Models.Users;

namespace TicTacToe.Interfaces;
public interface IUserService
{
    public Task<List<UserView>> GetUsers();

    public Task<UserView?> GetUser(int id);


    public Task<UserView> CreateUser(UserCreate user);

    /// <summary>
    /// Returns true if the email is available
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public Task<bool> IsEmailAvailable(string email);
}

