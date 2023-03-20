using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroics4.Heros
{
    class Golem : Hero
    {
        private int _adHp;

        public Golem(int adHp, int x, int y) : base(15, 5, x, y, 'G', 3)
        {
            _adHp = adHp;
        }

        public override void Fight(Hero hero)
        {
            if (this.GetDamage() >= hero.GetHp())
            {
                hero.SetLive(true);
                _adHp += 1;
            }
            else
            {
                hero.SetHp(hero.GetHp() - this.GetDamage());
            }

            if (hero.GetDamage() >= this.GetHp() + _adHp)
            {
                this.SetLive(true);
            }
            else
            {
                this.SetHp(hero.GetHp() - this.GetDamage() - _adHp);
                _adHp -= 1;
            }
        }

        public override string ToString()
        {
            return $"Hp: {this.GetHp}\nDamage: {this.GetDamage}\nAttack radius: {this.GetRadius}\nAddHealth: {_adHp}";
        }
    }
}
