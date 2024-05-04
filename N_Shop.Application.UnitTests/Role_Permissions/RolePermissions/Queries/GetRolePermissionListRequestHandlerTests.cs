using AutoMapper;
using Moq;
using N_Shop.Application.Contracts.Persistence.Role_Permissions;
using N_Shop.Application.Features.Role_Permissions.RolePermissions.Handlers.Queries;
using N_Shop.Application.Features.Role_Permissions.RolePermissions.Requests.Queries;
using N_Shop.Application.Profiles;
using N_Shop.Application.UnitTests.Mocks.Role_Permissions;

namespace N_Shop.Application.UnitTests.Role_Permissions.RolePermissions.Queries
{
    public class GetRolePermissionListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private Mock<IRoleRepository> _mockRoleRepository;
        private Mock<IPermissionRepository> _mockPermissionRepository;
        private Mock<IRolePermissionRepository> _mockRolePermissionRepository;
        public GetRolePermissionListRequestHandlerTests()
        {
            _mockRoleRepository =
                MockRoleRepository.GetRoleRepository();

            _mockPermissionRepository = MockPermissionRepository.GetPermissionRepository();

            _mockRolePermissionRepository = MockRolePermissionRepository.GetRolePermissionRepository();


            var mapperConfig = new MapperConfiguration(option =>
            {
                option.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        public async Task GerRolePermissionListTest()
        {
            var handler = new GetRolePermissionListRequestHandler(_mapper, _mockRoleRepository.Object, _mockPermissionRepository.Object, _mockRolePermissionRepository.Object);

            //var result = handler.Handle(new GetRolePermissionListRequest() { Id =2});
        }
    }
}
