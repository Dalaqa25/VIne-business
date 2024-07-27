using api.Dtos;
using api.Models;
using api.Helpers;

namespace api.Interfaces 
{
    public interface VinesInterface
    {
        Task<List<Vines>> GetAllAsync(VinesQuery vinesQuery);
        Task<Vines?> GetByIdAsync(int id);
        Task<Vines?> CreateAsync(Vines vinesModel);
        Task<Vines?> UpdateAsync(int id, UpdateVinesDto updateVinesDto);
        Task<Vines?> DeleteAsync(int id);
    }
}
