using FormationASPNETCore.Dtos;
using FormationASPNETCore.Entities;
using FormationASPNETCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormationASPNETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly FormationDbContext _context;
        private readonly IMediaService mediaService;

        public MediaController(FormationDbContext context, IMediaService publisherService)
        {
            _context = context;
            mediaService = publisherService;
        }

        [HttpGet("mock/")]
        public Publisher GetMock()
        {
            return mediaService.Mock();
        }

        [HttpGet("publisher/name/{name}")]
        public List<Publisher> FilterByName(string name)
        {
            return mediaService.GetPublishersByName(name).ToList();
        }

        [HttpGet("title/{title}")]
        public List<MediaDTO> FilterByTitle(string title)
        {
            return mediaService.FilterByTitle(title).ToList();
        }
    }
}
