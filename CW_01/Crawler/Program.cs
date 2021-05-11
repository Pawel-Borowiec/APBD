using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crawler
{
    
    class Program
    {
        static string REGEX = "[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+\\.?[a-z]+";
        static HttpResponseMessage httpResponse;
        public static async Task Main(string[] args)
        {

            Console.WriteLine(args.Length);
            if (args.Length!=0) {
                string url = args[0];
                using (HttpClient httpClient = new HttpClient()) //wywołuje dispose w odpowiednim momencie tak by zwolniły się zasoby
                {
                    try
                    {
                        httpResponse = await httpClient.GetAsync(url);

                        if (httpResponse.IsSuccessStatusCode)
                        {
                            string response = await httpResponse.Content.ReadAsStringAsync();
                            List<string> result = getResults(response);
                            showResults(result);
                        }
                        else
                        {
                            throw new ArgumentException("Niepoprawny adres URL");
                        }

                    }
                    catch (HttpRequestException e)
                    {
                        throw new Exception("Błąd w czasie pobierania strony");
                    }
                }
                
            } else {
                throw new ArgumentNullException("Nie przekazano argumentu");
            }
        }
        // Dodanie do listy wyników nowego rekordu po uprzednim sprawdzeniu czy się nie powtarza
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
        // Wypisanie wyników wyszukiwania bądź informacji o ich braku
        static void showResults(List<string> emails)
        {
            if (emails.Count!=0)
            {
                Console.WriteLine("Znalezione unikalne adresy email:");
                foreach (string x in emails)
                {
                    Console.WriteLine(x);
                }
            }
            else
            {
                Console.WriteLine("Nie znaleziono adresów email");
            }
        }
        // Wyciągnięcie z źródła strony zawartych w nim maili
        static List<string> getResults(string source)
        {
            List<String> temp = new List<string>();
            foreach (Match match in Regex.Matches(source, REGEX, RegexOptions.IgnoreCase))
            {
                temp = addToResults(temp, match.Value);
            }
            return temp;
        }
    }
    
}
