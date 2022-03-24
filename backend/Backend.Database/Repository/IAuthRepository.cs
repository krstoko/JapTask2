using backend.Core.Common;
using backend.Models;
using System.Threading.Tasks;

namespace backend.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<string>> Login(string username, string password);
    }
}
