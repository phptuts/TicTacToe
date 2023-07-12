using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TicTacToe.Interfaces;
using TicTacToe.Models;
using TicTacToe.Models.Users;

namespace TicTacToe.Repositories;
public class UserRepository : IUserRepository
{
    private readonly GameContext _context;
    private readonly IMapper _mapper;

    public UserRepository(GameContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<UserView>> GetAsync()
    {
       // This is bad because there is a million user you are fetching them all
       var users = await _context.Users.ToListAsync();
       return _mapper.Map<List<UserView>>(users); 
    }

    public async Task<UserView?> GetAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return null;
        }

        return _mapper.Map<UserView>(user);
    }

    public async Task<bool> EmailExist(string email)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email);

        return user is not null;
    }
    public async Task<UserView> CreateAsync(UserCreate userCreate)
    {
        var user = _mapper.Map<User>(userCreate);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return _mapper.Map<UserView>(user);
    }
}
