using Microsoft.AspNetCore.Mvc.Filters;
using N_Shop.Application.Contracts.Persistence.Role_Permissions;

namespace N_Shop.Application.Helpers.Attributes
{
    public class CheckPermissionAttribute : Attribute, IAsyncActionFilter
    {
        private IRolePermissionRepository _rolePermissionRepository;
        private int _permissionId;
        public CheckPermissionAttribute(int PermissionId)
        {
            _permissionId = PermissionId;
        }

        public void cheakp()
        {
            throw new NotImplementedException();
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            try
            {
                _rolePermissionRepository = (IRolePermissionRepository)context.HttpContext.RequestServices.GetService(typeof(IRolePermissionRepository));
                int roleId = int.Parse(context.HttpContext.User.FindFirst("uroleid").Value);
                if (roleId == 0)
                    throw new Exception($"(CheackPermission) roleId is null.");
                if (await _rolePermissionRepository.CheackPermission(roleId, _permissionId))
                    await next();
                else
                    throw new Exception($"(CheackPermission) not have permission");
            }
            catch (Exception ex)
            {
                throw new Exception($"(CheackPermission) have one permission =  ({ex})");
            }
        }
    }
}
