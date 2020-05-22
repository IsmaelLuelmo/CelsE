using CelsE.Common.Models;
using System.Threading.Tasks;

namespace CelsE.Common.Services
{
    public interface IApiService
    {
        Task<Response> GetParteAsync(string plaque, string urlBase, string servicePrefix, string controller);

        Task<bool> CheckConnectionAsync(string url);
    }
}
