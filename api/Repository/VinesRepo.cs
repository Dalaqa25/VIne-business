using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api;

public class VinesRepo : VinesInterface
{
    private readonly ApplicationDbContext _context;
    public VinesRepo(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Vines?> CreateAsync(Vines vinesModel)
    {
        await _context.Vines.AddAsync(vinesModel);
        await _context.SaveChangesAsync();
        return vinesModel;
    }

    public async Task<List<Vines>> GetAllAsync()
    {
        return await _context.Vines.ToListAsync();
    }

    public async Task<Vines?> GetByIdAsync(int id)
    {
        return await _context.Vines.FindAsync(id);
    }
}
