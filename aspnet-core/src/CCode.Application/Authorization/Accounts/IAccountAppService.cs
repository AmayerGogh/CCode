using System.Threading.Tasks;
using Abp.Application.Services;
using CCode.Authorization.Accounts.Dto;

namespace CCode.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
