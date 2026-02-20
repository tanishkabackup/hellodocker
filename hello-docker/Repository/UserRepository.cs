using hello_docker.Model;
using hello_docker.Model.Request;
using Microsoft.EntityFrameworkCore;

namespace hello_docker.Repository
{
    public class UserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetAllUserDetailsAsync()
        {
            return await _context.User.FirstOrDefaultAsync();
        }

        public async Task AddUser(CreateUser user)
        {
            try
            {
                var addUser =  new User
                {
                    UserName = user.UserName,
                    Name = user.Name 
                };
                await _context.User.AddAsync(addUser);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

    }
}
