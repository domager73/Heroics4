using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroics4
{
    class Archer : Hero
    {
        private int _adBush;

        public Archer(int adBush, int x, int y) : base(10, 7, x, y, 'A', 100)
        {
            _adBush = adBush;
        }

        public override void Fight(Hero hero)
        {
            if (this.GetDamage() + _adBush >= hero.GetHp())
            {
                hero.SetLive(true);
                _adBush += 10;
            }
            else
            {
                hero.SetHp(hero.GetHp() - this.GetDamage() - _adBush);
                _adBush += this.GetDamage() / 2;
            }
        }
    }
}
