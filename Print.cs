﻿using System;
using System.Threading;

namespace EternityRPG
{
    public static class Print
    {
        public static void Options(int type, Character player, MedicineBag medicineBag, Weapon weapon, Character[] bosses)
        {
            //battle options
            if (type == 1)
            {
                Text("What are you going to do?");
                Text(" [1] ", ConsoleColor.Green);
                Text("attack\n");
                Text(" [2] ".PadLeft(30, ' '), ConsoleColor.Green);
                Text("auto attack\n");
                Text(" [3] ".PadLeft(30, ' '), ConsoleColor.Green);
                Text("heal\n");
                Text(" [4] ".PadLeft(30, ' '), ConsoleColor.Green);
                Text("run away\n\n");
            }

            //battle optins => healing options
            if (type == 2)
            {
                Text("\n");
                Text("Choose a potion:".PadLeft(25, ' '));
                Text(" [1] ", ConsoleColor.DarkYellow);
                Text($"small\t");
                Text($"{medicineBag.SmallAmount}\n", ConsoleColor.DarkYellow);
                Text(" [2] ".PadLeft(30, ' '), ConsoleColor.DarkYellow);
                Text($"medium\t");
                Text($"{medicineBag.MediumAmount}\n", ConsoleColor.DarkYellow);
                Text(" [3] ".PadLeft(30, ' '), ConsoleColor.DarkYellow);
                Text($"big\t");
                Text($"{medicineBag.BigAmount}\n\n", ConsoleColor.DarkYellow);
                Text(" [<] ".PadLeft(30, ' '), ConsoleColor.DarkYellow);
                Text($"back\n\n");
            }

            //options to select the location
            if (type == 3)
            {
                int deathCounter = 0;
                foreach (var boss in bosses) if (boss.IsDead) deathCounter++;

                //if all bosses are dead, you can see last secret location
                if (deathCounter == 3)
                {
                    Text("Where do you want to go? ");
                    Text(" [1] ", ConsoleColor.Green);
                    Text("Dark forest\t");
                    Condition(bosses[0]);

                    Text(" [2] ".PadLeft(30, ' '), ConsoleColor.Green);
                    Text("Caves\t\t");
                    Condition(bosses[1]);

                    Text(" [3] ".PadLeft(30, ' '), ConsoleColor.Green);
                    Text("Volcano\t\t");
                    Condition(bosses[2]);

                    Text(" [4] ".PadLeft(30, ' '), ConsoleColor.Green);
                    Text("Lair of true evil\n\n", ConsoleColor.DarkRed);
                }

                //if not, you can see only three locations
                else
                {
                    Text("Where do you want to go? ");
                    Text(" [1] ", ConsoleColor.Green);
                    Text("Dark forest\t");
                    Condition(bosses[0]);

                    Text(" [2] ".PadLeft(30, ' '), ConsoleColor.Green);
                    Text("Caves\t\t");
                    Condition(bosses[1]);

                    Text(" [3] ".PadLeft(30, ' '), ConsoleColor.Green);
                    Text("Volcano\t\t");
                    Condition(bosses[2]);
                    Text("\n");
                }

                void Condition(Character boss)
                {
                    if (!boss.IsDead) 
                        Text("boss is alive\n", ConsoleColor.DarkRed);
                    else 
                        Text("boss is defeated\n", ConsoleColor.DarkGreen);
                }
            }

            //options to change direction
            if (type == 4)
            {
                Text("What is next?");
                Text(" [1] ", ConsoleColor.Cyan);
                Text("go to the shop\n");
                Text(" [2] ".PadLeft(18, ' '), ConsoleColor.Cyan);
                Text("change location\n");
                Text(" [3] ".PadLeft(18, ' '), ConsoleColor.Cyan);
                Text("show stats\n\n");
            }

            //shop options
            if (type == 5)
            {
                Text("You are in the shop.\nWhat do you want to buy? ");
                Text(" [1] ", ConsoleColor.Green);
                Text("small healing potion\t");
                Text($"{medicineBag.SmallCost} gold", ConsoleColor.DarkYellow);
                Text("  / ");
                Text($"you have {medicineBag.SmallAmount}\n", ConsoleColor.Cyan);
                Text(" [2] ".PadLeft(30, ' '), ConsoleColor.Green);
                Text("medium healing potion\t");
                Text($"{medicineBag.MediumCost} gold", ConsoleColor.DarkYellow);
                Text("  / ");
                Text($"you have {medicineBag.MediumAmount}\n", ConsoleColor.Cyan);
                Text(" [3] ".PadLeft(30, ' '), ConsoleColor.Green);
                Text("big healing potion\t");
                Text($"{medicineBag.BigCost} gold", ConsoleColor.DarkYellow);
                Text(" / ");
                Text($"you have {medicineBag.BigAmount}\n\n", ConsoleColor.Cyan);

                //you can see weapon according to the selected class of player
                Text(" [4] ".PadLeft(30, ' '), ConsoleColor.Green);
                Text($"{weapon.Weapon1}\t", ConsoleColor.DarkCyan);
                Text($"+{weapon.Damage1}\t", ConsoleColor.DarkRed);
                Text($"{weapon.Cost1} gold\n", ConsoleColor.DarkYellow);
                Text(" [5] ".PadLeft(30, ' '), ConsoleColor.Green);
                Text($"{weapon.Weapon2}\t", ConsoleColor.DarkCyan);
                Text($"+{weapon.Damage2}\t", ConsoleColor.DarkRed);
                Text($"{weapon.Cost2} gold\n\n", ConsoleColor.DarkYellow);

                //gold in your bag
                Text(" [<] ".PadLeft(30, ' '), ConsoleColor.Green);
                Text($"exit");
                Text($"\t\t\t{player.Gold} ", ConsoleColor.Green);
                Text("gold ", ConsoleColor.DarkYellow);
                Text("in your bag\n\n");
            }

            //selection of the player claa before start of the game
            if (type == 6)
            {
                Text("\nChoose your character's class: ");
                Text(" [1] ", ConsoleColor.Green);
                Text("knight\n");
                Text(" [2] ".PadLeft(36, ' '), ConsoleColor.Green);
                Text("archer\n");
                Text(" [3] ".PadLeft(36, ' '), ConsoleColor.Green);
                Text("mage\n\n");
            }

            //card of player before start of the game
            if (type == 7)
            {
                Text("".PadLeft(25, '>') + "\n", ConsoleColor.Magenta);
                Text("Your character\n", ConsoleColor.DarkYellow);
                Text("name:\t");
                Text($"{player.Name}\n", ConsoleColor.Green);
                Text("gender:\t");
                Text($"{player.Sex}\n", ConsoleColor.Green);
                Text("class:\t");
                Text($"{player.Class}\n", ConsoleColor.Green);
                Text("".PadLeft(25, '<') + "\n\n", ConsoleColor.Magenta);
            }

            //selection of player's gender
            if (type == 8)
            {
                Text("\nChoose your character's gender:");
                Text(" [1] ", ConsoleColor.Green);
                Text("male\n");
                Text(" [2] ".PadLeft(36, ' '), ConsoleColor.Green);
                Text("female\n\n");
            }
        }

