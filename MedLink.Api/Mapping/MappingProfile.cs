using AutoMapper;
using MedLink.Api.DTOs.Get;
using MedLink.Api.DTOs.Post;
using MedLink.Api.DTOs.Push;
using MedLink.Logic.Models;

namespace MedLink.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Biometric, GetBiometricDto>();
            CreateMap<Doctor, GetDoctorDto>();
            CreateMap<Illness, GetIllnessDto>();
            CreateMap<Insurance, GetInsuranceDto>();
            CreateMap<Operation, GetOperationDto>();
            CreateMap<Patient, GetPatientDto>();
            CreateMap<User, GetUserDto>();
            CreateMap<Visit, GetVisitDto>();

            CreateMap<PostBiometricDto, Biometric>();
            CreateMap<PostDoctorDto, Doctor>();
            CreateMap<PostIllnessDto, Illness>();
            CreateMap<PostInsuranceDto, Insurance>();
            CreateMap<PostOperationDto, Operation>();
            CreateMap<PostPatientDto, Patient>();
            CreateMap<PostUserDto, User>();
            CreateMap<PostVisitDto, Visit>();

            CreateMap<PushBiometricDto, Biometric>();
            CreateMap<PushDoctorDto, Doctor>();
            CreateMap<PushIllnessDto, Illness>();
            CreateMap<PushInsuranceDto, Insurance>();
            CreateMap<PushOperationDto, Operation>();
            CreateMap<PushPatientDto, Patient>();
            CreateMap<PushUserDto, User>();
            CreateMap<PushVisitDto, Visit>();
        }
    }
}

