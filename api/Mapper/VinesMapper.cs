using api.Dtos;
using api.Models;

namespace api.Mapper
{
    public static class VinesMapper
    {
        public static VinesDto ToVinesDto(this Vines VinesModel)
        {
            return new VinesDto
            {
                Id = VinesModel.Id,
                Name = VinesModel.Name,
                CreatedOn = VinesModel.CreatedOn,  
                Grape = VinesModel.Grapes.Select(g => g.ToGrapesDto()).ToList(),         
            };
        }

        public static Vines ToVinesFromCreate(this CreateVinesDto createVinesDto)
        {
            return new Vines
            {
                Name = createVinesDto.Name,
                CreatedOn = createVinesDto.CreatedOn,
            };
        }
    }
}
