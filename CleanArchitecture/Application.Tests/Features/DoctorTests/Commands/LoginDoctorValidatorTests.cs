using Application.Features.Doctor.Commands.LoginDoctor;
using Application.Features.Doctor.Models;
using Application.Features.Users.Models;
using Application.Interfaces;
using Application.Specifications.DoctorSpecifications;
using Autofac.Extras.Moq;
using Domain.Entities.DoctorAggregate;
using Domain.Entities.UserAggregate;
using Moq;
using Xunit;
using FluentValidation.TestHelper;
using System;

namespace Application.Tests.Features.DoctorTests.Commands
{
    public class LoginDoctorValidatorTests : IDisposable
    {
        private readonly AutoMock _mock;
        private readonly LoginDoctorCommandValidator _validator;

        public LoginDoctorValidatorTests()
        {
            _mock = AutoMock.GetLoose();

            _mock.Mock<IUnitOfWork>()
                    .Setup(x => x.Doctors.GetSingleBySpec(It.IsAny<DoctorWithUserPropsSpecifications>()))
                    .Returns(GetSampleDoctorEntity());

            _mock.Mock<ISecurePasswordHasher>()
                .Setup(x => x.Verify(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            _validator = _mock.Create<LoginDoctorCommandValidator>();
        }

        public void Dispose()
        {
            _mock.Dispose();
        }

        [Theory]
        [InlineData("ceco", "Aa+123456")]
        [InlineData("john", "1Aazefre$")]
        [InlineData("mike", "aAsdfsd13ecd%")]
        public void LoginDoctor_ValidModel(string username, string password)
        {
            var command = new LoginDoctorCommand() { Username = username, Password = password };
            var validationResult = _validator.Validate(command);

            Assert.True(validationResult.IsValid);
        }

        [Theory]
        [InlineData("ce", "Aa+123456")]
        [InlineData("johncfvsdfsdfsdfdrebgvregrewvfettgv", "1Aazefre$")]
        [InlineData(null, "aAsdfsd13ecd%")]
        public void LoginDoctor_InvalidUsername(string username, string password)
        {
            var command = new LoginDoctorCommand() { Username = username, Password = password };

            _validator.ShouldHaveValidationErrorFor(x => x.Username, command);
            _validator.ShouldNotHaveValidationErrorFor(x => x.Password, command);
        }

        [Theory]
        [InlineData("ceco", "aaaaaaaaaa")]
        [InlineData("john", "AAAAAAAAA")]
        [InlineData("mike", "%%%%%%%")]
        public void LoginDoctor_InvalidPassword(string username, string password)
        {
            var command = new LoginDoctorCommand() { Username = username, Password = password };

            _validator.ShouldNotHaveValidationErrorFor(x => x.Username, command);
            _validator.ShouldHaveValidationErrorFor(x => x.Password, command);
        }

        private Doctor GetSampleDoctorEntity() => new Doctor()
        {
            Id = 1,
            UserId = 1,
            User = new User
            {
                Id = 1,
                Username = "ceco",
                FirstName = "Tsvetko",
                LastName = "Parandiev",
            }
        };
    }
}
