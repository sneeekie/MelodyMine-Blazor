using AutoMapper;

using BLL.Repositories.Interfaces;
using BLL.Services.Interfaces;

namespace BLL.Services.Implementations;

public class TemplateService<TEntity, TDto> : ITemplateService<TDto>
    where TEntity : class
    where TDto : class
{
    private readonly ITemplateRepository<TEntity> _repository;
    private readonly IMapper _mapper;

    public TemplateService(ITemplateRepository<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<TDto>>(entities);
    }

    public async Task<TDto> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<TDto>(entity);
    }

    public async Task AddAsync(TDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        await _repository.AddAsync(entity);
    }

    public async Task UpdateAsync(TDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}