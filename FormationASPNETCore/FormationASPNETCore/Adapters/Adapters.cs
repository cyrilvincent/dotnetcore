using FormationASPNETCore.Dtos;
using FormationASPNETCore.Entities;

namespace FormationASPNETCore.Adapters
{
    public static class Adapters
    {
        public static MediaDTO ToMediaDTO(this Media media)
        {
            return new MediaDTO
            {
                Id = media.Id,
                Title = media.Title,
                Comment = media.Comment,
                MediaType = media.MediaType,
                Price = media.Price,
                PublisherName = media.Publisher?.Name
            };
        }
    }
}
