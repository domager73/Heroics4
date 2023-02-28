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

        public Knight(int armor,int x, int y) : base(16, 4, x, y, 'K', 8)
        {
            _armor = armor;
        }

        public override void Fight(Hero hero)
        {
            if (this.GetDamage() >= hero.GetHp())
            {
                hero.SetLive(true);
                _armor = 3;
            }
            else
            {
                hero.SetHp(hero.GetHp() - this.GetDamage());
            }

            if (hero.GetDamage() > this.GetHp() + _armor)
            {
                this.SetLive(true);
            }
            else
            {
                this.SetHp(hero.GetHp() - this.GetDamage() - _armor);
                _armor -= 1;
            }
        }
    }
}