        public static void BoosFight()
        {
            Text($@"{"\t"} ___    ___    ___   ___       ___   ___    ___   _  _   _____ {"\n"}", ConsoleColor.DarkRed, false, 2);
            Text($@"{"\t"}| _ )  / _ \  / __| / __|     | __| |_ _|  / __| | || | |_   _|{"\n"}", ConsoleColor.DarkRed, false, 2);
            Text($@"{"\t"}| _ \ | (_) | \__ \ \__ \     | _|   | |  | (_ | | __ |   | |  {"\n"}", ConsoleColor.DarkRed, false, 2);
            Text($@"{"\t"}|___/  \___/  |___/ |___/     |_|   |___|  \___| |_||_|   |_|  {"\n\n"}", ConsoleColor.DarkRed, false, 2);
        }

        public static void YouDied()
        {
            Text($@"{"\t"}__   __   ___    _   _       ___    ___   ___   ___  {"\n"}", ConsoleColor.DarkRed, false, 2);
            Text($@"{"\t"}\ \ / /  / _ \  | | | |     |   \  |_ _| | __| |   \ {"\n"}", ConsoleColor.DarkRed, false, 2);
            Text($@"{"\t"} \ V /  | (_) | | |_| |     | |) |  | |  | _|  | |) |{"\n"}", ConsoleColor.DarkRed, false, 2);
            Text($@"{"\t"}  |_|    \___/   \___/      |___/  |___| |___| |___/ {"\n\n"}", ConsoleColor.DarkRed, false, 2);
            Text("your journey is over :(".PadLeft(45, ' '), ConsoleColor.Red);

            Thread.Sleep(3000);
            Text("\n\nPress Enter to exit");
            Console.ReadLine();
        }

