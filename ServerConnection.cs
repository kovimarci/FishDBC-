using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FishDB
{
    public class ServerConnection
    {
        HttpClient client = new ();

        public ServerConnection(string url)
        {
            client.BaseAddress = new Uri(url);
        }

        public async Task<List<Fish>> GetFish()
        {
            try
            {
                return JsonSerializer.Deserialize<List<Fish>>(await (await client.GetAsync("/fish")).EnsureSuccessStatusCode().Content.ReadAsStringAsync());
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return null;
        }
        
        public async Task<bool> Register(string username, string password)
        {
            try
            {
                client.PostAsync("/registration", new StringContent(JsonSerializer.Serialize(new User(username, password)), Encoding.UTF8, "application/json"));
                return true;
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return false;
        }
    }
}
