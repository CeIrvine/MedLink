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
    public class VisitsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public VisitsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetVisitDto>>> GetVisit()
        {
            var visits = await _context.Visits.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<GetVisitDto>>(visits));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<GetVisitDto>>> GetVisit(int id)
        {
            var visit = await _context.Visits.FindAsync(id);
            if (visit is null)
                return NotFound();

            return Ok(_mapper.Map<GetVisitDto>(visit));
        }

        [HttpPost]
        public async Task<ActionResult<GetVisitDto>> CreateVisit(PostVisitDto dto)
        {
            var visit = _mapper.Map<Visit>(dto);
            _context.Visits.Add(visit);
            await _context.SaveChangesAsync();

            var visitDto = _mapper.Map<GetVisitDto>(visit);
            return CreatedAtAction(nameof(GetVisit), new { id = visit.Id }, visitDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVisit(int id, PutVisitDto dto)
        {
            var visit = await _context.Visits.FindAsync(id);
            if (visit is null)
                return NotFound();

            _mapper.Map(dto, visit);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisit(int id)
        {
            var visit = await _context.Visits.FindAsync(id);
            if (visit is null)
                return NotFound();

            _context.Visits.Remove(visit);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
