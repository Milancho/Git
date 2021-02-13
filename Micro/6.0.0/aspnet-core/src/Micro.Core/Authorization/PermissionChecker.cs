using Abp.Authorization;
using Micro.Authorization.Roles;
using Micro.Authorization.Users;

namespace Micro.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