        public static void BossVanquished()
        {
            Text($@"{"\t"} ___    ___    ___   ___    __   __    _     _  _    ___    _   _   ___   ___   _  _   ___   ___  {"\n"}", ConsoleColor.DarkGreen, false, 2);
            Text($@"{"\t"}| _ )  / _ \  / __| / __|   \ \ / /   /_\   | \| |  / _ \  | | | | |_ _| / __| | || | | __| |   \ {"\n"}", ConsoleColor.DarkGreen, false, 2);
            Text($@"{"\t"}| _ \ | (_) | \__ \ \__ \    \ V /   / _ \  | .` | | (_) | | |_| |  | |  \__ \ | __ | | _|  | |) |{"\n"}", ConsoleColor.DarkGreen, false, 2);
            Text($@"{"\t"}|___/  \___/  |___/ |___/     \_/   /_/ \_\ |_|\_|  \__\_\  \___/  |___| |___/ |_||_| |___| |___/ {"\n"}", ConsoleColor.DarkGreen, false, 2);
        }

        public static void TheEnd(Character player, Weapon weapon)
        {
            Text($@"{"\t"} _________          _______      _______  _        ______  { "\n"}", ConsoleColor.DarkGreen, false, 2);
            Text($@"{"\t"} \__   __/|\     /|(  ____ \    (  ____ \( (    /|(  __  \ {"\n"}", ConsoleColor.DarkGreen, false, 2);
            Text($@"{"\t"}    ) (   | )   ( || (    \/    | (    \/|  \  ( || (  \  ){"\n"}", ConsoleColor.DarkGreen, false, 2);
            Text($@"{"\t"}    | |   | (___) || (__        | (__    |   \ | || |   ) |{"\n"}", ConsoleColor.DarkGreen, false, 2);
            Text($@"{"\t"}    | |   |  ___  ||  __)       |  __)   | (\ \) || |   | |{ "\n"}", ConsoleColor.DarkGreen, false, 2);
            Text($@"{"\t"}    | |   | (   ) || (          | (      | | \   || |   ) |{"\n"}", ConsoleColor.DarkGreen, false, 2);
            Text($@"{"\t"}    | |   | )   ( || (____/\    | (____/\| )  \  || (__/  ){"\n"}", ConsoleColor.DarkGreen, false, 2);
            Text($@"{"\t"}    )_(   |/     \|(_______/    (_______/|/    )_)(______/ {"\n"}", ConsoleColor.DarkGreen, false, 2);

            if (!weapon.Weapon1Bought && !weapon.Weapon2Bought)
            {
                Text("\n");
                Text("".PadLeft(30, '>') + "\n", ConsoleColor.Magenta);
                MainStats();
                Text("".PadLeft(30, '<') + "\n\n", ConsoleColor.Magenta);
            }

            if (weapon.Weapon1Bought || weapon.Weapon2Bought)
            {
                Text("\n");
                Text("".PadLeft(36, '>') + "\n", ConsoleColor.Magenta);
                MainStats();

                if (weapon.Weapon1Bought)
                {
                    Text(" weapon:          ");
                    Text($"{weapon.Weapon1}\n", ConsoleColor.Green);
                }
                if (weapon.Weapon2Bought)
                {
                    Text(" weapon:          ");
                    Text($"{weapon.Weapon2}\n", ConsoleColor.Green);
                }

                Text("".PadLeft(36, '<') + "\n\n", ConsoleColor.Magenta);
            }

            void MainStats()
            {
                Text($" {player.Name}", ConsoleColor.DarkYellow);
                Text(" / ");
                Text($"{player.Sex}\n", ConsoleColor.Cyan);
                Text(" class:           ");
                Text($"{player.Class}\n", ConsoleColor.Green);
                Text(" lvl:             ");
                Text($"{player.Lvl}\n", ConsoleColor.Green);
                Text(" gold:            ");
                Text($"{player.Gold}\n", ConsoleColor.Green);
                Text(" exp:             ");
                Text($"{player.Exp}\n", ConsoleColor.Green);
                Text(" enemies killed:  ");
                Text($"{Program.DefeatedEnemiesOverall}\n", ConsoleColor.Green);
                Text(" bosses killed:   ");
                Text($"{Program.DefeatedBossesOverall}\n", ConsoleColor.Green);
            }

            Thread.Sleep(3000);
            Text("Press Enter to exit");
            Console.ReadLine();
        }

