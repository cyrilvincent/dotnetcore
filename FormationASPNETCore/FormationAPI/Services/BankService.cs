using FormationAPI.Entities;
using FormationAPI.Exceptions;

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
            client.Comptes.Add(compte);
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
                new BankException("Impossible de crédit un compte d'un autre client");
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
                new BankException("Impossible de débiter un compte d'un autre client");
            }
        }


        public IQueryable<Compte> Stats()
        {
            throw new NotImplementedException();
        }
    }
}
