using Domain.Entities.AdminAggregate;
using Domain.Entities.BodyЕxaminationResultAggregate;
using Domain.Entities.ClinicAggregate;
using Domain.Entities.DoctorAggregate;
using Domain.Entities.PatientAggregate;
using Domain.Entities.UserAggregate;
using Domain.Enums;
using System;
using System.Linq;
using Role = Domain.Entities.UserAggregate.Role;

namespace Persistence
{
    public class Initializer
    {
        public static void Initialize(Context context)
        {
            var initializer = new Initializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(Context context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return; // Db has been seeded
            }

            SeedUsers(context);
        }

        public void SeedUsers(Context context)
        {
            #region Roles
            var roles = new[]
            {
                new Role(){Value = Domain.Enums.Role.Admin},
                new Role(){Value = Domain.Enums.Role.Doctor},
                new Role(){Value = Domain.Enums.Role.Patient},
            };

            context.Roles.AddRange(roles);
            #endregion

            #region Clinics
            var clinics = new[]
            {
                new Clinic{Name = "Taranto", Address = new ClinicAddress{ City = "Atri", Country = "Italy" }},
                new Clinic{Name = "Nacka", Address = new ClinicAddress{ City = "Flen", Country = "Sweden" }},
                new Clinic{Name = "Mulhouse", Address = new ClinicAddress{ City = "Colmar", Country = "France" }},
            };

            context.Clinics.AddRange(clinics);
            #endregion

            #region Admins
            var admins = new Admin[]
            {
                new Admin
                {
                    User = new User
                    {
                        UserRoles =  new[] { new UserRole() { Role = roles[0] }, new UserRole() { Role = roles[1]}, new UserRole() { Role = roles[2] }},
                        Username = "John",
                        Birthdate = new DateTime(),
                        Blood = Blood.ABNegative,
                        Email = "admin@gmail.com",
                        FirstName = "John",
                        LastName = "Doe",
                        Height = 195,
                        Weight = 90,
                        Gender = Gender.Male,
                        PasswordHash = "asd", //todo
                        Patient = new Patient(),
                        Doctor = new Doctor
                        {
                            Clinic = clinics[0],
                            DoctorMedicalSpecialistTypes = new DoctorMedicalSpecialistType[]{ new DoctorMedicalSpecialistType { Type =  new Domain.Entities.DoctorAggregate.MedicalSpecialistType {Value = Domain.Enums.MedicalSpecialistType.Allergists } } },
                            Summary = "Experienced Full Stack Engineer with a demonstrated history of working in the information technology and services industry."
                        }
                    }
                }
            };

            context.Admins.AddRange(admins);
            #endregion

            #region Doctors
            var doctors = new Doctor[]
            {
                new Doctor
                {
                    Clinic = clinics[1],
                    DoctorMedicalSpecialistTypes = new DoctorMedicalSpecialistType[]{ new DoctorMedicalSpecialistType { Type =  new Domain.Entities.DoctorAggregate.MedicalSpecialistType {Value = Domain.Enums.MedicalSpecialistType.Anesthesiologists } } },
                    User = new User
                    {
                        UserRoles =  new[] { new UserRole() { Role = roles[1]}, new UserRole() { Role = roles[2] }},
                        Username = "Tony",
                        Birthdate = new DateTime(),
                        Blood = Blood.ABNegative,
                        Email = "doctor@gmail.com",
                        FirstName = "Tony",
                        LastName = "Watts",
                        Height = 175,
                        Weight = 80,
                        Gender = Gender.Male,
                        PasswordHash = "asd", //todo
                        Patient = new Patient()
                    }
                }
            };

            context.Doctors.AddRange(doctors);
            #endregion

            #region Patients
            var patients = new Patient[]
            {
                new Patient
                {
                    User = new User
                    {
                        UserRoles =  new[] {new UserRole() { Role = roles[2] }},
                        Username = "Hank",
                        Birthdate = new DateTime(),
                        Blood = Blood.ABNegative,
                        Email = "patient@gmail.com",
                        FirstName = "Tony",
                        LastName = "Hill",
                        Height = 182,
                        Weight = 83,
                        Gender = Gender.Male,
                        PasswordHash = "asd", //todo
                    }
                }
            };

            context.Patients.AddRange(patients);
            #endregion

            #region BodyExaminations
            var bodyЕxaminationTypes = new BodyЕxaminationType[]
            {
                new BodyЕxaminationType
                {
                    Value = BodyExaminationType.BloodOxygenLevel
                },
                new BodyЕxaminationType
                {
                    Value = BodyExaminationType.BloodPressure
                },
                new BodyЕxaminationType
                {
                    Value = BodyExaminationType.BodyTemperature
                },
                new BodyЕxaminationType
                {
                    Value = BodyExaminationType.PulseRate
                }
            };

            context.BodyЕxaminationTypes.AddRange(bodyЕxaminationTypes);
            #endregion

            context.SaveChanges();
        }
    }
}
