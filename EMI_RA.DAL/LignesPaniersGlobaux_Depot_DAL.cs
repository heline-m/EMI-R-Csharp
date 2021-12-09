using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace EMI_RA.DAL
{
    public class LignesPaniersGlobaux_Depot_DAL : Depot_DAL<LignesPaniersGlobaux_DAL>
    {
        public override List<LignesPaniersGlobaux_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select idLignesPaniersGlobaux, idProduits, quantite, idListesDAchats from lignesPaniersGlobaux";
            var reader = commande.ExecuteReader();

            var listeDeLignesPaniersGlobaux = new List<LignesPaniersGlobaux_DAL>();

            while (reader.Read())
            {
                var paniersGlobaux = new LignesPaniersGlobaux_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetInt32(3),
                                        reader.GetInt32(4));

                listeDeLignesPaniersGlobaux.Add(paniersGlobaux);
            }

            DetruireConnexionEtCommande();

            return listeDeLignesPaniersGlobaux;
        }

        public List<LignesPaniersGlobaux_DAL> GetAllByIdListeDAchats(int idProduits, int idPaniers, int idListesDAchats)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select idLignesPaniersGlobaux, idProduits, quantite, idListesDAchats, idPaniers from lignesPaniersGlobaux where idProduits=@idProduits";
            commande.Parameters.Add(new SqlParameter("@idProduits", idProduits));
            commande.Parameters.Add(new SqlParameter("@idPaniers", idPaniers));
            commande.Parameters.Add(new SqlParameter("@idListesDAchats", idListesDAchats));

            var reader = commande.ExecuteReader();

            var listeDeLignesPaniersGlobaux = new List<LignesPaniersGlobaux_DAL>();

            while (reader.Read())
            {
                var paniersGlobaux = new LignesPaniersGlobaux_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetInt32(3),
                                        reader.GetInt32(4));

                listeDeLignesPaniersGlobaux.Add(paniersGlobaux);
            }

            DetruireConnexionEtCommande();

            return listeDeLignesPaniersGlobaux;
        }

     
        public override LignesPaniersGlobaux_DAL GetByID(int idLignesPaniersGlobaux)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select idLignesPaniersGlobaux, idProduits, quantite, idListesDAchats, idPaniers from lignesPaniersGlobaux where idPaniers=@idPaniers";
            commande.Parameters.Add(new SqlParameter("@idLignesPaniersGlobaux", idLignesPaniersGlobaux));
            var reader = commande.ExecuteReader();

            var listeDeLignesPaniersGlobaux = new List<LignesPaniersGlobaux_DAL>();

            LignesPaniersGlobaux_DAL paniersGlobaux;
            if (reader.Read())
            {
                paniersGlobaux = new LignesPaniersGlobaux_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetInt32(3),
                                        reader.GetInt32(4));
            }
            else
                throw new Exception($"Pas de paniers globaux dans la BDD avec l'ID {idLignesPaniersGlobaux}");

            DetruireConnexionEtCommande();

            return paniersGlobaux;
        }

        public override LignesPaniersGlobaux_DAL Insert(LignesPaniersGlobaux_DAL lignePanierGlobal)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into lignesPaniersGlobaux(idProduits, quantite, idListesDAchats, idPaniers)"
                                    + " values (@idProduits, @quantite, @idListesDAchats, @idPaniers); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@idProduits", lignePanierGlobal.IDProduits));
            commande.Parameters.Add(new SqlParameter("@quantite", lignePanierGlobal.Quantite));
            commande.Parameters.Add(new SqlParameter("@idListesDAchats", lignePanierGlobal.IDListesDAchats));
            commande.Parameters.Add(new SqlParameter("@idPaniers", lignePanierGlobal.IDPaniers));

            var idLignesPaniersGlobaux = Convert.ToInt32((decimal)commande.ExecuteScalar());

            lignePanierGlobal.IDLignesPaniersGlobaux = idLignesPaniersGlobaux;

            DetruireConnexionEtCommande();

            return lignePanierGlobal;
        }

        public override LignesPaniersGlobaux_DAL Update(LignesPaniersGlobaux_DAL lignePanierGlobal)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update lignesPaniersGlobaux set idProduits=@idProduits, quantite=@quantite, idListesDAchats=@idListesDAchats, idPaniers=@idPaniers )"
                                    + " where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@idLignesPaniersGlobaux", lignePanierGlobal.IDLignesPaniersGlobaux));
            commande.Parameters.Add(new SqlParameter("@idProduits", lignePanierGlobal.IDProduits));
            commande.Parameters.Add(new SqlParameter("@quantite", lignePanierGlobal.Quantite));
            commande.Parameters.Add(new SqlParameter("@idListesDAchats", lignePanierGlobal.IDListesDAchats));
            commande.Parameters.Add(new SqlParameter("@idPaniers", lignePanierGlobal.IDPaniers));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour la ligne du panier global d'ID {lignePanierGlobal.IDLignesPaniersGlobaux}");
            }

            DetruireConnexionEtCommande();

            return lignePanierGlobal;
        }

        public override void Delete(LignesPaniersGlobaux_DAL lignePanierGlobal)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from LignesPaniersGlobaux where idLignesPaniersGlobaux=@idLignesPaniersGlobaux";
            commande.Parameters.Add(new SqlParameter("@idLignesPaniersGlobaux", lignePanierGlobal.IDLignesPaniersGlobaux));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer la ligne du panier global d'ID {lignePanierGlobal.IDLignesPaniersGlobaux}");
            }

            DetruireConnexionEtCommande();
        }
    }
}
