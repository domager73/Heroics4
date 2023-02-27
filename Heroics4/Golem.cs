using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroics4
{
    class Golem : Hero
    {
        private int _adHp;

        public Golem(int adHp, int x, int y) : base(15, 5, x, y, 'G')
        {
            _adHp = adHp;
        }

        public override void Fight(Hero hero)
        {
            if (_damage >= hero.GetHp())
            {
                hero.SetLive(true);
                _adHp += 1;
            }
            else
            {
                hero.SetHp(hero.GetHp() - _damage);
            }

            if (hero.GetDamage() > _hp + _adHp)
            {
                this.SetLive(true);
            }
            else
            {
                this.SetHp(hero.GetHp() - _damage);
                _adHp -= 1;
            }
        }
    }
}
