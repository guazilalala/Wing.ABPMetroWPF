using Abp.Authorization;
using MyProject.Authorization.Roles;
using MyProject.Authorization.Users;

namespace MyProject.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
