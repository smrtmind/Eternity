using System;
using System.Threading;

namespace myFirstRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            MedicineBag medicineBag = new MedicineBag();
            Player player = new Player();
            Weapon weapon = new Weapon();
            Boss boss1 = new Boss(1);
            Boss boss2 = new Boss(2);
            Boss boss3 = new Boss(3);
            Boss boss4 = new Boss(4);
            Boss boss = new Boss();
            Location location;

            string keyBoardInput = string.Empty;
            string playerName = string.Empty;
            string yesNo = string.Empty;
            string sex = string.Empty;

            int changeDirection = 0;
            int locationType = 1;
            int playerClass = 0;
            int choice = 0;

            PrintGameTitle();
            GetPressEnter();

            RainbowLoading();
            //Print("".PadLeft(Console.WindowWidth - 5, '|'), ConsoleColor.Blue, slowText: true);
            Console.Clear();

            Print("Hello, traveler. I can't remember your name. Can you help me with this?\n\n", ConsoleColor.DarkYellow);
            Thread.Sleep(4000);

            while (yesNo.ToLower() != "y")
            {
                yesNo = string.Empty;
                playerName = string.Empty;

                Print("Enter your name or press ENTER: ");

                Console.ForegroundColor = ConsoleColor.Green;
                keyBoardInput = Console.ReadLine();
                Console.ResetColor();

                //your name
                if (keyBoardInput.Length > 0) playerName = keyBoardInput;
                //default name
                else playerName = "Sam";

                //selection of player's gender
                PrintOptions(8, player, medicineBag, weapon, boss1, boss2, boss3);

                choice = 0;

                //gender of your character
                while (choice != 1 && choice != 2)
                {
                    Print("choose gender: ".PadLeft(47, ' '));
                    Console.ForegroundColor = ConsoleColor.Green;
                    keyBoardInput = Console.ReadLine();
                    int.TryParse(keyBoardInput, out choice);
                    Console.ResetColor();

                    if (choice == 1) sex = "male";
                    if (choice == 2) sex = "female";
                }

                //selection of the player claa before start of the game
                PrintOptions(6, player, medicineBag, weapon, boss1, boss2, boss3);

                playerClass = 0;

                while (playerClass != 1 && playerClass != 2 && playerClass != 3)
                {
                    Print("choose class: ".PadLeft(46, ' '));
                    Console.ForegroundColor = ConsoleColor.Green;
                    keyBoardInput = Console.ReadLine();
                    int.TryParse(keyBoardInput, out playerClass);
                    Console.ResetColor();
                }
                Console.Clear();

                //creating player and weapon according to collected data
                player = new Player(playerClass, playerName, sex);
                weapon = new Weapon(playerClass);

                //card of player before start of the game
                PrintOptions(7, player, medicineBag, weapon, boss1, boss2, boss3);

                yesNo = string.Empty;
                while (yesNo.ToLower() != "y" && yesNo.ToLower() != "n")
                {
                    Print("Are you ready to start the adventure with this character?");
                    Print(" [y] ", ConsoleColor.Green);
                    Print("/");
                    Print(" [n]", ConsoleColor.Green);
                    Print(": ");

                    Console.ForegroundColor = ConsoleColor.Green;
                    yesNo = Console.ReadLine();
                    Console.ResetColor();
                }
                Console.Clear();
            }
            Console.Clear();

            Print("The adventure begins\n\n");
            RainbowLoading();
            Print("\n\n");
            //Print("".PadLeft(Console.WindowWidth - 5, '|') + "\n\n", ConsoleColor.Blue, slowText: true);
            GetPressEnter();
            Console.Clear();
            //end with collecting the player data

            Print("\tAmong the many things that video games can do well,\n" +
                  "is to tell a good story. Sometimes, the story is so good, it  leaves\n" +
                  "a lasting impact on you, an impact akin to what you might feel after\n" +
                  "reading a great book, or watching a great movie. Games can offer you\n" +
                  "the same experience, but it’s honestly waay better, because you  get\n" +
                  "to play the game and BE the story.\n\n", ConsoleColor.DarkYellow, slowText: true);

            GetPressEnter();
            Console.Clear();

            Print("You starts your way at the dark forest, full of different creatures.\n" +
                  "You have to be careful, you never know what to expect.\n\n", ConsoleColor.DarkGreen);

            GetPressEnter();

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

                        //exit from the shop
                        if (keyBoardInput == "<") break;

                        switch (choiceInTheShop)
                        {
                            case 1:
                                BuyPotion(medicineBag.SmallCost, choiceInTheShop);
                                break;

                            case 2:
                                BuyPotion(medicineBag.MediumCost, choiceInTheShop);
                                break;

                            case 3:
                                BuyPotion(medicineBag.BigCost, choiceInTheShop);
                                break;

                            case 4:
                                BuyWeapon(weapon.Cost1, choiceInTheShop);
                                break;

                            case 5:
                                BuyWeapon(weapon.Cost2, choiceInTheShop);
                                break;
                        }

                        //buying potions
                        void BuyPotion(int cost, int type)
                        {
                            if (player.Gold >= cost)
                            {
                                player.Gold -= cost;
                                medicineBag.AddPotion(potionType: type);
                            }
                            else Print("not enough gold".PadLeft(41, ' ') + "\n", ConsoleColor.DarkRed);
                        }

                        //buying weapon
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

                    //if all bosses are dead, you can see menu with the last location
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

                    //if not, you can choose between three locations
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

                //create location according to the number of chosen location
                location = new Location(locationType);

                //create boss according to the number of chosen location
                switch (locationType)
                {
                    case 1:
                        boss = boss1;
                        break;

                    case 2:
                        boss = boss2;
                        break;

                    case 3:
                        boss = boss3;
                        break;

                    case 4:
                        boss = boss4;
                        break;
                }

                //enter to the secret location, if you already killed three bosses
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

                    //final fight of the game
                    if (yesNo.ToLower() == "y")
                    {
                        BossBattle(player, medicineBag, location, weapon, boss, boss1, boss2, boss3);

                        //if you win final battle
                        if (boss.CurrentHealth <= 0)
                        {
                            Console.Clear();
                            PrintTheEnd(player, weapon);
                            break;
                        }

                        //if you lost final battle
                        if (player.CurrentHealth <= 0)
                        {
                            PrintYouDied();
                            break;
                        }
                    }
                }

                //starting battle section according to the chosen location
                else
                {
                    //printing full info about the location, only once in each location, according to the chosen location
                    Print($"{location.LocationInfo}\n", ConsoleColor.DarkGreen);
                    //start battle section with regular enemies
                    BattleZone(player, medicineBag, location, weapon, boss, boss1, boss2, boss3);
                }

                //if you killed enough enemies in the location, you can fight with boss of this location, if it is not dead
                if (player.DefeatedEnemiesToFightTheBoss == boss.CounterToReachTheBoss && !boss.IsDead)
                {
                    PrintBossFight();
                    Print($"\tGet ready for battle, the {boss.Name} is coming...\n\n");
                    GetPressEnter();
                    Console.Clear();
                    //start boss fight
                    BossBattle(player, medicineBag, location, weapon, boss, boss1, boss2, boss3);
                }

                //if you were killed in the battle
                if (player.CurrentHealth <= 0)
                {
                    PrintYouDied();
                    break;
                }

                //change your direction
                PrintOptions(4, player, medicineBag, weapon, boss1, boss2, boss3);

                changeDirection = 0;
                while (changeDirection == 0 || changeDirection > 3)
                {
                    Print("make your choice: ".PadLeft(32, ' '));
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

        public static void GetPressEnter()
        {
            Thread.Sleep(1500);
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }

        public static void GetStatus(Player player, Weapon weapon)
        {
            //if you didn't buy any weapon from the shop
            if (!weapon.Weapon1Bought && !weapon.Weapon2Bought)
            {
                Print("\n");
                Print("".PadLeft(30, '>') + "\n", ConsoleColor.Magenta);
                MainStats();
                Print("".PadLeft(30, '<') + "\n\n", ConsoleColor.Magenta);
            }

            //if you have bought any weapon from the shop
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
                Print($" {player.Name}", ConsoleColor.DarkYellow);
                Print(" / ");
                Print($"{player.Sex}\n", ConsoleColor.Cyan);
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

        public static void Print(string text, ConsoleColor color = ConsoleColor.White, bool slowText = false, int speed = 5)
        {
            //slowly printing in the specified color
            if (slowText)
            {
                char[] letters = text.ToCharArray();

                Console.ForegroundColor = color;

                foreach (char element in letters)
                {
                    Console.Write(element);
                    Thread.Sleep(speed);
                }

                Console.ResetColor();
            }

            //regular printing in the specified color
            else
            {
                Console.ForegroundColor = color;
                Console.Write(text);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void PrintOptions(int type, Player player, MedicineBag medicineBag, Weapon weapon, Boss boss1, Boss boss2, Boss boss3)
        {
            //battle options
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

            //battle optins => healing options
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

            //options to select the location
            if (type == 3)
            {
                //if all bosses are dead, you can see last secret location
                if (boss1.IsDead && boss2.IsDead && boss3.IsDead)
                {
                    Print("Where do you want to go? ");
                    Print(" [1] ", ConsoleColor.Green);
                    Print("Dark forest\t");
                    Condition(boss1);

                    Print(" [2] ".PadLeft(30, ' '), ConsoleColor.Green);
                    Print("Caves\t\t");
                    Condition(boss2);

                    Print(" [3] ".PadLeft(30, ' '), ConsoleColor.Green);
                    Print("Volcano\t\t");
                    Condition(boss3);

                    Print(" [4] ".PadLeft(30, ' '), ConsoleColor.Green);
                    Print("Lair of true evil\n\n", ConsoleColor.DarkRed);
                }

                //if not, you can see only three locations
                else
                {
                    Print("Where do you want to go? ");
                    Print(" [1] ", ConsoleColor.Green);
                    Print("Dark forest\t");
                    Condition(boss1);

                    Print(" [2] ".PadLeft(30, ' '), ConsoleColor.Green);
                    Print("Caves\t\t");
                    Condition(boss2);

                    Print(" [3] ".PadLeft(30, ' '), ConsoleColor.Green);
                    Print("Volcano\t\t");
                    Condition(boss3);
                    Print("\n");
                }

                void Condition(Boss boss)
                {
                    if (!boss.IsDead) Print("boss is alive\n", ConsoleColor.DarkRed);
                    else Print("boss is defeated\n", ConsoleColor.DarkGreen);
                }
            }

            //options to change direction
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

            //shop options
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

                //you can see weapon according to the selected class of player
                Print(" [4] ".PadLeft(30, ' '), ConsoleColor.Green);
                Print($"{weapon.Weapon1}\t", ConsoleColor.DarkCyan);
                Print($"+{weapon.Damage1}\t", ConsoleColor.DarkRed);
                Print($"{weapon.Cost1} gold\n", ConsoleColor.DarkYellow);
                Print(" [5] ".PadLeft(30, ' '), ConsoleColor.Green);
                Print($"{weapon.Weapon2}\t", ConsoleColor.DarkCyan);
                Print($"+{weapon.Damage2}\t", ConsoleColor.DarkRed);
                Print($"{weapon.Cost2} gold\n\n", ConsoleColor.DarkYellow);

                //gold in your bag
                Print(" [<] ".PadLeft(30, ' '), ConsoleColor.Green);
                Print($"exit");
                Print($"\t\t\t{player.Gold} ", ConsoleColor.Green);
                Print("gold ", ConsoleColor.DarkYellow);
                Print("in your bag\n\n");
            }

            //selection of the player claa before start of the game
            if (type == 6)
            {
                Print("\nChoose your character's class: ");
                Print(" [1] ", ConsoleColor.Green);
                Print("warrior\n");
                Print(" [2] ".PadLeft(36, ' '), ConsoleColor.Green);
                Print("archer\n");
                Print(" [3] ".PadLeft(36, ' '), ConsoleColor.Green);
                Print("mage\n\n");
            }

            //card of player before start of the game
            if (type == 7)
            {
                Print("".PadLeft(25, '>') + "\n", ConsoleColor.Magenta);
                Print("Your character\n", ConsoleColor.DarkYellow);
                Print("name:\t");
                Print($"{player.Name}\n", ConsoleColor.Green);
                Print("gender:\t");
                Print($"{player.Sex}\n", ConsoleColor.Green);
                Print("class:\t");
                Print($"{player.PlayerClass}\n", ConsoleColor.Green);
                Print("".PadLeft(25, '<') + "\n\n", ConsoleColor.Magenta);
            }

            //selection of player's gender
            if (type == 8)
            {
                Print("\nChoose your character's gender:");
                Print(" [1] ", ConsoleColor.Green);
                Print("male\n");
                Print(" [2] ".PadLeft(36, ' '), ConsoleColor.Green);
                Print("female\n\n");
            }
        }

        public static void BattleZone(Player player, MedicineBag medicineBag, Location location, Weapon weapon, Boss boss, Boss boss1, Boss boss2, Boss boss3)
        {
            //setting counter of defeated enemies to 0 before the start of each battle
            player.DefeatedEnemiesToFightTheBoss = 0;

            string yesNo = string.Empty;
            while (yesNo.ToLower() != "n")
            {
                //printing short name of the location before each regular enemy
                Print($"Location: {location.ShortTitle}\n", ConsoleColor.DarkCyan);

                Random random = new Random();
                //create new enemy randomly every time when the cycle starts again, according to the chosen location
                Enemy enemy = location.CreateEnemy();
                int choice = 0;
                string keyBoardInput = string.Empty;
                yesNo = string.Empty;

                Print("\n");
                RainbowLoading(random.Next(1, 9));
                //Print("".PadLeft(random.Next(25, Console.WindowWidth - 5), '|') + "\n", ConsoleColor.DarkYellow, slowText: true, speed: 1);
                Print("\n");

                //print randomly generated phrase when new enemy appear
                Print(EntryBattlePhrase(enemy));
                //battle options
                PrintOptions(1, player, medicineBag, weapon, boss1, boss2, boss3);

                while (true)
                {
                    //every new cycle of fight generate unic damage for player and enemy
                    //if player bought weapon, it will generate damage + weapon damage
                    double playerDamage = player.GenerateDamage(weapon);
                    double enemyDamage = enemy.GenerateDamage();

                    Console.Write("choose action: ".PadLeft(41, ' '));
                    Console.ForegroundColor = ConsoleColor.Green;
                    keyBoardInput = Console.ReadLine();
                    int.TryParse(keyBoardInput, out int battleChoice);
                    Console.ResetColor();

                    //manual fight
                    if (battleChoice == 1)
                    {
                        enemy.CurrentHealth -= playerDamage;

                        //if an enemy is dead
                        if (enemy.CurrentHealth <= 0)
                        {
                            EnemyIsDead(player, enemy, playerDamage);
                            //print status of player
                            GetStatus(player, weapon);
                            break;
                        }

                        player.CurrentHealth -= enemyDamage;

                        //if the player is dead
                        if (player.CurrentHealth <= 0)
                        {
                            PlayerIsDead(player, enemy.Name, enemy.CurrentHealth, playerDamage, enemyDamage);
                            break;
                        }

                        //continue battle
                        else
                        {
                            Print($"\n\t{player.Name} deals {playerDamage} damage, {enemy.Name} has {enemy.CurrentHealth} health now\n");
                            Print($"\t{enemy.Name} deals {enemyDamage} damage, {player.Name} have {player.CurrentHealth} health now\n\n");
                        }
                        continue;
                    }

                    //automatic fight
                    if (battleChoice == 2)
                    {
                        while (player.CurrentHealth > 0 || enemy.CurrentHealth > 0)
                        {
                            playerDamage = player.GenerateDamage(weapon);
                            enemyDamage = enemy.GenerateDamage();

                            enemy.CurrentHealth -= playerDamage;

                            //if an enemy is dead
                            if (enemy.CurrentHealth <= 0)
                            {
                                EnemyIsDead(player, enemy, playerDamage);
                                //print status of player
                                GetStatus(player, weapon);
                                break;
                            }

                            player.CurrentHealth -= enemyDamage;

                            //if the player is dead
                            if (player.CurrentHealth <= 0)
                            {
                                PlayerIsDead(player, enemy.Name, enemy.CurrentHealth, playerDamage, enemyDamage);
                                break;
                            }

                            //continue battle
                            else
                            {
                                Print($"\n\t{player.Name} deals {playerDamage} damage, {enemy.Name} has {enemy.CurrentHealth} health now\n");
                                Print($"\t{enemy.Name} deals {enemyDamage} damage, {player.Name} have {player.CurrentHealth} health now\n\n");
                            }
                            //pause before the next automatic turn
                            Thread.Sleep(500);
                        }

                        break;
                    }

                    //battle optins => healing options
                    if (battleChoice == 3)
                    {
                        //print healing options
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

                        //check if you have potion according to chosen type of potion
                        int amountOfAids = medicineBag.UsePotion(choice);

                        if (choice == 1 || choice == 2 || choice == 3)
                        {
                            //if you have potion
                            if (amountOfAids > 0)
                            {
                                player.CurrentHealth += medicineBag.HealingPower;

                                //if player's current health equal or greater than maximum health
                                if (player.CurrentHealth > player.Health)
                                {
                                    player.CurrentHealth = player.Health;
                                    Print("\n\tmax health\n\n", ConsoleColor.DarkGreen);
                                }

                                //if not => heal
                                else
                                {
                                    Print($"\n\t+{medicineBag.HealingPower} health. {player.Name} have {player.CurrentHealth} now\n\n", ConsoleColor.DarkGreen);
                                }

                                //enemy does his turn, after you used yours for healing
                                player.CurrentHealth -= enemy.Damage;

                                //if you died after this attack
                                if (player.CurrentHealth <= 0)
                                {
                                    Print($"\t{enemy.Name} deals {enemyDamage} damage, {player.Name} get");
                                    Print($" fatal ", ConsoleColor.DarkRed);
                                    Print($"damage and has {player.CurrentHealth} health\n\n");

                                    break;
                                }

                                else Print($"\t{enemy.Name} deals {enemyDamage} damage, {player.Name} have {player.CurrentHealth} health now\n\n");
                            }

                            //if you don't have any potions
                            else
                            {
                                Print($"\n\tYou don't have {medicineBag.Name}\n\n", ConsoleColor.DarkRed);

                                //enemy does his turn, after you used yours for healing
                                player.CurrentHealth -= enemy.Damage;

                                //if you died after this attack
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

                        //if you want to exit healing options and return to the battle options
                        if (keyBoardInput == "<")
                        {
                            Print("\n");
                            continue;
                        }
                    }

                    //trying to run away from the enemy
                    if (battleChoice == 4)
                    {
                        //calculating the player's chance to escape randomly
                        int tryToEscape = random.Next(0, 100);

                        //if you succeed in escaping
                        if (tryToEscape > enemy.ChanceToInterruptTheEscape)
                        {
                            //lost some gold from your bag
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

                        //you can't avoid a battle with some enemies/bosses
                        else if (enemy.ChanceToInterruptTheEscape == 100)
                        {
                            Print($"\n\tyou can't escape from the {enemy.Name}\n", ConsoleColor.DarkRed);
                            //if you failed to escape, an enemy does his critical attack
                            CritDamage(enemy);

                            if (player.CurrentHealth <= 0) break;

                        }

                        else
                        {
                            Print("\n\tfailed to escape\n", ConsoleColor.DarkRed);
                            //if you failed to escape, an enemy does his critical attack
                            CritDamage(enemy);

                            if (player.CurrentHealth <= 0) break;
                            else continue;
                        }
                    }
                }

                if (player.CurrentHealth <= 0) break;
                if (player.DefeatedEnemiesToFightTheBoss == boss.CounterToReachTheBoss && !boss.IsDead) break;

                //asking if you want to continue grinding or not
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

                //local function to generate an enemy damage with multiplier, which is also generating randomly
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
                //printing short name of the location before each boss
                Print($"Location: {location.ShortTitle}\n\n", ConsoleColor.DarkCyan);
                Print($"{boss.Name}\n\n");

                Random random = new Random();
                int choice = 0;
                string keyBoardInput = string.Empty;

                //battle options
                PrintOptions(1, player, medicineBag, weapon, boss1, boss2, boss3);

                while (true)
                {
                    //every new cycle of fight generate unic damage for player and boss
                    //if player bought weapon, it will generate damage + weapon damage
                    double playerDamage = player.GenerateDamage(weapon);
                    double bossDamage = boss.GenerateDamage();

                    Console.Write("choose action: ".PadLeft(41, ' '));
                    Console.ForegroundColor = ConsoleColor.Green;
                    keyBoardInput = Console.ReadLine();
                    int.TryParse(keyBoardInput, out int battleChoice);
                    Console.ResetColor();

                    //manual fight
                    if (battleChoice == 1)
                    {
                        boss.CurrentHealth -= playerDamage;

                        //if the boss is dead
                        if (boss.CurrentHealth <= 0)
                        {
                            BossIsDead(player, boss, playerDamage);
                            //print status of player
                            GetStatus(player, weapon);
                            GetPressEnter();
                            Console.Clear();
                            break;
                        }

                        player.CurrentHealth -= bossDamage;

                        //if the player is dead
                        if (player.CurrentHealth <= 0)
                        {
                            PlayerIsDead(player, boss.Name, boss.CurrentHealth, playerDamage, bossDamage);
                            break;
                        }

                        //continue battle
                        else
                        {
                            Print($"\n\t{player.Name} deals {playerDamage} damage, {boss.Name} has {boss.CurrentHealth} health now\n");
                            Print($"\t{boss.Name} deals {bossDamage} damage, {player.Name} have {player.CurrentHealth} health now\n\n");
                        }
                        continue;
                    }

                    //automatic fight
                    if (battleChoice == 2)
                    {
                        while (player.CurrentHealth > 0 || boss.CurrentHealth > 0)
                        {
                            //every new cycle of fight generate unic damage for player and boss
                            //if player bought weapon, it will generate damage + weapon damage
                            playerDamage = player.GenerateDamage(weapon);
                            bossDamage = boss.GenerateDamage();

                            boss.CurrentHealth -= playerDamage;

                            //if the boss is dead
                            if (boss.CurrentHealth <= 0)
                            {
                                BossIsDead(player, boss, playerDamage);
                                //print status of player
                                GetStatus(player, weapon);
                                GetPressEnter();
                                Console.Clear();
                                break;
                            }

                            player.CurrentHealth -= bossDamage;

                            //if the player is dead
                            if (player.CurrentHealth <= 0)
                            {
                                PlayerIsDead(player, boss.Name, boss.CurrentHealth, playerDamage, bossDamage);
                                break;
                            }

                            else
                            {
                                Print($"\n\t{player.Name} deals {playerDamage} damage, {boss.Name} has {boss.CurrentHealth} health now\n");
                                Print($"\t{boss.Name} deals {bossDamage} damage, {player.Name} have {player.CurrentHealth} health now\n\n");
                            }
                            //pause before the next automatic turn
                            Thread.Sleep(500);
                        }

                        break;
                    }

                    //battle optins => healing options
                    if (battleChoice == 3)
                    {
                        //print healing options
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

                        //check if you have potion according to chosen type of potion
                        int amountOfAids = medicineBag.UsePotion(choice);

                        if (choice == 1 || choice == 2 || choice == 3)
                        {
                            //if you have potion
                            if (amountOfAids > 0)
                            {
                                player.CurrentHealth += medicineBag.HealingPower;

                                //if player's current health equal or greater than maximum health
                                if (player.CurrentHealth > player.Health)
                                {
                                    player.CurrentHealth = player.Health;
                                    Print("\n\tmax health\n\n", ConsoleColor.DarkGreen);
                                }

                                //if not => heal
                                else
                                {
                                    Print($"\n\t+{medicineBag.HealingPower} health. {player.Name} have {player.CurrentHealth} now\n\n", ConsoleColor.DarkGreen);
                                }

                                //boss does his turn, after you used yours for healing
                                player.CurrentHealth -= boss.Damage;

                                //if you died after this attack
                                if (player.CurrentHealth <= 0)
                                {
                                    Print($"\t{boss.Name} deals {bossDamage} damage, {player.Name} get");
                                    Print($" fatal ", ConsoleColor.DarkRed);
                                    Print($"damage and has {player.CurrentHealth} health\n\n");

                                    break;
                                }

                                else Print($"\t{boss.Name} deals {bossDamage} damage, {player.Name} have {player.CurrentHealth} health now\n\n");
                            }

                            //if you don't have any potions
                            else
                            {
                                Print($"\n\tYou don't have {medicineBag.Name}\n\n", ConsoleColor.DarkRed);

                                //boss does his turn, after you used yours for healing
                                player.CurrentHealth -= boss.Damage;

                                //if you died after this attack
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
                         
                        //if you want to exit healing options and return to the battle options
                        if (keyBoardInput == "<")
                        {
                            Print("\n");
                            continue;
                        }
                    }

                    //trying to run away from the enemy
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

                //local function to generate the boss damage with multiplier, which is also generating randomly
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
                $"\nUnexpectedly, {enemy.Name} jumps out of the hedge.\n\n",
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

        public static void PrintBossFight()
        {
            Print($@"{"\t"} ___    ___    ___   ___       ___   ___    ___   _  _   _____ {"\n"}", ConsoleColor.DarkRed, false, 2);
            Print($@"{"\t"}| _ )  / _ \  / __| / __|     | __| |_ _|  / __| | || | |_   _|{"\n"}", ConsoleColor.DarkRed, false, 2);
            Print($@"{"\t"}| _ \ | (_) | \__ \ \__ \     | _|   | |  | (_ | | __ |   | |  {"\n"}", ConsoleColor.DarkRed, false, 2);
            Print($@"{"\t"}|___/  \___/  |___/ |___/     |_|   |___|  \___| |_||_|   |_|  {"\n\n"}", ConsoleColor.DarkRed, false, 2);
        }

        public static void PrintYouDied()
        {
            Print($@"{"\t"}__   __   ___    _   _       ___    ___   ___   ___  {"\n"}", ConsoleColor.DarkRed, false, 2);
            Print($@"{"\t"}\ \ / /  / _ \  | | | |     |   \  |_ _| | __| |   \ {"\n"}", ConsoleColor.DarkRed, false, 2);
            Print($@"{"\t"} \ V /  | (_) | | |_| |     | |) |  | |  | _|  | |) |{"\n"}", ConsoleColor.DarkRed, false, 2);
            Print($@"{"\t"}  |_|    \___/   \___/      |___/  |___| |___| |___/ {"\n\n"}", ConsoleColor.DarkRed, false, 2);
            Print("your journey is over :(".PadLeft(45, ' '), ConsoleColor.Red);

            Thread.Sleep(3000);
            Print("\n\nPress Enter to exit");
            Console.ReadLine();
        }

        public static void PrintBossVanquished()
        {
            Print($@"{"\t"} ___    ___    ___   ___    __   __    _     _  _    ___    _   _   ___   ___   _  _   ___   ___  {"\n"}", ConsoleColor.DarkGreen, false, 2);
            Print($@"{"\t"}| _ )  / _ \  / __| / __|   \ \ / /   /_\   | \| |  / _ \  | | | | |_ _| / __| | || | | __| |   \ {"\n"}", ConsoleColor.DarkGreen, false, 2);
            Print($@"{"\t"}| _ \ | (_) | \__ \ \__ \    \ V /   / _ \  | .` | | (_) | | |_| |  | |  \__ \ | __ | | _|  | |) |{"\n"}", ConsoleColor.DarkGreen, false, 2);
            Print($@"{"\t"}|___/  \___/  |___/ |___/     \_/   /_/ \_\ |_|\_|  \__\_\  \___/  |___| |___/ |_||_| |___| |___/ {"\n"}", ConsoleColor.DarkGreen, false, 2);
        }

        public static void PrintTheEnd(Player player, Weapon weapon)
        {
            Print($@"{"\t"} _________          _______      _______  _        ______  { "\n"}", ConsoleColor.DarkGreen, false, 2);
            Print($@"{"\t"} \__   __/|\     /|(  ____ \    (  ____ \( (    /|(  __  \ {"\n"}", ConsoleColor.DarkGreen, false, 2);
            Print($@"{"\t"}    ) (   | )   ( || (    \/    | (    \/|  \  ( || (  \  ){"\n"}", ConsoleColor.DarkGreen, false, 2);
            Print($@"{"\t"}    | |   | (___) || (__        | (__    |   \ | || |   ) |{"\n"}", ConsoleColor.DarkGreen, false, 2);
            Print($@"{"\t"}    | |   |  ___  ||  __)       |  __)   | (\ \) || |   | |{ "\n"}", ConsoleColor.DarkGreen, false, 2);
            Print($@"{"\t"}    | |   | (   ) || (          | (      | | \   || |   ) |{"\n"}", ConsoleColor.DarkGreen, false, 2);
            Print($@"{"\t"}    | |   | )   ( || (____/\    | (____/\| )  \  || (__/  ){"\n"}", ConsoleColor.DarkGreen, false, 2);
            Print($@"{"\t"}    )_(   |/     \|(_______/    (_______/|/    )_)(______/ {"\n"}", ConsoleColor.DarkGreen, false, 2);

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
                Print("".PadLeft(36, '>') + "\n", ConsoleColor.Magenta);
                MainStats();

                if (weapon.Weapon1Bought)
                {
                    Print(" weapon:          ");
                    Print($"{weapon.Weapon1}\n", ConsoleColor.Green);
                }
                if (weapon.Weapon2Bought)
                {
                    Print(" weapon:          ");
                    Print($"{weapon.Weapon2}\n", ConsoleColor.Green);
                }

                Print("".PadLeft(36, '<') + "\n\n", ConsoleColor.Magenta);
            }

            void MainStats()
            {
                Print($" {player.Name}", ConsoleColor.DarkYellow);
                Print(" / ");
                Print($"{player.Sex}\n", ConsoleColor.Cyan);
                Print(" class:           ");
                Print($"{player.PlayerClass}\n", ConsoleColor.Green);
                Print(" lvl:             ");
                Print($"{player.Lvl}\n", ConsoleColor.Green);
                Print(" gold:            ");
                Print($"{player.Gold}\n", ConsoleColor.Green);
                Print(" exp:             ");
                Print($"{player.Exp}\n", ConsoleColor.Green);
                Print(" enemies killed:  ");
                Print($"{player.DefeatedEnemiesOverall}\n", ConsoleColor.Green);
                Print(" bosses killed:   ");
                Print($"{player.DefeatedBossesOverall}\n", ConsoleColor.Green);
            }

            Thread.Sleep(3000);
            Print("Press Enter to exit");
            Console.ReadLine();
        }

        public static void PrintGameTitle()
        {
            Print($@"{"\t"} _______ _________ _______  _______  _       __________________         {"\n"}", ConsoleColor.DarkMagenta, false, 2);
            Print($@"{"\t"}(  ____ \\__   __/(  ____ \(  ____ )( (    /|\__   __/\__   __/|\     /|{"\n"}", ConsoleColor.DarkMagenta, false, 2);
            Print($@"{"\t"}| (    \/   ) (   | (    \/| (    )||  \  ( |   ) (      ) (   ( \   / ){"\n"}", ConsoleColor.DarkMagenta, false, 2);
            Print($@"{"\t"}| (__       | |   | (__    | (____)||   \ | |   | |      | |    \ (_) / {"\n"}", ConsoleColor.DarkMagenta, false, 2);
            Print($@"{"\t"}|  __)      | |   |  __)   |     __)| (\ \) |   | |      | |     \   /  {"\n"}", ConsoleColor.DarkMagenta, false, 2);
            Print($@"{"\t"}| (         | |   | (      | (\ (   | | \   |   | |      | |      ) (   {"\n"}", ConsoleColor.DarkMagenta, false, 2);
            Print($@"{"\t"}| (____/\   | |   | (____/\| ) \ \__| )  \  |___) (___   | |      | |   {"\n"}", ConsoleColor.DarkMagenta, false, 2);
            Print($@"{"\t"}(_______/   )_(   (_______/|/   \__/|/    )_)\_______/   )_(      \_/   {"\n\n"}", ConsoleColor.DarkMagenta, false, 2);
        }

        public static void EnemyIsDead(Player player, Enemy enemy, double playerDamage)
        {
            player.DefeatedEnemiesOverall++;
            player.DefeatedEnemiesToFightTheBoss++;
            player.Gold += enemy.Gold;
            player.Exp += enemy.Exp;
            //check if player has enough experience to get new level
            player.LevelUp(player.Exp);

            Print($"\n\t{player.Name} deals {playerDamage} damage, {enemy.Name} get");
            Print($" fatal ", ConsoleColor.DarkRed);
            Print($"damage and has {enemy.CurrentHealth} health\n");
            Print($"\n\tVICTORY. You have earned {enemy.Gold} gold and {enemy.Exp} exp\n", ConsoleColor.DarkYellow);
        }

        public static void PlayerIsDead(Player player, string name, double currentHealth, double playerDamage, double enemyDamage)
        {
            Print($"\n\t{player.Name} deals {playerDamage} damage, {name} has {currentHealth} health now\n");
            Print($"\t{name} deals {enemyDamage} damage, {player.Name} get");
            Print($" fatal ", ConsoleColor.DarkRed);
            Print($"damage and has {player.CurrentHealth} health\n\n");
        }

        public static void BossIsDead(Player player, Boss boss, double playerDamage)
        {
            player.DefeatedBossesOverall++;
            boss.IsDead = true;
            player.Gold += boss.Gold;
            player.Exp += boss.Exp;
            //check if player has enough experience to get new level
            player.LevelUp(player.Exp);

            Print($"\n\t{player.Name} deals {playerDamage} damage, {boss.Name} get");
            Print($" fatal ", ConsoleColor.DarkRed);
            Print($"damage and has {boss.CurrentHealth} health\n");
            PrintBossVanquished();
            Print($"\n\tYou have earned {boss.Gold} gold and {boss.Exp} exp\n", ConsoleColor.DarkYellow);
        }

        public static void RainbowLoading(int length = 8)
        {
            for (int i = 0; i <= length; i++)
            {
                Print("|", ConsoleColor.Red, slowText: true);
                Print("|", ConsoleColor.DarkYellow, slowText: true);
                Print("|", ConsoleColor.Yellow, slowText: true);
                Print("|", ConsoleColor.Green, slowText: true);
                Print("|", ConsoleColor.Cyan, slowText: true);
                Print("|", ConsoleColor.DarkBlue, slowText: true);
                Print("|", ConsoleColor.DarkMagenta, slowText: true);
                Print("|", ConsoleColor.DarkBlue, slowText: true);
                Print("|", ConsoleColor.Cyan, slowText: true);
                Print("|", ConsoleColor.Green, slowText: true);
                Print("|", ConsoleColor.Yellow, slowText: true);
                Print("|", ConsoleColor.DarkYellow, slowText: true);
            }

            Print("|", ConsoleColor.Red, slowText: true);
            Print("|", ConsoleColor.DarkYellow, slowText: true);
            Print("|", ConsoleColor.Yellow, slowText: true);
            Print("|", ConsoleColor.Green, slowText: true);
            Print("|", ConsoleColor.Cyan, slowText: true);
            Print("|", ConsoleColor.DarkBlue, slowText: true);
            Print("|", ConsoleColor.DarkMagenta, slowText: true);
        }
    }
}
