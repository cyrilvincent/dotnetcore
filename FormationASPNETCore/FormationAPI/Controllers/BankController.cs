using FormationAPI.Adapters;
using FormationAPI.DTOs;
using FormationAPI.Entities;
using FormationAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace FormationAPI.Controllers
{
    [Route($"api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase // Stateless
    {
        private IBankService bankService;
        private IGestionCompteService gestionCompteService;

        public BankController(IBankService bankService, IGestionCompteService gestionCompteService )
        {
            this.bankService = bankService;
            this.gestionCompteService = gestionCompteService;
        }

        [HttpGet("mock/{solde}")]
        public CompteClientDTO GetMock(decimal solde)
        {
            var dto = new CompteClientDTO { FullName = "Vincent Cyril", Id=123, Comment="Mock", Solde=solde  };
            return dto;
        }

        [HttpGet("compte/{id}")]
        public CompteClientDTO GetCompte(long id)
        {
            return gestionCompteService.GetCompteById(id).ToCompteClientDTO();
        }

        [HttpGet("comptes/client/{id}")]
        public List<CompteClientDTO> GetComptesClient(long id)
        {
            return bankService.GetComptesByClient(id).Select(c => c.ToCompteClientDTO()).ToList();
        }
    }
}
