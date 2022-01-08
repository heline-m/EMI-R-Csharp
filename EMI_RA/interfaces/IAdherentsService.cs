using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA
{
    public interface IAdherentsService
    {

        public List<Adherents> GetAllAdherents();

        public Adherents GetByID(int idAdherents);
        public Adherents Insert(Adherents a);
        public Adherents Update(Adherents a);
        public void Delete(Adherents a);
    }
}
