using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.WinUI {
    public class APIService {

        private string _resoruce = null;
        public string _endpoint = "https://localhost:7289/";

        public APIService(string resorce) { _resoruce = resorce; }

        public async Task<T> Get<T>() {
            var list = await $"{_endpoint}{_resoruce}".GetJsonAsync<T>();
            return list;
        }
        public async Task<T> GetById<T>(object id) {
            var rez = await $"{_endpoint}{_resoruce}/{id}".GetJsonAsync<T>();
            return rez;
        }
    }
}
