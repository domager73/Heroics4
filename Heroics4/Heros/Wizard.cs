using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroics4.Heros;

class Wizard : Hero
{
    private int _dableDamage;

    public Wizard(int dableDamage, int x, int y) : base(10, 12, x, y, 'W', 10)
    {
        _dableDamage = dableDamage;
    }

    public override void Fight(Hero hero)
    {
        if (this.GetDamage() + _dableDamage >= hero.GetHp())
        {
            hero.SetLive(true);
            _dableDamage += 10;
        }
        else
        {
            hero.SetHp(hero.GetHp() - this.GetDamage() - _dableDamage);
            _dableDamage += this.GetDamage() / 2;
        }
    }
}
