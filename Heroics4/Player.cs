using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroics4
{
    class PLayer
    {
        private List<Hero> _hero;
        private int _money;
        private bool _which;

        public PLayer()
        {
            _hero = new List<Hero>();
            _money = 100;
        }

        public bool GetWhich() => _which;
        public void SetWhich(bool which) => _which = which;
        public int GetMoney() => _money;
        public void SetMoney(int money) => _money = money;
        public List<Hero> GetHero() => _hero;

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
