using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl;
using eAutobusModel;
using eAutobus.WinUI.Properties;
using Microsoft.Reporting.Map.WebForms.BingMaps;

namespace eAutobus.WinUI
{
    public class APIService
    {
        private string _route = null;
        public static string Username { get; set; }
        public static string Password { get; set; }


        public APIService(string route)
        {
            _route = route;
        }
        public async Task<T> Get<T>(object search = null)
        {
            var url = $"{Settings.Default.ApiURL}/{_route}";
            if (search!=null)
            {
                url += "?";
                url += await search.ToQueryString();
            }
            var result = await url.WithBasicAuth(Username,Password).GetJsonAsync<T>();
            return result;
        }
        public async Task<T> GetById<T>(object id)
        {
            var url = $"{Settings.Default.ApiURL}/{_route}/{id}";
            return await url.WithBasicAuth(Username,Password).GetJsonAsync<T>();
        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{Settings.Default.ApiURL}/{_route}";
            return await url.WithBasicAuth(Username,Password).PostJsonAsync(request).ReceiveJson<T>();
        }

        public async Task<T> Update<T>(object id,object request)
        {
            var url = $"{Settings.Default.ApiURL}/{_route}/{id}";
            return await url.WithBasicAuth(Username,Password).PutJsonAsync(request).ReceiveJson<T>();
        }
        public async Task<T> Delete<T>(object id)
        {
            var url = $"{Settings.Default.ApiURL}/{_route}/{id}";
            return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<T>();
        }
        public async Task<T> GetCijena<T>(object search)
        {
            var url = $"{Settings.Default.ApiURL}/{_route}";
            if (search != null)
            {
                url += "?";
                url += await search.ToQueryString();
            }
            var result = await url.GetJsonAsync<T>();
            return result;
        }

        public async Task<T> UplatiKartu<T>(int id,object request)
        {
           var _route1 = _route + "/UplatiKartu";
            var url = $"{Settings.Default.ApiURL}/{_route1}/{id}";
            var result = await url.PostJsonAsync(request).ReceiveJson<T>();

            return result;
        }

    }

}
