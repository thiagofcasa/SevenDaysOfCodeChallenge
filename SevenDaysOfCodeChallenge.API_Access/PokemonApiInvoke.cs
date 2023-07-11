using RestSharp;
using SevenDaysOfCodeChallenge.API_Access.Model;
using System.Net;
using System.Text.Json;

namespace SevenDaysOfCodeChallenge.API_Access
{
    public class PokemonApiInvoke
    {
        public PokeDex GetAllPokemon(string apiUrl)
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

        public Mascote GetPokemon(string url)
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
