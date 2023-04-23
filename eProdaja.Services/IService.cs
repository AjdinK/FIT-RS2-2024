using eProdaja.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;

namespace eProdaja.Services {
    public interface IService <T> where T : class{
        IEnumerable<T> Get();
        T GetByID(int id);

    }
}
