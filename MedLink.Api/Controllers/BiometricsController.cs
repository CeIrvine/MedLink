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
    public class BiometricsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BiometricsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetBiometricsDto>>> GetBiometrics()
        {
            var biometrics = await _context.Biometrics.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<GetBiometricsDto>>(biometrics));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<GetBiometricsDto>>> GetBiometric(int id)
        {
            var biometric = await _context.Biometrics.FindAsync(id);
            if (biometric is null)
                return NotFound();

            return Ok(_mapper.Map<GetBiometricsDto>(biometric));
        }

        [HttpPost]
        public async Task<ActionResult<GetBiometricsDto>> CreateBiometric(PostBiometricsDto dto)
        {
            var biometric = _mapper.Map<Biometrics>(dto);
            _context.Biometrics.Add(biometric);
            await _context.SaveChangesAsync();

            var biometricdto = _mapper.Map<GetBiometricsDto>(biometric);
            return CreatedAtAction(nameof(GetBiometric), new { id = biometric.Id }, biometricdto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBiometric(int id, PushBiometricsDto dto)
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

