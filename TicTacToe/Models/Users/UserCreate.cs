using Microsoft.EntityFrameworkCore;
using static NuGet.Client.ManagedCodeConventions;

namespace TicTacToe.Models.Users;

[Index(propertyName: "Email", additionalPropertyNames: new string[] { "isUnique" })]
public class UserCreate
{

    public string Email { get; set; }


    public string Password { get; set; }
}

