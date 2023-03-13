using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroics4.Heros.Hero
{
    class Wizard : Hero
    {
        private int _dableDamage;

        public Wizard(int dableDamage, int x, int y) : base(1,1,)
        {
            _dableDamage = dableDamage;
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
