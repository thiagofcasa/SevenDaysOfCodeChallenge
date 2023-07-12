using SevenDaysOfCodeChallenge.API_Access;
using SevenDaysOfCodeChallenge.API_Access.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SevenDaysOfCodeChallenge.UI
{
    public class InitialScreenInterface
    {
        public void Initializing()
        {
            Console.WriteLine("Qual é o seu nome?");
            string nome = Console.ReadLine().ToString();
            List<Mascote> mascoteList = new List<Mascote>();

            string opcao = "0";
            do
            {
                Console.WriteLine("-------------------- MENU --------------------");
                Console.WriteLine(nome + ", você deseja:");
                Console.WriteLine("1 - Adotar um mascote virtual.");
                Console.WriteLine("2 - Ver seus mascotes.");
                Console.WriteLine("3 - Sair");

                opcao = Console.ReadLine();

                switch (opcao)
                {

                    case "1":
                        Mascote mascote = AdotarMascote(nome);

                        if (mascote != null)
                        {
                            mascoteList.Add(mascote);
                        }
                        break;

                    case "2":
                        if (mascoteList.Count > 0)
                        {
                            VerMascotes(mascoteList);
                        }
                        else
                        {
                            Console.WriteLine("Você não tem nenhum mascote.");
                        }
                        break;

                    default:
                        break;
                }

            } while (opcao != "3");
        }

        private Mascote AdotarMascote(string nome)
        {
            Console.WriteLine(nome + " escolha uma espécie.");

            PokeDex catalogo = new PokeDex();
            catalogo = PokemonApiInvoke.GetAllPokemon("https://pokeapi.co/api/v2/pokemon/");
            Results escolhido = new Results();

            string opcao2 = "";
            do
            {
                foreach (var mascote in catalogo.results)
                {
                    Console.WriteLine("Nome: " + mascote.name);
                }

                Console.WriteLine();
                Console.WriteLine("Escreva o nome do mascote escolhido.");
                Console.WriteLine("9 - Ir para a próxima página.");
                Console.WriteLine("0 - Voltar");

                opcao2 = Console.ReadLine();

                //Buscar proxima pagina de opcoes de mascotes
                if (opcao2 == "9")
                {
                    catalogo = PokemonApiInvoke.GetAllPokemon(catalogo.next);
                }
                //Pesquisar o nome do mascote na lista
                else if (opcao2 != "0")
                {
                    escolhido = catalogo.results.Where(m => m.name == opcao2).FirstOrDefault();

                    if (escolhido != null)
                    {
                        //retorna informações do escolhido
                        Mascote mascoteEscolhido = BuscarMascote(escolhido.url, nome);

                        if (mascoteEscolhido != null)
                        {
                            return mascoteEscolhido;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        Console.WriteLine("O nome do mascote digitado não foi encontrado.");
                    }
                }

            } while (opcao2 != "0");


            throw new NotImplementedException();
        }

        private Mascote BuscarMascote(string urlApi, string nome)
        {
            Mascote mascote = PokemonApiInvoke.GetPokemon(urlApi);

            do
            {
                Console.WriteLine(nome + " você deseja:");
                Console.WriteLine("1 - SABER MAIS SOBRE O " + mascote.name);
                Console.WriteLine("2 - ADOTAR " + mascote.name);
                Console.WriteLine("3 - VOLTAR");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        ExibirDetalhesMascote(mascote);
                        break;

                    case "2":
                        return mascote;

                    case "3":
                        return null;
                }

            } while (true);
        }

        private void ExibirDetalhesMascote(Mascote mascote)
        {
            Console.WriteLine("Nome: " + mascote.name);
            Console.WriteLine("Altura: " + mascote.height);
            Console.WriteLine("Peso: " + mascote.weight);
            foreach (var item in mascote.abilities)
            {
                Console.WriteLine("Habilidades: " + item.ability.name);
            }
            Console.WriteLine("------------------------------------");
            Console.ReadKey();
        }

        private void VerMascotes(List<Mascote> mascoteList)
        {
            Console.WriteLine("-------------------- SEUS MASCOTES --------------------");
            foreach (var mascote in mascoteList)
            {
                Console.WriteLine(mascote.name);
            }
        }

    }
}
