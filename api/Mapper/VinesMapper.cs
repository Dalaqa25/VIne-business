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
                CreatedOn = VinesModel.CreatedOn
            };
        }

        public static Vines ToVinesFromCreate(this CreateVinesDto createVinesDto)
        {
            return new Vines
            {
                Name = createVinesDto.Name,
                CreatedOn = createVinesDto.CreatedOn
            };
        }
    }
}
