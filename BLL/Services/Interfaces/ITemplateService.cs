namespace BLL.Services.Interfaces;

public interface ITemplateService<TDto> where TDto : class
{
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(int id);
        Task AddAsync(TDto dto);
        Task UpdateAsync(TDto dto);
        Task DeleteAsync(int id);
}
