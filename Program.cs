using System;
using System.Threading;

namespace EternityRPG
{
    class Program
    {
        private static int DefeatedEnemiesToFightTheBoss { get; set; }
        public static int DefeatedEnemiesOverall { get; set; }
        public static int DefeatedBossesOverall { get; set; }
        private static int index { get; set; }

        private static Random random = new Random();
        private static Player player = new Player();
        private static Biome biome;
        private static Enemy enemy;

        private static Item[] inventory;

        private static Enemy[] bosses = new Enemy[]
        {
            new boss1(),
            new boss2(),
            new boss3(),
            new boss4()
        };

        static void Main(string[] args)
        {
            string YesOrNo = string.Empty;
            string input = string.Empty;
            int selectDirection = 0;
            int biomeType = 1;
            int choice = 0;

            Print.GameTitle();
            Print.PressEnter();
            Print.RainbowLoading();
            Console.Clear();
            Print.Text("Hello, traveler. I can't remember your", ConsoleColor.Cyan);
            Print.Text(" name ", ConsoleColor.DarkYellow);
            Print.Text("Can you help me with this?\n\n", ConsoleColor.Cyan);
            Thread.Sleep(2000);

            while (YesOrNo.ToLower() != "y")
            {
                YesOrNo = string.Empty;

                //selection of player's name
                Print.Text("Enter your name or press ENTER: ");

                Console.ForegroundColor = ConsoleColor.Green;
                input = Console.ReadLine();
                Console.ResetColor();

                player.SetName(input);

                //selection of player's gender
                Print.GenderOptions();
                choice = 0;
                while (choice == 0 || choice > 2)
                {
                    Print.Text("choose gender: ".PadLeft(47, ' '));
                    Console.ForegroundColor = ConsoleColor.Green;
                    input = Console.ReadLine();
                    int.TryParse(input, out choice);
                    Console.ResetColor();

                    player.SetGender(choice);
                }

                //selection of the player's class
                Print.PlayerClassOptions();
                choice = 0;
                while (choice == 0 || choice > 3)
                {
                    Print.Text("choose class: ".PadLeft(46, ' '));
                    Console.ForegroundColor = ConsoleColor.Green;
                    input = Console.ReadLine();
                    int.TryParse(input, out choice);
                    Console.ResetColor();

                    player.SetClass(choice);
                }
                Console.Clear();

                //card of player before start of the game
                Print.PlayerShortInfo(player);

                YesOrNo = string.Empty;
                while (YesOrNo.ToLower() != "y" && YesOrNo.ToLower() != "n")
                {
                    Print.Text("Are you ready to start the adventure with this character?");
                    Print.Text(" [y] ", ConsoleColor.Green);
                    Print.Text("/");
                    Print.Text(" [n]", ConsoleColor.Green);
                    Print.Text(": ");

                    Console.ForegroundColor = ConsoleColor.Green;
                    YesOrNo = Console.ReadLine();
                    Console.ResetColor();
                }
                Console.Clear();
            }
            Console.Clear();

            //creating player and weapon according to chosen class
            player = player.CreatePlayer();

            inventory = new Item[]
            {
                new Potion(90, 30, "small healing potion"),
                new Potion(180, 90, "medium healing potion"),
                new Potion(350, 150, "big healing potion"),
                new Weapon1(player.Class),
                new Weapon2(player.Class)
            };

            Print.Text("The adventure begins\n\n");
            Print.RainbowLoading();
            Console.Clear();

            //section of the main gameplay
            while (true)
            {
                //shop
                if (selectDirection == 1)
                {
                    Console.Clear();

                    YesOrNo = string.Empty;
                    while (YesOrNo.ToLower() != "n")
                    {
                        Print.ShopOptions(player, inventory);

                        int choiceInTheShop = 0;
                        while (choiceInTheShop == 0 || choiceInTheShop > 5)
                        {
                            Console.Write("make your choice: ".PadLeft(44, ' '));
                            Console.ForegroundColor = ConsoleColor.Green;
                            input = Console.ReadLine();
                            int.TryParse(input, out choiceInTheShop);
                            Console.ResetColor();

                            if (input == "<")
                            {
                                Console.Clear();
                                break;
                            }
                        }

                        //exit from the shop
                        if (input == "<") break;
                        //continue bwosing in the shop
                        else if (choiceInTheShop == 1) inventory[0].Add(player, inventory, choiceInTheShop);
                        else if (choiceInTheShop == 2) inventory[1].Add(player, inventory, choiceInTheShop);
                        else if (choiceInTheShop == 3) inventory[2].Add(player, inventory, choiceInTheShop);
                        else if (choiceInTheShop == 4) inventory[3].Add(player, inventory, choiceInTheShop);
                        else if (choiceInTheShop == 5) inventory[4].Add(player, inventory, choiceInTheShop);

                        YesOrNo = string.Empty;
                        while (YesOrNo.ToLower() != "y" && YesOrNo.ToLower() != "n")
                        {
                            Print.Text("\n" + "anything else?".PadLeft(40, ' '));
                            Print.Text(" [y] ", ConsoleColor.Green);
                            Print.Text("/");
                            Print.Text(" [n]", ConsoleColor.Green);
                            Print.Text(": ");

                            Console.ForegroundColor = ConsoleColor.Green;
                            YesOrNo = Console.ReadLine();
                            Console.ResetColor();

                            if (YesOrNo.ToLower() == "y" || YesOrNo.ToLower() == "n") Console.Clear();
                        }
                    }
                    selectDirection = 2;
                }

                //select between locations
                if (selectDirection == 2)
                {
                    Print.SelectLocation(bosses);

                    biomeType = 0;

                    //if all bosses are dead, you can see menu with the last location
                    int deathCounter = 0;
                    foreach (var boss in bosses) if (boss.IsDead) deathCounter++;

                    if (deathCounter == 3)
                    {
                        while (biomeType == 0 || biomeType > 4)
                        {
                            Console.Write("make your choice: ".PadLeft(44, ' '));
                            Console.ForegroundColor = ConsoleColor.Green;
                            int.TryParse(Console.ReadLine(), out biomeType);
                            Console.ResetColor();

                            index = biomeType - 1;
                        }
                    }

                    //if not, you can choose between three locations
                    else
                    {
                        while (biomeType == 0 || biomeType > 3)
                        {
                            Console.Write("make your choice: ".PadLeft(44, ' '));
                            Console.ForegroundColor = ConsoleColor.Green;
                            int.TryParse(Console.ReadLine(), out biomeType);
                            Console.ResetColor();

                            index = biomeType - 1;
                        }
                    }
                }
                Console.Clear();

                //create location according to the number of chosen location
                biome = new Biome(biomeType);

                //enter to the secret location, if you already killed three bosses
                if (biomeType == 4)
                {
                    YesOrNo = string.Empty;
                    while (YesOrNo.ToLower() != "y" && YesOrNo.ToLower() != "n")
                    {
                        Print.Text($"Are you ready for final battle?");
                        Print.Text(" [y] ", ConsoleColor.Cyan);
                        Print.Text("/");
                        Print.Text(" [n]", ConsoleColor.Cyan);
                        Print.Text(": ");

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        YesOrNo = Console.ReadLine();
                        Console.ResetColor();
                    }
                    Console.Clear();

                    //final fight of the game
                    if (YesOrNo.ToLower() == "y")
                    {
                        BattleZone(bossBattle: true);

                        //if you win final battle
                        if (bosses[index].CurrentHealth <= 0)
                        {
                            Console.Clear();
                            Print.TheEnd(player, inventory);
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
                    Print.Text($"{biome.LocationInfo}\n", ConsoleColor.DarkGreen, slowText: true);
                    //start battle section with regular enemies
                    BattleZone();
                }

                //if you killed enough enemies in the location, you can fight with boss of this location, if it is not dead
                if (DefeatedEnemiesToFightTheBoss == bosses[index].CounterToReachTheBoss && !bosses[index].IsDead)
                {
                    Print.BoosFight();
                    Print.Text($"\tGet ready for battle, the {bosses[index].Name} is coming...\n\n");
                    Print.PressEnter();
                    Console.Clear();
                    //start boss fight
                    BattleZone(bossBattle: true);
                }

                //if you were killed in the battle
                if (player.CurrentHealth <= 0)
                {
                    Print.YouDied();
                    break;
                }

                //change your direction
                Print.ChangeDirection();

                selectDirection = 0;
                while (selectDirection == 0 || selectDirection > 3)
                {
                    Print.Text("make your choice: ".PadLeft(32, ' '));
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    int.TryParse(Console.ReadLine(), out selectDirection);
                    Console.ResetColor();

                    //show status information
                    if (selectDirection == 3)
                    {
                        Print.PlayerStatistics(player, inventory);
                        selectDirection = 0;
                        continue;
                    }
                }

                Console.Clear();
            }
        }

        public static void BattleZone(bool bossBattle = false)
        {
            if (!bossBattle)
            {
                //setting counter of defeated enemies to 0 before the start of each battle
                DefeatedEnemiesToFightTheBoss = 0;
            }

            string YesOrNo = string.Empty;
            while (YesOrNo.ToLower() != "n")
            {
                int choice = 0;
                string keyBoardInput = string.Empty;
                YesOrNo = string.Empty;

                //printing short name of the location before each regular enemy
                Print.Text($"Location: {biome.ShortTitle}\n", ConsoleColor.DarkCyan);

                if (!bossBattle)
                {
                    //create new enemy randomly every time when the cycle starts again, according to the chosen location
                    enemy = biome.CreateEnemy();
                    Print.RainbowLoading(random.Next(1, 9));

                    //print randomly generated phrase when new enemy appear
                    Print.Text(Print.EntryBattlePhrase(enemy));
                }

                else
                {
                    enemy = bosses[index];
                    Print.Text($"\n{enemy.Name}\n\n");
                }

                Print.BattleOptions();

                while (true)
                {
                    //every new cycle of fight generate unic damage for player and enemy
                    double playerDamage = PlayerDamage();
                    double enemyDamage = enemy.GenerateDamage();

                    Console.Write("choose action: ".PadLeft(41, ' '));
                    Console.ForegroundColor = ConsoleColor.Green;
                    keyBoardInput = Console.ReadLine();
                    int.TryParse(keyBoardInput, out int battleChoice);
                    Console.ResetColor();

                    //manual fight
                    if (battleChoice == 1)
                    {
                        if (random.Next(0, 100) > player.CritChance)
                            player.Attack(player, enemy, playerDamage);
                        else
                            player.SpecialAttack(player, enemy, playerDamage);

                        //if an enemy is dead
                        if (enemy.CurrentHealth <= 0)
                        {
                            player.Gold += enemy.Gold;
                            player.Exp += enemy.Exp;
                            //check if player has enough experience to get new level
                            player.LevelUp(player.Exp);
                            Print.PlayerStatistics(player, inventory);

                            if (!bossBattle)
                            {
                                DefeatedEnemiesOverall++;
                                DefeatedEnemiesToFightTheBoss++;
                                break;
                            }

                            else
                            {
                                DefeatedBossesOverall++;
                                Print.PressEnter();
                                Console.Clear();
                                break;
                            }
                        }

                        if (random.Next(0, 100) > enemy.CritChance)
                            enemy.Attack(player, enemy, enemyDamage);
                        else
                            enemy.SpecialAttack(player, enemy, enemyDamage);

                        //if the player is dead
                        if (player.CurrentHealth <= 0) break;
                    }

                    //automatic fight
                    if (battleChoice == 2)
                    {
                        while (player.CurrentHealth > 0 || enemy.CurrentHealth > 0)
                        {
                            //every new cycle of fight generate unic damage for player and enemy
                            playerDamage = PlayerDamage();
                            enemyDamage = enemy.GenerateDamage();

                            if (random.Next(0, 100) > player.CritChance)
                                player.Attack(player, enemy, playerDamage);
                            else
                                player.SpecialAttack(player, enemy, playerDamage);

                            //if an enemy is dead
                            if (enemy.CurrentHealth <= 0)
                            {
                                player.Gold += enemy.Gold;
                                player.Exp += enemy.Exp;
                                //check if player has enough experience to get new level
                                player.LevelUp(player.Exp);
                                Print.PlayerStatistics(player, inventory);

                                if (!bossBattle)
                                {
                                    DefeatedEnemiesOverall++;
                                    DefeatedEnemiesToFightTheBoss++;
                                    break;
                                }

                                else
                                {
                                    DefeatedBossesOverall++;
                                    Print.PressEnter();
                                    Console.Clear();
                                    break;
                                }
                            }

                            if (random.Next(0, 100) > enemy.CritChance)
                                enemy.Attack(player, enemy, enemyDamage);
                            else
                                enemy.SpecialAttack(player, enemy, enemyDamage);

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
                        Print.HealingOptions(inventory);

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

                        if (choice == 1 || choice == 2 || choice == 3)
                        {
                            //if you have potion
                            if (inventory[choice - 1].Amount > 0)
                            {
                                inventory[choice - 1].Use(player, inventory, choice);

                                //if player's current health equal or greater than maximum health
                                if (player.CurrentHealth > player.Health)
                                {
                                    player.CurrentHealth = player.Health;
                                    Print.Text("\n\tmax health\n", ConsoleColor.DarkGreen);
                                }

                                //if not => heal
                                else Print.Text($"\n\t+{inventory[choice - 1].HealingPower} health. {player.Name} have {player.CurrentHealth} now\n", ConsoleColor.DarkGreen);

                                //enemy does his turn, after you used yours for healing
                                enemy.Attack(player, enemy, enemyDamage);

                                //if you died after this attack
                                if (player.CurrentHealth <= 0) break;
                            }

                            //if you don't have any potions
                            else
                            {
                                Print.Text($"\n\tYou don't have {inventory[choice - 1].Title}\n", ConsoleColor.DarkRed);

                                //boss does his turn, after you used yours for healing
                                enemy.Attack(player, enemy, enemyDamage);

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
                        //if you succeed in escaping
                        if (random.Next(0, 100) > enemy.ChanceToInterruptTheEscape)
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
                        else if (enemy.ChanceToInterruptTheEscape == 100)
                        {
                            Print.Text($"\n\tyou can't escape from the {enemy.Name}\n", ConsoleColor.DarkRed);
                            //if you failed to escape, an enemy does his critical attack
                            enemy.SpecialAttack(player, enemy, enemyDamage);

                            if (player.CurrentHealth <= 0) break;
                        }

                        else
                        {
                            Print.Text("\n\tfailed to escape\n", ConsoleColor.DarkRed);
                            //if you failed to escape, an enemy does his critical attack
                            enemy.SpecialAttack(player, enemy, enemyDamage);

                            if (player.CurrentHealth <= 0) break;
                            else continue;
                        }
                    }
                }

                if (player.CurrentHealth <= 0) break;
                if (bosses[index].CurrentHealth <= 0) break;
                if (DefeatedEnemiesToFightTheBoss == bosses[index].CounterToReachTheBoss && !bosses[index].IsDead) break;

                //asking if you want to continue grinding or not
                YesOrNo = string.Empty;
                while (YesOrNo.ToLower() != "y" && YesOrNo.ToLower() != "n")
                {
                    Print.Text($"Farm more at the {biome.ShortTitle}?");
                    Print.Text(" [y] ", ConsoleColor.Cyan);
                    Print.Text("/");
                    Print.Text(" [n]", ConsoleColor.Cyan);
                    Print.Text(": ");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    YesOrNo = Console.ReadLine();
                    Console.ResetColor();

                    if (YesOrNo.ToLower() == "y" || YesOrNo.ToLower() == "n") Console.Clear();
                }

                double PlayerDamage()
                {
                    double playerDamage;
                    //if player bought weapon, it will generate damage + weapon damage
                    if (!inventory[3].WeaponIsBought && !inventory[4].WeaponIsBought)
                        playerDamage = player.GenerateDamage();
                    else
                        playerDamage = player.GenerateDamage(inventory);

                    return playerDamage;
                }
            }
        }
    }
}
