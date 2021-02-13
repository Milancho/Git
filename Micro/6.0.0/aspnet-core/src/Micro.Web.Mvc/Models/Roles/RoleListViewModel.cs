using System.Collections.Generic;
using Micro.Roles.Dto;

namespace Micro.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
