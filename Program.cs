using System;
using System.Threading;

namespace myFirstRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.ForegroundColor = ConsoleColor.Cyan;
            //GetTitle("THE DARK STONE\n\n");
            //Console.ResetColor();

            //Thread.Sleep(2000);
            //Console.WriteLine("Press any key");
            //Console.ReadLine();

            //Console.ForegroundColor = ConsoleColor.Blue;
            //GetLoading("".PadLeft(115, '|'));
            //Console.ResetColor();
            //Console.Clear();

            //Console.WriteLine("Hello, traveler. I will call you Sam.\n");

            Random random = new Random();
            Player player = new Player();

            int ggMaxHealth = 0;
            int enemyMaxHealth = 0;
            bool numberIsFound = false;
            int healingPower = 0;
            int remainingAids = 0;

            int exp = 0, gold = 0;
            int smallAid = 1, mediumAid = 0, bigAid = 0;
            int choice = 0;

            int ggClassChoosing = 0;
            string ggName = string.Empty, enemyName = string.Empty;

            string sex = string.Empty, ggClass = string.Empty;

            string keyBoardInput = string.Empty, yesNo = string.Empty, yesNo2 = string.Empty;

            while (yesNo.ToLower() != "y")
            {
                ggName = string.Empty;

                while (true)
                {
                    Console.Clear();
                    Print("Do you want to change your name?");
                    GetYesNo();

                    Console.ForegroundColor = ConsoleColor.Green;
                    yesNo = Console.ReadLine();
                    Console.ResetColor();

                    if (yesNo.ToLower() == "y")
                    {
                        Print("\n");
                        while (ggName.Length == 0)
                        {
                            Print("enter your new name: ");

                            Console.ForegroundColor = ConsoleColor.Green;
                            ggName = Console.ReadLine();
                            Console.ResetColor();
                        }
                        break;
                    }

                    if (yesNo.ToLower() == "n")
                    {
                        ggName = "Sam";
                        break;
                    }

                    else continue;
                }

                Print("\nChoose your character's gender: ");

                Print(" [1] ", ConsoleColor.Green);
                Print("male\n");
                Print(" [2] ".PadLeft(37, ' '), ConsoleColor.Green);
                Print("female\n\n");

                while (choice != 1 || choice != 2)
                {
                    Console.Write("choose gender: ".PadLeft(48, ' '));
                    Console.ForegroundColor = ConsoleColor.Green;
                    keyBoardInput = Console.ReadLine();
                    int.TryParse(keyBoardInput, out choice);
                    Console.ResetColor();

                    if (choice == 1)
                    {
                        sex = "male";
                        break;
                    }

                    if (choice == 2)
                    {
                        sex = "female";
                        break;
                    }

                    else Print("incorrect format".PadLeft(64, ' ') + "\n", ConsoleColor.Red);
                }

                Print("\nChoose your character's class: ");
                Print("  [1] ", ConsoleColor.Green);
                Print("warrior\n");
                Print(" [2] ".PadLeft(37, ' '), ConsoleColor.Green);
                Print("archer\n");
                Print(" [3] ".PadLeft(37, ' '), ConsoleColor.Green);
                Print("mage\n\n");

                //while (ggClassChoosing != 1 || ggClassChoosing != 2 || ggClassChoosing != 3)
                //{
                    Console.Write("choose class: ".PadLeft(47, ' '));
                    Console.ForegroundColor = ConsoleColor.Green;
                    keyBoardInput = Console.ReadLine();
                    int.TryParse(keyBoardInput, out ggClassChoosing);
                    Console.ResetColor();

                    player = new Player(ggClassChoosing, ggName);

                    //if (ggClassChoosing == 1)
                    //{
                    //    player = new Player("warrior", 200, lvlOfPower: 1, ggName);
                    //    break;
                    //}

                    //if (ggClassChoosing == 2)
                    //{
                    //    player = new Player("archer", 160, lvlOfPower: 2, ggName);
                    //    break;
                    //}

                    //if (ggClassChoosing == 3)
                    //{
                    //    player = new Player("mage", 120, lvlOfPower: 3, ggName);
                    //    break;
                    //}

                    //else Print("incorrect format".PadLeft(63, ' ') + "\n", ConsoleColor.Red);
                //}

                Console.Clear();

                Print("".PadLeft(25, '>') + "\n", ConsoleColor.Magenta);
                Print("Your character\n", ConsoleColor.DarkYellow);
                Print("name:\t");
                Print($"{player.Name}\n", ConsoleColor.Green);
                Print("gender:\t");
                Print($"{sex}\n", ConsoleColor.Green);
                Print("class:\t");
                Print($"{player.HeroClass}\n", ConsoleColor.Green);
                Print("".PadLeft(25, '<') + "\n", ConsoleColor.Magenta);

                while (true)
                {
                    Print("\nAre you ready to start the adventure with this character?");
                    GetYesNo();

                    Console.ForegroundColor = ConsoleColor.Green;
                    yesNo = Console.ReadLine();
                    Console.ResetColor();

                    if (yesNo == "y")
                    {
                        Console.Clear();
                        break;
                    }

                    if (yesNo == "n")
                    {
                        Console.Clear();
                        break;
                    }

                    else
                    {
                        Print("incorrect format".PadLeft(86, ' '), ConsoleColor.Red);
                        continue;
                    }
                }
            }

            Console.Clear();

            //Console.WriteLine("The adventure begins");

            //Console.ForegroundColor = ConsoleColor.Blue;
            //GetLoading("".PadLeft(115, '|'));
            //Console.ResetColor();
            //Console.WriteLine();

            //GetPressEnter();

            //Закончил создание персонажа, далее следует геймплей______________________________________________________________________________________________________

            //GetSlowText("\tAmong the many things that video games can do well,\n" +
            //            "is to tell a good story. Sometimes, the story is so good, it  leaves\n" +
            //            "a lasting impact on you, an impact akin to what you might feel after\n" +
            //            "reading a great book, or watching a great movie. Games can offer you\n" +
            //            "the same experience, but it’s honestly waay better, because you  get\n" +
            //            "to play the game and BE the story.\n");

            //GetPressEnter();

            //Console.WriteLine("You starts your way at the small field, full of treis. " +
            //                  "There are a lot of animals. You walk friendly.");

            //GetPressEnter();

            

            do
            {

                int enemyType = random.Next(1, 4);
                Enemy enemy = new Enemy(enemyType);
                enemyMaxHealth = enemy.Health;

                player = new Player(ggClassChoosing, ggName);
                ggMaxHealth = player.MaxHealth;

                //int enemyType = random.Next(1, 4);
                //Enemy enemy = new Enemy(enemyType);
                //enemyMaxHealth = enemy.Health;
                //Enemy enemy = new Enemy(name: "Rat", health: 20, lvlOfPower: 1);

                //Console.ForegroundColor = ConsoleColor.Blue;
                //GetLoading("".PadLeft(random.Next(35, 115), '|'));
                //Console.ResetColor();

                Print($"\nBut suddenly, you see the enemy.It is a big {enemy.Name}\n\n");

                Print("What are you going to do?");
                Print(" [1] ", ConsoleColor.Green);
                Print("fight\n");
                Print(" [2] ".PadLeft(30, ' '), ConsoleColor.Green);
                Print("heal\n");
                Print(" [3] ".PadLeft(30, ' '), ConsoleColor.Green);
                Print("try to run away\n\n");

                while (choice != 1 || choice != 2 || choice != 3)
                {
                    enemy = new Enemy(enemyType, enemyMaxHealth);
                    player = new Player(ggClassChoosing, ggName, ggMaxHealth);

                    Console.Write("choose action: ".PadLeft(41, ' '));
                    Console.ForegroundColor = ConsoleColor.Green;
                    keyBoardInput = Console.ReadLine();
                    int.TryParse(keyBoardInput, out int battleChoice);
                    Console.ResetColor();

                    if (battleChoice == 1)
                    {
                        //if (player.LvlOfPower == 1) ggHit = random.Next(1, 4);
                        //if (player.LvlOfPower == 2) ggHit = random.Next(2, 5);
                        //if (player.LvlOfPower == 3) ggHit = random.Next(3, 6);
                        enemyMaxHealth -= player.Damage;
                        ggMaxHealth -= enemy.Damage;

                        Print($"\n\t{player.Name} atacked with {player.Damage} damage, {enemy.Name} has {enemyMaxHealth} now\n");
                        Print($"\t{enemy.Name} atacked with {enemy.Damage} damage, {player.Name} have {ggMaxHealth} now\n\n");

                        if (enemy.Health <= 0)
                        {
                            Print("Victory. You have earned 5 gold and 15 exp\n\n", ConsoleColor.DarkYellow);

                            gold += 5;
                            exp += 15;

                            GetStatus(ggMaxHealth, ref gold, ref exp);

                            break;
                        }

                        else if (ggMaxHealth <= 0) break;
                        continue;
                    }

                    if (battleChoice == 2)
                    {
                        Print("\n");
                        Print("Choose the aid:".PadLeft(25, ' '));
                        Print(" [1] ", ConsoleColor.Green);
                        Print("small\n");
                        Print(" [2] ".PadLeft(30, ' '), ConsoleColor.Green);
                        Print("medium\n");
                        Print(" [3] ".PadLeft(30, ' '), ConsoleColor.Green);
                        Print("big\n\n");

                        do
                        {
                            numberIsFound = false;

                            while (!numberIsFound)
                            {
                                Console.Write("make your choice: ".PadLeft(44, ' '));
                                Console.ForegroundColor = ConsoleColor.Green;
                                keyBoardInput = Console.ReadLine();
                                numberIsFound = int.TryParse(keyBoardInput, out choice);
                                Console.ResetColor();
                            }

                            string aid = string.Empty;

                            if (choice == 1)
                            {
                                remainingAids = smallAid;
                                healingPower = 15;
                                aid = "small";
                            }

                            else if (choice == 2)
                            {
                                remainingAids = mediumAid;
                                healingPower = 35;
                                aid = "medium";
                            }

                            else if (choice == 3)
                            {
                                remainingAids = bigAid;
                                healingPower = 70;
                                aid = "big";
                            }

                            else Print("incorrect format".PadLeft(60, ' ') + "\n", ConsoleColor.Red);

                            if (remainingAids > 0)
                            {
                                player.CurrentHealth += healingPower;
                                remainingAids--;

                                if (player.CurrentHealth > player.MaxHealth)
                                {
                                    player.CurrentHealth = player.MaxHealth;
                                    Print("\tmax health \n");
                                }
                            }

                            else Print($"\n\tYou don't have {aid} aids\n");

                            enemyMaxHealth -= player.Damage;
                            player.CurrentHealth -= enemy.Damage;

                            Print($"\t{enemy.Name} atacked with {enemy.Damage} damage, {player.Name} have {player.CurrentHealth} now\n\n");
                        }
                        while (choice != 1 && choice != 2 && choice != 3);
                    }

                    if (battleChoice == 3)
                    {
                        Print("You have run away...\n");
                        gold -= 5;

                        if (gold <= 0) gold = 0;

                        break;
                    }

                    else Print("incorrect format".PadLeft(57, ' ') + "\n", ConsoleColor.Red);
                }

                do
                {
                    if (player.CurrentHealth <= 0)
                    {
                        Print("".PadLeft(26, ' '));
                        Print("Y O U   D I E D\n", ConsoleColor.Red, slowText: true);
                        Print("your journey is over :(".PadLeft(45, ' ') + "\n", ConsoleColor.Red);
                        break;
                    }

                    Print("Move forward?");
                    GetYesNo();

                    Console.ForegroundColor = ConsoleColor.Green;
                    yesNo = Console.ReadLine();
                    Console.ResetColor();

                    if (yesNo == "y")
                    {
                        Console.Clear();
                        enemyType = 0;
                        break;
                    }

                    if (yesNo == "n")
                    {
                        Console.Clear();
                        enemyType = 0;
                        break;
                    }

                    else
                    {
                        Print("y - go".PadLeft(32, ' ') + "\n", ConsoleColor.Red);
                        Print("n - farm a little bit more\n".PadLeft(53, ' '), ConsoleColor.Red);
                        continue;
                    }
                }
                while (yesNo.ToLower() != "y" || yesNo.ToLower() != "n");
            }
            while (yesNo.ToLower() != "y");

            //GetLevelUp(ref exp, player.MaxHealth, player.CurrentHealth, player.LvlOfPower, ref ggClassChoosing);

            Print("You see the shop. Move in to buy aids?");
            GetYesNo();
        }

        internal static void GetLevelUp(ref int exp, int maxHealth, int ggHealth, int ggHit, ref int ggClassChoosing)
        {
            Random random = new Random();

            if (exp >= 50 && exp < 100)
            {
                maxHealth += 10;
                ggHealth = maxHealth;

                if (ggClassChoosing == 1) ggHit = random.Next(3, 5);

                if (ggClassChoosing == 2) ggHit = random.Next(4, 6);

                if (ggClassChoosing == 3) ggHit = random.Next(5, 7);
            }

            else if (exp >= 100 && exp < 170)
            {
                maxHealth += 20;
                ggHealth = maxHealth;

                if (ggClassChoosing == 1) ggHit = random.Next(5, 7);

                if (ggClassChoosing == 2) ggHit = random.Next(6, 8);

                if (ggClassChoosing == 3) ggHit = random.Next(7, 9);
            }

            else if (exp >= 170 && exp < 250)
            {
                maxHealth += 30;
                ggHealth = maxHealth;

                if (ggClassChoosing == 1) ggHit = random.Next(7, 9);

                if (ggClassChoosing == 2) ggHit = random.Next(8, 10);

                if (ggClassChoosing == 3) ggHit = random.Next(9, 11);
            }
        }
        internal static void GetYesNo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" [y] ");
            Console.ResetColor();

            Console.Write("/");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" [n] ");
            Console.ResetColor();

            Console.Write(": ");
        }
        internal static void GetPressEnter()
        {
            Thread.Sleep(3000);
            Console.WriteLine("\nPress Enter to continue");
            Console.ReadLine();
            Console.Clear();
        }
        internal static void GetStatus(int ggHealth, ref int gold, ref int exp)
        {
            Print("".PadLeft(25, '>') + "\n", ConsoleColor.Magenta);
            Print("Status\n", ConsoleColor.DarkYellow);
            Print("health:\t");
            Print($"{ggHealth}\n", ConsoleColor.Green);
            Print("exp:\t");
            Print($"{gold}\n", ConsoleColor.Green);
            Print("gold:\t");
            Print($"{exp}\n", ConsoleColor.Green);
            Print("".PadLeft(25, '<') + "\n\n", ConsoleColor.Magenta);
        }
        public static void Print(string text, ConsoleColor color = ConsoleColor.White, bool slowText = false)
        {
            if (slowText)
            {
                char[] letters = text.ToCharArray();

                Console.ForegroundColor = color;

                foreach (char element in letters)
                {
                    Console.Write(element);
                    Thread.Sleep(5);
                }

                Console.ResetColor();
            }

            else
            {
                Console.ForegroundColor = color;
                Console.Write(text);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
