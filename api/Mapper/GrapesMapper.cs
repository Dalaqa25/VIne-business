using api.Dtos.Grapes;
using api.Models;

namespace api.Mapper
{
    public static class GrapesMapper
    {
        public static GrapesDto ToGrapesDto(this Grapes grapesModel)
        {
            return new GrapesDto
            {
                Name = grapesModel.Name
            };
        }
    }
}


