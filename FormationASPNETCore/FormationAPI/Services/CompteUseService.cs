using FormationAPI.Entities;
using FormationAPI.Exceptions;

namespace FormationAPI.Services
{
    public interface ICompteUseService
    {
        void Crediter(Compte compte, decimal montant);
        void Debiter(Compte compte, decimal montant);
    }

    public class CompteUseService : ICompteUseService
    {
        private FormationDbContext context;
        public CompteUseService(FormationDbContext context)
        {
            this.context = context;
        }

        public void Crediter(Compte compte, decimal montant)
        {
            var transaction = new Transaction { Compte = compte, Montant=montant, Type = TransactionType.Credit };
            compte.Solde += montant;
            compte.Transactions.Add(transaction);
        }

        public void Debiter(Compte compte, decimal montant)
        {
            if (montant <= compte.Solde)
            {
                var transaction = new Transaction { Compte = compte, Montant = montant, Type = TransactionType.Debit };
                compte.Solde -= montant;
                compte.Transactions.Add(transaction);
            }
            else
            {
                new BankException("Solde insuffisant");
            }
        }

        
    }
}
