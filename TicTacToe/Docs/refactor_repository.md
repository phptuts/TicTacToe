# Repository Refactor

1. Create an interface IUserRepository with basic crud information

2. Install AutoMapper Dependencies

```
Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection
```

3. Add this to your program.cs file.

```cs
builder.Services.AddAutoMapper(typeof(Program));
```

4. Add this MapperClass

```cs
using AutoMapper;
using TicTacToe.Models.Users;

namespace TicTacToe.Mappers;

public class MappingProfiles: Profile
{   
    public MappingProfiles()
    {
        CreateMap<User, UserView>().ReverseMap();
    }
}
```

5. Add an interface and repository with a simple method.  Then inject Imapper and Context into the repository.

```cs
using TicTacToe.Models.Users;

namespace TicTacToe.Interfaces;
public interface IUserRepository
{
    /// <summary>
    /// Gets a list of users from the database.
    /// </summary>
    /// <returns></returns>
    public Task<List<UserView>> GetAsync();
}

```

```cs
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
}
```

6. Add this to your program.cs so that you can inject it into the controller.

```
builder.Services.AddTransient<IUserRepository, UserRepository>();
```

7. Inject IUserRepository into the controller and change the get endpoint.

```cs
        private readonly GameContext _context;
        private readonly IUserRepository _userRepository;

        public UsersController(GameContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserView>>> GetUsers()
        {
          return await _userRepository.GetAsync();
        }
```

8. Using dbeaver insert a record into the database and run the project.  You should see one record in the get endpoint.