        public static void GameTitle()
        {
            Text($@"{"\t"} _______ _________ _______  _______  _       __________________         {"\n"}", ConsoleColor.DarkMagenta, false, 2);
            Text($@"{"\t"}(  ____ \\__   __/(  ____ \(  ____ )( (    /|\__   __/\__   __/|\     /|{"\n"}", ConsoleColor.DarkMagenta, false, 2);
            Text($@"{"\t"}| (    \/   ) (   | (    \/| (    )||  \  ( |   ) (      ) (   ( \   / ){"\n"}", ConsoleColor.DarkMagenta, false, 2);
            Text($@"{"\t"}| (__       | |   | (__    | (____)||   \ | |   | |      | |    \ (_) / {"\n"}", ConsoleColor.DarkMagenta, false, 2);
            Text($@"{"\t"}|  __)      | |   |  __)   |     __)| (\ \) |   | |      | |     \   /  {"\n"}", ConsoleColor.DarkMagenta, false, 2);
            Text($@"{"\t"}| (         | |   | (      | (\ (   | | \   |   | |      | |      ) (   {"\n"}", ConsoleColor.DarkMagenta, false, 2);
            Text($@"{"\t"}| (____/\   | |   | (____/\| ) \ \__| )  \  |___) (___   | |      | |   {"\n"}", ConsoleColor.DarkMagenta, false, 2);
            Text($@"{"\t"}(_______/   )_(   (_______/|/   \__/|/    )_)\_______/   )_(      \_/   {"\n\n"}", ConsoleColor.DarkMagenta, false, 2);
        }

        public static void Text(string text, ConsoleColor color = ConsoleColor.White, bool slowText = false, int speed = 5)
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

        public static void RainbowLoading(int length = 8)
        {
            for (int i = 0; i <= length; i++)
            {
                Text("|", ConsoleColor.Red, slowText: true);
                Text("|", ConsoleColor.DarkYellow, slowText: true);
                Text("|", ConsoleColor.Yellow, slowText: true);
                Text("|", ConsoleColor.Green, slowText: true);
                Text("|", ConsoleColor.Cyan, slowText: true);
                Text("|", ConsoleColor.DarkBlue, slowText: true);
                Text("|", ConsoleColor.DarkMagenta, slowText: true);
                Text("|", ConsoleColor.DarkBlue, slowText: true);
                Text("|", ConsoleColor.Cyan, slowText: true);
                Text("|", ConsoleColor.Green, slowText: true);
                Text("|", ConsoleColor.Yellow, slowText: true);
                Text("|", ConsoleColor.DarkYellow, slowText: true);
            }

            Text("|", ConsoleColor.Red, slowText: true);
            Text("|", ConsoleColor.DarkYellow, slowText: true);
            Text("|", ConsoleColor.Yellow, slowText: true);
            Text("|", ConsoleColor.Green, slowText: true);
            Text("|", ConsoleColor.Cyan, slowText: true);
            Text("|", ConsoleColor.DarkBlue, slowText: true);
            Text("|", ConsoleColor.DarkMagenta, slowText: true);
        }

        public static void PressEnter()
        {
            Thread.Sleep(1500);
            Text("Press Enter to continue\n");
            Console.ReadLine();
        }

        public static void PlayerStatistics(Character player, Weapon weapon)
        {
            //if you didn't buy any weapon from the shop
            if (!weapon.Weapon1Bought && !weapon.Weapon2Bought)
            {
                Text("\n");
                Text("".PadLeft(30, '>') + "\n", ConsoleColor.Magenta);
                MainStats();
                Text("".PadLeft(30, '<') + "\n\n", ConsoleColor.Magenta);
            }

            //if you have bought any weapon from the shop
            if (weapon.Weapon1Bought || weapon.Weapon2Bought)
            {
                Text("\n");
                Text("".PadLeft(30, '>') + "\n", ConsoleColor.Magenta);
                MainStats();

                if (weapon.Weapon1Bought)
                {
                    Text(" weapon:     ");
                    Text($"{weapon.Weapon1}\n", ConsoleColor.Green);
                }
                if (weapon.Weapon2Bought)
                {
                    Text(" weapon:     ");
                    Text($"{weapon.Weapon2}\n", ConsoleColor.Green);
                }

                Text("".PadLeft(30, '<') + "\n\n", ConsoleColor.Magenta);
            }

            void MainStats()
            {
                Text($" {player.Name}", ConsoleColor.DarkYellow);
                Text(" / ");
                Text($"{player.Sex}\n", ConsoleColor.Cyan);
                Text(" class:      ");
                Text($"{player.Class}\n", ConsoleColor.Green);
                Text(" lvl:        ");
                Text($"{player.Lvl}\n", ConsoleColor.Green);
                Text(" health:     ");
                Text($"{player.Health}".PadLeft(1, ' '), ConsoleColor.Green);
                Text(" / ");
                Text($"{player.CurrentHealth}\n", ConsoleColor.DarkYellow);
                Text(" gold:       ");
                Text($"{player.Gold}\n", ConsoleColor.Green);
                Text(" exp:        ");
                Text($"{player.Exp}\n", ConsoleColor.Green);
            }
        }
    }
}