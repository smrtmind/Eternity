using System;
using System.Threading;

namespace EternityRPG
{
    class Program
    {
        private static int DefeatedEnemiesToFightTheBoss { get; set; }
        public static int DefeatedEnemiesOverall { get; set; }
        public static int DefeatedBossesOverall { get; set; }
        private static int bossType { get; set; }

        private static Random random = new Random();
        private static Player player = new Player();
        public static Item[] inventory;
        private static Biome biome;
        private static Enemy enemy;

        private static Enemy[] bosses = new Enemy[]
        {
            new Boss(bossType: 1),
            new Boss(bossType: 2),
            new Boss(bossType: 3),
            new Boss(bossType: 4)
        };

        static void Main(string[] args)
        {
            string yesOrNo = string.Empty;
            string input = string.Empty;
            int choice = default;

            Print.GameTitle();
            Print.PressEnter();
            Print.RainbowLoading();
            Console.Clear();
            Print.Text("Hello, traveler. I can't remember your", ConsoleColor.Cyan);
            Print.Text(" name ", ConsoleColor.DarkYellow);
            Print.Text("Can you help me with this?\n\n", ConsoleColor.Cyan);
            Thread.Sleep(2000);

            //******************** SECTION OF CREATING A PLAYER ********************
            while (yesOrNo != "y")
            {
                yesOrNo = string.Empty;

                //selection of player's name
                Print.Text("Enter your name or press ENTER: ");
                Console.ForegroundColor = ConsoleColor.Green;
                input = Console.ReadLine();
                Console.ResetColor();

                player.SetName(input);

                //selection of player's gender
                Print.GenderOptions();
                choice = default;
                while (choice == 0 || choice > 2)
                {
                    Print.Text("choose gender: ".PadLeft(47, ' '));
                    Console.ForegroundColor = ConsoleColor.Green;
                    input = Console.ReadLine();
                    int.TryParse(input, out choice);
                    Console.ResetColor();

                    player.SetGender(choice);
                }

                //selection of player's class
                Print.PlayerClassOptions();
                choice = default;
                while (choice == 0 || choice > 3)
                {
                    Print.Text("choose class: ".PadLeft(46, ' '));
                    Console.ForegroundColor = ConsoleColor.Green;
                    input = Console.ReadLine();
                    int.TryParse(input, out choice);
                    Console.ResetColor();

                    player.SetClass(choice);
                }

                yesOrNo = string.Empty;
                while (yesOrNo != "y" && yesOrNo != "n")
                {
                    Console.Clear();
                    //card of player before start of the game
                    Print.PlayerShortInfo(player);
                    Print.Question("Are you ready to start the adventure with this character?");

                    Console.ForegroundColor = ConsoleColor.Green;
                    yesOrNo = Console.ReadLine().ToLower();
                    Console.ResetColor();
                }
                Console.Clear();
            }

            //creating player and weapons according to chosen class
            player = player.CreatePlayer();
            inventory = new Item[]
            {
                new Potion(potionType: 1),
                new Potion(potionType: 2),
                new Potion(potionType: 3),
                new Weapon(player.Class, weaponType: 1),
                new Weapon(player.Class, weaponType: 2)
            };

            Print.Text("The adventure begins\n");
            Print.RainbowLoading();
            Console.Clear();

            //******************** SECTION OF THE MAIN GAMEPLAY ********************
            while (true)
            {
                //******************** CHOOSING DIRECTION ********************
                int selectDirection = default;
                while (selectDirection == 0 || selectDirection > 3)
                {
                    Console.Clear();
                    //change your direction
                    Print.ChangeDirection();

                    Print.Text("make your choice: ".PadLeft(23, ' '));
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    int.TryParse(Console.ReadLine(), out selectDirection);
                    Console.ResetColor();
                }

                //******************** SHOP ********************
                if (selectDirection == 1)
                {
                    input = string.Empty;
                    while (input != "<")
                    {
                        Console.Clear();
                        Print.ShopOptions(player, inventory);
                        Console.Write("make your choice: ".PadLeft(44, ' '));

                        Console.ForegroundColor = ConsoleColor.Green;
                        input = Console.ReadLine();
                        Console.ResetColor();

                        //exit from the shop
                        if (input == "<") break;

                        int.TryParse(input, out choice);
                        //trying to buy something
                        if (choice > 0 && choice <= inventory.Length)
                            inventory[choice - 1].Buy(player, inventory, choice);
                    }
                }

                //******************** LOCATIONS ********************
                if (selectDirection == 2)
                {
                    int maxLocations;
                    int deathCounter = default;

                    //checking if you killed enough bosses to unlock final location
                    foreach (var boss in bosses)
                        if (boss.IsDead)
                            deathCounter++;

                    if (deathCounter == bosses.Length - 1) maxLocations = 4;
                    else maxLocations = 3;

                    choice = default;
                    while (choice == 0 || choice > maxLocations)
                    {
                        Console.Clear();
                        Print.SelectLocation(bosses);
                        Console.Write("make your choice: ".PadLeft(44, ' '));

                        Console.ForegroundColor = ConsoleColor.Green;
                        input = Console.ReadLine();
                        Console.ResetColor();

                        //exit from choosing locations
                        if (input == "<") break;

                        int.TryParse(input, out choice);
                    }
                    if (input == "<") continue;

                    //create location according to the number of chosen location
                    biome = new Biome(choice);
                    bossType = choice - 1;

                    //enter to the secret location, if you already killed three bosses
                    if (choice == 4)
                    {
                        yesOrNo = string.Empty;
                        while (yesOrNo != "y" && yesOrNo != "n")
                        {
                            Console.Clear();
                            Print.Question($"Are you ready for final battle?", ConsoleColor.Cyan);

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            yesOrNo = Console.ReadLine().ToLower();
                            Console.ResetColor();
                        }
                        Console.Clear();

                        //final fight of the game
                        if (yesOrNo == "y")
                        {
                            BattleZone(bossBattle: true);

                            //if you win final battle
                            if (bosses[bossType].IsDead)
                            {
                                Console.Clear();
                                Print.TheEnd(player, inventory);
                                break;
                            }
                        }
                    }

                    //starting battle section according to the chosen location
                    else
                    {
                        Console.Clear();
                        //printing full info about the location, only once in each location, according to the chosen location
                        Print.Text($"{biome.LocationInfo}\n", ConsoleColor.DarkGreen, slowText: true);
                        //start battle section with regular enemies
                        BattleZone();
                    }
                }

                //******************** PLAYER STATS ********************
                if (selectDirection == 3)
                {
                    Print.PlayerStatistics(player, inventory);
                    Print.PressEnter();
                }

                //if you killed enough enemies in the location, you can fight with boss of this location, if it is not dead
                if (DefeatedEnemiesToFightTheBoss == bosses[bossType].CounterToReachTheBoss && !bosses[bossType].IsDead)
                {
                    Print.BoosFight();
                    Print.Text($"\tGet ready for battle, the {bosses[bossType].Name} is coming...\n\n");
                    Print.PressEnter();
                    Console.Clear();
                    //start boss fight
                    BattleZone(bossBattle: true);
                }

                //if you were killed in the battle
                if (player.IsDead) break;
            }
        }

