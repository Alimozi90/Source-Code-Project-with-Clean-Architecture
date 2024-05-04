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
    public static class MockRoleRepository
    {
        public static Mock<IRoleRepository> GetRoleRepository()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Id=1,
                    Name="ادمین",
                },
                new Role()
                {
                    Id =2,
                    Name="کاربر عادی"
                }
            };

            var mockRepository = new Mock<IRoleRepository>();

            mockRepository.Setup(r => r.GetAll()).ReturnsAsync(roles);

            mockRepository.Setup(r => r.Add(It.IsAny<Role>()))
                .ReturnsAsync((Role role) =>
                {
                    roles.Add(role);
                    return role;
                });
            return mockRepository;
        }

    }
}
