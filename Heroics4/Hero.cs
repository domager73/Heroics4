using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroics4
{
    abstract class Hero
    {
        protected int _hp;
        protected int _damage;
        protected int _x;
        protected int _y;
        protected char _look;
        protected 

        private bool _live;

        protected Hero(int hp, int damage, int x, int y, char look)
        {
            _hp = hp;
            _damage = damage;
            _x = x;
            _y = y;
            _live = false;
            _look = look;
        }

        public void Draw(bool which)
        {
            if (which) Console.ForegroundColor = ConsoleColor.Blue;
            else Console.ForegroundColor = ConsoleColor.Red;

            Console.SetCursorPosition(_x, _y);
            Console.Write(_look);
        }

        public virtual void Fight(Hero hero) { }

        public int GetHp() => _hp;
        public void SetLive(bool live) => _live = live;
        public int GetDamage() => _damage;
        public void SetHp(int hp) => _hp = hp;
    }
}
