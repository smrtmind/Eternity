using System;
using System.Threading;

namespace EternityRPG
{
    class Program
    {
        public static int indexOfBoss { get; set; }
        public static int indexOfEnemy { get; set; }
        public static int DefeatedEnemiesOverall { get; set; }
        public static int DefeatedBossesOverall { get; set; }
        public static int DefeatedEnemiesToFightTheBoss { get; set; }

        static void Main(string[] args)
        {
            MedicineBag medicineBag = new MedicineBag();
            Character player;
            Weapon weapon = new Weapon();
            Location location;

            string keyBoardInput = string.Empty;
            string playerName = string.Empty;
            string yesNo = string.Empty;
            string sex = string.Empty;

            int changeDirection = 0;
            int locationType = 1;
            int playerClass = 0;
            int choice = 0;

            Character[] bosses = new Character[]
            {
                new boss1(),
                new boss2(),
                new boss3(),
                new boss4()
            };

            Character[] enemies = new Character[9];

            //PrintGameTitle();
            //GetPressEnter();

            //RainbowLoading();
            ////Print("".PadLeft(Console.WindowWidth - 5, '|'), ConsoleColor.Blue, slowText: true);
            //Console.Clear();

            //Print("Hello, traveler. I can't remember your name. Can you help me with this?\n\n", ConsoleColor.DarkYellow);
            //Thread.Sleep(4000);

            //while (yesNo.ToLower() != "y")
            //{
            //    yesNo = string.Empty;
            //    playerName = string.Empty;

            //    Print("Enter your name or press ENTER: ");

            //    Console.ForegroundColor = ConsoleColor.Green;
            //    keyBoardInput = Console.ReadLine();
            //    Console.ResetColor();

            //    //your name
            //    if (keyBoardInput.Length > 0) playerName = keyBoardInput;
            //    //default name
            //    else playerName = "Sam";

            //    //selection of player's gender
            //    PrintOptions(8, player, medicineBag, weapon, boss1, boss2, boss3);

            //    choice = 0;

            //    //gender of your character
            //    while (choice != 1 && choice != 2)
            //    {
            //        Print("choose gender: ".PadLeft(47, ' '));
            //        Console.ForegroundColor = ConsoleColor.Green;
            //        keyBoardInput = Console.ReadLine();
            //        int.TryParse(keyBoardInput, out choice);
            //        Console.ResetColor();

            //        if (choice == 1) sex = "male";
            //        if (choice == 2) sex = "female";
            //    }

            //    //selection of the player claa before start of the game
            //    PrintOptions(6, player, medicineBag, weapon, boss1, boss2, boss3);

            //    playerClass = 0;

            //    while (playerClass != 1 && playerClass != 2 && playerClass != 3)
            //    {
            //        Print("choose class: ".PadLeft(46, ' '));
            //        Console.ForegroundColor = ConsoleColor.Green;
            //        keyBoardInput = Console.ReadLine();
            //        int.TryParse(keyBoardInput, out playerClass);
            //        Console.ResetColor();
            //    }
            //    Console.Clear();

            //    //creating player and weapon according to collected data
            //    player = new Player(playerClass, playerName, sex);
            //    weapon = new Weapon(playerClass);

            //    //card of player before start of the game
            //    PrintOptions(7, player, medicineBag, weapon, boss1, boss2, boss3);

            //    yesNo = string.Empty;
            //    while (yesNo.ToLower() != "y" && yesNo.ToLower() != "n")
            //    {
            //        Print("Are you ready to start the adventure with this character?");
            //        Print(" [y] ", ConsoleColor.Green);
            //        Print("/");
            //        Print(" [n]", ConsoleColor.Green);
            //        Print(": ");

            //        Console.ForegroundColor = ConsoleColor.Green;
            //        yesNo = Console.ReadLine();
            //        Console.ResetColor();
            //    }
            //    Console.Clear();
            //}
            //Console.Clear();

            //Print("The adventure begins\n\n");
            //RainbowLoading();
            //Print("\n\n");
            ////Print("".PadLeft(Console.WindowWidth - 5, '|') + "\n\n", ConsoleColor.Blue, slowText: true);
            //GetPressEnter();
            //Console.Clear();
            ////end with collecting the player data

            //Print("\tAmong the many things that video games can do well,\n\n" +
            //      "is to tell a good story. Sometimes, the story is so good, it  leaves\n\n" +
            //      "a lasting impact on you, an impact akin to what you might feel after\n\n" +
            //      "reading a great book, or watching a great movie. Games can offer you\n\n" +
            //      "the same experience, but it’s honestly waay better, because you  get\n\n" +
            //      "to play the game and BE the story.\n\n", ConsoleColor.DarkYellow, slowText: true);

            //GetPressEnter();
            //Console.Clear();

            //Print("You starts your way at the dark forest, full of different creatures.\n" +
            //      "You have to be careful, you never know what to expect.\n\n", ConsoleColor.DarkGreen);

            //GetPressEnter();



            player = new Mage("Oleg", "male");
            weapon = new Weapon(3);


            //player = new Player(3, "Oleg", "male");
            //weapon = new Weapon(3);


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
                        Print.Options(5, player, medicineBag, weapon, bosses);

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
                            else Print.Text("not enough gold".PadLeft(41, ' ') + "\n", ConsoleColor.DarkRed);
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

                            else Print.Text("not enough gold".PadLeft(41, ' ') + "\n", ConsoleColor.DarkRed);
                        }
                        Console.WriteLine();

