using FormationASPNETCore.Entities;
using FormationASPNETCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormationASPNETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly FormationDbContext _context;
        private readonly IPublisherService _publisherService;

        public PublisherController(FormationDbContext context, IPublisherService publisherService)
        {
            _context = context;
            _publisherService = publisherService;
        }

        [HttpGet("mock/")]
        public Publisher GetMock()
        {
            return _publisherService.Mock();
        }

        [HttpGet("name/{name}")]
        public List<Publisher> FilterByName(string name)
        {
            return _publisherService.FilterByName(name).ToList();
        }
    }
}
