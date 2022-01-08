using System;

namespace EMI_RA.DTO
{
    public class Produits_DTO
    {
        public int ID { get; set; }
        public string Libelle { get; set; }
        public string Marque { get; set; }
        public string Reference { get; set; }
        public int IdFournisseurs { get; set; }
    }
}
