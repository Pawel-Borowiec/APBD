using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crawler
{
    class Program
    {
        static HttpResponseMessage httpResponse;
        public static async Task Main(string[] args)
        {

            Console.WriteLine(args.Length);
            if (args[0].Length >0) {
                string url = args[0];
                HttpClient httpClient = new HttpClient();
                try
                {
                    httpResponse = await httpClient.GetAsync(url);
                    string response = await httpResponse.Content.ReadAsStringAsync();
                    string emailPattern = "[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+\\.?[a-z]+";

                    List<string> result = new List<string>();
                    foreach (Match match in Regex.Matches(response,emailPattern, RegexOptions.IgnoreCase))
                    {
                        result = addToResults(result,match.Value);
                    }
                    Console.WriteLine(result.Count);

                    foreach (string x in result)
                    {
                        Console.WriteLine(x);
                    }
                    Console.WriteLine(Regex.IsMatch(response, emailPattern) ? "Jest" : "Nie");
                }
                catch (HttpRequestException e)
                {
                    throw new ArgumentException("Przekazany argument nie jest adresem URL");
                }
                
            } else {
                throw new ArgumentNullException("Nie przekazano argumentu");
            }
            httpResponse.Dispose();
        }

        static List<string> addToResults(List<String> lista, string newElement)
        {
            bool condition = true;
            foreach ( string x in lista)
            {
                if(x.Equals(newElement))
                {
                    condition = false;
                }
            }
            if (condition)
            {
                lista.Add(newElement);
            }
            return lista;
        }
    }
    
}
