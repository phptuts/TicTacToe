using Microsoft.EntityFrameworkCore;
using TicTacToe.Models.Users;

namespace TicTacToe.Models;

public class GameContext : DbContext
{
	public GameContext(DbContextOptions<GameContext> options) : base(options)
	{

	}

	public DbSet<User> Users { get; set; }
}

