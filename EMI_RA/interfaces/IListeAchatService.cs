using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA
{
    public interface IListeAchatService
    {
        //public List<ListeAchat> GetAllListeAchat();
        //public ListeAchat GetListeAchatByID(int IdListeAchat);
        //public ListeAchat Insert(ListeAchat l);
        //public ListeAchat Update(ListeAchat l);
        //public void Delete(ListeAchat l);
        void genererListeAchat(int IdAdherent, IFormFile csvFile);
    }
}
