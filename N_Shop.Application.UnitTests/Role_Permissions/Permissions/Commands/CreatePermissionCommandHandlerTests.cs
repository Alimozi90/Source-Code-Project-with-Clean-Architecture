using AutoMapper;
using Moq;
using N_Shop.Application.Contracts.Persistence.Role_Permissions;
using N_Shop.Application.DTOs.Role_Permissions.Permission;
using N_Shop.Application.Features.Role_Permissions.Permissions.Handlers.Commands;
using N_Shop.Application.Features.Role_Permissions.Permissions.Requests.Commands;
using N_Shop.Application.Profiles;
using N_Shop.Application.Responses;
using N_Shop.Application.UnitTests.Mocks.Role_Permissions;
using Shouldly;
namespace N_Shop.Application.UnitTests.Role_Permissions.Permissions.Commands
{
    public class CreatePermissionCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private Mock<IPermissionRepository> _mockRepository;
        private CreatePermissionDto _createPermissionDto;
        public CreatePermissionCommandHandlerTests()
        {
            _mockRepository = MockPermissionRepository.GetPermissionRepository();
            var mapperConfig = new MapperConfiguration(option =>
             {
                 option.AddProfile<MappingProfile>();
             });
            _mapper = mapperConfig.CreateMapper();

            _createPermissionDto = new CreatePermissionDto()
            {
                Id = 3,
                Name = "مدیریت کاربران"
            };

        }
        [Fact]
        public async Task CreatePermissionTests()
        {
            var handler = new CreatePermissionCommandHandler(_mapper, _mockRepository.Object);
            var result = await handler.Handle(new CreatePermissionCommand() { CreatePermissionDto = _createPermissionDto }, CancellationToken.None);
            result.ShouldBeOfType<BaseCommandResponse>();
            var permissions = await _mockRepository.Object.GetAll();
            permissions.Count.ShouldBe(3);
        }
    }
}
