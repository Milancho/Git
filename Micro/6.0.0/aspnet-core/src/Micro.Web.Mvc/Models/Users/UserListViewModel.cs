using System.Collections.Generic;
using Micro.Roles.Dto;

namespace Micro.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
