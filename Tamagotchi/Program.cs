using Tamagotchi.View;

namespace Tamagotchi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------- Iniciando Jogo --------------------");
            TamagotchiView tamagotchiView = new TamagotchiView();

            tamagotchiView.Initializing();
        }
    }
}