using Application.Features.Doctor.Commands.SetWeeklyWorkingTime;
using Application.Features.Doctor.Models;
using Application.Helpers.FluentValidators;
using Application.Interfaces;
using Autofac.Extras.Moq;
using Domain.Entities.DoctorAggregate;
using Domain.Entities.UserAggregate;
using FluentValidation.TestHelper;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Application.Tests.Features.DoctorTests.Commands
{
    public class SetWeeklyWorkingTimeCommandValidatorTests : IDisposable
    {
        private readonly AutoMock _mock;
        private readonly SetWeeklyWorkingTimeCommandValidator _validator;

        public SetWeeklyWorkingTimeCommandValidatorTests()
        {
            _mock = AutoMock.GetLoose();

            _mock.Mock<IUnitOfWork>()
                    .Setup(x => x.Doctors.GetById(It.IsAny<int>()))
                    .Returns(GetSampleDoctorEntity());

            _validator = _mock.Create<SetWeeklyWorkingTimeCommandValidator>();
        }
        public void Dispose()
        {
            _mock.Dispose();
        }

        [Fact]
        public void SetWeeklyWorkingTimeCommand_ValidModel()
        {
            var command = new SetWeeklyWorkingTimeCommand() { DoctorId = 1, NumOfWeeks = 1 , WorkingTimes = new List<WorkingTimeUnit> { new WorkingTimeUnit { Open = DateTime.Now.AddDays(-1), Close = DateTime.Now.AddHours(2) } } };
            
            _validator.ShouldNotHaveValidationErrorFor(x => x.DoctorId, command);
            _validator.ShouldNotHaveValidationErrorFor(x => x.NumOfWeeks, command);
            _validator.ShouldNotHaveValidationErrorFor(x => x.WorkingTimes, command);
            _validator.ShouldHaveChildValidator(x => x.WorkingTimes, typeof(WorkingTimeUnitValidator));
        }

        [Theory]
        [InlineData(null)]
        [InlineData(-1)]
        public void SetWeeklyWorkingTimeCommand_InvalidDoctorId(int? id)
        {
            var command = new SetWeeklyWorkingTimeCommand() { DoctorId = id, NumOfWeeks = 1, WorkingTimes = new List<WorkingTimeUnit> { new WorkingTimeUnit { Open = DateTime.Now.AddDays(-1), Close = DateTime.Now.AddHours(2) } } };

            _validator.ShouldHaveValidationErrorFor(x => x.DoctorId, command);
            _validator.ShouldNotHaveValidationErrorFor(x => x.NumOfWeeks, command);
            _validator.ShouldNotHaveValidationErrorFor(x => x.WorkingTimes, command);
            _validator.ShouldHaveChildValidator(x => x.WorkingTimes, typeof(WorkingTimeUnitValidator));
        }

        [Theory]
        [InlineData(null)]
        [InlineData(-1)]
        public void SetWeeklyWorkingTimeCommand_InvalidNumOfWeeks(int? count)
        {
            var command = new SetWeeklyWorkingTimeCommand() { DoctorId = 1, NumOfWeeks = count, WorkingTimes = new List<WorkingTimeUnit> { new WorkingTimeUnit { Open = DateTime.Now.AddDays(-1), Close = DateTime.Now.AddHours(2) } } };

            _validator.ShouldNotHaveValidationErrorFor(x => x.DoctorId, command);
            _validator.ShouldHaveValidationErrorFor(x => x.NumOfWeeks, command);
            _validator.ShouldNotHaveValidationErrorFor(x => x.WorkingTimes, command);
            _validator.ShouldHaveChildValidator(x => x.WorkingTimes, typeof(WorkingTimeUnitValidator));
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
