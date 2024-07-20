using api.Models;

namespace api.Interfaces
{
    public interface GrapesInterface
    {
        Task<List<Grapes>> GetAllAsync();
        Task<Grapes?> GetById(int id);
        Task<Grapes?> CreateAsync(Grapes grapesModel);
    }
}
