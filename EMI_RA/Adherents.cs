using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA
{
    public class Adherents
    {
        public int ID { get; set; }
        public String Societe { get; set; }
        public String CiviliteContact { get; set; }
        public String NomContact { get; set; }
        public String PrenomContact { get; set; }
        public String Email { get; set; }
        public String Adresse { get; set; }
        public DateTime? DateAdhesion { get; set; }


        public Adherents(String societe, String civiliteContact, String nomContact, String prenomContact, String email, String adresse)
                    => (Societe, CiviliteContact, NomContact, PrenomContact, Email, Adresse) = (societe, civiliteContact, nomContact, prenomContact, email, adresse);

        public Adherents(int idAdherents, String societe, String civiliteContact, String nomContact, String prenomContact, String email, String adresse) : this (societe, civiliteContact, nomContact, prenomContact, email, adresse)
        {
            ID = idAdherents;
        }

        public Adherents(int iD)
        {
            ID = iD;
        }

    }
}