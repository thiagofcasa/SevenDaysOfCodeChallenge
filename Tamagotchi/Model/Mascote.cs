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
    }
}
