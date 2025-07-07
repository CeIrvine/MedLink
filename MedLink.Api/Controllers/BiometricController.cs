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
    public class BiometricController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BiometricController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetBiometricDto>>> GetBiometrics()
        {
            var biometrics = await _context.Biometrics.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<GetBiometricDto>>(biometrics));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<GetBiometricDto>>> GetBiometric(int id)
        {
            var biometric = await _context.Biometrics.FindAsync(id);
            if (biometric is null)
                return NotFound();

            return Ok(_mapper.Map<GetBiometricDto>(biometric));
        }

        [HttpPost]
        public async Task<ActionResult<GetBiometricDto>> CreateBiometric(PostBiometricDto dto)
        {
            var patient = await _context.Patients.FindAsync(dto.PatientId);
            if (patient is null)
                return NotFound($"Patient with ID {dto.PatientId} not found.");

            var biometric = _mapper.Map<Biometric>(dto);
            _context.Biometrics.Add(biometric);
            await _context.SaveChangesAsync();

            var biometricDto = _mapper.Map<GetBiometricDto>(biometric);
            return CreatedAtAction(nameof(GetBiometric), new { id = biometric.Id }, biometricDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBiometric(int id, PutBiometricDto dto)
        {
            var biometric = await _context.Biometrics.FindAsync(id);
            if (biometric is null)
                return NotFound();

            _mapper.Map(dto, biometric);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBiometric(int id)
        {
            var biometrics = await _context.Biometrics.FindAsync(id);
            if (biometrics is null)
                return NotFound();

            _context.Biometrics.Remove(biometrics);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
/*{ 
"patientId": 1,
  "fingerprint": "VGhpcyBpcyBhIHRlc3QgYnl0ZSBhcnJheQ==",
  "faceId": "VGhpcyBpcyBhbm90aGVyIHRlc3Q=",
  "weight": 70,
  "height": 175,
  "bloodType": "A+",
  "gender": "Male"
}*/

