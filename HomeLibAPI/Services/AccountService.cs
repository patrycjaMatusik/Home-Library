using HomeLibAPI.Entities;
using HomeLibAPI.Models;
using HomeLibraryAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeLibAPI.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
        //string GenerateJwt(LoginDto dto);
    }
    public class AccountService : IAccountService
    {
        private readonly HomeLibraryDbContext _context;
        //private readonly IPasswordHasher<User> _passwordHasher;
        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                Email = dto.Email,
                RoleId = dto.RoleId
            };
            //var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);

            //newUser.PasswordHash = hashedPassword;
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
    }
}
