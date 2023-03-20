using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroics4.Heros;

abstract class Hero
{
    private int _hp;
    private int _damage;
    private int _x;
    private int _y;
    private char _look;
    private int _attackRadius;

    private bool _live;

    protected Hero(int hp, int damage, int x, int y, char look, int attackRadius)
    {
        _hp = hp;
        _damage = damage;
        _x = x;
        _y = y;
        _live = false;
        _look = look;
        _attackRadius = attackRadius;
    }

    public void Draw(bool which)
    {
        if (which) Console.ForegroundColor = ConsoleColor.Blue;
        else Console.ForegroundColor = ConsoleColor.Red;

        Console.SetCursorPosition(_x, _y);
        Console.Write(_look);
    }

    public void Move(ConsoleKey move)
    {
        switch (move)
        {
            case ConsoleKey.W:
                if (_y > 1)
                {
                    _y -= 1;
                }
                break;
            case ConsoleKey.D:
                if (_x < 119)
                {
                    _x += 4;
                }
                break;
            case ConsoleKey.S:
                if (_y < 19)
                {
                    _y += 1;
                }
                break;
            case ConsoleKey.A:
                if (_x > 41)
                {
                    _x -= 4;
                }
                break;
            default: break;
        }
    }

    public virtual void Fight(Hero hero) { }

    public int GetHp() => _hp;
    public void SetLive(bool live) => _live = live;
    public bool GetLive() => _live;
    public int GetDamage() => _damage;
    public void SetHp(int hp) => _hp = hp;
    public int GetX() => _x;
    public void SetX(int x) => _x = x;
    public int GetY() => _y;
    public void SetY(int y) => _y = y;
    public int GetRadius() => _attackRadius;
}
