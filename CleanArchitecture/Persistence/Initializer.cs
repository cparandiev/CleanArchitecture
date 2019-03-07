using Domain.Entities.AdminAggregate;
using Domain.Entities.BodyExaminationResultAggregate;
using Domain.Entities.ClinicAggregate;
using Domain.Entities.DoctorAggregate;
using Domain.Entities.PatientAggregate;
using Domain.Entities.UserAggregate;
using Domain.Enums;
using System;
using System.Collections.Generic;
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

            #region Types
            var bloodOxygenLevelType = new Domain.Entities.BodyExaminationResultAggregate.BodyExaminationType
            {
                Value = Domain.Enums.BodyExaminationType.BloodOxygenLevel
            };
            var bloodPressureType = new Domain.Entities.BodyExaminationResultAggregate.BodyExaminationType
            {
                Value = Domain.Enums.BodyExaminationType.BloodPressure
            };
            var bodyTemperatureType = new Domain.Entities.BodyExaminationResultAggregate.BodyExaminationType
            {
                Value = Domain.Enums.BodyExaminationType.BodyTemperature
            };
            var pulseRateType = new Domain.Entities.BodyExaminationResultAggregate.BodyExaminationType
            {
                Value = Domain.Enums.BodyExaminationType.PulseRate
            };
            #endregion
            
            var bloodOxygenLevelBodyExaminationResults = new BodyExaminationResult[]
            {
                new BodyExaminationResult
                {
                    BloodOxygenLevel = new BloodOxygenLevelExamination{OxygenLevel=90},
                    ExaminationDate = DateTime.Now,
                    Patient = patients[0],
                    BodyExaminationResultTypes = new List<BodyExaminationResultType>{new BodyExaminationResultType { Type = bloodOxygenLevelType} }
                },
                new BodyExaminationResult
                {
                    BloodOxygenLevel = new BloodOxygenLevelExamination{OxygenLevel=70},
                    ExaminationDate = DateTime.Now.AddDays(1),
                    Patient = patients[0],
                    BodyExaminationResultTypes = new List<BodyExaminationResultType>{new BodyExaminationResultType { Type = bloodOxygenLevelType} }
                },
                new BodyExaminationResult
                {
                    BloodOxygenLevel = new BloodOxygenLevelExamination{OxygenLevel=85},
                    ExaminationDate = DateTime.Now.AddDays(2),
                    Patient = patients[0],
                    BodyExaminationResultTypes = new List<BodyExaminationResultType>{new BodyExaminationResultType { Type = bloodOxygenLevelType} }
                },
                new BodyExaminationResult
                {
                    BloodOxygenLevel = new BloodOxygenLevelExamination{OxygenLevel=95},
                    ExaminationDate = DateTime.Now.AddDays(3),
                    Patient = patients[0],
                    BodyExaminationResultTypes = new List<BodyExaminationResultType>{new BodyExaminationResultType { Type = bloodOxygenLevelType} }
                },
                new BodyExaminationResult
                {
                    BloodOxygenLevel = new BloodOxygenLevelExamination{OxygenLevel=82},
                    ExaminationDate = DateTime.Now.AddDays(4),
                    Patient = patients[0],
                    BodyExaminationResultTypes = new List<BodyExaminationResultType>{new BodyExaminationResultType { Type = bloodOxygenLevelType} }
                },
                new BodyExaminationResult
                {
                    BloodOxygenLevel = new BloodOxygenLevelExamination{OxygenLevel=74},
                    ExaminationDate = DateTime.Now.AddDays(5),
                    Patient = patients[0],
                    BodyExaminationResultTypes = new List<BodyExaminationResultType>{new BodyExaminationResultType { Type = bloodOxygenLevelType} }
                },
                new BodyExaminationResult
                {
                    BloodOxygenLevel = new BloodOxygenLevelExamination{OxygenLevel=83},
                    ExaminationDate = DateTime.Now.AddDays(6),
                    Patient = patients[0],
                    BodyExaminationResultTypes = new List<BodyExaminationResultType>{new BodyExaminationResultType { Type = bloodOxygenLevelType} }
                },
            };

            var BloodPressureBodyExaminationResults = new BodyExaminationResult[]
            {
                new BodyExaminationResult
                {
                    BloodPressure = new BloodPressureExamination{DiastolicBloodPressure=80, SystolicBloodPressure=122},
                    ExaminationDate = DateTime.Now,
                    Patient = patients[0],
                    BodyExaminationResultTypes = new List<BodyExaminationResultType>{new BodyExaminationResultType { Type = bloodPressureType } }
                },
                new BodyExaminationResult
                {
                    BloodPressure = new BloodPressureExamination{DiastolicBloodPressure=70, SystolicBloodPressure=110},
                    ExaminationDate = DateTime.Now.AddDays(1),
                    Patient = patients[0],
                    BodyExaminationResultTypes = new List<BodyExaminationResultType>{new BodyExaminationResultType { Type = bloodPressureType } }
                },
                new BodyExaminationResult
                {
                    BloodPressure = new BloodPressureExamination{DiastolicBloodPressure=90, SystolicBloodPressure=140},
                    ExaminationDate = DateTime.Now.AddDays(2),
                    Patient = patients[0],
                    BodyExaminationResultTypes = new List<BodyExaminationResultType>{new BodyExaminationResultType { Type = bloodPressureType } }
                },
                new BodyExaminationResult
                {
                    BloodPressure = new BloodPressureExamination{DiastolicBloodPressure=60, SystolicBloodPressure=126},
                    ExaminationDate = DateTime.Now.AddDays(3),
                    Patient = patients[0],
                    BodyExaminationResultTypes = new List<BodyExaminationResultType>{new BodyExaminationResultType { Type = bloodPressureType } }
                },
                new BodyExaminationResult
                {
                    BloodPressure = new BloodPressureExamination{DiastolicBloodPressure=70, SystolicBloodPressure=110},
                    ExaminationDate = DateTime.Now.AddDays(4),
                    Patient = patients[0],
                    BodyExaminationResultTypes = new List<BodyExaminationResultType>{new BodyExaminationResultType { Type = bloodPressureType } }
                },
                new BodyExaminationResult
                {
                    BloodPressure = new BloodPressureExamination{DiastolicBloodPressure=84, SystolicBloodPressure=128},
                    ExaminationDate = DateTime.Now.AddDays(5),
                    Patient = patients[0],
                    BodyExaminationResultTypes = new List<BodyExaminationResultType>{new BodyExaminationResultType { Type = bloodPressureType } }
                },
                new BodyExaminationResult
                {
                    BloodPressure = new BloodPressureExamination{DiastolicBloodPressure=90, SystolicBloodPressure=135},
                    ExaminationDate = DateTime.Now.AddDays(6),
                    Patient = patients[0],
                    BodyExaminationResultTypes = new List<BodyExaminationResultType>{new BodyExaminationResultType { Type = bloodPressureType} }
                },
            };

            var bodyTemperatureExaminationResults = new BodyExaminationResult[]
            {
                new BodyExaminationResult
                {
                    BodyTemperature= new BodyTemperatureExamination{Temperature = 36.5m},
                    ExaminationDate = DateTime.Now,
                    Patient = patients[0],
                    BodyExaminationResultTypes = new List<BodyExaminationResultType>{new BodyExaminationResultType { Type = bodyTemperatureType } }
                },
                new BodyExaminationResult
                {
                    BodyTemperature= new BodyTemperatureExamination{Temperature = 38.5m},
                    ExaminationDate = DateTime.Now.AddDays(1),
                    Patient = patients[0],
                    BodyExaminationResultTypes = new List<BodyExaminationResultType>{new BodyExaminationResultType { Type = bodyTemperatureType } }
                },
                new BodyExaminationResult
                {
                    BodyTemperature= new BodyTemperatureExamination{Temperature = 37.2m},
                    ExaminationDate = DateTime.Now.AddDays(2),
                    Patient = patients[0],
                    BodyExaminationResultTypes = new List<BodyExaminationResultType>{new BodyExaminationResultType { Type = bodyTemperatureType } }
                },
                new BodyExaminationResult
                {
                    BodyTemperature= new BodyTemperatureExamination{Temperature = 35.4m},
                    ExaminationDate = DateTime.Now.AddDays(3),
                    Patient = patients[0],
                    BodyExaminationResultTypes = new List<BodyExaminationResultType>{new BodyExaminationResultType { Type = bodyTemperatureType } }
                },
                new BodyExaminationResult
                {
                    BodyTemperature= new BodyTemperatureExamination{Temperature = 39.2m},
                    ExaminationDate = DateTime.Now.AddDays(4),
                    Patient = patients[0],
                    BodyExaminationResultTypes = new List<BodyExaminationResultType>{new BodyExaminationResultType { Type = bodyTemperatureType } }
                },
                new BodyExaminationResult
                {
                    BodyTemperature= new BodyTemperatureExamination{Temperature = 36.7m},
                    ExaminationDate = DateTime.Now.AddDays(5),
                    Patient = patients[0],
                    BodyExaminationResultTypes = new List<BodyExaminationResultType>{new BodyExaminationResultType { Type = bodyTemperatureType } }
                },
                new BodyExaminationResult
                {
                    BodyTemperature= new BodyTemperatureExamination{Temperature = 37.7m},
                    ExaminationDate = DateTime.Now.AddDays(6),
                    Patient = patients[0],
                    BodyExaminationResultTypes = new List<BodyExaminationResultType>{new BodyExaminationResultType { Type = bodyTemperatureType} }
                },
            };

            var pulseRateBodyExaminationResults = new BodyExaminationResult[]
            {
                new BodyExaminationResult
                {
                    PulseRate = new PulseRateExamination{Rate=80},
                    ExaminationDate = DateTime.Now,
                    Patient = patients[0],
                    BodyExaminationResultTypes = new List<BodyExaminationResultType>{new BodyExaminationResultType { Type = pulseRateType } }
                },
                new BodyExaminationResult
                {
                    PulseRate = new PulseRateExamination{Rate=60},
                    ExaminationDate = DateTime.Now.AddDays(1),
                    Patient = patients[0],
                    BodyExaminationResultTypes = new List<BodyExaminationResultType>{new BodyExaminationResultType { Type = pulseRateType } }
                },
                new BodyExaminationResult
                {
                    PulseRate = new PulseRateExamination{Rate=80},
                    ExaminationDate = DateTime.Now.AddDays(2),
                    Patient = patients[0],
                    BodyExaminationResultTypes = new List<BodyExaminationResultType>{new BodyExaminationResultType { Type = pulseRateType } }
                },
                new BodyExaminationResult
                {
                    PulseRate = new PulseRateExamination{Rate=75},
                    ExaminationDate = DateTime.Now.AddDays(3),
                    Patient = patients[0],
                    BodyExaminationResultTypes = new List<BodyExaminationResultType>{new BodyExaminationResultType { Type = pulseRateType } }
                },
                new BodyExaminationResult
                {
                    PulseRate = new PulseRateExamination{Rate=98},
                    ExaminationDate = DateTime.Now.AddDays(4),
                    Patient = patients[0],
                    BodyExaminationResultTypes = new List<BodyExaminationResultType>{new BodyExaminationResultType { Type = pulseRateType } }
                },
                new BodyExaminationResult
                {
                    PulseRate = new PulseRateExamination{Rate=111},
                    ExaminationDate = DateTime.Now.AddDays(5),
                    Patient = patients[0],
                    BodyExaminationResultTypes = new List<BodyExaminationResultType>{new BodyExaminationResultType { Type = pulseRateType } }
                },
                new BodyExaminationResult
                {
                    PulseRate = new PulseRateExamination{Rate=91},
                    ExaminationDate = DateTime.Now.AddDays(6),
                    Patient = patients[0],
                    BodyExaminationResultTypes = new List<BodyExaminationResultType>{new BodyExaminationResultType { Type = pulseRateType } }
                },
            };

            context.BodyExaminationResults.AddRange(bloodOxygenLevelBodyExaminationResults);
            context.BodyExaminationResults.AddRange(BloodPressureBodyExaminationResults);
            context.BodyExaminationResults.AddRange(bodyTemperatureExaminationResults);
            context.BodyExaminationResults.AddRange(pulseRateBodyExaminationResults);
            #endregion

            context.SaveChanges();
        }
    }
}
