using Application.Interfaces;
using Application.Specifications.DoctorSpecifications;
using Autofac.Extras.Moq;
using System.Collections.Generic;
using Xunit;
using Domain.Entities.DoctorAggregate;
using Domain.Entities.UserAggregate;
using System.Linq;
using AutoMapper;
using Application.Features.Doctor.Models;
using Application.Features.Users.Models;
using Application.Features.Doctor.Queries.GetDoctor;
using System.Threading;
using System.Threading.Tasks;
using Moq;

namespace Application.Tests.Features.DoctorTests.Queries
{
    public class GetDoctorTests
    {
        [Fact]
        public async Task GetDoctor_ValidCall()
        {
            int mockedUserId = 1;
            var mockedDoctorEntity = GetSampleDoctorsEntities().First();

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IUnitOfWork>()
                    .Setup(x => x.Doctors.GetSingleBySpec(It.IsAny<DoctorWithUserPropsSpecifications>()))
                    .Returns(mockedDoctorEntity);

                mock.Mock<IMapper>()
                    .Setup(x => x.Map<DoctorDto>(mockedDoctorEntity))
                    .Returns(GetSampleDoctorsDtos().First());

                var cls = mock.Create<GetDoctorByIdQueryHandler>();

                var expected = GetSampleDoctorsDtos().First();
                var actual = await cls.Handle(new GetDoctorByIdQuery() { UserId = mockedUserId }, CancellationToken.None);

                Assert.True(actual != null);
                Assert.Equal(expected.Id, actual.Id);
                Assert.Equal(expected.User.Id, actual.User.Id);
                Assert.Equal(expected.User.FirstName, actual.User.FirstName);
                Assert.Equal(expected.User.LastName, actual.User.LastName);

                mock.Mock<IUnitOfWork>()
                    .Verify(x => x.Doctors.GetSingleBySpec(It.IsAny<DoctorWithUserPropsSpecifications>()), Times.Once);

                mock.Mock<IMapper>()
                    .Verify(x => x.Map<DoctorDto>(It.IsAny<Doctor>()), Times.Once);
            };
        }

        private List<Doctor> GetSampleDoctorsEntities() => new List<Doctor>
        {
            new Doctor()
            {
                Id = 1,
                UserId = 1,
                User = new User
                {
                    Id = 1,
                    FirstName = "Tsvetko",
                    LastName = "Parandiev",
                }
            },
            new Doctor()
            {
                Id = 2,
                UserId = 2,
                User = new User
                {
                    Id = 2,
                    FirstName = "Shayne",
                    LastName = "Wason",
                }
            },
            new Doctor()
            {
                Id = 3,
                UserId = 3,
                User = new User
                {
                    Id = 3,
                    FirstName = "Ted",
                    LastName = "Tavernia",
                }
            },
        };

        private List<DoctorDto> GetSampleDoctorsDtos() => new List<DoctorDto>
        {
            new DoctorDto()
            {
                Id = 1,
                User = new UserDto
                {
                    Id = 1,
                    FirstName = "Tsvetko",
                    LastName = "Parandiev",
                }
            },
            new DoctorDto()
            {
                Id = 2,
                User = new UserDto
                {
                    Id = 2,
                    FirstName = "Shayne",
                    LastName = "Wason",
                }
            },
            new DoctorDto()
            {
                Id = 3,
                User = new UserDto
                {
                    Id = 3,
                    FirstName = "Ted",
                    LastName = "Tavernia",
                }
            },
        };
    }
}
