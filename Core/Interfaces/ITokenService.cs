using Core.Entities.Identity;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateToken(User user);
    }
}
