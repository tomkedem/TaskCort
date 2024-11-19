using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Dtos;
using UserService.Interfaces;

namespace UserService.Services
{
    public class MockUserService : IUserService
    {
        // Simulated user data
        private readonly List<(string UserId, string Username, string Password, string Role)> _users =
            new List<(string, string, string, string)>
            {
                ("1", "admin", "admin123", "Admin"),
                ("2", "viewer", "viewer123", "Viewer")
            };

        // Simulated role-based permissions
        private readonly Dictionary<string, List<string>> _rolePermissions = new Dictionary<string, List<string>>
        {
            { "Admin", new List<string> { "ViewCases", "EditCases", "DeleteCases" } },
            { "Viewer", new List<string> { "ViewCases" } }
        };

        // Authenticate a user by username and password
        public Task<AuthResponse> AuthenticateUser(AuthDto authDto)
        {
            var user = _users.FirstOrDefault(u => u.Username == authDto.Username && u.Password == authDto.Password);

            if (user == default)
            {
                return Task.FromResult(new AuthResponse
                {
                    IsAuthenticated = false,
                    ErrorMessage = "Invalid username or password."
                });
            }

            // Simulate generating a token
            var token = Guid.NewGuid().ToString();

            return Task.FromResult(new AuthResponse
            {
                IsAuthenticated = true,
                Token = token
            });
        }

        
    }
}
