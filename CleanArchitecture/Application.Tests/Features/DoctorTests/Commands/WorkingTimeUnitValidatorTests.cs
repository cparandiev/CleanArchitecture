using Application.Features.Doctor.Models;
using Application.Helpers.FluentValidators;
using Autofac.Extras.Moq;
using FluentValidation.TestHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Application.Tests.Features.DoctorTests.Commands
{
    public class WorkingTimeUnitValidatorTests : IDisposable
    {
        private readonly AutoMock _mock;
        private readonly WorkingTimeUnitValidator _validator;

        public WorkingTimeUnitValidatorTests()
        {
            _mock = AutoMock.GetLoose();
            
            _validator = _mock.Create<WorkingTimeUnitValidator>();
        }
        public void Dispose()
        {
            _mock.Dispose();
        }

        [Theory]
        [ClassData(typeof(WorkingTimeUnitValidTestData))]
        public void WorkingTimeUnit_ValidModel(DateTime? open, DateTime? close)
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.Open, new WorkingTimeUnit { Open = open, Close = close });
            _validator.ShouldNotHaveValidationErrorFor(x => x.Close, new WorkingTimeUnit { Open = open, Close = close });
        }

        [Theory]
        [ClassData(typeof(WorkingTimeUnitInvalidOpenDateTimeTestData))]
        public void WorkingTimeUnit_InvalidOpenDateTime(DateTime? open, DateTime? close)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.Open, new WorkingTimeUnit { Open = open, Close = close });
            _validator.ShouldNotHaveValidationErrorFor(x => x.Close, new WorkingTimeUnit { Open = open, Close = close });
        }

        [Theory]
        [ClassData(typeof(WorkingTimeUnitInvalidCloseDateTimeTestData))]
        public void WorkingTimeUnit_InvalidCloseDateTime(DateTime? open, DateTime? close)
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.Open, new WorkingTimeUnit { Open = open, Close = close });
            _validator.ShouldHaveValidationErrorFor(x => x.Close, new WorkingTimeUnit { Open = open, Close = close });
        }
    }

    public class WorkingTimeUnitValidTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { DateTime.Now.AddHours(1), DateTime.Now.AddHours(3) };
            yield return new object[] { DateTime.Now.AddHours(-2), DateTime.Now.AddHours(-1) };
            yield return new object[] { DateTime.Now.AddHours(2), DateTime.Now.AddHours(5) };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class WorkingTimeUnitInvalidOpenDateTimeTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { null, DateTime.Now.AddHours(5) };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class WorkingTimeUnitInvalidCloseDateTimeTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { DateTime.Now.AddHours(5), null };
            yield return new object[] { DateTime.Now.AddHours(5), DateTime.Now.AddHours(-5) };
            yield return new object[] { DateTime.Now.AddHours(5), DateTime.Now.AddHours(2) };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
