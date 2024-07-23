using api.Models;
using api.Dtos;

namespace api.Interfaces
{
    public interface GrapesInterface
    {
        Task<List<Grapes>> GetAllAsync();
        Task<Grapes?> GetById(int id);
        Task<Grapes?> CreateAsync(Grapes grapesModel);
        Task<Grapes?> UpdateAsync(int id, UpdateGrapesDto updateGrapesDto);
        Task<Grapes?> DeleteAsync(int id);
    }
}
