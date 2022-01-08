using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA.DAL
{
    public class ListeAchat_Depot_DAL : Depot_DAL<ListeAchat_DAL>
    {
        public ListeAchat_Depot_DAL()
            : base()
        {

        }

        public override List<ListeAchat_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select idListesDAchats, idAdherant, idPaniersGlobaux, annee, numeroSemaine from listesDAchats";
            //pour lire les lignes une par une
            var reader = commande.ExecuteReader();

            var listeAchat = new List<ListeAchat_DAL>();

            while (reader.Read())
            {
                //dans reader.GetInt32 on met la colonne que l'on souhaite récupérer ici 0 = ID, 1 = Societe...
                var achat = new ListeAchat_DAL(reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5));

                listeAchat.Add(achat);
            }

            DetruireConnexionEtCommande();

            return listeAchat;
        }

        public override ListeAchat_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select idListesDAchats, idAdherant, idPaniersGlobaux, annee, numeroSemaine from listesDAchats where idListesDAchats=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            var listeDAchats = new List<ListeAchat_DAL>();

            ListeAchat_DAL listeAchat;
            if (reader.Read())
            {
                listeAchat = new ListeAchat_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetInt32(3),
                                        reader.GetInt32(4));
            }
            else
                throw new Exception($"Pas de liste d'achat dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();

            return listeAchat;
        }

        public override ListeAchat_DAL Insert(ListeAchat_DAL listeAchat)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into listesDAchats (idAdherents, annee, numeroSemaine)"
                                    + " values (@idAdherent, @annee, @numeroSemaine); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@idAdherent", listeAchat.IdAdherents));
            commande.Parameters.Add(new SqlParameter("@annee", listeAchat.Annee));
            commande.Parameters.Add(new SqlParameter("@numeroSemaine", listeAchat.NumeroSemaine));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            listeAchat.ID = ID;

            DetruireConnexionEtCommande();

            return listeAchat;
        }

        public override ListeAchat_DAL Update(ListeAchat_DAL listeAchat)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update listesDAchats set idAdherents = @idAdherent, idPaniersGlobaux = @idPaniersGlobaux, annee = @annee, numeroSemaine = @numeroSemaine)"
                                    + " where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", listeAchat.ID));
            commande.Parameters.Add(new SqlParameter("@idAdherent", listeAchat.IdAdherents));
            commande.Parameters.Add(new SqlParameter("@idPaniersGlobaux", listeAchat.IdPaniersGlobaux));
            commande.Parameters.Add(new SqlParameter("@annee", listeAchat.Annee));
            commande.Parameters.Add(new SqlParameter("@numeroSemaine", listeAchat.NumeroSemaine));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour la liste d'achat avec l'ID  {listeAchat.ID}");
            }

            DetruireConnexionEtCommande();

            return listeAchat;
        }

        public override void Delete(ListeAchat_DAL listeAchat)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from listesDAchats where idListesDAchats = @ID";
            commande.Parameters.Add(new SqlParameter("@ID", listeAchat.ID));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer la liste d'achat avec l'ID {listeAchat.ID}");
            }

            DetruireConnexionEtCommande();
        }
    }
}
