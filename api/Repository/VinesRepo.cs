using api.Data;
using api.Dtos;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
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

    public async Task<Vines?> DeleteAsync(int id)
    {
        var vinesModel = await _context.Vines.FirstOrDefaultAsync(x => x.Id == id);

        if(vinesModel == null)
        {
            return null;
        }

        
        _context.Vines.Remove(vinesModel);

        await _context.SaveChangesAsync();

        return vinesModel;
    }

    public async Task<List<Vines>> GetAllAsync()
    {
        return await _context.Vines.Include(v => v.Grapes).ToListAsync();
    }

    public async Task<Vines?> GetByIdAsync(int id)
    {
        return await _context.Vines.Include(v => v.Grapes).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Vines?> UpdateAsync(int id, UpdateVinesDto updateVinesDto)
    {
        var vinesModel = await _context.Vines.FirstOrDefaultAsync(x => x.Id == id);

        if (vinesModel == null)
        {
            return null;
        }

        vinesModel.CreatedOn = updateVinesDto.CreatedOn;
        vinesModel.Name = updateVinesDto.Name;

        await _context.SaveChangesAsync();

        return vinesModel;
    }
}
