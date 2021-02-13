using System.Collections.Generic;
using Micro.Roles.Dto;

namespace Micro.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}