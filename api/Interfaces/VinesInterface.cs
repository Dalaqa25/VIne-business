using api.Dtos;
using api.Models;

namespace api.Interfaces 
{
    public interface VinesInterface
    {
        Task<List<Vines>> GetAllAsync();
        Task<Vines?> GetByIdAsync(int id);
        Task<Vines?> CreateAsync(Vines vinesModel);
        Task<Vines?> UpdateAsync(int id, UpdateVinesDto updateVinesDto);
        Task<Vines?> DeleteAsync(int id);
    }
}
