using AutoMapper;
using Tamagotchi.Model;
using Tamagotchi.View;

namespace Tamagotchi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Mascote, MascoteViewItem>());
            var mapper = config.CreateMapper();

            Console.WriteLine("-------------------- Iniciando Jogo --------------------");

            Console.WriteLine(".……(\\__ /)");
            Console.WriteLine(".……(=’.’=)");
            Console.WriteLine("…☆(”)_(”)☆");

            TamagotchiView tamagotchiView = new TamagotchiView();

            tamagotchiView.Initializing();
        }
    }
}