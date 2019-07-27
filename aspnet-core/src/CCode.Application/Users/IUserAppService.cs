using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CCode.Roles.Dto;
using CCode.Users.Dto;

namespace CCode.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
