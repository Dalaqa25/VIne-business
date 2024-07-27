using api.Models;
using api.Dtos;
using api.Helpers;

namespace api.Interfaces
{
    public interface GrapesInterface
    {
        Task<List<Grapes>> GetAllAsync(GrapesQuery grapesQuery);
        Task<Grapes?> GetById(int id);
        Task<Grapes?> CreateAsync(Grapes grapesModel);
        Task<Grapes?> UpdateAsync(int id, UpdateGrapesDto updateGrapesDto);
        Task<Grapes?> DeleteAsync(int id);
        Task<bool> VinesExistsAsync(int VinesId);
    }
}
