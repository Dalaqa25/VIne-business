﻿using api.Data;
using api.Dtos;
using api.Interfaces;
using api.Mapper;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class GrapesRepo : GrapesInterface
    {
        private readonly ApplicationDbContext _context;
        public GrapesRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Grapes?> CreateAsync(Grapes grapesModel)
        {
            await _context.Grapes.AddAsync(grapesModel);
            await _context.SaveChangesAsync();
            return grapesModel;
        }

        public async Task<Grapes?> DeleteAsync(int id)
        {
           var grapesModel = await _context.Grapes.FirstOrDefaultAsync(x => x.Id == id);

           if (grapesModel == null)
           {
            return null;
           }

            _context.Grapes.Remove(grapesModel);
            await _context.SaveChangesAsync();

            return grapesModel;
        }

        public async Task<List<Grapes>> GetAllAsync()
        {
            return await _context.Grapes.ToListAsync();
        }

        public async Task<Grapes?> GetById(int id)
        {
            return await _context.Grapes.FindAsync(id);
        }

        public async Task<Grapes?> UpdateAsync(int id, UpdateGrapesDto updateGrapes)
        {
            var grapesModel = await _context.Grapes.FirstOrDefaultAsync(x => x.Id == id);

            if (grapesModel == null)
            {
                return null;
            }

            grapesModel.Name = updateGrapes.Name;

            await _context.SaveChangesAsync();

            return grapesModel;
        }
    }
}
