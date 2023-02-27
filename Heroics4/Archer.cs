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

        public Archer(int adBush, int x, int y) : base(10, 7, x, y, 'A')
        {
            _adBush = adBush;
        }

        public override void Fight(Hero hero)
        {
            if (_damage >= hero.GetHp())
            {
                hero.SetLive(true);
                _adBush += 10;
            }
            else
            {
                hero.SetHp(hero.GetHp() - _damage);
                _adBush += _damage / 2;
            }

            if (hero.GetDamage() > _hp)
            {
                this.SetLive(true);
            }
            else
            {
                this.SetHp(hero.GetHp() - _damage);
            }
        }
    }
}
