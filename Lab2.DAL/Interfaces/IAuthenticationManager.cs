using Lab2.DAL.Models.User;

namespace Lab2.DAL.Interfaces
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(LoginUser loginUser);
        Task<string> CreateToken();
    }
}
