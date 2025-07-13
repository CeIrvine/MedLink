using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedLink.Api.Data;
using MedLink.Logic.Models;
using AutoMapper;
using MedLink.Api.DTOs.Get;
using MedLink.Api.DTOs.Post;
using MedLink.Api.DTOs.Push;
using MedLink.Api.Controller;

namespace MedLink.Api.Controllers
{
    public class IllnessesController 
        : BaseApiController<Illness, GetIllnessDto, PostIllnessDto, PutIllnessDto>
    {
        public IllnessesController(AppDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }
    }            
}