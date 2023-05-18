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
        public static string username = null;
        public static string password = null;

        public APIService(string resorce) { _resoruce = resorce; }

        public async Task<T> Get<T>(object search = null) {
            var query = "";
            if (search != null) { query = await search.ToQueryString(); }
            var list = await $"{_endpoint}{_resoruce}?{query}".WithBasicAuth(username,password).GetJsonAsync<T>();
            return list;
        }
        public async Task<T> GetById<T>(object id) {
            var rez = await $"{_endpoint}{_resoruce}/{id}".WithBasicAuth(username, password).GetJsonAsync<T>();
            return rez;
        }
        public async Task<T> Post<T>(object request) {
            try {
                var rez = await $"{_endpoint}{_resoruce}".WithBasicAuth(username, password).PostJsonAsync(request).ReceiveJson<T>();
                return rez;
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();
                var stringBuilder = new StringBuilder();
                foreach (var error in errors) {
                    stringBuilder.AppendLine($"{error.Key},{string.Join(":", error.Value)}");
                }
                MessageBox.Show(stringBuilder.ToString(),
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            } 
        }
        public async Task<T> Put<T>(object id , object request) {
            try {
                var rez = await $"{_endpoint}{_resoruce}/{id}".WithBasicAuth(username, password).PutJsonAsync(request).ReceiveJson<T>();
                return rez;
            }
             catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();
                var stringBuilder = new StringBuilder();
                foreach (var error in errors) {
                    stringBuilder.AppendLine($"{error.Key},{string.Join(":", error.Value)}");
                }
                MessageBox.Show(stringBuilder.ToString(),
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }
        }
    }
}
