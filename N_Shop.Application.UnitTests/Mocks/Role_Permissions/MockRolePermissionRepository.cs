using Moq;
using N_Shop.Application.Contracts.Persistence.Role_Permissions;
using N_Shop.Domain.Role_Permissions;

namespace N_Shop.Application.UnitTests.Mocks.Role_Permissions
{
    public static class MockRolePermissionRepository
    {
        public static Mock<IRolePermissionRepository> GetRolePermissionRepository()
        {
            var rolePermissionRepository = new Mock<IRolePermissionRepository>();

            var rolePermissions = new List<RolePermission>()
            {
                new RolePermission()
                {
                    RoleId = 1,
                     PermissionId = 1,
                },
                new RolePermission()
                {
                    RoleId = 1,
                    PermissionId = 2,
                }
            };


            rolePermissionRepository.Setup(rp => rp.GetAll()).ReturnsAsync(rolePermissions);

            rolePermissionRepository.Setup(rp => rp.GetPermissionsByRoleId(It.IsAny<int>())).ReturnsAsync((int roleid) =>
            {
                return rolePermissions;
            });

            rolePermissionRepository.Setup(rp => rp.Add(It.IsAny<RolePermission>()))
                .ReturnsAsync((RolePermission rolePermission) =>
                {
                    rolePermissions.Add(rolePermission);
                    return rolePermission;
                });

            return rolePermissionRepository;
        }
    }
}
