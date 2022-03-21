using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA
{
    public class Fournisseurs
    {
        public int IdFournisseurs { get; set; }
        public String Societe { get; set; }
        public String CiviliteContact { get; set; }
        public String NomContact { get; set; }
        public String PrenomContact { get; set; }
        public String Email { get; set; }
        public String Adresse { get; set; }
        public DateTime DateAdhesion { get; set; }
        public bool Actif { get; set; }
        public String MotDePasse { get; set; }
        public bool MotDePasseChange { get; set; }

        public Fournisseurs(String societe, String civiliteContact, String nomContact, String prenomContact, String email, String adresse, bool actif, String motDePasse, bool motDePasseChange)
                    => (Societe, CiviliteContact, NomContact, PrenomContact, Email, Adresse, Actif, MotDePasse, MotDePasseChange) = (societe, civiliteContact, nomContact, prenomContact, email, adresse, actif, motDePasse, motDePasseChange);
        public Fournisseurs(int idFournisseurs, String societe, String civiliteContact, String nomContact, String prenomContact, String email, String adresse, bool actif, String motDePasse, bool motDePasseChange)
                    => (IdFournisseurs, Societe, CiviliteContact, NomContact, PrenomContact, Email, Adresse, Actif, MotDePasse, MotDePasseChange) = (idFournisseurs, societe, civiliteContact, nomContact, prenomContact, email, adresse, actif, motDePasse, motDePasseChange);

        public Fournisseurs(int iDFournisseurs, String societe, String civiliteContact, String nomContact, String prenomContact, String email, String adresse, DateTime dateAdhesion, bool actif, String motDePasse, bool motDePasseChange)
            : this(societe, civiliteContact, nomContact, prenomContact, email, adresse, actif, motDePasse, motDePasseChange)
        {
            IdFournisseurs = iDFournisseurs;
            DateAdhesion = dateAdhesion;
        }
        public Fournisseurs(int id)
        {
            IdFournisseurs = id;
        }
        public Fournisseurs()
        {

        }
    }
}