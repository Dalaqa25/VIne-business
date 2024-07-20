using api.Dtos;
using api.Dtos.Grapes;
using api.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace api.Mapper
{
    public static class GrapesMapper
    {
        public static GrapesDto ToGrapesDto(this Grapes grapesModel)
        {
            return new GrapesDto
            {
                Id = grapesModel.Id,
                Name = grapesModel.Name
            };
        }

        public static Grapes ToGrapesToCreateDto(this CreateGrapesDto createGrapesDto)
        {
            return new Grapes
            {
                Name = createGrapesDto.Name
            };
        }
    }
}


