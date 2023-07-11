using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SevenDaysOfCodeChallenge.API_Access.Model
{
    public class Mascote
    {
        public List<AbilityInfo> abilities { get; set; }
        public string name { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
    }

    public class Ability
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class AbilityInfo
    {
        public Ability ability { get; set; }
        public bool is_hidden { get; set; }
        public int slot { get; set; }
    }

}
