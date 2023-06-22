using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;
using PetClinic.BLL.Interfaces;
using PetClinic.BLL.Services;
using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;

namespace PetClinic.BLL.Tests;

public class UserAccountServiceTests
{
    private readonly UserAccountService _userAccountService;
    private readonly Mock<UserManager<UserEntity> >_mockUserManager = new ();
    private readonly Mock<IUnitOfWork> _mockUnitOfWork = new ();
    private readonly Mock<IMapper> _mockMapper = new ();
    private readonly Mock<IConfiguration> _mockConfiguration = new ();
    private readonly Mock<ITokenService> _tokenService = new ();

    public UserAccountServiceTests()
    {
        _userAccountService = new UserAccountService(
            _mockUserManager.Object,
            _mockMapper.Object,
            _mockConfiguration.Object,
            _mockUnitOfWork.Object,
            _tokenService.Object
            );
    }

    
}
