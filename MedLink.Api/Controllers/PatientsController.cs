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
    public class PatientsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PatientsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetPatientDto>>> GetPatients()
        {
            var patients = await _context.Patients.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<GetPatientDto>>(patients));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<GetPatientDto>>> GetPatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient is null)
                return NotFound();

            return Ok(_mapper.Map<GetPatientDto>(patient));
        }

        [HttpPost] 
        public async Task<ActionResult<GetPatientDto>> CreatePatient(PostPatientDto dto)
        {
            var patient = _mapper.Map<Patient>(dto);
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            var patientDto = _mapper.Map<GetPatientDto>(patient);
            return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, patientDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePatient(int id, PutPatientDto dto)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient is null)
                return NotFound();

            _mapper.Map(dto, patient);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient is null)
                return NotFound();

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
