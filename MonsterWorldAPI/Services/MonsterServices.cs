using MonsterWorldAPI.Models;
using System;
using MonsterWorldAPI.API;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonsterWorldAPI.Services
{
    public class MonsterServices
    {
        string[] Names = new string[] { "Assassin", "Blood", "Extinguisher", "Punisher" };
        string[] Conj = new string[] { "Of Ladies", "Of Sinners", "Of Undeads", "Of Italians" };
        int qtt = 10;
        Random rnd = new Random();
        public List<Monster> AddMonster()
        {
            List<Monster> monsters = new List<Monster>();
            Monster monster = new();
            var monsterArray = monster.MonsterDificulty;
            var valuesAsArray = Enum.GetValues(typeof(Dificulty));
            int j = 1;

            for (int i = 0; i < qtt; i++)
            {
                var name = $"{Names[rnd.Next(Names.Length)]} {Conj[rnd.Next(Conj.Length)]}";
                foreach (Dificulty dificulty in valuesAsArray)
                {

                    
                    monsters.Add(new Monster()
                    {
                        Attack = rnd.Next(2 + j, 10 + j),
                        Experience = rnd.Next(2 + j, 10 + j),
                        Hp = rnd.Next(2 + j, 10 + j),
                        Id = j,
                        MonsterDificulty = dificulty,
                        Name = name + " " + dificulty
                    });
                    j++;

                }
            }
            return monsters;
        }

    }
}
