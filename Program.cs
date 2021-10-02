using System;
using System.Threading;

namespace EternityRPG
{
    class Program
    {
        public static int index { get; set; }
        public static int DefeatedEnemiesOverall { get; set; }
        public static int DefeatedBossesOverall { get; set; }
        public static int DefeatedEnemiesToFightTheBoss { get; set; }

        static void Main(string[] args)
        {
            MedicineBag medicineBag = new MedicineBag();
            Weapon weapon = new Weapon();
            Location location;
            Player player;

            Enemy[] bosses = new Enemy[]
            {
                new boss1(),
                new boss2(),
                new boss3(),
                new boss4()
            };

            string keyBoardInput = string.Empty;
            string playerName = string.Empty;
            string gender = string.Empty;
            string yesNo = string.Empty;

            int changeDirection = 0;
            int locationType = 1;
            int playerClass = 0;
            int choice = 0;

            Print.GameTitle();
            Print.PressEnter();
            Print.RainbowLoading();
            Console.Clear();
            Print.Text("Hello, traveler. I can't remember your name. Can you help me with this?\n\n", ConsoleColor.DarkYellow);
            Thread.Sleep(3000);

            while (yesNo.ToLower() != "y")
            {
                yesNo = string.Empty;
                playerName = string.Empty;

                Print.Text("Enter your name or press ENTER: ");

                Console.ForegroundColor = ConsoleColor.Green;
                keyBoardInput = Console.ReadLine();
                Console.ResetColor();

                //your name
                if (keyBoardInput.Length > 0) playerName = keyBoardInput;
                //default name
                else playerName = "Sam";

                //selection of player's gender
                Print.GenderOptions();

                choice = 0;
                //gender of your character
                while (choice == 0 || choice > 2)
                {
                    Print.Text("choose gender: ".PadLeft(47, ' '));
                    Console.ForegroundColor = ConsoleColor.Green;
                    keyBoardInput = Console.ReadLine();
                    int.TryParse(keyBoardInput, out choice);
                    Console.ResetColor();

                    if (choice == 1) gender = "male";
                    if (choice == 2) gender = "female";
                }

                //selection of the player class before start of the game
                Print.PlayerClassOptions();

                playerClass = 0;
                while (playerClass == 0 || playerClass > 3)
                {
                    Print.Text("choose class: ".PadLeft(46, ' '));
                    Console.ForegroundColor = ConsoleColor.Green;
                    keyBoardInput = Console.ReadLine();
                    int.TryParse(keyBoardInput, out playerClass);
                    Console.ResetColor();
                }
                Console.Clear();

                //creating player and weapon according to collected data
                player = CreatePlayer(playerClass, playerName, gender);
                weapon = new Weapon(playerClass);

                //card of player before start of the game
                Print.PlayerShortInfo(player);

                yesNo = string.Empty;
                while (yesNo.ToLower() != "y" && yesNo.ToLower() != "n")
                {
                    Print.Text("Are you ready to start the adventure with this character?");
                    Print.Text(" [y] ", ConsoleColor.Green);
                    Print.Text("/");
                    Print.Text(" [n]", ConsoleColor.Green);
                    Print.Text(": ");

                    Console.ForegroundColor = ConsoleColor.Green;
                    yesNo = Console.ReadLine();
                    Console.ResetColor();
                }
                Console.Clear();
            }
            Console.Clear();

            player = CreatePlayer(playerClass, playerName, gender);

            Print.Text("The adventure begins\n\n");
            Print.RainbowLoading();
            Console.Clear();
            //end with collecting the player data

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
                        Print.ShopOptions(player, weapon, medicineBag);

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
                    Print.SelectLocation(bosses);

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

                            index = locationType - 1;
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

                            index = locationType - 1;
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
                        if (bosses[index].CurrentHealth <= 0)
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
                    Print.Text($"{location.LocationInfo}\n", ConsoleColor.DarkGreen, slowText: true);
                    //start battle section with regular enemies
                    BattleZone(player, medicineBag, location, weapon, bosses);
                }

