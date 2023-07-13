using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tamagotchi.Model;

namespace Tamagotchi.Service
{
    public class PokemonService
    {
        public static PokeDex GetAllPokemon(string apiUrl)
        {
            try
            {
                var client = new RestClient(apiUrl);
                RestRequest request = new RestRequest("", Method.Get);

                var response = client.Execute(request);
                var result = JsonSerializer.Deserialize<PokeDex>(response.Content);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Mascote GetPokemon(string url)
        {
            try
            {
                /*var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{id}")*/
                ;
                var client = new RestClient(url);
                RestRequest request = new RestRequest("", Method.Get);

                var response = client.Execute(request);

                var result = JsonSerializer.Deserialize<Mascote>(response.Content);

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
