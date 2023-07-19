using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Model
{
    public class Mascote
    {
        public List<AbilityInfo> abilities { get; set; }
        public string name { get; set; }
        public int height { get; set; }
        public int weight { get; set; }

        public int fome { get; set; }
        public int sono { get; set; }
        public int humor { get; set; }
        public int idade { get; set; }
        public DateTime nascimento { get; set; }

        public Mascote()
        {
            Random num = new Random();

            fome = num.Next(0, 5);
            sono = num.Next(0, 5);
            humor = num.Next(0, 5);
            idade = 0;
            nascimento = DateTime.Now;
        }
    }
}