                        yesNo = string.Empty;
                        while (yesNo.ToLower() != "y" && yesNo.ToLower() != "n")
                        {
                            Print.Text("anything else?".PadLeft(40, ' '));
                            Print.Text(" [y] ", ConsoleColor.Green);
                            Print.Text("/");
                            Print.Text(" [n]", ConsoleColor.Green);
                            Print.Text(": ");

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
                    Print.Options(3, player, medicineBag, weapon, bosses);

                    locationType = 0;

                    //if all bosses are dead, you can see menu with the last location
                    int deathCounter = 0;
                    foreach (var boss in bosses) if (boss.IsDead) deathCounter++;

                    if (deathCounter == 3)
                    {
                        while (locationType == 0 || locationType > 4)
                        {
                            Console.Write("make your choice: ".PadLeft(44, ' '));
                            Console.ForegroundColor = ConsoleColor.Green;
                            int.TryParse(Console.ReadLine(), out locationType);
                            Console.ResetColor();

                            indexOfBoss = locationType - 1;
                        }
                    }

                    //if not, you can choose between three locations
                    else
                    {
                        while (locationType == 0 || locationType > 3)
                        {
                            Console.Write("make your choice: ".PadLeft(44, ' '));
                            Console.ForegroundColor = ConsoleColor.Green;
                            int.TryParse(Console.ReadLine(), out locationType);
                            Console.ResetColor();

                            indexOfBoss = locationType - 1;
                        }
                    }
                }
                Console.Clear();

                //create location according to the number of chosen location
                location = new Location(locationType);

                //enter to the secret location, if you already killed three bosses
                if (locationType == 4)
                {
                    yesNo = string.Empty;
                    while (yesNo.ToLower() != "y" && yesNo.ToLower() != "n")
                    {
                        Print.Text($"Are you ready for final battle?");
                        Print.Text(" [y] ", ConsoleColor.Cyan);
                        Print.Text("/");
                        Print.Text(" [n]", ConsoleColor.Cyan);
                        Print.Text(": ");

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        yesNo = Console.ReadLine();
                        Console.ResetColor();
                    }
                    Console.Clear();

                    //final fight of the game
                    if (yesNo.ToLower() == "y")
                    {
                        BossBattle(player, medicineBag, location, weapon, bosses);

                        //if you win final battle
                        if (bosses[indexOfBoss].CurrentHealth <= 0)
                        {
                            Console.Clear();
                            Print.TheEnd(player, weapon);
                            break;
                        }

                        //if you lost final battle
                        if (player.CurrentHealth <= 0)
                        {
                            Print.YouDied();
                            break;
                        }
                    }
                }

                //starting battle section according to the chosen location
                else
                {
                    //printing full info about the location, only once in each location, according to the chosen location
                    Print.Text($"{location.LocationInfo}\n", ConsoleColor.DarkGreen);
                    //start battle section with regular enemies
                    BattleZone(player, medicineBag, location, weapon, bosses, enemies);
                }

                //if you killed enough enemies in the location, you can fight with boss of this location, if it is not dead
                if (DefeatedEnemiesToFightTheBoss == bosses[indexOfBoss].CounterToReachTheBoss && !bosses[indexOfBoss].IsDead)
                {
                    Print.BoosFight();
                    Print.Text($"\tGet ready for battle, the {bosses[indexOfBoss].Name} is coming...\n\n");
                    Print.PressEnter();
                    Console.Clear();
                    //start boss fight
                    BossBattle(player, medicineBag, location, weapon, bosses);
                }

