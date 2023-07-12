using TicTacToe.Interfaces;
using TicTacToe.Models.Users;
using BCrypt.Net;

namespace TicTacToe.Services;

public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
	{
        _userRepository = userRepository;
    }

    public async Task<UserView> CreateUser(UserCreate userDto)
    {
        userDto.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
        return await _userRepository.CreateAsync(userDto);
    }

    public async Task<UserView?> GetUser(int id)
    {
        return await _userRepository.GetAsync(id);
    }

    public async Task<List<UserView>> GetUsers()
    {
        return await _userRepository.GetAsync();
    }

    public async Task<bool> IsEmailAvailable(string email)
    {
        return ! await _userRepository.EmailExist(email);
    }
}

