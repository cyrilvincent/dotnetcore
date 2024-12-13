using FormationAPI.Entities;

namespace FormationAPI.Services
{
    public interface IGestionCompteService // QUOI VERBE ORIENTE API
    {
        Client CreateClient(string prenom, string nom); // USE CASE
        Client GetClientById(long id);
        IQueryable<Client> GetClientsByNom(string nom);
        void RemoveClient(long id);
        Compte CreateCompte(Client client, decimal solde);

        Compte GetCompteById(long id);
        void AddClient(Compte compte, Client client);
        void RemoveClientFromCompte(Compte compte, Client client);

    }

    public class GestionCompteService : IGestionCompteService
    {
        private FormationDbContext context;

        public GestionCompteService(FormationDbContext context)
        {
            this.context = context;
        }

        public void AddClient(Compte compte, Client client)
        {
            compte.Clients.Add(client);
        }

        public Client CreateClient(string prenom, string nom)
        {
            var client = new Client { Nom = nom, Prenom = prenom };
            context.Clients.Add(client);
            return client;
        }

        public Compte CreateCompte(Client client, decimal solde)
        {
            var compte = new Compte { Solde = solde };
            context.Comptes.Add(compte);
            return compte;
        }

        public Client GetClientById(long id)
        {
            return context.Clients.First(c => c.Id == id);
        }

        public Compte GetCompteById(long id)
        {
            return context.Comptes.Where(c => c.Id == id).First();
        }

        public IQueryable<Client> GetClientsByNom(string nom)
        {
            return context.Clients.Where(c => c.Nom.ToUpper() == nom.ToUpper());
        }

        public void RemoveClient(long id)
        {
            var client = GetClientById(id);
            context.Clients.Remove(client);
        }

        public void RemoveClientFromCompte(Compte compte, Client client)
        {
            compte.Clients.Remove(client);
        }

    }
}
