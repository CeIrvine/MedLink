using AutoMapper;
using MedLink.Api.DTOs.Get;
using MedLink.Api.DTOs.Post;
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
            CreateMap<Operation, GetOperationDTO>();
            CreateMap<Patient, GetPatientDTO>();
            CreateMap<User, GetUserDTO>();
            CreateMap<Visit, GetVisitDTO>();

            CreateMap<Biometrics, PostBiometricsDTO>();
            CreateMap<Doctor, PostDoctorDTO>();
            CreateMap<Illness, PostIllnessDTO>();
            CreateMap<Insurance, PostInsuranceDTO>();
            CreateMap<Operation, PostOperationDTO>();
            CreateMap<Patient, PostPatientDTO>();
            CreateMap<User, PostUserDTO>();
            CreateMap<Visit, PostVisitDTO>();
        }
    }
}
