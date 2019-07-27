using Abp.Authorization;
using CCode.Authorization.Roles;
using CCode.Authorization.Users;

namespace CCode.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
