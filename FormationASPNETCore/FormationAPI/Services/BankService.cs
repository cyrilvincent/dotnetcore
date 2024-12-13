using FormationAPI.Entities;

namespace FormationAPI.Services
{
    public interface IBankService
    {
        Compte CreateCompteAndClient(string nomClient, string prenomClient);
        void Crediter(long compteId, long clientId, decimal montant);
        void Debiter(long compteId, long clientId, decimal montant);
        IQueryable<Compte> Stats();
    }

    public class BankService : IBankService
    {
        private FormationDbContext context;
        private IGestionCompteService gestionCompteService;
        private ICompteUseService compteUseService;


        public BankService(FormationDbContext context,
            IGestionCompteService gestionCompteService,
            ICompteUseService compteUseService)
        {
            this.context = context;
            this.gestionCompteService = gestionCompteService;
            this.compteUseService = compteUseService;
        }

        public Compte CreateCompteAndClient(string nomClient, string prenomClient)
        {
            var client = gestionCompteService.CreateClient(nomClient, prenomClient);
            var compte = gestionCompteService.CreateCompte(client, 0m);
            context.SaveChanges();
            return compte;
        }

        public void Crediter(long compteId, long clientId, decimal montant)
        {
            var client = gestionCompteService.GetClientById(clientId);
            var compte = gestionCompteService.GetCompteById(compteId);
            if (client.Comptes.Contains(compte))
            {
                compteUseService.Crediter(compte, montant);
                context.SaveChanges();
            }
            else
            {
                // TODO Exception
            }
        }

        public void Debiter(long compteId, long clientId, decimal montant)
        {
            var client = gestionCompteService.GetClientById(clientId);
            var compte = gestionCompteService.GetCompteById(compteId);
            if (client.Comptes.Contains(compte))
            {
                compteUseService.Debiter(compte, montant);
            }
            else
            {
                // TODO Exception
            }
        }


        public IQueryable<Compte> Stats()
        {
            throw new NotImplementedException();
        }
    }
}