                //if you were killed in the battle
                if (player.CurrentHealth <= 0)
                {
                    Print.YouDied();
                    break;
                }

                //change your direction
                Print.Options(4, player, medicineBag, weapon, bosses);

                changeDirection = 0;
                while (changeDirection == 0 || changeDirection > 3)
                {
                    Print.Text("make your choice: ".PadLeft(32, ' '));
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    int.TryParse(Console.ReadLine(), out changeDirection);
                    Console.ResetColor();

                    //show status information
                    if (changeDirection == 3)
                    {
                        Print.PlayerStatistics(player, weapon);
                        changeDirection = 0;
                        continue;
                    }
                }

                Console.Clear();
            }
        }

        public static void BattleZone(Character player, MedicineBag medicineBag, Location location, Weapon weapon, Character[] bosses, Character[] enemies)
        {
            //setting counter of defeated enemies to 0 before the start of each battle
            DefeatedEnemiesToFightTheBoss = 0;

            string yesNo = string.Empty;
            while (yesNo.ToLower() != "n")
            {
                //printing short name of the location before each regular enemy
                Print.Text($"Location: {location.ShortTitle}\n", ConsoleColor.DarkCyan);

                Random random = new Random();
                enemies = new Character[]
                {
                    new Enemy(1),
                    new Enemy(2),
                    new Enemy(3),
                    new Enemy(4),
                    new Enemy(5),
                    new Enemy(6),
                    new Enemy(7),
                    new Enemy(8),
                    new Enemy(9)
                };
                //create new enemy randomly every time when the cycle starts again, according to the chosen location
                indexOfEnemy = location.EnemyIndex();
                int choice = 0;
                string keyBoardInput = string.Empty;
                yesNo = string.Empty;

                Print.RainbowLoading(random.Next(1, 9));

                //print randomly generated phrase when new enemy appear
                Print.Text(Print.EntryBattlePhrase(enemies[indexOfEnemy]));
                //battle options
                Print.Options(1, player, medicineBag, weapon, bosses);

                while (true)
                {
                    //every new cycle of fight generate unic damage for player and enemy
                    //if player bought weapon, it will generate damage + weapon damage
                    double playerDamage;
                    if (!weapon.Weapon1Bought && !weapon.Weapon2Bought)
                    {
                        playerDamage = player.GenerateDamage();
                    }    
                    else playerDamage = player.GenerateDamage(weapon);

                    double enemyDamage = enemies[indexOfEnemy].GenerateDamage();

                    Console.Write("choose action: ".PadLeft(41, ' '));
                    Console.ForegroundColor = ConsoleColor.Green;
                    keyBoardInput = Console.ReadLine();
                    int.TryParse(keyBoardInput, out int battleChoice);
                    Console.ResetColor();

                    //manual fight
                    if (battleChoice == 1)
                    {
                        enemies[indexOfEnemy].CurrentHealth -= playerDamage;

                        //if an enemy is dead
                        if (enemies[indexOfEnemy].CurrentHealth <= 0)
                        {
                            EnemyIsDead();

                            //check if player has enough experience to get new level
                            player.LevelUp(player.Exp);
                            player.Turn(player, enemies, playerDamage, indexOfEnemy);
                            Print.PlayerStatistics(player, weapon);
                            break;
                        }

                        player.CurrentHealth -= enemyDamage;

                        player.Turn(player, enemies, playerDamage, indexOfEnemy);
                        enemies[indexOfEnemy].Turn(player, enemies, enemyDamage, indexOfEnemy);
                        //if the player is dead
                        if (player.CurrentHealth <= 0) break;
                    }

                    //automatic fight
                    if (battleChoice == 2)
                    {
                        while (player.CurrentHealth > 0 || enemies[indexOfEnemy].CurrentHealth > 0)
                        {
                            if (!weapon.Weapon1Bought && !weapon.Weapon2Bought)
                            {
                                playerDamage = player.GenerateDamage();
                            }
                            else playerDamage = player.GenerateDamage(weapon);

                            enemyDamage = enemies[indexOfEnemy].GenerateDamage();
                            enemies[indexOfEnemy].CurrentHealth -= playerDamage;

                            //if an enemy is dead
                            if (enemies[indexOfEnemy].CurrentHealth <= 0)
                            {
                                EnemyIsDead();

                                //check if player has enough experience to get new level
                                player.LevelUp(player.Exp);
                                player.Turn(player, enemies, playerDamage, indexOfEnemy);
                                Print.PlayerStatistics(player, weapon);
                                break;
                            }

                            player.CurrentHealth -= enemyDamage;

                            player.Turn(player, enemies, playerDamage, indexOfEnemy);
                            enemies[indexOfEnemy].Turn(player, enemies, enemyDamage, indexOfEnemy);
                            //if the player is dead
                            if (player.CurrentHealth <= 0) break;
                            else Thread.Sleep(500);
                        }

                        break;
                    }

                    //battle optins => healing options
                    if (battleChoice == 3)
                    {
                        //print healing options
                        Print.Options(2, player, medicineBag, weapon, bosses);

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
                                    Print.Text("\n\tmax health\n\n", ConsoleColor.DarkGreen);
                                }

                                //if not => heal
                                else Print.Text($"\n\t+{medicineBag.HealingPower} health. {player.Name} have {player.CurrentHealth} now\n\n", ConsoleColor.DarkGreen);

                                //enemy does his turn, after you used yours for healing
                                player.CurrentHealth -= enemies[indexOfEnemy].Damage;
                                enemies[indexOfEnemy].Turn(player, enemies, enemyDamage, indexOfEnemy);

                                //if you died after this attack
                                if (player.CurrentHealth <= 0) break;
                            }

                            //if you don't have any potions
                            else
                            {
                                Print.Text($"\n\tYou don't have {medicineBag.Name}\n\n", ConsoleColor.DarkRed);

                                //boss does his turn, after you used yours for healing
                                player.CurrentHealth -= enemies[indexOfEnemy].Damage;
                                enemies[indexOfEnemy].Turn(player, enemies, enemyDamage, indexOfEnemy);

                                //if you died after this attack
                                if (player.CurrentHealth <= 0) break;
                            }
                        }

                        //if you want to exit healing options and return to the battle options
                        if (keyBoardInput == "<")
                        {
                            Print.Text("\n");
                            continue;
                        }
                    }

                    //trying to run away from the enemy
                    if (battleChoice == 4)
                    {
                        //calculating the player's chance to escape randomly
                        int tryToEscape = random.Next(0, 100);

                        //if you succeed in escaping
                        if (tryToEscape > enemies[indexOfEnemy].ChanceToInterruptTheEscape)
                        {
                            //lost some gold from your bag
                            player.Gold -= 10;

                            Print.Text("\n\tYou escaped successfully ");
                            Print.Text("-10 ", ConsoleColor.DarkRed);
                            Print.Text("gold", ConsoleColor.DarkYellow);
                            Print.Text(", ");

                            if (player.Gold <= 0) player.Gold = 0;

                            Print.Text($"{player.Gold} ", ConsoleColor.DarkGreen);
                            Print.Text("gold ", ConsoleColor.DarkYellow);
                            Print.Text("remaining\n\n");

                            break;
                        }

                        //you can't avoid a battle with some enemies
                        else if (enemies[indexOfEnemy].ChanceToInterruptTheEscape == 100)
                        {
                            Print.Text($"\n\tyou can't escape from the {enemies[indexOfEnemy].Name}\n", ConsoleColor.DarkRed);
                            //if you failed to escape, an enemy does his critical attack
                            CritDamage(enemies[indexOfEnemy], enemyDamage);

                            if (player.CurrentHealth <= 0) break;
                        }

                        else
                        {
                            Print.Text("\n\tfailed to escape\n", ConsoleColor.DarkRed);
                            //if you failed to escape, an enemy does his critical attack
                            CritDamage(enemies[indexOfEnemy], enemyDamage);

                            if (player.CurrentHealth <= 0) break;
                            else continue;
                        }
                    }
                }

                if (player.CurrentHealth <= 0) break;
                if (DefeatedEnemiesToFightTheBoss == bosses[indexOfBoss].CounterToReachTheBoss && !bosses[indexOfBoss].IsDead) break;

                //asking if you want to continue grinding or not
                yesNo = string.Empty;
                while (yesNo.ToLower() != "y" && yesNo.ToLower() != "n")
                {
                    Print.Text($"Farm more at the {location.ShortTitle}?");
                    Print.Text(" [y] ", ConsoleColor.Cyan);
                    Print.Text("/");
                    Print.Text(" [n]", ConsoleColor.Cyan);
                    Print.Text(": ");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    yesNo = Console.ReadLine();
                    Console.ResetColor();

                    if (yesNo.ToLower() == "y" || yesNo.ToLower() == "n") Console.Clear();
                }

                //local function to generate an enemy damage with multiplier, which is also generating randomly
                void CritDamage(Character enemy, double enemyDamage)
                {
                    int criticalDamageMultiplier = random.Next(2, 4);

                    player.CurrentHealth -= enemyDamage * criticalDamageMultiplier;

                    if (player.CurrentHealth <= 0)
                    {
                        Print.Text($"\n\t{enemy.Name} made a ");
                        Print.Text("CRITICAL ", ConsoleColor.Red);
                        Print.Text($"attack {enemyDamage * criticalDamageMultiplier} damage, {player.Name} get");
                        Print.Text($" fatal ", ConsoleColor.DarkRed);
                        Print.Text($"damage and has {player.CurrentHealth} health\n");
                    }

                    else
                    {
                        Print.Text($"\n\t{enemy.Name} made a ");
                        Print.Text("CRITICAL ", ConsoleColor.Red);
                        Print.Text($"attack {enemyDamage * criticalDamageMultiplier} damage, {player.Name} have {player.CurrentHealth} now\n\n");
                    }
                }

                void EnemyIsDead()
                {
                    DefeatedEnemiesOverall++;
                    DefeatedEnemiesToFightTheBoss++;
                    player.Gold += enemies[indexOfEnemy].Gold;
                    player.Exp += enemies[indexOfEnemy].Exp;
                }
            }
        }

        public static void BossBattle(Character player, MedicineBag medicineBag, Location location, Weapon weapon, Character[] bosses)
        {
            while (true)
            {
                //printing short name of the location before each boss
                Print.Text($"Location: {location.ShortTitle}\n\n", ConsoleColor.DarkCyan);
                Print.Text($"{bosses[indexOfBoss].Name}\n\n");

                Random random = new Random();
                int choice = 0;
                string keyBoardInput = string.Empty;

                //battle options
                Print.Options(1, player, medicineBag, weapon, bosses);

                while (true)
                {
                    //every new cycle of fight generate unic damage for player and boss
                    //if player bought weapon, it will generate damage + weapon damage
                    double playerDamage;
                    if (!weapon.Weapon1Bought && !weapon.Weapon2Bought)
                    {
                        playerDamage = player.GenerateDamage();
                    }
                    else playerDamage = player.GenerateDamage(weapon);

                    double bossDamage = bosses[indexOfBoss].GenerateDamage();

                    Console.Write("choose action: ".PadLeft(41, ' '));
                    Console.ForegroundColor = ConsoleColor.Green;
                    keyBoardInput = Console.ReadLine();
                    int.TryParse(keyBoardInput, out int battleChoice);
                    Console.ResetColor();

                    //manual fight
                    if (battleChoice == 1)
                    {
                        bosses[indexOfBoss].CurrentHealth -= playerDamage;

                        //if the boss is dead
                        if (bosses[indexOfBoss].CurrentHealth <= 0)
                        {
                            BossIsDead();

                            //check if player has enough experience to get new level
                            player.LevelUp(player.Exp);
                            player.Turn(player, bosses, playerDamage, indexOfBoss);
                            Print.PlayerStatistics(player, weapon);
                            Print.PressEnter();
                            Console.Clear();
                            break;
                        }

                        player.CurrentHealth -= bossDamage;

                        player.Turn(player, bosses, playerDamage, indexOfBoss);
                        bosses[indexOfBoss].Turn(player, bosses, bossDamage, indexOfBoss);
                        //if the player is dead
                        if (player.CurrentHealth <= 0) break;
                    }

                    //automatic fight
                    if (battleChoice == 2)
                    {
                        while (player.CurrentHealth > 0 || bosses[indexOfBoss].CurrentHealth > 0)
                        {
                            //every new cycle of fight generate unic damage for player and boss
                            //if player bought weapon, it will generate damage + weapon damage
                            if (!weapon.Weapon1Bought && !weapon.Weapon2Bought)
                            {
                                playerDamage = player.GenerateDamage();
                            }
                            else playerDamage = player.GenerateDamage(weapon);
                            
                            bossDamage = bosses[indexOfBoss].GenerateDamage();
                            bosses[indexOfBoss].CurrentHealth -= playerDamage;

                            //if the boss is dead
                            if (bosses[indexOfBoss].CurrentHealth <= 0)
                            {
                                BossIsDead();

                                //check if player has enough experience to get new level
                                player.LevelUp(player.Exp);
                                player.Turn(player, bosses, playerDamage, indexOfBoss);
                                Print.PlayerStatistics(player, weapon);
                                Print.PressEnter();
                                Console.Clear();
                                break;
                            }

                            player.CurrentHealth -= bossDamage;

                            player.Turn(player, bosses, playerDamage, indexOfBoss);
                            bosses[indexOfBoss].Turn(player, bosses, bossDamage, indexOfBoss);
                            //if the player is dead
                            if (player.CurrentHealth <= 0) break;
                            //continue battle
                            else Thread.Sleep(500);
                        }

                        break;
                    }

                    //battle optins => healing options
                    if (battleChoice == 3)
                    {
                        //print healing options
                        Print.Options(2, player, medicineBag, weapon, bosses);

                        choice = 0;
                        while (choice == 0 || choice > 3)
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
                                    Print.Text("\n\tmax health\n\n", ConsoleColor.DarkGreen);
                                }

                                //if not => heal
                                else Print.Text($"\n\t+{medicineBag.HealingPower} health. {player.Name} have {player.CurrentHealth} now\n\n", ConsoleColor.DarkGreen);

                                //boss does his turn, after you used yours for healing
                                player.CurrentHealth -= bosses[indexOfBoss].Damage;
                                bosses[indexOfBoss].Turn(player, bosses, bossDamage, indexOfBoss);

                                //if you died after this attack
                                if (player.CurrentHealth <= 0) break;
                            }

                            //if you don't have any potions
                            else
                            {
                                Print.Text($"\n\tYou don't have {medicineBag.Name}\n\n", ConsoleColor.DarkRed);

                                //boss does his turn, after you used yours for healing
                                player.CurrentHealth -= bosses[indexOfBoss].Damage;
                                bosses[indexOfBoss].Turn(player, bosses, bossDamage, indexOfBoss);

                                //if you died after this attack
                                if (player.CurrentHealth <= 0) break;
                            }
                        }

                        //if you want to exit healing options and return to the battle options
                        if (keyBoardInput == "<")
                        {
                            Print.Text("\n");
                            continue;
                        }
                    }

                    //trying to run away from the enemy
                    if (battleChoice == 4)
                    {
                        //you can't escape from boss
                        Print.Text($"\n\tyou can't escape from the {bosses[indexOfBoss].Name}\n", ConsoleColor.DarkRed);
                        CritDamage(bosses[indexOfBoss], bossDamage);

                        if (player.CurrentHealth <= 0) break;
                    }
                }

                if (player.CurrentHealth <= 0) break;
                if (bosses[indexOfBoss].CurrentHealth <= 0) break;

                //local function to generate the boss damage with multiplier, which is also generating randomly
                void CritDamage(Character boss, double bossDamage)
                {
                    int criticalDamageMultiplier = random.Next(2, 4);

                    player.CurrentHealth -= bossDamage * criticalDamageMultiplier;

                    if (player.CurrentHealth <= 0)
                    {
                        Print.Text($"\n\t{boss.Name} made a ");
                        Print.Text("CRITICAL ", ConsoleColor.Red);
                        Print.Text($"attack {bossDamage * criticalDamageMultiplier} damage, {player.Name} get");
                        Print.Text($" fatal ", ConsoleColor.DarkRed);
                        Print.Text($"damage and has {player.CurrentHealth} health\n\n");
                    }

                    else
                    {
                        Print.Text($"\n\t{boss.Name} made a ");
                        Print.Text("CRITICAL ", ConsoleColor.Red);
                        Print.Text($"attack {bossDamage * criticalDamageMultiplier} damage, {player.Name} have {player.CurrentHealth} now\n\n");
                    }
                }

                void BossIsDead()
                {
                    DefeatedBossesOverall++;
                    bosses[indexOfBoss].IsDead = true;
                    player.Gold += bosses[indexOfBoss].Gold;
                    player.Exp += bosses[indexOfBoss].Exp;
                }
            }
        }
    }
}
