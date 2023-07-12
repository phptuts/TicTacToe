

using System.ComponentModel.DataAnnotations;

namespace TicTacToe.Models.Users;

public class User
{
    [Key]
    public int Id { get; set;}

    public string Email { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string Password { get; set; }
}