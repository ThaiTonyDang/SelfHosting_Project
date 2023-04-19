using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SeftHosting
{
    public class Program
    {
        static void Main(string[] args)
        {
            var baseAddress = "http://localhost:5000/";
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                var client = new HttpClient();
                var response = client.GetAsync(baseAddress + "api/product").Result;

                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.ReadLine();
            }    
        }
    }
}
