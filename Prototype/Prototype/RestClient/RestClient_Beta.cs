using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.RestClient
{
    class RestClient_Beta
    {
        public string EndPoint { get; set; }

        private static readonly HttpClient client = new HttpClient();

        public RestClient_Beta()
        {
            EndPoint = string.Empty;
        }

        public async Task<string> DoRequest()
        {
            string responseVal = string.Empty;
            try
            {
                HttpResponseMessage response = await client.GetAsync(EndPoint);
                response.EnsureSuccessStatusCode();
                responseVal = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseVal);
                Console.ReadLine();
            } catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return responseVal;
        }
    }
}
