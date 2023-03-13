using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroics4.Heros.Hero
{
    class Archer : Hero
    {
        private int _addBush;

        public Archer(int adBush, int x, int y) : base(10, 7, x, y, 'A', 100)
        {
            _addBush = adBush;
        }

        public override void Fight(Hero hero)
        {
            if (this.GetDamage() + _addBush >= hero.GetHp())
            {
                hero.SetLive(true);
                _addBush += 10;
            }
            else
            {
                hero.SetHp(hero.GetHp() - this.GetDamage() - _addBush);
                _addBush += this.GetDamage() / 2;
            }
        }
    }
}
