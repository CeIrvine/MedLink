using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedLink.Api.Data;
using MedLink.Logic.Models;
using AutoMapper;
using MedLink.Logic.DTOs.Get;
using MedLink.Logic.DTOs.Post;
using MedLink.Logic.DTOs.Push;
using MedLink.Api.Controller;

namespace MedLink.Api.Controllers
{
    public class DoctorsController 
        : BaseApiController<Doctor, GetDoctorDto, PostDoctorDto, PutDoctorDto>
    {
        public DoctorsController(AppDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }
    }                
}