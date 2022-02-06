using EMI_RA_WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA.WPF
{
    public static class GestionnaireDeFenetres
    {

        public static Fournisseurs Fournisseurs { get; set; }
        public static AjouterAdhérent ajouterAdhérent { get; set; }
        public static ModifierAdherent modifierAdherent { get; set; }
        public static ModifierFournisseur modifierFournisseur { get; set; }
        public static AjouterFournisseurs AjouterFournisseurs { get; set; }
        public static Commande Commande { get; set; }
        public static EnregistrerPrixFournisseurs EnregistrerPrixFournisseurs { get; set; }
    }
}
