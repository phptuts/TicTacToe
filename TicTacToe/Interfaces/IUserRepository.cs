using TicTacToe.Models.Users;

namespace TicTacToe.Interfaces;
public interface IUserRepository
{
    /// <summary>
    /// Gets a list of users from the database.
    /// </summary>
    /// <returns></returns>
    public Task<List<UserView>> GetAsync();

    /// <summary>
    /// Gets a user by the id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<UserView?> GetAsync(int id);

    /// <summary>
    /// Creates a user
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public Task<UserView> CreateAsync(UserCreate user);

    /// <summary>
    /// Return true if the email already exists
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public Task<bool> EmailExist(string email);
}

