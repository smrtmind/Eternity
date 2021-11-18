using System;
using System.Threading;

namespace EternityRPG
{
    class Program
    {
        private static int biomeType { get; set; }

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

                Game.player.SetName(input);

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

                    Game.player.SetGender(choice);
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

                    Game.player.SetClass(choice);
                }

                yesOrNo = string.Empty;
                while (yesOrNo != "y" && yesOrNo != "n")
                {
                    Console.Clear();
                    //card of player before start of the game
                    Print.PlayerShortInfo(Game.player);
                    Print.Question("Are you ready to start the adventure with this character?");

                    Console.ForegroundColor = ConsoleColor.Green;
                    yesOrNo = Console.ReadLine().ToLower();
                    Console.ResetColor();
                }
                Console.Clear();
            }

            //creating player and weapons according to chosen class
            Game.player = Game.player.CreatePlayer();
            Game.InitializeWorld();
            
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
                        Print.ShopOptions(Game.player, Game.inventory);
                        Console.Write("make your choice: ".PadLeft(44, ' '));

                        Console.ForegroundColor = ConsoleColor.Green;
                        input = Console.ReadLine();
                        Console.ResetColor();

                        //exit from the shop
                        if (input == "<") break;

                        int.TryParse(input, out choice);
                        //trying to buy something
                        if (choice > 0 && choice <= Game.inventory.Length)
                            Game.inventory[choice - 1].Buy(Game.player, Game.inventory, choice);
                    }
                }

                //******************** LOCATIONS ********************
                if (selectDirection == 2)
                {
                    int maxLocations;
                    int deathCounter = default;

                    //checking if you killed enough bosses to unlock final location
                    foreach (var boss in Game.bosses)
                        if (boss.IsDead)
                            deathCounter++;

                    if (deathCounter == Game.bosses.Length - 1) 
                        maxLocations = Game.biomes.Length;
                    else 
                        maxLocations = Game.biomes.Length - 1;

                    choice = default;
                    while (choice == 0 || choice > maxLocations)
                    {
                        Console.Clear();
                        Print.SelectLocation(Game.bosses, Game.biomes, maxLocations);
                        Console.Write("make your choice: ".PadLeft(44, ' '));

                        Console.ForegroundColor = ConsoleColor.Green;
                        input = Console.ReadLine();
                        Console.ResetColor();

                        //exit from choosing locations
                        if (input == "<") break;

                        int.TryParse(input, out choice);
                        //create location according to the number of chosen location
                        biomeType = choice - 1;
                    }
                    if (input == "<") continue;

                    //enter to the secret location, if you already killed three bosses
                    if (choice == Game.biomes.Length)
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
                            if (Game.bosses[biomeType].IsDead)
                            {
                                Console.Clear();
                                Print.TheEnd(Game.player, Game.inventory);
                                break;
                            }
                        }
                    }

                    //starting battle section according to the chosen location
                    else
                    {
                        Console.Clear();
                        //printing full info about the location, only once in each location, according to the chosen location
                        Print.Text($"{Game.biomes[biomeType].LocationInfo}\n", ConsoleColor.DarkGreen, slowText: true);
                        //start battle section with regular enemies
                        BattleZone();
                    }
                }

                //******************** PLAYER STATS ********************
                if (selectDirection == 3)
                {
                    Print.PlayerStatistics(Game.player, Game.inventory);
                    Print.PressEnter();
                }

                //if you killed enough enemies in the location, you can fight with boss of this location, if it is not dead
                if (Game.DefeatedEnemiesToFightTheBoss == Game.bosses[biomeType].CounterToReachTheBoss && !Game.bosses[biomeType].IsDead)
                {
                    Print.BoosFight();
                    Print.Text($"\tGet ready for battle, the {Game.bosses[biomeType].Name} is coming...\n\n");
                    Print.PressEnter();
                    Console.Clear();
                    //start boss fight
                    BattleZone(bossBattle: true);
                }

                //if you were killed in the battle
                if (Game.player.IsDead) break;
            }
        }

        //******************** SECTION OF BATTLE LOGIC ********************
        public static void BattleZone(bool bossBattle = false)
        {
            if (!bossBattle)
            {
                //setting counter of defeated enemies to 0 before the start of each battle
                Game.DefeatedEnemiesToFightTheBoss = 0;
            }

            string yesOrNo = string.Empty;
            while (yesOrNo.ToLower() != "n")
            {
                int choice = default;
                string keyBoardInput = string.Empty;
                yesOrNo = string.Empty;

                //printing short name of the location before each regular enemy
                Print.Text($"Location: {Game.biomes[biomeType].ShortTitle}\n", ConsoleColor.DarkCyan);

                if (!bossBattle)
                {
                    //create new enemy randomly every time when the cycle starts again, according to the chosen location
                    Game.enemy = Game.biomes[biomeType].CreateEnemy();
                    Print.RainbowLoading(Game.random.Next(1, 9));

                    //print randomly generated phrase when new enemy appear
                    Print.Text(Print.EntryBattlePhrase(Game.enemy));
                }

                else
                {
                    Game.enemy = Game.bosses[biomeType];
                    Print.Text($"\n{Game.enemy.Name}\n\n");
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
                        while (Game.player.HP > 0 || Game.enemy.HP > 0)
                        {
                            NextAttack(Game.player, PlayerDamage());

                            //if an enemy is dead
                            if (Game.enemy.IsDead)
                            {
                                Game.player.Gold += Game.enemy.Gold;
                                Game.player.Exp += Game.enemy.Exp;
                                //check if player has enough experience to get new level
                                Game.player.LevelUp(Game.player.Exp);
                                Print.PlayerStatistics(Game.player, Game.inventory);

                                if (!bossBattle)
                                {
                                    Game.DefeatedEnemiesOverall++;
                                    Game.DefeatedEnemiesToFightTheBoss++;
                                    break;
                                }

                                else
                                {
                                    Game.DefeatedBossesOverall++;
                                    Print.PressEnter();
                                    Console.Clear();
                                    return;
                                }
                            }

                            NextAttack(Game.enemy, Game.enemy.GenerateDamage());

                            //if the player is dead
                            if (Game.player.IsDead) return;
                            //if the player has low hp
                            if (Game.player.HP <= Game.player.DangerousLevelOfHealth()) break;
                            //if manual fight, break to choose next option
                            if (battleChoice == 1) break;
                            //else continue automatic fight 
                            else Thread.Sleep(500);
                        }

                        if (Game.enemy.IsDead) break;
                    }

                    //battle optins => healing options
                    if (battleChoice == 3)
                    {
                        Print.HealingOptions(Game.inventory);

                        choice = default;
                        while (choice == 0 || choice > Game.AmountOfPotions())
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

                        if (choice > 0 && choice <= Game.AmountOfPotions())
                        {
                            //if you have potion
                            if (Game.inventory[choice - 1].Amount > 0)
                            {
                                Game.inventory[choice - 1].Use(Game.player, Game.inventory, choice);

                                //if player's current health equal or greater than maximum health
                                if (Game.player.HP > Game.player.MaxHP)
                                {
                                    Game.player.HP = Game.player.MaxHP;
                                    Print.Text("\n\tmax health\n", ConsoleColor.DarkGreen);
                                }

                                //if not => heal
                                else Print.Text($"\n\t+{Game.inventory[choice - 1].HealingPower} health. {Game.player.Name} have {Game.player.HP} now\n", ConsoleColor.DarkGreen);
                            }

                            //if you don't have any potions
                            else Print.Text($"\n\tYou don't have {Game.inventory[choice - 1].Title} healing potion\n", ConsoleColor.DarkRed);

                            //enemy does his turn, after you tried to heal
                            NextAttack(Game.enemy, Game.enemy.GenerateDamage());

                            //if the player is dead
                            if (Game.player.IsDead) return;
                        }
                    }

                    //trying to run away from the enemy
                    if (battleChoice == 4)
                    {
                        //calculating the player's chance to escape randomly
                        //if you succeed in escaping
                        if (Game.random.Next(0, 100) > Game.enemy.ChanceToInterruptTheEscape)
                        {
                            //lost 10 percent of all gold you own
                            double penalty = (int)((Game.player.Gold / 100) * 10);
                            Game.player.Gold -= penalty;

                            if (Game.player.Gold <= 0) Game.player.Gold = 0;

                            Print.Text("\n\tYou escaped successfully", ConsoleColor.DarkGreen);
                            Print.Text($"\n\t-{penalty} gold", ConsoleColor.DarkRed);
                            Print.Text(", ");
                            Print.Text($"{Game.player.Gold} gold ", ConsoleColor.DarkYellow);
                            Print.Text("remaining\n\n");

                            Print.PressEnter();
                            Console.Clear();
                            return;
                        }

                        //you can't avoid a battle with some enemies
                        else
                        {
                            if (Game.enemy.ChanceToInterruptTheEscape == 100)
                                Print.Text($"\n\tyou can't escape from the {Game.enemy.Name}\n", ConsoleColor.DarkRed);
                            else
                                Print.Text("\n\tfailed to escape\n", ConsoleColor.DarkRed);

                            //if you failed to escape, an enemy does his attack
                            NextAttack(Game.enemy, Game.enemy.GenerateDamage());

                            //if the player is dead
                            if (Game.player.IsDead) return;
                        }
                    }
                }

                if (Game.DefeatedEnemiesToFightTheBoss == Game.bosses[biomeType].CounterToReachTheBoss && !Game.bosses[biomeType].IsDead) return;

                //asking if you want to continue grinding or not
                yesOrNo = string.Empty;
                while (yesOrNo != "y" && yesOrNo != "n")
                {
                    Print.Question($"Farm more at the {Game.biomes[biomeType].ShortTitle}?", ConsoleColor.Cyan);

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    yesOrNo = Console.ReadLine().ToLower();
                    Console.ResetColor();

                    if (yesOrNo == "y" || yesOrNo == "n")
                        Console.Clear();
                }

                void NextAttack(Character attacker, double damage)
                {
                    if (Game.random.Next(0, 100) > attacker.CritChance)
                        attacker.Attack(Game.player, Game.enemy, damage);
                    else
                        attacker.Attack(Game.player, Game.enemy, damage, crit: true);
                }

                double PlayerDamage()
                {
                    //if player bought weapon, it will generate damage + weapon damage
                    for (int i = 0; i < Game.inventory.Length; i++)
                    {
                        if (Game.inventory[i].WeaponIsBought)
                            return Game.player.GenerateDamage() + Game.inventory[i].Damage;
                    }
                    //otherwise only base damage of player
                    return Game.player.GenerateDamage();
                }
            }
        }
    }
}
