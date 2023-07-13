using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.Model;
using Tamagotchi.Service;

namespace Tamagotchi.Controller
{
    public static class TamagotchiController
    {
        public static Mascote BuscarMascote(string urlApi)
        {
            return PokemonService.GetPokemon(urlApi);
        }

        public static PokeDex BuscarCatalogo(string urlApi)
        {
            return PokemonService.GetAllPokemon("https://pokeapi.co/api/v2/pokemon/");
        }
    }
}
