using FormationAPI.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FormationAPI.Services
{
    public class CompteADO
    {
        private string connString = "Data Source=localhost;Initial Catalog=Formation;Integrated Security=True;Encrypt=False";

        public List<Compte> SelectAllComptes()
        {
            var comptes = new List<Compte>();
            SqlConnection sqlConnection = new SqlConnection(connString);
            var sql = "select * from compte";
            SqlCommand cmd = new SqlCommand(sql, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var id = reader.GetInt64(0);
                var solde = reader.GetDecimal(1);
                var compte = new Compte { Id = id, Solde = solde };
                comptes.Add(compte);
            }
            return comptes;
        }

        public void AddCompte(Compte compte)
        {
            SqlConnection sqlConnection = new SqlConnection(connString);
            var commentaire = "null";
            if (compte.Commentaire != null)
            {
                commentaire = $"'{compte.Commentaire}'";
            }
            var sql = $"insert into compte values ({compte.Id},{compte.Solde},'{compte.Devise}',{commentaire})";
            var cmd = new SqlCommand(sql, sqlConnection);
            cmd.ExecuteNonQuery();
        }

        public void AddCompte2(Compte compte)
        {
            SqlConnection sqlConnection = new SqlConnection(connString);
            var commentaire = "null";
            if (compte.Commentaire != null)
            {
                commentaire = $"'{compte.Commentaire}'";
            }
            var sql = $"insert into compte values (@id,@solde,@devise,@commentaire)";
            var cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = compte.Id;
            cmd.Parameters.Add("@solde", SqlDbType.Decimal).Value = compte.Solde;
            cmd.Parameters.Add("@devise", SqlDbType.NVarChar).Value = compte.Devise;
            cmd.Parameters.Add("@commentaire", SqlDbType.NVarChar).Value = compte.Commentaire;
            cmd.ExecuteNonQuery();
        }
    }
}
