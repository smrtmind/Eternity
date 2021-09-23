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

            Player player;
            MedicineBag medicineBag = new MedicineBag();

            string playerName = string.Empty, enemyName = string.Empty;

            string sex = string.Empty, ggClass = string.Empty;

            string keyBoardInput = string.Empty, yesNo = string.Empty;

            //while (yesNo.ToLower() != "y")
            //{
            //    yesNo = string.Empty;
            //    playerName = string.Empty;

            //    while (yesNo.ToLower() != "y" && yesNo.ToLower() != "n")
            //    {
            //        Console.Clear();
            //        Print("Do you want to change your name?");
            //        GetYesNo();

            //        Console.ForegroundColor = ConsoleColor.Green;
            //        yesNo = Console.ReadLine();
            //        Console.ResetColor();

            //        if (yesNo.ToLower() == "y")
            //        {
            //            Print("\n");
            //            while (playerName.Length == 0)
            //            {
            //                Print("enter your new name: ");

            //                Console.ForegroundColor = ConsoleColor.Green;
            //                playerName = Console.ReadLine();
            //                Console.ResetColor();
            //            }
            //        }

            //        if (yesNo.ToLower() == "n") playerName = "Sam";
            //    }

            //    Print("\nChoose your character's gender: ");
            //    Print(" [1] ", ConsoleColor.Green);
            //    Print("male\n");
            //    Print(" [2] ".PadLeft(37, ' '), ConsoleColor.Green);
            //    Print("female\n\n");

            //    choice = 0;

            //    while (choice != 1 && choice != 2)
            //    {
            //        Console.Write("choose gender: ".PadLeft(48, ' '));
            //        Console.ForegroundColor = ConsoleColor.Green;
            //        keyBoardInput = Console.ReadLine();
            //        int.TryParse(keyBoardInput, out choice);
            //        Console.ResetColor();

            //        if (choice == 1) sex = "male";
            //        if (choice == 2) sex = "female";
            //    }

            //    Print("\nChoose your character's class: ");
            //    Print("  [1] ", ConsoleColor.Green);
            //    Print("warrior\n");
            //    Print(" [2] ".PadLeft(37, ' '), ConsoleColor.Green);
            //    Print("archer\n");
            //    Print(" [3] ".PadLeft(37, ' '), ConsoleColor.Green);
            //    Print("mage\n\n");

            //    playerClass = 0;

            //    while (playerClass != 1 && playerClass != 2 && playerClass != 3)
            //    {
            //        Console.Write("choose class: ".PadLeft(47, ' '));
            //        Console.ForegroundColor = ConsoleColor.Green;
            //        keyBoardInput = Console.ReadLine();
            //        int.TryParse(keyBoardInput, out playerClass);
            //        Console.ResetColor();

            //        player = new Player(playerClass, playerName);
            //    }

            //    Console.Clear();

            //    Print("".PadLeft(25, '>') + "\n", ConsoleColor.Magenta);
            //    Print("Your character\n", ConsoleColor.DarkYellow);
            //    Print("name:\t");
            //    Print($"{player.Name}\n", ConsoleColor.Green);
            //    Print("gender:\t");
            //    Print($"{sex}\n", ConsoleColor.Green);
            //    Print("class:\t");
            //    Print($"{player.PlayerClass}\n", ConsoleColor.Green);
            //    Print("".PadLeft(25, '<') + "\n\n", ConsoleColor.Magenta);

            //    yesNo = string.Empty;

            //    while (yesNo.ToLower() != "y" && yesNo.ToLower() != "n")
            //    {
            //        Print("Are you ready to start the adventure with this character?");
            //        GetYesNo();

            //        Console.ForegroundColor = ConsoleColor.Green;
            //        yesNo = Console.ReadLine();
            //        Console.ResetColor();
            //    }
            //    Console.Clear();
            //}

            //Console.Clear();

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
            medicineBag.AddPotion(1, amount: 1);
            medicineBag.AddPotion(2, amount: 1);
            medicineBag.AddPotion(3, amount: 1);
            player = new Player(playerType: 3, name: "Oleg");



            

            //battle sectioon
            BattleSection(player, medicineBag);



            Print("You see the shop. Move in to buy aids?");
            GetYesNo();

            Console.ForegroundColor = ConsoleColor.Green;
            yesNo = Console.ReadLine();
            Console.ResetColor();

            int count = 0;
            while (count != 9)
            {
                if (yesNo.ToLower() == "y")
                {
                    Console.WriteLine("You are int the shop.");
                    GetStatus(player);

                    Console.WriteLine("Which aid?");
                    int.TryParse(Console.ReadLine(), out int aid);

                    switch (aid)
                    {
                        case 1:
                            medicineBag.AddPotion(potionType: 1, amount: 1);
                            break;

                        case 2:
                            medicineBag.AddPotion(potionType: 2, amount: 1);
                            break;

                        case 3:
                            medicineBag.AddPotion(potionType: 3, amount: 1);
                            break;
                    }
                }

                count++;
            }


            medicineBag.UsePotion(2);
            medicineBag.UsePotion(1);
            medicineBag.UsePotion(3);

            if (yesNo.ToLower() == "n")
            {

            }
        }

        internal static void GetYesNo()
        {
            Print(" [y] ", ConsoleColor.Green);
            Print("/");
            Print(" [n] ", ConsoleColor.Green);
            Print(": ");
        }
        internal static void GetPressEnter()
        {
            Thread.Sleep(3000);
            Console.WriteLine("\nPress Enter to continue");
            Console.ReadLine();
            Console.Clear();
        }
        internal static void GetStatus(Player player)
        {
            Print("".PadLeft(25, '>') + "\n", ConsoleColor.Magenta);
            Print("Status\n", ConsoleColor.DarkYellow);
            Print("lvl: \t");
            Print($"{player.Lvl}\n", ConsoleColor.Green);
            Print("health:\t");
            Print($"{player.Health}", ConsoleColor.Green);
            Print(" / ");
            Print($"{player.CurrentHealth}\n", ConsoleColor.DarkYellow);
            Print("gold:\t");
            Print($"{player.Gold}\n", ConsoleColor.Green);
            Print("exp:\t");
            Print($"{player.Exp}\n", ConsoleColor.Green);
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
        public static void PrintOptions(int type)
        {
            if (type == 1)
            {
                Print("What are you going to do?");
                Print(" [1] ", ConsoleColor.Green);
                Print("fight\n");
                Print(" [2] ".PadLeft(30, ' '), ConsoleColor.Green);
                Print("heal\n");
                Print(" [3] ".PadLeft(30, ' '), ConsoleColor.Green);
                Print("try to run away\n\n");
            }

            if (type == 2)
            {
                Print("\n");
                Print("Choose the aid:".PadLeft(25, ' '));
                Print(" [1] ", ConsoleColor.Green);
                Print("small\n");
                Print(" [2] ".PadLeft(30, ' '), ConsoleColor.Green);
                Print("medium\n");
                Print(" [3] ".PadLeft(30, ' '), ConsoleColor.Green);
                Print("big\n\n");
            }
        }
        public static void BattleSection(Player player, MedicineBag medicineBag)
        {
            Random random = new Random();
            int choice = 0;
            string yesNo = string.Empty;
            string keyBoardInput = string.Empty;

            while (yesNo.ToLower() != "n")
            {
                yesNo = string.Empty;
                Enemy enemy = new Enemy(random.Next(1, 2));

                //Console.ForegroundColor = ConsoleColor.Blue;
                //GetLoading("".PadLeft(random.Next(35, 115), '|'));
                //Console.ResetColor();

                Print($"\nBut suddenly, you see the enemy. It is a big {enemy.Name}\n\n");

                PrintOptions(1);

                while (true)
                {
                    double playerDamage = player.GenerateDamage();
                    double enemyDamage = enemy.GenerateDamage();

                    Console.Write("choose action: ".PadLeft(41, ' '));
                    Console.ForegroundColor = ConsoleColor.Green;
                    keyBoardInput = Console.ReadLine();
                    int.TryParse(keyBoardInput, out int battleChoice);
                    Console.ResetColor();

                    if (battleChoice == 1)
                    {
                        enemy.CurrentHealth -= playerDamage;

                        if (enemy.CurrentHealth <= 0)
                        {
                            player.Gold += enemy.Gold;
                            player.Exp += enemy.Exp;
                            player.LevelUp(player.Exp);

                            Print($"\n\t{player.Name} deals {playerDamage} damage, {enemy.Name} get fatal damage and has {enemy.CurrentHealth} health\n");
                            Print($"\n\tVictory. You have earned {enemy.Gold} gold and {enemy.Exp} exp\n", ConsoleColor.DarkYellow);

                            GetStatus(player);
                            break;
                        }

                        player.CurrentHealth -= enemyDamage;

                        if (player.CurrentHealth <= 0)
                        {
                            Print($"\n\t{player.Name} deals {playerDamage} damage, {enemy.Name} has {enemy.CurrentHealth} health now\n");
                            Print($"\t{enemy.Name} deals {enemyDamage} damage, {player.Name} get fatal damage and has {player.CurrentHealth} health\n\n");

                            Print("".PadLeft(26, ' '));
                            Print("Y O U   D I E D\n", ConsoleColor.Red, slowText: true);
                            Print("your journey is over :(".PadLeft(45, ' ') + "\n", ConsoleColor.Red);

                            break;
                        }

                        else
                        {
                            Print($"\n\t{player.Name} deals {playerDamage} damage, {enemy.Name} has {enemy.CurrentHealth} health now\n");
                            Print($"\t{enemy.Name} deals {enemyDamage} damage, {player.Name} have {player.CurrentHealth} health now\n\n");
                        }

                        continue;
                    }

                    if (battleChoice == 2)
                    {
                        PrintOptions(2);

                        choice = 0;

                        while (choice != 1 && choice != 2 && choice != 3)
                        {
                            Console.Write("make your choice: ".PadLeft(44, ' '));
                            Console.ForegroundColor = ConsoleColor.Green;
                            keyBoardInput = Console.ReadLine();
                            int.TryParse(keyBoardInput, out choice);
                            Console.ResetColor();
                        }

                        string aid = string.Empty;
                        int amountOfAids = medicineBag.UsePotion(choice);

                        if (amountOfAids > 0)
                        {
                            player.CurrentHealth += medicineBag.HealingPower;

                            if (player.CurrentHealth > player.Health)
                            {
                                player.CurrentHealth = player.Health;
                                Print("\n\tmax health\n\n", ConsoleColor.DarkGreen);
                            }

                            else
                            {
                                Print($"\n\t+{medicineBag.HealingPower} health. {player.Name} have {player.CurrentHealth} now\n\n", ConsoleColor.DarkGreen);
                            }

                            player.CurrentHealth -= enemy.Damage;
                            Print($"\t{enemy.Name} atacked with {enemy.Damage} damage, {player.Name} have {player.CurrentHealth} now\n\n");
                        }

                        else
                        {
                            Print($"\n\tYou don't have {medicineBag.Name} aids\n\n", ConsoleColor.DarkRed);

                            player.CurrentHealth -= enemy.Damage;
                            Print($"\t{enemy.Name} atacked with {enemy.Damage} damage, {player.Name} have {player.CurrentHealth} now\n\n");
                        }
                    }

                    if (battleChoice == 3)
                    {
                        int tryToEscape = random.Next(0, 100);

                        if (tryToEscape > enemy.ChanceToInterruptTheEscape)
                        {
                            player.Gold -= 10;

                            Print("\n\tYou escaped successfully ");
                            Print("-10 ", ConsoleColor.DarkRed);
                            Print("gold", ConsoleColor.DarkYellow);
                            Print(", ");
                            
                            if (player.Gold <= 0) player.Gold = 0;

                            Print($"{player.Gold} ", ConsoleColor.DarkGreen);
                            Print("gold ", ConsoleColor.DarkYellow);
                            Print("remaining\n\n");

                            break;
                        }

                        else if (enemy.ChanceToInterruptTheEscape == 100)
                        {
                            Print($"\n\tyou can't escape from the {enemy.Name}\n", ConsoleColor.DarkRed);
                            CritDamage(enemy);
                            
                        }

                        else
                        {
                            Print("\n\tfailed to escape\n", ConsoleColor.DarkRed);
                            CritDamage(enemy);

                            continue;
                        }
                    }
                }

                while (yesNo.ToLower() != "y" && yesNo.ToLower() != "n")
                {
                    Print("Farm more?");
                    GetYesNo();

                    Console.ForegroundColor = ConsoleColor.Green;
                    yesNo = Console.ReadLine();
                    Console.ResetColor();
                }
                Console.Clear();
            }

            void CritDamage(Enemy enemy)
            {
                int criticalDamageMultiplier = random.Next(2, 4);

                player.CurrentHealth -= enemy.Damage * criticalDamageMultiplier;
                Print($"\n\t{enemy.Name} made a ");
                Print("CRITICAL ", ConsoleColor.Red);
                Print($"attack {enemy.Damage * criticalDamageMultiplier} damage, {player.Name} have {player.CurrentHealth} now\n\n");
            }
        }
    }
}
