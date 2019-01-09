using Application.Features.Doctor.Commands.CreateDoctor;
using Application.Interfaces;
using Autofac.Extras.Moq;
using Moq;
using System;
using Domain.Entities.ClinicAggregate;
using Xunit;
using Domain.Entities.UserAggregate;
using FluentValidation.TestHelper;

namespace Application.Tests.Features.DoctorTests.Commands
{
    public class CreateDoctorValidatorTests : IDisposable
    {
        private readonly AutoMock _mock;
        private readonly CreateDoctorCommandValidator _validator;

        public CreateDoctorValidatorTests()
        {
            _mock = AutoMock.GetLoose();

            _mock.Mock<IUnitOfWork>()
                    .Setup(x => x.Clinics.GetById(It.IsAny<int>()))
                    .Returns(GetSampleClinicEntity());

            _mock.Mock<IUnitOfWork>()
                    .Setup(x => x.Users.GetById(It.IsAny<int>()))
                    .Returns(GetSampleUserEntity());

            _validator = _mock.Create<CreateDoctorCommandValidator>();
        }

        [Theory]
        [InlineData(1, "some summmary", 1)]
        public void CreateDoctor_ValidModel(int? userId, string summary, int? clinicId)
        {
            var command = new CreateDoctorCommand() { UserId =  userId, Summary = summary, ClinicId = clinicId};
            var validationResult = _validator.Validate(command);

            Assert.True(validationResult.IsValid);
        }

        [Theory]
        [InlineData(null, "some summmary", 1)]
        [InlineData(-12, "some summmary", 1)]
        public void CreateDoctor_InvalidUserId(int? userId, string summary, int? clinicId)
        {
            var command = new CreateDoctorCommand() { UserId = userId, Summary = summary, ClinicId = clinicId };

            _validator.ShouldHaveValidationErrorFor(x => x.UserId, command);
            _validator.ShouldNotHaveValidationErrorFor(x => x.Summary, command);
            _validator.ShouldNotHaveValidationErrorFor(x => x.ClinicId, command);
        }

        [Theory]
        [InlineData(1, null, 1)]
        [InlineData(1, "asd", 1)]
        public void CreateDoctor_InvalidSummary(int? userId, string summary, int? clinicId)
        {
            var command = new CreateDoctorCommand() { UserId = userId, Summary = summary, ClinicId = clinicId };

            _validator.ShouldNotHaveValidationErrorFor(x => x.UserId, command);
            _validator.ShouldHaveValidationErrorFor(x => x.Summary, command);
            _validator.ShouldNotHaveValidationErrorFor(x => x.ClinicId, command);
        }

        [Theory]
        [InlineData(1, "some summmary", null)]
        [InlineData(1, "some summmary", -1)]
        public void CreateDoctor_InvalidClinicId(int? userId, string summary, int? clinicId)
        {
            var command = new CreateDoctorCommand() { UserId = userId, Summary = summary, ClinicId = clinicId };

            _validator.ShouldNotHaveValidationErrorFor(x => x.UserId, command);
            _validator.ShouldNotHaveValidationErrorFor(x => x.Summary, command);
            _validator.ShouldHaveValidationErrorFor(x => x.ClinicId, command);
        }

        public void Dispose()
        {
            _mock.Dispose();
        }

        private Clinic GetSampleClinicEntity() => new Clinic(){};

        private User GetSampleUserEntity() => new User() { };
    }
}
