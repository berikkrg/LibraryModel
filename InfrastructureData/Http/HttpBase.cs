using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureData.Http
{
    /// <summary>
    /// The HttpBase class provides a base for making HTTP requests.
    /// </summary>
    public class HttpBase
    {
        // The base URL for the HTTP requests.
        private readonly string _baseUrl;
        public HttpBase()
        {
            //WARNING! if you are going to run API app on http/https/IIS express look at LibraryModelAPI.Properties.launchsettings.json
            // set the baseUrl depending on localhost addresses
            _baseUrl = "http://localhost:5287/swagger";
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri(_baseUrl);
        }
        public HttpClient HttpClient { get; set; }
    }
}