        //******************** SECTION OF BATTLE LOGIC ********************
        public static void BattleZone(bool bossBattle = false)
        {
            if (!bossBattle)
            {
                //setting counter of defeated enemies to 0 before the start of each battle
                DefeatedEnemiesToFightTheBoss = 0;
            }

            string yesOrNo = string.Empty;
            while (yesOrNo.ToLower() != "n")
            {
                int choice = default;
                string keyBoardInput = string.Empty;
                yesOrNo = string.Empty;

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
                    enemy = bosses[bossType];
                    Print.Text($"\n{enemy.Name}\n\n");
                }

                Print.BattleOptions();

                while (true)
                {
                    Console.Write("choose action: ".PadLeft(41, ' '));
                    Console.ForegroundColor = ConsoleColor.Green;
                    keyBoardInput = Console.ReadLine();
                    int.TryParse(keyBoardInput, out int battleChoice);
                    Console.ResetColor();

                    //manual fight - 1 && automatic fight - 2
                    if (battleChoice == 1 || battleChoice == 2)
                    {
                        while (player.HP > 0 || enemy.HP > 0)
                        {
                            NextAttack(player, PlayerDamage());

                            //if an enemy is dead
                            if (enemy.IsDead)
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
                                    return;
                                }
                            }

                            NextAttack(enemy, enemy.GenerateDamage());

                            //if the player is dead
                            if (player.IsDead) return;
                            //if the player has low hp
                            if (player.HP <= 20) break;
                            //if manual fight, break to choose next option
                            if (battleChoice == 1) break;
                            //else continue automatic fight 
                            else Thread.Sleep(500);
                        }

                        if (enemy.IsDead) break;
                    }

