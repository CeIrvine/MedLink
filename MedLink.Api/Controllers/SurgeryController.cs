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
    public class SurgeryController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SurgeryController(AppDbContext context, IMapper mapper)
        {
           _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetSurgeryDto>>> GetSurgery()
        {
            var surgeries = await _context.Surgerys.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<GetSurgeryDto>>(surgeries));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<GetSurgeryDto>>> GetSurgery(int id)
        {
            var surgery = await _context.Surgerys.FindAsync(id);
            if (surgery is null)
                return NotFound();
            return Ok(_mapper.Map<GetSurgeryDto>(surgery));
        }

        [HttpPost]
        public async Task<ActionResult<GetSurgeryDto>> CreateSurgery(PostSurgeryDto dto)
        {
            var surgery = _mapper.Map<Surgery>(dto);
            _context.Surgerys.Add(surgery);
            await _context.SaveChangesAsync();

            var surgeryDto = _mapper.Map<GetSurgeryDto>(surgery);
            return CreatedAtAction(nameof(GetSurgery), new { id = surgery.Id }, surgeryDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSurgery(int id, PutSurgeryDto dto)
        {
            var surgery = await _context.Surgerys.FindAsync(id);
            if (surgery is null)
                return NotFound();

            _mapper.Map(dto, surgery);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSurgery(int id)
        {
            var surgery = await _context.Surgerys.FindAsync(id);
            if (surgery is null)
                return NotFound();

            _context.Surgerys.Remove(surgery);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
