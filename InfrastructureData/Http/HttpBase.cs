using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureData.Http
{
    public class HttpBase
    {
        private readonly string _baseUrl;
        public HttpBase()
        {
            _baseUrl = "http://localhost:5287/swagger";
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri(_baseUrl);
        }
        public HttpClient HttpClient { get; set; }


    }
}
