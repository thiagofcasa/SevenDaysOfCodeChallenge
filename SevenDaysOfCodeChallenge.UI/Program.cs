using SevenDaysOfCodeChallenge.API_Access;
using SevenDaysOfCodeChallenge.API_Access.Model;

namespace SevenDaysOfCodeChallenge.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PokemonApiInvoke pkApi = new PokemonApiInvoke();
            PokeDex pokeDex = new PokeDex();

            pokeDex = pkApi.GetAllPokemon("https://pokeapi.co/api/v2/pokemon/");
            int sair = 0;
            Results escolhido = new Results();

            do
            {
                Console.WriteLine("Escolha o seu mascote!");

                int qtdMascotes = pokeDex.results.Count();

                Results[] arrayMascotes = new Results[qtdMascotes];

                foreach (var mascote in pokeDex.results)
                {
                    Console.WriteLine("Nome: " + mascote.name);
                }

                Console.WriteLine();
                Console.WriteLine("Escreva o nome do mascote escolhido ou tecle 9 para ir para a proxima lista.");

                string nome = Console.ReadLine();

                if (nome == "9")
                {
                    pokeDex = pkApi.GetAllPokemon(pokeDex.next);
                }
                else
                {
                    escolhido = pokeDex.results.Where(m => m.name == nome).FirstOrDefault();

                    if (escolhido != null)
                    {
                        //retorna informações do escolhido
                        sair = 1;
                    }
                    else
                    {
                        Console.WriteLine("O nome do mascote digitado não foi encontrado.");
                    }
                }


            } while (sair != 1);

            Mascote meuMascote = pkApi.GetPokemon(escolhido.url);

            Console.WriteLine();
            Console.WriteLine("Nome: " + meuMascote.name);
            Console.WriteLine("Altura: " + meuMascote.height);
            Console.WriteLine("Peso:" + meuMascote.weight);
            foreach (var abilitie in meuMascote.abilities)
            {
                Console.WriteLine("Abilidade: " + abilitie.ability.name);
            }
        }
    }
}