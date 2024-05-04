using AutoMapper;
using Moq;
using N_Shop.Application.Contracts.Persistence.Role_Permissions;
using N_Shop.Application.DTOs.Role_Permissions.Role;
using N_Shop.Application.Features.Role_Permissions.Roles.Handlers.Commands;
using N_Shop.Application.Features.Role_Permissions.Roles.Requests.Commands;
using N_Shop.Application.Profiles;
using N_Shop.Application.Responses;
using N_Shop.Application.UnitTests.Mocks.Role_Permissions;
using Shouldly;

namespace N_Shop.Application.UnitTests.Role_Permissions.Roles.Commands
{
    public class CreateRoleCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private Mock<IRoleRepository> _mockRepository;
        private CreateRoleDto _createRoleDto;
        public CreateRoleCommandHandlerTests()
        {
            _mockRepository = MockRoleRepository.GetRoleRepository();

            var mapperConfig = new MapperConfiguration(option =>
            {
                option.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _createRoleDto = new CreateRoleDto()
            {
                Id = 3,
                Name = "افزودن نقش"
            };

        }
        [Fact]
        public async Task CreateRoleTests()
        {
            var handler = new CreateRoleCommandHandler(_mapper, _mockRepository.Object);
            var result = await handler.Handle(new CreateRoleCommand()
            {
                CreateRoleDto = _createRoleDto
            }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();
            var roles = await _mockRepository.Object.GetAll();
            roles.Count.ShouldBe(3);
        }
    }
}
