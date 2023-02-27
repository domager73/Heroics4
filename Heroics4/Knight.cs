using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroics4
{
    class Knight : Hero
    {
        private int _armor;

        public Knight(int armor,int x, int y) : base(16, 4, x, y, 'K')
        {
            _armor = armor;
        }

        public override void Fight(Hero hero)
        {
            if (_damage >= hero.GetHp())
            {
                hero.SetLive(true);
                _armor = 3;
            }
            else
            {
                hero.SetHp(hero.GetHp() - _damage);
            }

            if (hero.GetDamage() > _hp + _armor)
            {
                this.SetLive(true);
            }
            else
            {
                this.SetHp(hero.GetHp() - _damage);
                _armor -= 1;
            }
        }
    }
}
