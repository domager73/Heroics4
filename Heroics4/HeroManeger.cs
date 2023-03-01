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
                if (!_hero[i].GetLive())
                {
                    str = str + $"{i}: hp:{_hero[i].GetHp()}, damage:{_hero[i].GetDamage()}\n";
                }
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

        #region SupportMethods

        private int InputInt(string msg)
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

        private char InputString(string msg)
        {
            bool inputReault;
            char str;

            List<char> list = new List<char>(3) { 'a', 'k', 'g' };

            Console.Write(msg);

            do
            {
                inputReault = char.TryParse(Console.ReadLine(), out str);

                if (!list.Contains(str))
                {
                    inputReault = false;
                }
            } while (!inputReault);


            return str;
        }

        private int ChoseKey(char key, List<Hero> heros, int money)
        {
            rnd = new Random();

            Console.WriteLine("Введите координату по X(0..79) и по Y(0..19)");
            int x = InputInt("X: ");
            int y = InputInt("Y: ");

            switch (key)
            {
                case 'a':
                    heros.Add(new Archer(rnd.Next(1, 3 + 1), x + 40, y));
                    money -= 30;
                    break;
                case 'k':
                    heros.Add(new Knight(rnd.Next(1, 4 + 1), x + 40, y));
                    money -= 20;
                    break;
                case 'g':
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
                Console.WriteLine("Archer: A(30p)\nGolem: G(20p)\nKhight: K(15)\n");

                char choos2 = InputString($"Chosse hero {numHero}p: ");

                money = ChoseKey(choos2, hero, money);
            }
        }

        private void CheckDied(int number, bool whichPl)
        {
            if (whichPl)
            {
                if (_player1.GetHero()[number].GetHp() <= 0)
                {
                    _player1.GetHero().RemoveAt(number);
                    _player1.GetHero()[number].SetLive(true);
                }
            }
            else
            {
                if (_player2.GetHero()[number].GetHp() <= 0)
                {
                    _player2.GetHero().RemoveAt(number);
                    _player2.GetHero()[number].SetLive(true);
                }
            }
        }

        private int CalculatonAttackRadius(int num1, int num2)
        {
            int radius;
            int y1 = _player1.GetHero()[num1].GetY();
            int x1 = _player1.GetHero()[num1].GetX() / 4;
            int y2 = _player2.GetHero()[num2].GetY();
            int x2 = _player2.GetHero()[num2].GetX() / 4;

            radius = Convert.ToInt32(Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)));

            return radius;
        }

        private void FightHero(bool numPlayer)
        {
            int attacking = InputInt("Выберете кем отаковать: ");
            int defending = InputInt("Выберете кого отаковать: ");

            if (numPlayer)
            {
                if (_player1.GetHero()[attacking].GetRadius() >= CalculatonAttackRadius(attacking, defending))
                {
                    _player1.GetHero()[attacking].Fight(_player2.GetHero()[defending]);

                    CheckDied(defending, false);

                    CheckDied(attacking, true);
                }
                else
                {
                    Console.WriteLine("Герою из команды 1 нехватило аттаки");
                }
            }
            else
            {
                if (_player2.GetHero()[attacking].GetRadius() >= CalculatonAttackRadius(attacking, defending) && !numPlayer)
                {
                    _player2.GetHero()[attacking].Fight(_player1.GetHero()[defending]);

                    CheckDied(attacking, false);

                    CheckDied(defending, true);
                }
                else
                {
                    Console.WriteLine("Герою из команды 2 нехватило аттаки");
                }
            }
        }

        private void Vinner()
        {
            if (!CheckDied(_player1) && !CheckDied(_player2))
            {
                Console.WriteLine("Ничья");
            }
            else if (CheckDied(_player1))
            {
                Console.WriteLine("ВЫйграл 1 игрок!!!!!");
            }
            else if (CheckDied(_player2))
            {
                Console.WriteLine("ВЫйграл 2 игрок!!!!!!!!!!!!!");
            }
        }
        #endregion

        #region WriteField

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
                Console.SetCursorPosition(i + 40, 19);
                Console.Write('-');
            }

            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(39, i);
                Console.Write('|');
                Console.SetCursorPosition(119, i);
                Console.Write('|');
            }
        }

        #endregion

        #region LogicMethods
        private void ChoosHeroes()
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

        private void PlayerActions(PLayer player, int num) 
        {
            bool check = num == 1;

            for(int i = 0; i < 2; i++) 
            {
                WriteField();
                Console.SetCursorPosition(0, 0);
                int act = InputInt($"Действия: \n1: Ходить\n2: Атаковать\nВыберите действие за {num} персонажа: ");

                switch (act) 
                {
                    case 1:
                        Console.Clear();

                        WriteField();

                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine($"Игрок под номером {num} Ходите");

                        int activePlayer = InputInt("Введите номер героя каким вы будете ходить: ");

                        for(int j = 0; j < 5; j++)
                        {
                            WriteField();
                            ConsoleKey move = Console.ReadKey().Key;

                            player.GetHero()[activePlayer].Move(move);

                            Console.Clear();
                        }
                        break;

                    case 2:
                        Console.Clear();

                        WriteField();

                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine($"Атакует {num} игрок");
                        FightHero(check);

                        Console.Clear();
                        break;
                }
            }
        }

        public void Play()
        {
            ChoosHeroes();
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

                PlayerActions(_player1, 1);
                Console.Clear();
                if (CheckDied(_player1) && CheckDied(_player2)) break;

                PlayerActions(_player2, 2);
                Console.Clear();
                if (CheckDied(_player1) && CheckDied(_player2)) break;

                Console.Clear();
                WriteIndicators();

                Console.WriteLine("Нажмите Enter для продолжения");
                Console.ReadLine();

                Console.Clear();
            }

            Vinner();
        }
        #endregion
    }
}
