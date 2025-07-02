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
            CreateMap<Biometrics, GetBiometricsDTO>();
            CreateMap<Doctor, GetDoctorDTO>();
            CreateMap<Illness, GetIllnessDTO>();
            CreateMap<Insurance, GetInsuranceDTO>();
            CreateMap<Operation, GetOperationDTO>();
            CreateMap<Patient, GetPatientDTO>();
            CreateMap<User, GetUserDTO>();
            CreateMap<Visit, GetVisitDTO>();

            CreateMap<PostBiometricsDTO, Biometrics>();
            CreateMap<PostDoctorDTO, Doctor>();
            CreateMap<PostIllnessDTO, Illness>();
            CreateMap<PostInsuranceDTO, Insurance>();
            CreateMap<PostOperationDTO, Operation>();
            CreateMap<PostPatientDTO, Patient>();
            CreateMap<PostUserDTO, User>();
            CreateMap<PostVisitDTO, Visit>();

            CreateMap<PushBiometricsDTO, Biometrics>();
            CreateMap<PushDoctorDTO, Doctor>();
            CreateMap<PushIllnessDTO, Illness>();
            CreateMap<PushInsuranceDTO, Insurance>();
            CreateMap<PushOperationDTO, Operation>();
            CreateMap<PushPatientDTO, Patient>();
            CreateMap<PushUserDTO, User>();
            CreateMap<PushVisitDTO, Visit>();
        }
    }
}

