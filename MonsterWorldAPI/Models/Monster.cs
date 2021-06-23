using MonsterWorldAPI.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonsterWorldAPI.Models
{
    public class Monster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Experience { get; set; }
        public int Attack { get; set; }
        public Dificulty MonsterDificulty { get; set; } //Dificuldade do tipo ENUM Dificuldade
    }
}
