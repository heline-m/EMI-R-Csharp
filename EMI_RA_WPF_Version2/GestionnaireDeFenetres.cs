using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA.WPF
{
    public static class GestionnaireDeFenetres
    {

        static public Fournisseurs Fournisseurs { get; set; }
        static public AjouterAdhérent ajouterAdhérent { get; set; }
        static public ModifierAdherent modifierAdherent { get; set; }
        static public ModifierFournisseur modifierFournisseur { get; set; }
        static public AjouterFournisseurs AjouterFournisseurs { get; set; }
        static public Commande Commande { get; set; }

    }
}