                //if you killed enough enemies in the location, you can fight with boss of this location, if it is not dead
                if (DefeatedEnemiesToFightTheBoss == bosses[index].CounterToReachTheBoss && !bosses[index].IsDead)
                {
                    Print.BoosFight();
                    Print.Text($"\tGet ready for battle, the {bosses[index].Name} is coming...\n\n");
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
                Print.ChangeDirection();

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

        public static void BattleZone(Player player, MedicineBag medicineBag, Location location, Weapon weapon, Enemy[] bosses)
        {
            //setting counter of defeated enemies to 0 before the start of each battle
            DefeatedEnemiesToFightTheBoss = 0;

            string yesNo = string.Empty;
            while (yesNo.ToLower() != "n")
            {
                //printing short name of the location before each regular enemy
                Print.Text($"Location: {location.ShortTitle}\n", ConsoleColor.DarkCyan);

                Random random = new Random();
                //create new enemy randomly every time when the cycle starts again, according to the chosen location
                Enemy enemy = location.CreateEnemy();

                int choice = 0;
                string keyBoardInput = string.Empty;
                yesNo = string.Empty;

                Print.RainbowLoading(random.Next(1, 9));

                //print randomly generated phrase when new enemy appear
                Print.Text(Print.EntryBattlePhrase(enemy));

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
                            EnemyIsDead();
                            //check if player has enough experience to get new level
                            player.LevelUp(player.Exp);
                            Print.PlayerStatistics(player, weapon);
                            break;
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
                                EnemyIsDead();
                                //check if player has enough experience to get new level
                                player.LevelUp(player.Exp);
                                Print.PlayerStatistics(player, weapon);
                                break;
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
                        Print.HealingOptions(medicineBag);

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
                                    Print.Text("\n\tmax health\n", ConsoleColor.DarkGreen);
                                }

                                //if not => heal
                                else Print.Text($"\n\t+{medicineBag.HealingPower} health. {player.Name} have {player.CurrentHealth} now\n", ConsoleColor.DarkGreen);

                                //enemy does his turn, after you used yours for healing
                                enemy.Attack(player, enemy, enemyDamage);

                                //if you died after this attack
                                if (player.CurrentHealth <= 0) break;
                            }

                            //if you don't have any potions
                            else
                            {
                                Print.Text($"\n\tYou don't have {medicineBag.Name}\n", ConsoleColor.DarkRed);

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
                if (DefeatedEnemiesToFightTheBoss == bosses[index].CounterToReachTheBoss && !bosses[index].IsDead) break;

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

                void EnemyIsDead()
                {
                    DefeatedEnemiesOverall++;
                    DefeatedEnemiesToFightTheBoss++;
                    player.Gold += enemy.Gold;
                    player.Exp += enemy.Exp;
                }

                double PlayerDamage()
                {
                    double playerDamage;
                    //if player bought weapon, it will generate damage + weapon damage
                    if (!weapon.Weapon1Bought && !weapon.Weapon2Bought)
                        playerDamage = player.GenerateDamage();
                    else
                        playerDamage = player.GenerateDamage(weapon);

                    return playerDamage;
                }
            }
        }