                    //battle optins => healing options
                    if (battleChoice == 3)
                    {
                        Print.HealingOptions(inventory);

                        choice = default;
                        while (choice == 0 || choice > 3)
                        {
                            Console.Write("make your choice: ".PadLeft(44, ' '));
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            keyBoardInput = Console.ReadLine();
                            int.TryParse(keyBoardInput, out choice);
                            Console.ResetColor();

                            if (keyBoardInput == "<")
                            {
                                Print.Text("\n");
                                break;
                            }
                        }

                        if (choice > 0 && choice <= 3)
                        {
                            //if you have potion
                            if (inventory[choice - 1].Amount > 0)
                            {
                                inventory[choice - 1].Use(player, inventory, choice);

                                //if player's current health equal or greater than maximum health
                                if (player.HP > player.MaxHP)
                                {
                                    player.HP = player.MaxHP;
                                    Print.Text("\n\tmax health\n", ConsoleColor.DarkGreen);
                                }

                                //if not => heal
                                else Print.Text($"\n\t+{inventory[choice - 1].HealingPower} health. {player.Name} have {player.HP} now\n", ConsoleColor.DarkGreen);
                            }

                            //if you don't have any potions
                            else Print.Text($"\n\tYou don't have {inventory[choice - 1].Title}\n", ConsoleColor.DarkRed);

                            //enemy does his turn, after you tried to heal
                            NextAttack(enemy, enemy.GenerateDamage());

                            //if the player is dead
                            if (player.IsDead) return;
                        }
                    }

                    //trying to run away from the enemy
                    if (battleChoice == 4)
                    {
                        //calculating the player's chance to escape randomly
                        //if you succeed in escaping
                        if (random.Next(0, 100) > enemy.ChanceToInterruptTheEscape)
                        {
                            //lost 10 percent of all gold you own
                            double penalty = (int)((player.Gold / 100) * 10);
                            player.Gold -= penalty;

                            if (player.Gold <= 0) player.Gold = 0;

                            Print.Text("\n\tYou escaped successfully", ConsoleColor.DarkGreen);
                            Print.Text($"\n\t-{penalty} gold", ConsoleColor.DarkRed);
                            Print.Text(", ");
                            Print.Text($"{player.Gold} gold ", ConsoleColor.DarkYellow);
                            Print.Text("remaining\n\n");

                            Print.PressEnter();
                            Console.Clear();
                            return;
                        }

                        //you can't avoid a battle with some enemies
                        else
                        {
                            if (enemy.ChanceToInterruptTheEscape == 100)
                                Print.Text($"\n\tyou can't escape from the {enemy.Name}\n", ConsoleColor.DarkRed);
                            else
                                Print.Text("\n\tfailed to escape\n", ConsoleColor.DarkRed);

                            //if you failed to escape, an enemy does his attack
                            NextAttack(enemy, enemy.GenerateDamage());

                            //if the player is dead
                            if (player.IsDead) return;
                        }
                    }
                }

                if (DefeatedEnemiesToFightTheBoss == bosses[bossType].CounterToReachTheBoss && !bosses[bossType].IsDead) return;

                //asking if you want to continue grinding or not
                yesOrNo = string.Empty;
                while (yesOrNo != "y" && yesOrNo != "n")
                {
                    Print.Question($"Farm more at the {biome.ShortTitle}?", ConsoleColor.Cyan);

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    yesOrNo = Console.ReadLine().ToLower();
                    Console.ResetColor();

                    if (yesOrNo == "y" || yesOrNo == "n")
                        Console.Clear();
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

                void NextAttack(Character attacker, double damage)
                {
                    if (random.Next(0, 100) > attacker.CritChance)
                        attacker.Attack(player, enemy, damage);
                    else
                        attacker.Attack(player, enemy, damage, crit: true);
                }
            }
        }
    }
}
