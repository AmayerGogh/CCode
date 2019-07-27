using System.Threading.Tasks;
using Abp.Application.Services;
using CCode.Sessions.Dto;

namespace CCode.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
