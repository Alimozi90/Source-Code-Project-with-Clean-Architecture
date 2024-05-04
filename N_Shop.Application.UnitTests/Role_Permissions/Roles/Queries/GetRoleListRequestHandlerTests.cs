using AutoMapper;
using Moq;
using N_Shop.Application.Contracts.Persistence.Role_Permissions;
using N_Shop.Application.DTOs.Role_Permissions.Role;
using N_Shop.Application.Features.Role_Permissions.Roles.Handlers.Queries;
using N_Shop.Application.Features.Role_Permissions.Roles.Requests.Queries;
using N_Shop.Application.Profiles;
using N_Shop.Application.UnitTests.Mocks.Role_Permissions;
using Shouldly;

namespace N_Shop.Application.UnitTests.Role_Permissions.Roles.Queries
{
    public class GetRoleListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private Mock<IRoleRepository> _mockRepository;
        public GetRoleListRequestHandlerTests()
        {
            _mockRepository = MockRoleRepository.GetRoleRepository();
            var mapperConfig = new MapperConfiguration(option =>
            {
                option.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetRoleListTests()
        {
            var handler = new GetRoleListRequestHandler(_mapper, _mockRepository.Object);
            var result = await handler.Handle(new GetRoleListRequest(), CancellationToken.None);
            result.ShouldBeOfType<List<RoleDto>>();
            result.Count.ShouldBe(2);
        }
    }
}
