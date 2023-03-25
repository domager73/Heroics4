using Heroics4.Heros;
using System.Numerics;

namespace Heroics4
{
    class HeroManager
    {
        #region Variable

        private PLayer _player1;
        private PLayer _player2;

        Random rnd;

        #endregion

        #region CreateMethods

        public HeroManager()
        {
            _player1 = new PLayer();
            _player1.SetId(1);

            _player2 = new PLayer();
            _player2.SetId(2);
        }
        #endregion

        #region SupportMethods
        private int ChoseKey(char key, List<Hero> heros, int money)
        {
            rnd = new Random();

            Console.WriteLine("Введите координату по X(1..19) и по Y(1..19)");
            int x = Util.InputInt("X: ", 20, 1) * 4;
            int y = Util.InputInt("Y: ", 20, 1);

            switch (key)
            {
                case 'a':
                    if (money >= 30)
                    {
                        heros.Add(new Archer(2, x + 40, y));
                        money -= 30;
                    }
                    break;
                case 'k':
                    if (money >= 20)
                    {
                        heros.Add(new Knight(4, x + 40, y));
                        money -= 20;
                    }
                    break;
                case 'g':
                    if (money >= 15)
                    {
                        heros.Add(new Golem(3, x + 40, y));
                        money -= 15;
                    }
                    break;
            }

            return money;
        }

        private void PLayerChoose(int money, List<Hero> hero, int numHero)
        {
            while (money > 15)
            {
                Console.Clear();

                WriteField();

                Console.SetCursorPosition(0, 0);

                Console.ForegroundColor = ConsoleColor.White;

                SelectMenu();
                int characterSelect = Util.InputInt("Выберите действие: ");
                switch (characterSelect)
                {
                    case 2:
                        Console.Clear();
                        CharacterHero();
                        Console.ReadKey();
                        break;
                    case 1:
                        Console.Clear();
                        WriteField();
                        Console.SetCursorPosition(0, 0);

                        Console.WriteLine($"Money: {money}");
                        Console.WriteLine($"Archer: a(30p)");
                        Console.WriteLine($"Golem: g(15p)");
                        Console.WriteLine($"Khight: k(20p)");

                        char choos2 = Util.InputChar($"Chosse hero {numHero}p: ");
                        money = ChoseKey(choos2, hero, money);
                        break;
                }
            }
        }

        private void CheckDied(int number, PLayer player)
        {
            if (player.GetHero()[number].GetHp() <= 0)
            {
                player.GetHero().RemoveAt(number);
                player.GetHero()[number].SetLive(true);
            }
        }

        private int CalculatonAttackRadius(int num1, int num2)
        {
            int radius;
            int y1 = _player1.GetHero()[num1].GetY();
            int x1 = _player1.GetHero()[num1].GetX() / 4;
            int y2 = _player2.GetHero()[num2].GetY();
            int x2 = _player2.GetHero()[num2].GetX() / 4;

            radius = (int)(Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)));

