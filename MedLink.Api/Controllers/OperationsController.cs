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
    public class OperationsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public OperationsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetOperationDto>>> GetOperation()
        {
            var operations = await _context.Operations.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<GetOperationDto>>(operations));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<GetOperationDto>>> GetOperation(int id)
        {
            var operation = await _context.Operations.FindAsync(id);
            if (operation is null)
                return NotFound();

            return Ok(_mapper.Map<GetOperationDto>(operation));
        }

        [HttpPost]
        public async Task<ActionResult<GetOperationDto>> CreateOperation(PostOperationDto dto)
        {
            var operation = _mapper.Map<Operation>(dto);
            _context.Operations.Add(operation);
            await _context.SaveChangesAsync();

            var operationDto = _mapper.Map<GetOperationDto>(operation);
            return CreatedAtAction(nameof(GetOperation), new { id = operation.Id }, operationDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOperation(int id, PutOperationDto dto)
        {
            var operation = await _context.Operations.FindAsync(id);
            if (operation is null)
                return NotFound();

            _mapper.Map(dto, operation);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperation(int id)
        {
            var operation = await _context.Operations.FindAsync(id);
            if (operation is null)
                return NotFound();

            _context.Operations.Remove(operation);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}