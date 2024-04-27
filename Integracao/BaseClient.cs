using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integracao
{
    public class BaseClient
    {
        static readonly HttpClient _client = new HttpClient();
        string _baseUrl = "https://ptg4shc8-7029.brs.devtunnels.ms/";

        public async Task<HttpResponseMessage> GetShare(string symbol)
        {
            var url = _baseUrl + "Share/" + symbol;
            var response = await _client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Erro ao buscar informações");
            }
            return response;
        }
    }
}
