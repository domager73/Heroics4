using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heroics4.Heros;

namespace Heroics4
{
    class PLayer
    {
        private List<Hero> _hero;
        private int _money;
        private bool _which;
        private int _id;

        public PLayer()
        {
            _hero = new List<Hero>();
            _money = 30;
        }

        public int GetMoney() => _money;
        public void SetMoney(int money) => _money = money;
        public List<Hero> GetHero() => _hero;
        public int GetId() => _id;
        public void SetId(int id) => _id = id;

        public override string ToString()
        {
            string str = " ";

            for (int i = 0; i < _hero.Count; i++)
            {
                if (!_hero[i].GetLive())
                {
                    str = str + $"{i}: hp:{_hero[i].GetHp()}, damage:{_hero[i].GetDamage()}\n";
                }
            }

            return str;
        }
    }
}
