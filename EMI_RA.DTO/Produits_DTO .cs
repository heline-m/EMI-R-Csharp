using System;

namespace EMI_RA.DTO
{
    public class Produits_DTO
    {
        public int ID { get; set; }
        public String Libelle { get; set; }
        public String Marque { get; set; }
        public String Reference { get; set; }
        public int IdFournisseurs { get; set; }
    }
}
