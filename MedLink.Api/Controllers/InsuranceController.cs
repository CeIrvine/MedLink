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
    public class InsuranceController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public InsuranceController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetInsuranceDto>>> GetInsurances()
        {
            var insurances = await _context.Insurances.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<GetInsuranceDto>>(insurances));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<GetInsuranceDto>>> GetInsurance(int id)
        {
            var insurance = await _context.Insurances.FindAsync(id);
            if (insurance is null)
                return NotFound();

            return Ok(_mapper.Map<GetInsuranceDto>(insurance));
        }

        [HttpPost]
        public async Task<ActionResult<GetInsuranceDto>> CreateInsurance(PostInsuranceDto dto)
        {
            var insurance = _mapper.Map<Insurance>(dto);
            _context.Insurances.Add(insurance);
            await _context.SaveChangesAsync();

            var insuranceDto = _mapper.Map<GetInsuranceDto>(insurance);
            return CreatedAtAction(nameof(GetInsurance), new { id = insurance.Id }, insuranceDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateInsurance(int id, PutInsuranceDto dto)
        {
            var insurance = await _context.Insurances.FindAsync(id);
            if (insurance is null)
                return NotFound();

            _mapper.Map(dto, insurance);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsurance(int id)
        {
            var insurance = await _context.Insurances.FindAsync(id);
            if (insurance is null)
                return NotFound();

            _context.Insurances.Remove(insurance);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}