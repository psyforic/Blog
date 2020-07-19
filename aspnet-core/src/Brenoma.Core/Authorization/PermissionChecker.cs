using Abp.Authorization;
using Brenoma.Authorization.Roles;
using Brenoma.Authorization.Users;

namespace Brenoma.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
