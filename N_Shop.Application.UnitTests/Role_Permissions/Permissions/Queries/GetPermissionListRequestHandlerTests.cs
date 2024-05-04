using AutoMapper;
using Moq;
using N_Shop.Application.Contracts.Persistence.Role_Permissions;
using N_Shop.Application.DTOs.Role_Permissions.Permission;
using N_Shop.Application.Features.Role_Permissions.Permissions.Handlers.Queries;
using N_Shop.Application.Features.Role_Permissions.Permissions.Requests.Queries;
using N_Shop.Application.Profiles;
using N_Shop.Application.UnitTests.Mocks.Role_Permissions;
using Shouldly;
namespace N_Shop.Application.UnitTests.Role_Permissions.Permissions.Queries
{
    public class GetPermissionListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private Mock<IPermissionRepository> _mockRepository;
        public GetPermissionListRequestHandlerTests()
        {
            _mockRepository = MockPermissionRepository.GetPermissionRepository();

            var mapperConfig = new MapperConfiguration(option =>
             {
                 option.AddProfile<MappingProfile>();
             });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetPermissionList()
        {
            var handler = new GetPermissionListRequestHandler(_mapper, _mockRepository.Object);
            var result = await handler.Handle(new GetPermissionListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<PermissionDto>>();
            result.Count.ShouldBe(2);
        }
    }
}
