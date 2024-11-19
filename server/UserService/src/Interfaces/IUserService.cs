using System.Threading.Tasks;
using UserService.Dtos;

namespace UserService.Interfaces
{
    public interface IUserService
    {
        // Authenticate a user with their credentials
        Task<AuthResponse> AuthenticateUser(AuthDto authDto);
     
    }
}