        public static void BossBattle(Player player, MedicineBag medicineBag, Location location, Weapon weapon, Enemy[] bosses)
        {
            while (true)
            {
                //printing short name of the location before each boss
                Print.Text($"Location: {location.ShortTitle}\n\n", ConsoleColor.DarkCyan);
                Print.Text($"{bosses[index].Name}\n\n");

                Random random = new Random();
                int choice = 0;
                string keyBoardInput = string.Empty;

                Print.BattleOptions();

                while (true)
                {
                    //every new cycle of fight generate unic damage for player and boss
                    double playerDamage = PlayerDamage();
                    double bossDamage = bosses[index].GenerateDamage();

                    Console.Write("choose action: ".PadLeft(41, ' '));
                    Console.ForegroundColor = ConsoleColor.Green;
                    keyBoardInput = Console.ReadLine();
                    int.TryParse(keyBoardInput, out int battleChoice);
                    Console.ResetColor();

                    //manual fight
                    if (battleChoice == 1)
                    {
                        if (random.Next(0, 100) > player.CritChance)
                            player.Attack(player, bosses[index], playerDamage);
                        else
                            player.SpecialAttack(player, bosses[index], playerDamage);

                        //if the boss is dead
                        if (bosses[index].CurrentHealth <= 0)
                        {
                            BossIsDead();
                            //check if player has enough experience to get new level
                            player.LevelUp(player.Exp);
                            Print.PlayerStatistics(player, weapon);
                            Print.PressEnter();
                            Console.Clear();
                            break;
                        }

                        if (random.Next(0, 100) > bosses[index].CritChance)
                            bosses[index].Attack(player, bosses[index], bossDamage);
                        else
                            bosses[index].SpecialAttack(player, bosses[index], bossDamage);

                        //if the player is dead
                        if (player.CurrentHealth <= 0) break;
                    }

                    //automatic fight
                    if (battleChoice == 2)
                    {
                        while (player.CurrentHealth > 0 || bosses[index].CurrentHealth > 0)
                        {
                            //every new cycle of fight generate unic damage for player and boss
                            playerDamage = PlayerDamage();
                            bossDamage = bosses[index].GenerateDamage();

                            if (random.Next(0, 100) > player.CritChance)
                                player.Attack(player, bosses[index], playerDamage);
                            else
                                player.SpecialAttack(player, bosses[index], playerDamage);

                            //if the boss is dead
                            if (bosses[index].CurrentHealth <= 0)
                            {
                                BossIsDead();
                                //check if player has enough experience to get new level
                                player.LevelUp(player.Exp);
                                Print.PlayerStatistics(player, weapon);
                                Print.PressEnter();
                                Console.Clear();
                                break;
                            }

                            if (random.Next(0, 100) > bosses[index].CritChance)
                                bosses[index].Attack(player, bosses[index], bossDamage);
                            else
                                bosses[index].SpecialAttack(player, bosses[index], bossDamage);

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
                        Print.HealingOptions(medicineBag);

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
                                    Print.Text("\n\tmax health\n", ConsoleColor.DarkGreen);
                                }

                                //if not => heal
                                else Print.Text($"\n\t+{medicineBag.HealingPower} health. {player.Name} have {player.CurrentHealth} now\n", ConsoleColor.DarkGreen);

                                //boss does his turn, after you used yours for healing
                                bosses[index].Attack(player, bosses[index], bossDamage);

                                //if you died after this attack
                                if (player.CurrentHealth <= 0) break;
                            }

                            //if you don't have any potions
                            else
                            {
                                Print.Text($"\n\tYou don't have {medicineBag.Name}\n", ConsoleColor.DarkRed);

                                //boss does his turn, after you used yours for healing
                                bosses[index].Attack(player, bosses[index], bossDamage);

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
                        Print.Text($"\n\tyou can't escape from the {bosses[index].Name}\n", ConsoleColor.DarkRed);
                        bosses[index].SpecialAttack(player, bosses[index], bossDamage);

                        if (player.CurrentHealth <= 0) break;
                    }
                }

                if (player.CurrentHealth <= 0) break;
                if (bosses[index].CurrentHealth <= 0) break;

                void BossIsDead()
                {
                    DefeatedBossesOverall++;
                    player.Gold += bosses[index].Gold;
                    player.Exp += bosses[index].Exp;
                }

                double PlayerDamage()
                {
                    double playerDamage;
                    //if player bought weapon, it will generate damage + weapon damage
                    if (!weapon.Weapon1Bought && !weapon.Weapon2Bought)
                        playerDamage = player.GenerateDamage();
                    else
                        playerDamage = player.GenerateDamage(weapon);

                    return playerDamage;
                }
            }
        }

        public static Player CreatePlayer(int playerClass, string playerName, string gender)
        {
            if (playerClass == 1) return new Knight(playerName, gender);
            if (playerClass == 2) return new Archer(playerName, gender);
            else return new Mage(playerName, gender);
        }
    }
}
