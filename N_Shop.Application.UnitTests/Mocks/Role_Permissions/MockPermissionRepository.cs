using Moq;
using N_Shop.Application.Contracts.Persistence.Role_Permissions;
using N_Shop.Domain.Role_Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Shop.Application.UnitTests.Mocks.Role_Permissions
{
    public static class MockPermissionRepository
    {
        public static Mock<IPermissionRepository> GetPermissionRepository()
        {
            var permissions = new List<Permission>()
            {
                new Permission()
                {
                    Id = 1,
                    Name ="دسترسی به نقش ها"
                },
                new Permission()
                {
                    Id=2,
                    Name ="مدیریت کاربران"
                }
            };

            var mockRepository = new Mock<IPermissionRepository>();

            mockRepository.Setup(p => p.GetAll()).ReturnsAsync(permissions);

            mockRepository.Setup(p => p.Add(It.IsAny<Permission>()))
                .ReturnsAsync((Permission permission) =>
                {
                    permissions.Add(permission);
                    return permission;
                });

            return mockRepository;
        }
    }
}
