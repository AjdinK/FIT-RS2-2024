using eProdaja.Model;
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

        public async Task<T> Get<T>(object search = null) {
            var query = "";
            if (search != null) { query = await search.ToQueryString(); }
            var list = await $"{_endpoint}{_resoruce}?{query}".GetJsonAsync<T>();
            return list;
        }
        public async Task<T> GetById<T>(object id) {
            var rez = await $"{_endpoint}{_resoruce}/{id}".GetJsonAsync<T>();
            return rez;
        }
        public async Task<T> Post<T>(object request) {
            var rez = await $"{_endpoint}{_resoruce}".PostJsonAsync(request).ReceiveJson<T>();
            return rez;
        }
        public async Task<T> Put<T>(object id , object request) {
            var rez = await $"{_endpoint}{_resoruce}/{id}".PutJsonAsync(request).ReceiveJson<T>();
            return rez;
        }
    }
}
