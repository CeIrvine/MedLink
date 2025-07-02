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
    public class DoctorController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public DoctorController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetDoctorDto>>> GetDoctors()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<GetDoctorDto>>(doctors));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<GetDoctorDto>>> GetDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor is null)
                return NotFound();

            return Ok(_mapper.Map<GetDoctorDto>(doctor));
        }

        [HttpPost]
        public async Task<ActionResult<GetDoctorDto>> CreateDoctor(PostDoctorDto dto)
        {
            var doctor = _mapper.Map<Doctor>(dto);
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            var doctorDto = _mapper.Map<GetDoctorDto>(doctor);
            return CreatedAtAction(nameof(GetDoctor), new { id = doctor.Id }, doctorDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDoctor(int id, PushDoctorDto dto)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor is null)
                return NotFound();

            _mapper.Map(dto, doctor);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor is null)
                return NotFound();

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}