using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedLink.Api.Data;
using MedLink.Logic.Models;
using AutoMapper;
using MedLink.Api.DTOs.Get;

namespace MedLink.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PatientController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetPatientDTO>>> GetPatients()
        {
            var patients = await _context.Patient.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<GetPatientDTO>>(patients));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<GetPatientDTO>>> GetPatients(int id)
        {
            var patient = await _context.Patient.FindAsync(id);
            if (patient == null)
                return NotFound();

            return Ok(_mapper.Map<GetPatientDTO>(patient));
        }

        [HttpPost] 
        public async Task<ActionResult<GetPatientDTO>> CreatePatient(CreatePatientDTO patient)
        {
            _context.Patient.Add(patient);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPatients), new { id = patient.Id }, patient);
        }
    }
}
