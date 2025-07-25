using AutoMapper;
using MedLink.Logic.Models;
using MedLink.Logic.DTOs.Get;
using MedLink.Logic.DTOs.Post;
using MedLink.Logic.DTOs.Push;

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
            CreateMap<Surgery, GetSurgeryDto>();

            CreateMap<PostBiometricDto, Biometric>();
            CreateMap<PostDoctorDto, Doctor>();
            CreateMap<PostIllnessDto, Illness>();
            CreateMap<PostInsuranceDto, Insurance>();
            CreateMap<PostOperationDto, Operation>();
            CreateMap<PostPatientDto, Patient>();
            CreateMap<PostUserDto, User>();
            CreateMap<PostVisitDto, Visit>();
            CreateMap<PostSurgeryDto, Surgery>();

            CreateMap<PutBiometricDto, Biometric>();
            CreateMap<PutDoctorDto, Doctor>();
            CreateMap<PutIllnessDto, Illness>();
            CreateMap<PutInsuranceDto, Insurance>();
            CreateMap<PutOperationDto, Operation>();
            CreateMap<PutPatientDto, Patient>();
            CreateMap<PutUserDto, User>();
            CreateMap<PutVisitDto, Visit>();
            CreateMap<PutSurgeryDto, Surgery>();
        }
    }
}

