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
                Name = VinesModel.Name,
                CreatedOn = VinesModel.CreatedOn
            };
        }
    }
}
