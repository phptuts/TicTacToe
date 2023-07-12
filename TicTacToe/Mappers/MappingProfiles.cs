using AutoMapper;
using TicTacToe.Models.Users;

namespace TicTacToe.Mappers;

public class MappingProfiles: Profile
{   
    public MappingProfiles()
    {
        CreateMap<User, UserView>().ReverseMap();
        CreateMap<User, UserCreate>().ReverseMap();
    }
}

