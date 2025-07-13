using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedLink.Api.Data;
using MedLink.Logic.Models;
using AutoMapper;
using MedLink.Api.DTOs.Get;
using MedLink.Api.DTOs.Post;
using MedLink.Api.DTOs.Push;

namespace MedLink.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController<TEntity, TGetDto, TPostDto, TPutDto> : ControllerBase
        where TEntity : class, new()        
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly DbSet<TEntity> _dbSet;


        public BaseApiController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _dbSet = _context.Set<TEntity>();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TGetDto>>> GetAll()
        {
            var entities = await _dbSet.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<TGetDto>>(entities));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TGetDto>> GetById(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity is null)
                return NotFound();
            return Ok(_mapper.Map<TGetDto>(entity));
        }

        [HttpPost]
        public async Task<ActionResult<TGetDto>> Create(TPostDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            var entityDto = _mapper.Map<TGetDto>(entity);
            return CreatedAtAction(nameof(GetById), new { id = GetEntityId(entity) }, entityDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, TPutDto dto)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity is null)
                return NotFound();
            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity is null)
                return NotFound();
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        protected virtual int GetEntityId(TEntity entity)
        {
            var property = typeof(TEntity).GetProperty("Id");
            return (int)(property?.GetValue(entity) ?? 0);
        }            
    }
}