            return radius;
        }

        private void FightHero(PLayer attackingP, PLayer defendingP)
        {
            int attacking = Util.InputInt("Выберете кем отаковать: ");
            int defending = Util.InputInt("Выберете кого отаковать: ");

            if (_player1.GetHero()[attacking].GetRadius() >= CalculatonAttackRadius(attacking, defending))
            {
                _player1.GetHero()[attacking].Fight(_player2.GetHero()[defending]);

                CheckDied(defending, _player2);

                CheckDied(attacking, _player1);
            }
            else
            {
                Console.WriteLine("Герою нехватило радиуса аттаки");
            }
        }

        private void Winner()
        {
            if (!CheckDied(_player1) && !CheckDied(_player2))
            {
                Console.WriteLine("Ничья");
            }
            else if (CheckDied(_player1))
            {
                Console.WriteLine("Выйграл 1 игрок!!!!!");
            }
            else if (CheckDied(_player2))
            {
                Console.WriteLine("Выйграл 2 игрок!!!!!!!!!!!!!");
            }
        }
        #endregion

        #region Write
        private void CharacterHero()
        {
            Console.WriteLine($"Khignt:\nHp: 16\nDamage: 4\nAttack radius: 4\nArmot: 4\nMoney: 20\n");
            Console.WriteLine($"Archer:\nHp: 10\nDamage: 7\nAttack radius: infinity\nAddDamage: 2\nMoney: 30\n");
            Console.WriteLine($"Golem:\nHp: 15\nDamage: 5\nAttack radius: 3\nAddHealth: 3\nMoney: 15\n");
        }
        private void SelectMenu()
        {
            Console.WriteLine("1: Купить персонажа");
            Console.WriteLine("2: Посмотреть характеристики персонажей");
        }

        private void WriteIndicators()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Player1: ");
            Console.WriteLine(_player1);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("Player2: ");
            Console.WriteLine(_player2);
        }

        private void WriteField()
        {
            WriteBount();

            for (int i = 0; i < _player1.GetHero().Count; i++)
            {
                if (!_player1.GetHero()[i].GetLive())
                {
                    _player1.GetHero()[i].Draw(true);
                    Console.Write(i);
                }
            }

            for (int i = 0; i < _player2.GetHero().Count; i++)
            {
                if (!_player2.GetHero()[i].GetLive())
                {
                    _player2.GetHero()[i].Draw(false);
                    Console.Write(i);
                }
            }
        }

        private void WriteBount()
        {
            for (int i = 0; i < 80; i++)
            {
                Console.SetCursorPosition(i + 40, 0);
                Console.Write('-');
                Console.SetCursorPosition(i + 40, 20);
                Console.Write('-');

                if (i % 16 == 0 && i != 0)
                {
                    Console.SetCursorPosition(i + 40, 0);
                    Console.Write("|");
                }
            }

            for (int i = 0; i < 21; i++)
            {
                Console.SetCursorPosition(39, i);
                Console.Write('|');
                Console.SetCursorPosition(119, i);
                Console.Write('|');

                if (i % 4 == 0)
                {
                    Console.SetCursorPosition(39, i);
                    Console.Write(i);
                }
            }
        }

        #endregion

        #region LogicMethods
        private void ChooseHeroes()
        {
            PLayerChoose(_player1.GetMoney(), _player1.GetHero(), 1);

            PLayerChoose(_player2.GetMoney(), _player2.GetHero(), 2);
        }

        private bool CheckDied(PLayer player)
        {
            for (int i = 0; i < player.GetHero().Count; i++)
            {
                if (!player.GetHero()[i].GetLive())
                {
                    return true;
                }
            }

            return false;
        }

        private void MoveHero(PLayer attackingP, int activePlayer) 
        {
            for (int j = 0; j < 5; j++)
            {
                WriteField();
                ConsoleKey move = Console.ReadKey().Key;

                bool checkMove;
                do
                {
                    checkMove = true;

                    if (move == ConsoleKey.A || move == ConsoleKey.S || move == ConsoleKey.W || move == ConsoleKey.D)
                    {
                        attackingP.GetHero()[activePlayer].Move(move);

                        checkMove = false;

                        Console.Clear();
                    }
                } while (checkMove);
            }
        }

        private void PlayerActions(PLayer attackingP, PLayer defendingP)
        {
            for (int i = 0; i < 2; i++)
            {
                WriteField();
                Console.SetCursorPosition(0, 0);
                int act = Util.InputInt($"Действия: \n1: Ходить\n2: Атаковать\nВыберите действие за {attackingP.GetId()} персонажа: ");

                switch (act)
                {
                    case 1:
                        Console.Clear();

                        WriteField();

                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine($"Игрок под номером {attackingP.GetId()} Ходите");

                        int activePlayer = Util.InputInt("Введите героя каким ходить: ");
                        Console.WriteLine("Ходить на WASD");

                        MoveHero(attackingP, activePlayer);

                        break;

                    case 2:
                        Console.Clear();

                        WriteField();

                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine($"Атакует {attackingP.GetId()} игрок");
                        FightHero(attackingP, defendingP);

                        Console.Clear();
                        break;
                }
            }
        }

        public void Play()
        {
            ChooseHeroes();
            Console.Clear();

            WriteField();
            WriteIndicators();

            Console.SetCursorPosition(80, 10);
            Console.WriteLine("Нажмите enter что бы продолжить");

            Console.ReadLine();
            Console.Clear();

            while (CheckDied(_player1) && CheckDied(_player2))
            {
                WriteField();

                PlayerActions(_player1, _player2);
                if (!CheckDied(_player1) || !CheckDied(_player2)) break;

                PlayerActions(_player2, _player1);
                if (!CheckDied(_player1) || !CheckDied(_player2)) break;

                Console.Clear();
                WriteIndicators();

                Console.WriteLine("Нажмите Enter для продолжения");
                Console.ReadLine();

                Console.Clear();
            }

            Winner();
        }
        #endregion
    }
}