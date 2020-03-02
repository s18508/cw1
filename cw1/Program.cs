using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cw1
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //int tmp1 = 1;
            //double tmp2 = 2.0;
            //string tmp3 = "aaaa";
            //bool tmp4 = true;
            //var tmp5 = "bbb";
            //Console.WriteLine($"{tmp3} {tmp5} {tmp1+tmp2}");
            //var newPerson = new Person { FirstName = "Dominika" };
            var url =args.Length>0 ? args[0] : "https://www.pja.edu.pl";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            //2xx
            if (response.IsSuccessStatusCode)
            {
                var htmlContent = await response.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);
                var matches = regex.Matches(htmlContent);
                foreach (var match in matches)
                {
                    Console.WriteLine(match.ToString());
                }
            }

        }
    }
}
