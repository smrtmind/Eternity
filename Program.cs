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
            Location location;
            Boss boss = new Boss();
            Boss boss1 = new Boss(1);
            Boss boss2 = new Boss(2);
            Boss boss3 = new Boss(3);
            Boss finalBoss = new Boss(4);
            Weapon weapon = new Weapon();
            MedicineBag medicineBag = new MedicineBag();

            
            string playerName = string.Empty, enemyName = string.Empty;

            string sex = string.Empty, ggClass = string.Empty;

            string keyBoardInput = string.Empty, yesNo = string.Empty;

            int locationType = 1;
            int changeDirection = 0;

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
            medicineBag.AddPotion(1);
            medicineBag.AddPotion(2);
            medicineBag.AddPotion(3);
            player = new Player(typeOfCharacter: 3, name: "Oleg");
            weapon = new Weapon(3);





            //section of the main gameplay
            while (true)
            {
                //shop
                if (changeDirection == 1)
                {
                    Console.Clear();

                    yesNo = string.Empty;
                    while (yesNo.ToLower() != "n")
                    {
                        PrintOptions(5, player, medicineBag, weapon, boss1, boss2, boss3);

                        int choiceInTheShop = 0;
                        while (choiceInTheShop == 0 || choiceInTheShop > 5)
                        {
                            Console.Write("make your choice: ".PadLeft(44, ' '));
                            Console.ForegroundColor = ConsoleColor.Green;
                            keyBoardInput = Console.ReadLine();
                            int.TryParse(keyBoardInput, out choiceInTheShop);
                            Console.ResetColor();

                            if (keyBoardInput == "<")
                            {
                                Console.Clear();
                                break;
                            }
                        }

                        if (keyBoardInput == "<") break;

                        switch (choiceInTheShop)
                        {
                            case 1: BuyPotion(medicineBag.SmallCost, choiceInTheShop);
                                break;

                            case 2: BuyPotion(medicineBag.MediumCost, choiceInTheShop);
                                break;

                            case 3: BuyPotion(medicineBag.BigCost, choiceInTheShop);
                                break;

                            case 4: BuyWeapon(weapon.Cost1, choiceInTheShop);
                                break;

                            case 5: BuyWeapon(weapon.Cost2, choiceInTheShop);
                                break;
                        }

                        void BuyPotion(int cost, int type)
                        {
                            if (player.Gold >= cost)
                            {
                                player.Gold -= cost;
                                medicineBag.AddPotion(potionType: type);
                            }
                            else Print("not enough gold".PadLeft(41, ' ') + "\n", ConsoleColor.DarkRed);
                        }

                        void BuyWeapon(int cost, int type)
                        {
                            if (player.Gold >= cost)
                            {
                                player.Gold -= cost;
                                if (type == 4)
                                {
                                    weapon.Weapon1Bought = true;
                                    weapon.Weapon2Bought = false;
                                }


                                if (type == 5)
                                {
                                    weapon.Weapon2Bought = true;
                                    weapon.Weapon1Bought = false;
                                }
                            }

                            else Print("not enough gold".PadLeft(41, ' ') + "\n", ConsoleColor.DarkRed);
                        }
                        Console.WriteLine();

                        yesNo = string.Empty;
                        while (yesNo.ToLower() != "y" && yesNo.ToLower() != "n")
                        {
                            Print("anything else?".PadLeft(40, ' '));
                            Print(" [y] ", ConsoleColor.Green);
                            Print("/");
                            Print(" [n]", ConsoleColor.Green);
                            Print(": ");

                            Console.ForegroundColor = ConsoleColor.Green;
                            yesNo = Console.ReadLine();
                            Console.ResetColor();

                            if (yesNo.ToLower() == "y" || yesNo.ToLower() == "n") Console.Clear();
                        }
                    }
                    
                    changeDirection = 2;
                }

                //select between locations
                if (changeDirection == 2)
                {
                    PrintOptions(3, player, medicineBag, weapon, boss1, boss2, boss3);

                    locationType = 0;

                    if (boss1.IsDead && boss2.IsDead && boss3.IsDead)
                    {
                        while (locationType != 1 && locationType != 2 && locationType != 3 && locationType != 4)
                        {
                            Console.Write("make your choice: ".PadLeft(44, ' '));
                            Console.ForegroundColor = ConsoleColor.Green;
                            int.TryParse(Console.ReadLine(), out locationType);
                            Console.ResetColor();
                        }
                    }

                    else
                    {
                        while (locationType != 1 && locationType != 2 && locationType != 3)
                        {
                            Console.Write("make your choice: ".PadLeft(44, ' '));
                            Console.ForegroundColor = ConsoleColor.Green;
                            int.TryParse(Console.ReadLine(), out locationType);
                            Console.ResetColor();
                        }
                    }
                }
                Console.Clear();

                location = new Location(locationType);

                switch (locationType)
                {
                    case 1: boss = boss1;
                        break;

                    case 2: boss = boss2;
                        break;

                    case 3: boss = boss3;
                        break;

                    case 4: boss = finalBoss;
                        break;
                }

                if (locationType == 4)
                {
                    yesNo = string.Empty;
                    while (yesNo.ToLower() != "y" && yesNo.ToLower() != "n")
                    {
                        Print($"Are you ready for final battle?");
                        Print(" [y] ", ConsoleColor.Cyan);
                        Print("/");
                        Print(" [n]", ConsoleColor.Cyan);
                        Print(": ");

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        yesNo = Console.ReadLine();
                        Console.ResetColor();
                    }
                    Console.Clear();

                    if (yesNo.ToLower() == "y")
                    {
                        BossBattle(player, medicineBag, location, weapon, boss, boss1, boss2, boss3);

                        if (boss.CurrentHealth <= 0)
                        {
                            Console.WriteLine("THE END");
                            break;
                        }
                    }

                    if (yesNo.ToLower() == "n")
                    {
                        player.DefeatedEnemies = 0;
                        Console.Clear();
                    }
                }

                else
                {
                    Print($"{location.LocationInfo}\n", ConsoleColor.DarkGreen);
                    BattleSection(player, medicineBag, location, weapon, boss1, boss2, boss3);
                }

                if (player.DefeatedEnemies == 2)
                {
                    if (!boss.IsDead)
                    {
                        Console.WriteLine($"Prepare to battle, the {boss.Name} is coming...");
                        Console.ReadLine();
                        Console.Clear();
                        BossBattle(player, medicineBag, location, weapon, boss, boss1, boss2, boss3);
                    }

                    else
                    {
                        Console.WriteLine($"{boss.Name} is already dead.");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }

                if (player.CurrentHealth <= 0)
                {
                    Print("".PadLeft(26, ' '));
                    Print("Y O U   D I E D\n", ConsoleColor.Red);
                    Print("your journey is over :(".PadLeft(45, ' ') + "\n", ConsoleColor.Red);
                    break;
                }

                PrintOptions(4, player, medicineBag, weapon, boss1, boss2, boss3);

                changeDirection = 0;
                while (changeDirection == 0 || changeDirection > 3)
                {
                    Console.Write("make your choice: ".PadLeft(32, ' '));
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    int.TryParse(Console.ReadLine(), out changeDirection);
                    Console.ResetColor();

                    //show status information
                    if (changeDirection == 3)
                    {
                        GetStatus(player, weapon);
                        changeDirection = 0;
                        continue;
                    }
                }

                Console.Clear();
            }
        }

        internal static void GetPressEnter()
        {
            Thread.Sleep(3000);
            Console.WriteLine("\nPress Enter to continue");
            Console.ReadLine();
            Console.Clear();
        }
        internal static void GetStatus(Player player, Weapon weapon)
        {
            if (!weapon.Weapon1Bought && !weapon.Weapon2Bought)
            {
                Print("\n");
                Print("".PadLeft(30, '>') + "\n", ConsoleColor.Magenta);
                MainStats();
                Print("".PadLeft(30, '<') + "\n\n", ConsoleColor.Magenta);
            }

            if (weapon.Weapon1Bought || weapon.Weapon2Bought)
            {
                Print("\n");
                Print("".PadLeft(30, '>') + "\n", ConsoleColor.Magenta);
                MainStats();

                if (weapon.Weapon1Bought)
                {
                    Print(" weapon:     ");
                    Print($"{weapon.Weapon1}\n", ConsoleColor.Green);
                }
                if (weapon.Weapon2Bought)
                {
                    Print(" weapon:     ");
                    Print($"{weapon.Weapon2}\n", ConsoleColor.Green);
                }

                Print("".PadLeft(30, '<') + "\n\n", ConsoleColor.Magenta);
            }

            void MainStats()
            {
                Print($" {player.Name}\n", ConsoleColor.DarkYellow);
                Print(" class:      ");
                Print($"{player.PlayerClass}\n", ConsoleColor.Green);
                Print(" lvl:        ");
                Print($"{player.Lvl}\n", ConsoleColor.Green);
                Print(" health:     ");
                Print($"{player.Health}".PadLeft(1, ' '), ConsoleColor.Green);
                Print(" / ");
                Print($"{player.CurrentHealth}\n", ConsoleColor.DarkYellow);
                Print(" gold:       ");
                Print($"{player.Gold}\n", ConsoleColor.Green);
                Print(" exp:        ");
                Print($"{player.Exp}\n", ConsoleColor.Green);
            }
            
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
        public static void PrintOptions(int type, Player player, MedicineBag medicineBag, Weapon weapon, Boss boss1, Boss boss2, Boss boss3)
        {
            if (type == 1)
            {
                Print("What are you going to do?");
                Print(" [1] ", ConsoleColor.Green);
                Print("attack\n");
                Print(" [2] ".PadLeft(30, ' '), ConsoleColor.Green);
                Print("auto attack\n");
                Print(" [3] ".PadLeft(30, ' '), ConsoleColor.Green);
                Print("heal\n");
                Print(" [4] ".PadLeft(30, ' '), ConsoleColor.Green);
                Print("run away\n\n");
            }

            if (type == 2)
            {
                Print("\n");
                Print("Choose a potion:".PadLeft(25, ' '));
                Print(" [1] ", ConsoleColor.DarkYellow);
                Print($"small\t");
                Print($"{medicineBag.SmallAmount}\n", ConsoleColor.DarkYellow);
                Print(" [2] ".PadLeft(30, ' '), ConsoleColor.DarkYellow);
                Print($"medium\t");
                Print($"{medicineBag.MediumAmount}\n", ConsoleColor.DarkYellow);
                Print(" [3] ".PadLeft(30, ' '), ConsoleColor.DarkYellow);
                Print($"big\t");
                Print($"{medicineBag.BigAmount}\n\n", ConsoleColor.DarkYellow);
                Print(" [<] ".PadLeft(30, ' '), ConsoleColor.DarkYellow);
                Print($"back\n\n");
            }

            if (type == 3)
            {
                if (boss1.IsDead && boss2.IsDead && boss3.IsDead)
                {
                    Print("Where do you want to go? ");
                    Print(" [1] ", ConsoleColor.Green);
                    Print("Dark forest\n");
                    Print(" [2] ".PadLeft(30, ' '), ConsoleColor.Green);
                    Print("Caves\n");
                    Print(" [3] ".PadLeft(30, ' '), ConsoleColor.Green);
                    Print("Volcano\n");
                    Print(" [4] ".PadLeft(30, ' '), ConsoleColor.Green);
                    Print("Lair of true evil\n\n", ConsoleColor.DarkRed);
                }

                else
                {
                    Print("Where do you want to go? ");
                    Print(" [1] ", ConsoleColor.Green);
                    Print("Dark forest\n");
                    Print(" [2] ".PadLeft(30, ' '), ConsoleColor.Green);
                    Print("Caves\n");
                    Print(" [3] ".PadLeft(30, ' '), ConsoleColor.Green);
                    Print("Volcano\n\n");
                }
            }

            if (type == 4)
            {
                Print("What is next?");
                Print(" [1] ", ConsoleColor.Cyan);
                Print("go to the shop\n");
                Print(" [2] ".PadLeft(18, ' '), ConsoleColor.Cyan);
                Print("change location\n");
                Print(" [3] ".PadLeft(18, ' '), ConsoleColor.Cyan);
                Print("show stats\n\n");
            }

            if (type == 5)
            {
                Print("You are in the shop.\nWhat do you want to buy? ");
                Print(" [1] ", ConsoleColor.Green);
                Print("small healing potion\t");
                Print($"{medicineBag.SmallCost} gold", ConsoleColor.DarkYellow);
                Print("  / ");
                Print($"you have {medicineBag.SmallAmount}\n", ConsoleColor.Cyan);
                Print(" [2] ".PadLeft(30, ' '), ConsoleColor.Green);
                Print("medium healing potion\t");
                Print($"{medicineBag.MediumCost} gold", ConsoleColor.DarkYellow);
                Print("  / ");
                Print($"you have {medicineBag.MediumAmount}\n", ConsoleColor.Cyan);
                Print(" [3] ".PadLeft(30, ' '), ConsoleColor.Green);
                Print("big healing potion\t");
                Print($"{medicineBag.BigCost} gold", ConsoleColor.DarkYellow);
                Print(" / ");
                Print($"you have {medicineBag.BigAmount}\n\n", ConsoleColor.Cyan);

                Print(" [4] ".PadLeft(30, ' '), ConsoleColor.Green);
                Print($"{weapon.Weapon1}\t", ConsoleColor.DarkCyan);
                Print($"+{weapon.Damage1} dmg\t", ConsoleColor.DarkRed);
                Print($"{weapon.Cost1} gold\n", ConsoleColor.DarkYellow);
                Print(" [5] ".PadLeft(30, ' '), ConsoleColor.Green);
                Print($"{weapon.Weapon2}\t", ConsoleColor.DarkCyan);
                Print($"+{weapon.Damage2} dmg\t", ConsoleColor.DarkRed);
                Print($"{weapon.Cost2} gold\n\n", ConsoleColor.DarkYellow);

                Print(" [<] ".PadLeft(30, ' '), ConsoleColor.Green);
                Print($"exit");
                Print($"\t\t\t{player.Gold} ", ConsoleColor.Green);
                Print("gold ", ConsoleColor.DarkYellow);
                Print("in your bag\n\n");
            }
        }
        public static void BattleSection(Player player, MedicineBag medicineBag, Location location, Weapon weapon, Boss boss1, Boss boss2, Boss boss3)
        {
            player.DefeatedEnemies = 0;

            string yesNo = string.Empty;
            while (yesNo.ToLower() != "n" && player.DefeatedEnemies != 2)
            {
                Print($"Location: {location.ShortTitle}\n", ConsoleColor.DarkCyan);

                Random random = new Random();
                Enemy enemy = location.CreateEnemy();
                int choice = 0;
                
                string keyBoardInput = string.Empty;

                yesNo = string.Empty;

                //Console.ForegroundColor = ConsoleColor.Blue;
                //GetLoading("".PadLeft(random.Next(35, 115), '|'));
                //Console.ResetColor();

                Print(EntryBattlePhrase(enemy));

                PrintOptions(1, player, medicineBag, weapon, boss1, boss2, boss3);

                while (true)
                {
                    double playerDamage = player.GenerateDamage(weapon);
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
                            player.DefeatedEnemies++;
                            player.Gold += enemy.Gold;
                            player.Exp += enemy.Exp;
                            player.LevelUp(player.Exp);

                            Print($"\n\t{player.Name} deals {playerDamage} damage, {enemy.Name} get");
                            Print($" fatal ", ConsoleColor.DarkRed);
                            Print($"damage and has {enemy.CurrentHealth} health\n");
                            Print($"\n\tVICTORY. You have earned {enemy.Gold} gold and {enemy.Exp} exp\n", ConsoleColor.DarkYellow);

                            GetStatus(player, weapon);
                            break;
                        }

                        player.CurrentHealth -= enemyDamage;

                        if (player.CurrentHealth <= 0)
                        {
                            Print($"\n\t{player.Name} deals {playerDamage} damage, {enemy.Name} has {enemy.CurrentHealth} health now\n");
                            Print($"\t{enemy.Name} deals {enemyDamage} damage, {player.Name} get");
                            Print($" fatal ", ConsoleColor.DarkRed);
                            Print($"damage and has {player.CurrentHealth} health\n\n");

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
                        while (player.CurrentHealth > 0 || enemy.CurrentHealth > 0)
                        {
                            playerDamage = player.GenerateDamage(weapon);
                            enemyDamage = enemy.GenerateDamage();

                            enemy.CurrentHealth -= playerDamage;

                            if (enemy.CurrentHealth <= 0)
                            {
                                player.DefeatedEnemies++;
                                player.Gold += enemy.Gold;
                                player.Exp += enemy.Exp;
                                player.LevelUp(player.Exp);

                                Print($"\n\t{player.Name} deals {playerDamage} damage, {enemy.Name} get");
                                Print($" fatal ", ConsoleColor.DarkRed);
                                Print($"damage and has {enemy.CurrentHealth} health\n");
                                Print($"\n\tVICTORY. You have earned {enemy.Gold} gold and {enemy.Exp} exp\n", ConsoleColor.DarkYellow);

                                GetStatus(player, weapon);
                                break;
                            }

                            player.CurrentHealth -= enemyDamage;

                            if (player.CurrentHealth <= 0)
                            {
                                Print($"\n\t{player.Name} deals {playerDamage} damage, {enemy.Name} has {enemy.CurrentHealth} health now\n");
                                Print($"\t{enemy.Name} deals {enemyDamage} damage, {player.Name} get");
                                Print($" fatal ", ConsoleColor.DarkRed);
                                Print($"damage and has {player.CurrentHealth} health\n\n");

                                break;
                            }

                            else
                            {
                                Print($"\n\t{player.Name} deals {playerDamage} damage, {enemy.Name} has {enemy.CurrentHealth} health now\n");
                                Print($"\t{enemy.Name} deals {enemyDamage} damage, {player.Name} have {player.CurrentHealth} health now\n\n");
                            }

                            Thread.Sleep(500);
                        }

                        break;
                    }

                    if (battleChoice == 3)
                    {
                        PrintOptions(2, player, medicineBag, weapon, boss1, boss2, boss3);

                        choice = 0;

                        while (choice != 1 && choice != 2 && choice != 3)
                        {
                            Console.Write("make your choice: ".PadLeft(44, ' '));
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            keyBoardInput = Console.ReadLine();
                            int.TryParse(keyBoardInput, out choice);
                            Console.ResetColor();

                            if (keyBoardInput == "<") break;
                        }

                        if (choice == 1 || choice == 2 || choice == 3)
                        {
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

                                if (player.CurrentHealth <= 0)
                                {
                                    Print($"\t{enemy.Name} deals {enemyDamage} damage, {player.Name} get");
                                    Print($" fatal ", ConsoleColor.DarkRed);
                                    Print($"damage and has {player.CurrentHealth} health\n\n");

                                    break;
                                }

                                else Print($"\t{enemy.Name} deals {enemyDamage} damage, {player.Name} have {player.CurrentHealth} health now\n\n");
                            }

                            else
                            {
                                Print($"\n\tYou don't have {medicineBag.Name}\n\n", ConsoleColor.DarkRed);

                                player.CurrentHealth -= enemy.Damage;

                                if (player.CurrentHealth <= 0)
                                {
                                    Print($"\t{enemy.Name} deals {enemyDamage} damage, {player.Name} get");
                                    Print($" fatal ", ConsoleColor.DarkRed);
                                    Print($"damage and has {player.CurrentHealth} health\n\n");

                                    break;
                                }

                                else Print($"\t{enemy.Name} deals {enemyDamage} damage, {player.Name} have {player.CurrentHealth} health now\n\n");
                            }
                        }

                        if (keyBoardInput == "<")
                        {
                            Print("\n");
                            continue;
                        }
                    }

                    if (battleChoice == 4)
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

                            if (player.CurrentHealth <= 0) break;

                        }

                        else
                        {
                            Print("\n\tfailed to escape\n", ConsoleColor.DarkRed);
                            CritDamage(enemy);

                            if (player.CurrentHealth <= 0) break;
                            else continue;
                        }
                    }
                }

                if (player.CurrentHealth <= 0) break;
                if (player.DefeatedEnemies == 2) break;

                yesNo = string.Empty;
                while (yesNo.ToLower() != "y" && yesNo.ToLower() != "n")
                {
                    Print($"Farm more at the {location.ShortTitle}?");
                    Print(" [y] ", ConsoleColor.Cyan);
                    Print("/");
                    Print(" [n]", ConsoleColor.Cyan);
                    Print(": ");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    yesNo = Console.ReadLine();
                    Console.ResetColor();

                    if (yesNo.ToLower() == "y" || yesNo.ToLower() == "n") Console.Clear();
                }

                void CritDamage(Enemy enemy)
                {
                    int criticalDamageMultiplier = random.Next(2, 4);

                    player.CurrentHealth -= enemy.Damage * criticalDamageMultiplier;

                    if (player.CurrentHealth <= 0)
                    {
                        Print($"\n\t{enemy.Name} made a ");
                        Print("CRITICAL ", ConsoleColor.Red);
                        Print($"attack {enemy.Damage * criticalDamageMultiplier} damage, {player.Name} get");
                        Print($" fatal ", ConsoleColor.DarkRed);
                        Print($"damage and has {player.CurrentHealth} health\n\n");
                    }

                    else
                    {
                        Print($"\n\t{enemy.Name} made a ");
                        Print("CRITICAL ", ConsoleColor.Red);
                        Print($"attack {enemy.Damage * criticalDamageMultiplier} damage, {player.Name} have {player.CurrentHealth} now\n\n");
                    }
                }
            }
        }
        public static void BossBattle(Player player, MedicineBag medicineBag, Location location, Weapon weapon, Boss boss, Boss boss1, Boss boss2, Boss boss3)
        {
            while (true)
            {
                Print($"Location: {location.ShortTitle}\n\n", ConsoleColor.DarkCyan);
                Print($"{boss.Name}\n\n");

                Random random = new Random();
                int choice = 0;

                string keyBoardInput = string.Empty;

                //Console.ForegroundColor = ConsoleColor.Blue;
                //GetLoading("".PadLeft(random.Next(35, 115), '|'));
                //Console.ResetColor();

                PrintOptions(1, player, medicineBag, weapon, boss1, boss2, boss3);

                while (true)
                {
                    double playerDamage = player.GenerateDamage(weapon);
                    double bossDamage = boss.GenerateDamage();

                    Console.Write("choose action: ".PadLeft(41, ' '));
                    Console.ForegroundColor = ConsoleColor.Green;
                    keyBoardInput = Console.ReadLine();
                    int.TryParse(keyBoardInput, out int battleChoice);
                    Console.ResetColor();

                    if (battleChoice == 1)
                    {
                        boss.CurrentHealth -= playerDamage;

                        if (boss.CurrentHealth <= 0)
                        {
                            boss.IsDead = true;
                            player.Gold += boss.Gold;
                            player.Exp += boss.Exp;
                            player.LevelUp(player.Exp);

                            Print($"\n\t{player.Name} deals {playerDamage} damage, {boss.Name} get");
                            Print($" fatal ", ConsoleColor.DarkRed);
                            Print($"damage and has {boss.CurrentHealth} health\n");
                            Print($"\n\tVICTORY. You have earned {boss.Gold} gold and {boss.Exp} exp\n", ConsoleColor.DarkYellow);

                            GetStatus(player, weapon);
                            break;
                        }

                        player.CurrentHealth -= bossDamage;

                        if (player.CurrentHealth <= 0)
                        {
                            Print($"\n\t{player.Name} deals {playerDamage} damage, {boss.Name} has {boss.CurrentHealth} health now\n");
                            Print($"\t{boss.Name} deals {bossDamage} damage, {player.Name} get");
                            Print($" fatal ", ConsoleColor.DarkRed);
                            Print($"damage and has {player.CurrentHealth} health\n\n");

                            break;
                        }

                        else
                        {
                            Print($"\n\t{player.Name} deals {playerDamage} damage, {boss.Name} has {boss.CurrentHealth} health now\n");
                            Print($"\t{boss.Name} deals {bossDamage} damage, {player.Name} have {player.CurrentHealth} health now\n\n");
                        }

                        continue;
                    }

                    if (battleChoice == 2)
                    {
                        while (player.CurrentHealth > 0 || boss.CurrentHealth > 0)
                        {
                            playerDamage = player.GenerateDamage(weapon);
                            bossDamage = boss.GenerateDamage();

                            boss.CurrentHealth -= playerDamage;

                            if (boss.CurrentHealth <= 0)
                            {
                                boss.IsDead = true;
                                player.Gold += boss.Gold;
                                player.Exp += boss.Exp;
                                player.LevelUp(player.Exp);

                                Print($"\n\t{player.Name} deals {playerDamage} damage, {boss.Name} get");
                                Print($" fatal ", ConsoleColor.DarkRed);
                                Print($"damage and has {boss.CurrentHealth} health\n");
                                Print($"\n\tVICTORY. You have earned {boss.Gold} gold and {boss.Exp} exp\n", ConsoleColor.DarkYellow);

                                GetStatus(player, weapon);
                                break;
                            }

                            player.CurrentHealth -= bossDamage;

                            if (player.CurrentHealth <= 0)
                            {
                                Print($"\n\t{player.Name} deals {playerDamage} damage, {boss.Name} has {boss.CurrentHealth} health now\n");
                                Print($"\t{boss.Name} deals {bossDamage} damage, {player.Name} get");
                                Print($" fatal ", ConsoleColor.DarkRed);
                                Print($"damage and has {player.CurrentHealth} health\n\n");

                                break;
                            }

                            else
                            {
                                Print($"\n\t{player.Name} deals {playerDamage} damage, {boss.Name} has {boss.CurrentHealth} health now\n");
                                Print($"\t{boss.Name} deals {bossDamage} damage, {player.Name} have {player.CurrentHealth} health now\n\n");
                            }

                            Thread.Sleep(500);
                        }

                        break;
                    }

                    if (battleChoice == 3)
                    {
                        PrintOptions(2, player, medicineBag, weapon, boss1, boss2, boss3);

                        choice = 0;

                        while (choice != 1 && choice != 2 && choice != 3)
                        {
                            Console.Write("make your choice: ".PadLeft(44, ' '));
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            keyBoardInput = Console.ReadLine();
                            int.TryParse(keyBoardInput, out choice);
                            Console.ResetColor();

                            if (keyBoardInput == "<") break;
                        }

                        if (choice == 1 || choice == 2 || choice == 3)
                        {
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

                                player.CurrentHealth -= boss.Damage;

                                if (player.CurrentHealth <= 0)
                                {
                                    Print($"\t{boss.Name} deals {bossDamage} damage, {player.Name} get");
                                    Print($" fatal ", ConsoleColor.DarkRed);
                                    Print($"damage and has {player.CurrentHealth} health\n\n");

                                    break;
                                }

                                else Print($"\t{boss.Name} deals {bossDamage} damage, {player.Name} have {player.CurrentHealth} health now\n\n");
                            }

                            else
                            {
                                Print($"\n\tYou don't have {medicineBag.Name}\n\n", ConsoleColor.DarkRed);

                                player.CurrentHealth -= boss.Damage;

                                if (player.CurrentHealth <= 0)
                                {
                                    Print($"\t{boss.Name} deals {bossDamage} damage, {player.Name} get");
                                    Print($" fatal ", ConsoleColor.DarkRed);
                                    Print($"damage and has {player.CurrentHealth} health\n\n");

                                    break;
                                }

                                else Print($"\t{boss.Name} deals {bossDamage} damage, {player.Name} have {player.CurrentHealth} health now\n\n");
                            }
                        }

                        if (keyBoardInput == "<")
                        {
                            Print("\n");
                            continue;
                        }
                    }

                    if (battleChoice == 4)
                    {
                        int tryToEscape = random.Next(0, 100);

                        if (tryToEscape > boss.ChanceToInterruptTheEscape)
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

                        else if (boss.ChanceToInterruptTheEscape == 100)
                        {
                            Print($"\n\tyou can't escape from the {boss.Name}\n", ConsoleColor.DarkRed);
                            CritDamage(boss);

                            if (player.CurrentHealth <= 0) break;

                        }

                        else
                        {
                            Print("\n\tfailed to escape\n", ConsoleColor.DarkRed);
                            CritDamage(boss);

                            if (player.CurrentHealth <= 0) break;
                            else continue;
                        }
                    }
                }

                if (player.CurrentHealth <= 0) break;
                if (boss.CurrentHealth <= 0) break;

                void CritDamage(Boss boss)
                {
                    int criticalDamageMultiplier = random.Next(2, 4);

                    player.CurrentHealth -= boss.Damage * criticalDamageMultiplier;

                    if (player.CurrentHealth <= 0)
                    {
                        Print($"\n\t{boss.Name} made a ");
                        Print("CRITICAL ", ConsoleColor.Red);
                        Print($"attack {boss.Damage * criticalDamageMultiplier} damage, {player.Name} get");
                        Print($" fatal ", ConsoleColor.DarkRed);
                        Print($"damage and has {player.CurrentHealth} health\n\n");
                    }

                    else
                    {
                        Print($"\n\t{boss.Name} made a ");
                        Print("CRITICAL ", ConsoleColor.Red);
                        Print($"attack {boss.Damage * criticalDamageMultiplier} damage, {player.Name} have {player.CurrentHealth} now\n\n");
                    }
                }
            }
        }
        public static string EntryBattlePhrase(Enemy enemy)
        {
            Random random = new Random();

            string[] entryPhrase =
            {
                $"\nBut suddenly, you see the enemy. It is {enemy.Name}.\n\n",
                $"\nUnexpectedly, {enemy.Name} jumps out of the tree.\n\n",
                $"\nYou notice {enemy.Name} nearby, it's fast approaching.\n\n",
                $"\nAn evil {enemy.Name} comes around the corner and takes you by surprise.\n\n",
                $"\nYou see {enemy.Name} on the road, most likely it cannot be bypassed.\n\n",
                $"\n{enemy.Name} slowly comes out from the darkness.\n\n",
                $"\nEverything went well, but now {enemy.Name} is blocking your path.\n\n",
                $"\nQuietly sneaking up on you, {enemy.Name} is going to attack.\n\n",
                $"\nLeaving almost no chance to escape, {enemy.Name} shows its evil grin.\n\n",
                $"\nYou meet the gaze of {enemy.Name}, it looks at you, you look at him.\n\n"
            };

            return entryPhrase[random.Next(0, 10)];
        }
    }
}
