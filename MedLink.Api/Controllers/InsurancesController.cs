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
    public class InsurancesController 
        : BaseApiController<Insurance, GetInsuranceDto, PostInsuranceDto, PutInsuranceDto>
    {
        public InsurancesController(AppDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }
    }      
}