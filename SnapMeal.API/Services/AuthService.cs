using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SnapMeal.API.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapMeal.API.Services
{
    public class AuthService
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _dbContext;

        public AuthService(IConfiguration configuration, ApplicationDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        // Register user
        public async Task<(bool Success, string Message)> RegisterAsync(User user)
        {
            var existingUser = _dbContext.Users.FirstOrDefault(u => u.Email == user.Email);
            if (existingUser != null)
            {
                return (false, "Email already in use.");
            }

            // Hash the password (in real-world, use a proper password hashing algorithm like bcrypt or PBKDF2)
            user.Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(user.Password));

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return (true, "User registered successfully.");
        }

        // Login user
        public async Task<(bool Success, string Message, string Token)> LoginAsync(UserLogin userLogin)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == userLogin.Email);
            if (user == null)
            {
                return (false, "Invalid credentials.", null);
            }

            // Check password (in real-world, verify the hashed password properly)
            if (user.Password != Convert.ToBase64String(Encoding.UTF8.GetBytes(userLogin.Password)))
            {
                return (false, "Invalid credentials.", null);
            }

            var token = GenerateJwtToken(user);
            return (true, "Login successful.", token);
        }

        // Generate JWT Token
        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(tokenDescriptor);

            return token;
        }
    }
}
