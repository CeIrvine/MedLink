using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedLink.Api.Data;
using MedLink.Logic.Models;
using AutoMapper;
using MedLink.Api.DTOs.Get;
using MedLink.Api.DTOs.Post;
using MedLink.Api.DTOs.Push;

namespace MedLink.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IllnessController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public IllnessController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetIllnessDto>>> GetIllnesses()
        {
            var illnesses = await _context.Illnesses.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<GetIllnessDto>>(illnesses));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<GetIllnessDto>>> GetIllness(int id)
        {
            var illness = await _context.Illnesses.FindAsync(id);
            if (illness is null)
                return NotFound();

            return Ok(_mapper.Map<GetIllnessDto>(illness));
        }

        [HttpPost]
        public async Task<ActionResult<GetIllnessDto>> CreateIllness(PostIllnessDto dto)
        {
            var illness = _mapper.Map<Illness>(dto);
            _context.Illnesses.Add(illness);
            await _context.SaveChangesAsync();

            var illnessDto = _mapper.Map<GetPatientDto>(illness);
            return CreatedAtAction(nameof(GetIllness), new { id = illness.Id }, illnessDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateIllness (int id, PushIllnessDto dto)
        {
            var illness = await _context.Illnesses.FindAsync(id);
            if (illness is null)
                return NotFound();

            _mapper.Map(dto, illness);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIllness(int id)
        {
            var illness = await _context.Illnesses.FindAsync(id);
            if (illness is null)
                return NotFound();

            _context.Illnesses.Remove(illness);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}