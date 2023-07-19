using Tamagotchi.Service;

namespace Tamagotchi.Model
{
    public class PokeDex
    {
        public int count { get; set; }
        public string? next { get; set; }
        public string? previous { get; set; }
        public List<Results>? results { get; set; }

        public static PokeDex ProximaPagina(PokeDex mascote)
        {
            return PokemonService.GetAllPokemon(mascote.next);
        }
    }

    public class Results
    {
        public string name { get; set; }
        public string url { get; set; }
    }
}
