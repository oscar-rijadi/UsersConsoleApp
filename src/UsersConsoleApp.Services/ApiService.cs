using System;
using System.IO;
using System.Net;
using UsersConsoleApp.Interfaces;

namespace UsersConsoleApp.Services
{
    public class ApiService : IApiService
    {
        public string GetData(string apiEndpoint)
        {
            try
            {
                var httpRequest = (HttpWebRequest)WebRequest.Create(apiEndpoint);
                using (var response = (HttpWebResponse)httpRequest.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream == null) return null;
                        var sr = new StreamReader(responseStream);
                        return sr.ReadToEnd();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
