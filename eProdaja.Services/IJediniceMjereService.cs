using eProdaja.Model;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services {
    public interface IJediniceMjereService {

        IEnumerable<JediniceMjere> Get();
        public JediniceMjere GetByID(int id);

    }
} 
