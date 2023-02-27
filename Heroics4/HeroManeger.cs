using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Heroics4
{
    class PLayer
    {
        private List<Hero> _hero;
        private int _money;
        private bool _which;

        public PLayer()
        {
            _hero = new List<Hero>();
            _money = 15;
        }

        public bool GetWhich() => _which;
        public void SetWhich(bool which) => _which = which;
        public int GetMoney() => _money;
        public void SetMoney(int money) => _money = money;
        public List<Hero> GetHero() => _hero;

        public override string ToString()
        {
            string str = " ";

            for (int i = 0; i < _hero.Count; i++) 
            {
                str = str + $"{i}: hp:{_hero[i].GetHp()}, damage:{_hero[i].GetDamage()}\n";
            }

            return str;
        }
    }

    class HeroManeger
    {
        #region Variable

        private PLayer _player1;
        private PLayer _player2;

        Random rnd;

        #endregion

        #region CreateMethods

        public HeroManeger()
        {
            _player1 = new PLayer();
            _player1.SetWhich(true);
            _player2 = new PLayer();
            _player2.SetWhich(false);
        }
        #endregion

        #region LogicMethods
        private void ChoosHeroes()
        {
            PLayerChoose(_player1.GetMoney(), _player1.GetHero(), 1);

            PLayerChoose(_player2.GetMoney(), _player2.GetHero(), 2);
        }

        public void Play()
        {
            ChoosHeroes();
            Console.Clear();

            Draw();
        }
        #endregion

        #region SupportMethods

        int InputInt(string msg)
        {
            bool inputReault;
            int number;

            Console.Write(msg);

            do
            {
                inputReault = int.TryParse(Console.ReadLine(), out number);
            } while (!inputReault);

            return number;
        }

        private int ChoseKey(string key, List<Hero> heros, int money)
        {
            rnd = new Random();

            Console.WriteLine("Введите координату по X(0..79) и по Y(0..19)");
            int x = InputInt("X: ");
            int y = InputInt("Y: ");

            switch (key)
            {
                case "a":
                    heros.Add(new Archer(rnd.Next(1, 3 + 1), x + 40, y));
                    money -= 30;
                    break;
                case "k":
                    heros.Add(new Knight(rnd.Next(1, 4 + 1), x + 40, y));
                    money -= 20;
                    break;
                case "g":
                    heros.Add(new Golem(rnd.Next(1, 3 + 1), x + 40, y));
                    money -= 15;
                    break;
            }

            return money;
        }

        private void PLayerChoose(int money, List<Hero> hero, int numHero)
        {
            while (money > 0)
            {
                Console.Clear();

                WriteField();

                Console.SetCursorPosition(0, 0);

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Archer: A(30p)\nGolem: G(20p)\nKhight: K(15)");

                Console.Write($"Chosse hero {numHero}p: ");
                string choos2 = Console.ReadLine();
                money = ChoseKey(choos2, hero, money);
            }
        }

        #endregion

        #region WriteField

        private void WriteIndicators()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Player1: ");
            Console.WriteLine(_player1);

            Console.SetCursorPosition(0, 10);
            Console.WriteLine("Player2: ");
            Console.WriteLine(_player2);
        }

        private void WriteField()
        {
            WriteBount();

            for (int i = 0; i < _player1.GetHero().Count; i++)
            {
                _player1.GetHero()[i].Draw(true);
                Console.Write(i);
            }

            for (int i = 0; i < _player2.GetHero().Count; i++)
            {
                _player2.GetHero()[i].Draw(false);
                Console.Write(i);
            }
        }

        private void WriteBount()
        {
            for (int i = 0; i < 80; i++)
            {
                Console.SetCursorPosition(i + 40, 0);
                Console.Write('-');
            }

            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(39, i);
                Console.Write('|');
            }

            for (int i = 0; i < 80; i++)
            {
                Console.SetCursorPosition(i + 40, 19);
                Console.Write('-');
            }

            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(119, i);
                Console.Write('|');
            }
        }

        private void Draw()
        {
            WriteIndicators();

            WriteField();
        }

        #endregion
    }
}
