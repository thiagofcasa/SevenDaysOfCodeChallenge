using Tamagotchi.Model;
using Tamagotchi.Service;

namespace Tamagotchi.Controller
{
    public static class TamagotchiController
    {
        public static Mascote BuscarMascote(string urlApi)
        {
            try
            {
                return PokemonService.GetPokemon(urlApi);
            }
            catch (Exception ex)
            {
                throw new Exception(ex);
            }
        }

        public static PokeDex BuscarCatalogo(string urlApi)
        {
            try
            {
                return PokemonService.GetAllPokemon(urlApi);
            }
            catch (Exception ex)
            {
                throw new Exception(ex);
            }
        }

        public static string Idade(Mascote mascote)
        {
            DateTime agora = DateTime.Now;

            TimeSpan resultado = agora - mascote.nascimento;

            return resultado.ToString();
        }
    }
}
