using Tamagotchi.Controller;
using Tamagotchi.Model;
using Tamagotchi.Util;

namespace Tamagotchi.View
{
    public class TamagotchiView
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
            catalogo = TamagotchiController.BuscarCatalogo("https://pokeapi.co/api/v2/pokemon/");
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
                    catalogo = TamagotchiController.BuscarCatalogo(catalogo.next);
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

            return null;
        }

        private Mascote BuscarMascote(string urlApi, string nome)
        {
            try
            {
                Mascote mascote = TamagotchiController.BuscarMascote(urlApi);

                if (mascote != null)
                {
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
                                try
                                {
                                    ExibirDetalhesMascote(mascote);
                                    break;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    break;
                                }

                            case "2":
                                return mascote;

                            case "3":
                                return null;
                        }

                    } while (true);
                }
                else
                {
                    Console.WriteLine("Não foi possivel buscar mascote.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

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

            Dictionary<string, string> dict = new Dictionary<string, string>();
            int i = 1;
            foreach (var mascote in mascoteList)
            {
                Console.WriteLine(i + ". " + mascote.name);
                dict.Add(i.ToString(), mascote.name);
                i++;
            }

            Console.WriteLine();
            Console.WriteLine("Digite o numero do mascote que deseja interagir.");
            Console.WriteLine("Digite 0 para voltar.");
            string option = Console.ReadLine();

            if (option != "0")
            {
                if (dict.ContainsKey(option))
                {
                    Mascote mascote = mascoteList.Where(x => x.name == dict[option]).FirstOrDefault();

                    //show information about mascote.
                    Interagir(mascote);
                }
                else
                {
                    Console.WriteLine("O valor digitado não corresponde a nenhum mascote.");
                }
            }
        }

        private void Interagir(Mascote mascote)
        {
            string opcao = "";
            do
            {
                Console.WriteLine("--------- " + mascote.name.ToUpper() + " ----------");
                Console.WriteLine("1 - Saber como o " + mascote.name + " está.");
                Console.WriteLine("2 - Alimentar " + mascote.name + "!");
                Console.WriteLine("3 - Brincar com " + mascote.name + "!");
                Console.WriteLine("4 - Colocar o " + mascote.name + " para dormir!");
                Console.WriteLine("9 - VOLTAR");

                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        MostrarMascote(mascote);
                        break;
                    case "2":
                        Alimentar(mascote);
                        break;
                    case "3":
                        Brincar(mascote);
                        break;

                    case "4":
                        Dormir(mascote);
                        break;

                    default:
                        break;
                }
            } while (opcao != "9");
        }

        private void Dormir(Mascote mascote)
        {
            if (mascote.sono < (Enum.GetValues(typeof(Sono)).Length) - 1)
            {
                mascote.sono++;
                MostrarMascote(mascote);
            }
            else
            {
                MostrarMascote(mascote);
            }

        }

        private void Brincar(Mascote mascote)
        {
            if (mascote.humor < (Enum.GetValues(typeof(Humor)).Length) - 1)
            {
                mascote.humor++;
                MostrarMascote(mascote);
            }
            else
            {
                MostrarMascote(mascote);
            }
        }

        private void Alimentar(Mascote mascote)
        {
            if (mascote.fome < (Enum.GetValues(typeof(Fome)).Length) - 1)
            {
                mascote.fome++;
                MostrarMascote(mascote);
            }
            else
            {
                Console.WriteLine("O " + mascote.name + (" esta explodindo."));
                MostrarMascote(mascote);
            }
        }

        private void MostrarMascote(Mascote mascote)
        {
            Console.WriteLine("Nome: " + mascote.name);
            Console.WriteLine("Altura: " + mascote.height);
            Console.WriteLine("Peso: " + mascote.weight);
            Console.WriteLine("Idade: " + TamagotchiController.Idade(mascote));

            Console.WriteLine(mascote.name + " esta " + (Fome)mascote.fome);
            Console.WriteLine(mascote.name + " está " + (Humor)mascote.humor);
            Console.WriteLine(mascote.name + " está " + (Sono)mascote.sono);
            Console.WriteLine();


        }


    }

}