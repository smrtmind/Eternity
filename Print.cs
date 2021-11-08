using System;
using System.Threading;

namespace EternityRPG
{
    public static class Print
    {
        public static void Question(string text, ConsoleColor color = ConsoleColor.Green)
        {
            Text($"{text}");
            Text(" [y] ", color);
            Text("/");
            Text(" [n]", color);
            Text(": ");
        }

        public static void GenderOptions()//selection of player's gender
        {
            Text("\nChoose your character's gender:");
            Text(" [1] ", ConsoleColor.Green);
            Text("male\n");
            Text(" [2] ".PadLeft(36, ' '), ConsoleColor.Green);
            Text("female\n\n");
        }

        public static void PlayerClassOptions()//selection of the player class before start of the game
        {
            Text("\nChoose your character's class: ");
            Text(" [1] ", ConsoleColor.Green);
            Text("warrior\n");
            Text(" [2] ".PadLeft(36, ' '), ConsoleColor.Green);
            Text("archer\n");
            Text(" [3] ".PadLeft(36, ' '), ConsoleColor.Green);
            Text("mage\n\n");
        }

        public static void PlayerShortInfo(Player player)//card of player before start of the game
        {
            Text("".PadLeft(25, '>') + "\n", ConsoleColor.Magenta);
            Text("Your character\n", ConsoleColor.DarkYellow);

            if (player.Name == "Ash")
            {
                Text("name:\t");
                Text($"{player.Name} ", ConsoleColor.Green);
                Text("(default)\n");
            }
            else
            {
                Text("name:\t");
                Text($"{player.Name}\n", ConsoleColor.Green);
            }

            Text("gender:\t");
            Text($"{player.Gender}\n", ConsoleColor.Green);
            Text("class:\t");
            Text($"{player.Class}\n", ConsoleColor.Green);
            Text("".PadLeft(25, '<') + "\n\n", ConsoleColor.Magenta);
        }

        public static void ShopOptions(Player player, Item[] inventory)
        {
            Text("You are in the shop.\nWhat do you want to buy? ");
            Text(" [1] ", ConsoleColor.Green);
            Text($"{inventory[0].Title}\t");
            Text($"{inventory[0].Cost} gold", ConsoleColor.DarkYellow);
            Text("  / ");
            Text($"you have {inventory[0].Amount}\n", ConsoleColor.Cyan);
            Text(" [2] ".PadLeft(30, ' '), ConsoleColor.Green);
            Text($"{inventory[1].Title}\t");
            Text($"{inventory[1].Cost} gold", ConsoleColor.DarkYellow);
            Text("  / ");
            Text($"you have {inventory[1].Amount}\n", ConsoleColor.Cyan);
            Text(" [3] ".PadLeft(30, ' '), ConsoleColor.Green);
            Text($"{inventory[2].Title}\t");
            Text($"{inventory[2].Cost} gold", ConsoleColor.DarkYellow);
            Text(" / ");
            Text($"you have {inventory[2].Amount}\n\n", ConsoleColor.Cyan);

            //you can see weapon according to the selected class of player
            Text(" [4] ".PadLeft(30, ' '), ConsoleColor.Green);
            Text($"{inventory[3].Title}\t", ConsoleColor.DarkCyan);
            Text($"+{inventory[3].Damage}\t", ConsoleColor.DarkRed);
            Text($"{inventory[3].Cost} gold\n", ConsoleColor.DarkYellow);
            Text(" [5] ".PadLeft(30, ' '), ConsoleColor.Green);
            Text($"{inventory[4].Title}\t", ConsoleColor.DarkCyan);
            Text($"+{inventory[4].Damage}\t", ConsoleColor.DarkRed);
            Text($"{inventory[4].Cost} gold\n\n", ConsoleColor.DarkYellow);

            //gold in your bag
            Text(" [<] ".PadLeft(30, ' '), ConsoleColor.Green);
            Text($"exit");
            Text($"\t\t\t{player.Gold} ", ConsoleColor.Green);
            Text("gold ", ConsoleColor.DarkYellow);
            Text("in your bag\n\n");
        }

        public static void SelectLocation(Enemy[] bosses)
        {
            int deathCounter = 0;
            foreach (var boss in bosses)
                if (boss.IsDead)
                    deathCounter++;

            Text("Where do you want to go? ");
            Text(" [1] ", ConsoleColor.Green);
            Text("Dark forest\t\t");
            Condition(bosses[0]);

            Text(" [2] ".PadLeft(30, ' '), ConsoleColor.Green);
            Text("Mysterious caves\t\t");
            Condition(bosses[1]);

            Text(" [3] ".PadLeft(30, ' '), ConsoleColor.Green);
            Text("Ancient volcano\t\t");
            Condition(bosses[2]);

            //if all bosses are dead you can see the last location
            if (deathCounter == 3)
            {
                Text(" [4] ".PadLeft(30, ' '), ConsoleColor.Green);
                Text("Lair of true evil\n\n", ConsoleColor.DarkRed);
            }
            else Text("\n");

            Text(" [<] ".PadLeft(30, ' '), ConsoleColor.Green);
            Text($"exit\n\n");

            void Condition(Enemy boss)
            {
                if (!boss.IsDead)
                    Text("boss is alive\n", ConsoleColor.DarkRed);
                else
                    Text("boss is defeated\n", ConsoleColor.DarkGreen);
            }
        }

        public static void ChangeDirection()//options to choose between shop, locations...
        {
            Text("What is next?");
            Text(" [1] ", ConsoleColor.Cyan);
            Text("go to the shop\n");
            Text(" [2] ".PadLeft(18, ' '), ConsoleColor.Cyan);
            Text("change location\n");
            Text(" [3] ".PadLeft(18, ' '), ConsoleColor.Cyan);
            Text("show stats\n\n");
        }

        public static void BattleOptions()
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

        public static void HealingOptions(Item[] potions)//battle optins => healing options
        {
            Text("\n");
            Text("Choose a potion:".PadLeft(25, ' '));
            Text(" [1] ", ConsoleColor.DarkYellow);
            Text($"small\t");
            Text($"{potions[0].Amount}\n", ConsoleColor.DarkYellow);
            Text(" [2] ".PadLeft(30, ' '), ConsoleColor.DarkYellow);
            Text($"medium\t");
            Text($"{potions[1].Amount}\n", ConsoleColor.DarkYellow);
            Text(" [3] ".PadLeft(30, ' '), ConsoleColor.DarkYellow);
            Text($"big\t");
            Text($"{potions[2].Amount}\n\n", ConsoleColor.DarkYellow);
            Text(" [<] ".PadLeft(30, ' '), ConsoleColor.DarkYellow);
            Text($"back\n\n");
        }

        public static void BoosFight()
        {
            Text($@"{"\t"} ___    ___    ___   ___       ___   ___    ___   _  _   _____ {"\n"}", ConsoleColor.DarkYellow, false, 2);
            Text($@"{"\t"}| _ )  / _ \  / __| / __|     | __| |_ _|  / __| | || | |_   _|{"\n"}", ConsoleColor.Red, false, 2);
            Text($@"{"\t"}| _ \ | (_) | \__ \ \__ \     | _|   | |  | (_ | | __ |   | |  {"\n"}", ConsoleColor.DarkRed, false, 2);
            Text($@"{"\t"}|___/  \___/  |___/ |___/     |_|   |___|  \___| |_||_|   |_|  {"\n\n"}", ConsoleColor.DarkMagenta, false, 2);
        }

        public static void YouDied()
        {
            Text($@"{"\t"}__   __   ___    _   _       ___    ___   ___   ___  {"\n"}", ConsoleColor.DarkYellow, false, 2);
            Text($@"{"\t"}\ \ / /  / _ \  | | | |     |   \  |_ _| | __| |   \ {"\n"}", ConsoleColor.Red, false, 2);
            Text($@"{"\t"} \ V /  | (_) | | |_| |     | |) |  | |  | _|  | |) |{"\n"}", ConsoleColor.DarkRed, false, 2);
            Text($@"{"\t"}  |_|    \___/   \___/      |___/  |___| |___| |___/ {"\n\n"}", ConsoleColor.DarkMagenta, false, 2);
            Text("your journey is over :(".PadLeft(45, ' '), ConsoleColor.Red);

            Thread.Sleep(3000);
            Text("\n\nPress Enter to exit");
            Console.ReadLine();
        }

        public static void BossVanquished()
        {
            Text($@"{"\t"} ___    ___    ___   ___    __   __    _     _  _    ___    _   _   ___   ___   _  _   ___   ___  {"\n"}", ConsoleColor.Cyan, false, 2);
            Text($@"{"\t"}| _ )  / _ \  / __| / __|   \ \ / /   /_\   | \| |  / _ \  | | | | |_ _| / __| | || | | __| |   \ {"\n"}", ConsoleColor.DarkCyan, false, 2);
            Text($@"{"\t"}| _ \ | (_) | \__ \ \__ \    \ V /   / _ \  | .` | | (_) | | |_| |  | |  \__ \ | __ | | _|  | |) |{"\n"}", ConsoleColor.Blue, false, 2);
            Text($@"{"\t"}|___/  \___/  |___/ |___/     \_/   /_/ \_\ |_|\_|  \__\_\  \___/  |___| |___/ |_||_| |___| |___/ {"\n"}", ConsoleColor.DarkBlue, false, 2);
        }

        public static void TheEnd(Player player, Item[] inventory)
        {
            Text($@"{"\t"} _________          _______      _______  _        ______  { "\n"}", ConsoleColor.Cyan, false, 2);
            Text($@"{"\t"} \__   __/|\     /|(  ____ \    (  ____ \( (    /|(  __  \ {"\n"}", ConsoleColor.DarkCyan, false, 2);
            Text($@"{"\t"}    ) (   | )   ( || (    \/    | (    \/|  \  ( || (  \  ){"\n"}", ConsoleColor.Blue, false, 2);
            Text($@"{"\t"}    | |   | (___) || (__        | (__    |   \ | || |   ) |{"\n"}", ConsoleColor.DarkBlue, false, 2);
            Text($@"{"\t"}    | |   |  ___  ||  __)       |  __)   | (\ \) || |   | |{ "\n"}", ConsoleColor.DarkMagenta, false, 2);
            Text($@"{"\t"}    | |   | (   ) || (          | (      | | \   || |   ) |{"\n"}", ConsoleColor.DarkBlue, false, 2);
            Text($@"{"\t"}    | |   | )   ( || (____/\    | (____/\| )  \  || (__/  ){"\n"}", ConsoleColor.Blue, false, 2);
            Text($@"{"\t"}    )_(   |/     \|(_______/    (_______/|/    )_)(______/ {"\n"}", ConsoleColor.Cyan, false, 2);

            if (!inventory[3].WeaponIsBought && !inventory[4].WeaponIsBought)
            {
                Text("\n");
                Text("".PadLeft(42, '>') + "\n", ConsoleColor.Magenta);
                MainStats();
                Text("".PadLeft(42, '<') + "\n\n", ConsoleColor.Magenta);
            }

            if (inventory[3].WeaponIsBought || inventory[4].WeaponIsBought)
            {
                Text("\n");
                Text("".PadLeft(42, '>') + "\n", ConsoleColor.Magenta);
                MainStats();

                if (inventory[3].WeaponIsBought)
                {
                    Text(" weapon:          ");
                    Text($"{inventory[3].Title}\n", ConsoleColor.DarkRed);
                }
                if (inventory[4].WeaponIsBought)
                {
                    Text(" weapon:          ");
                    Text($"{inventory[4].Title}\n", ConsoleColor.DarkRed);
                }

                Text("".PadLeft(42, '<') + "\n\n", ConsoleColor.Magenta);
            }

            void MainStats()
            {
                Text($" {player.Name}", ConsoleColor.DarkCyan);
                Text(" / ");
                Text($"{player.Gender}", ConsoleColor.DarkGray);
                Text(" / ");
                Text($"{player.Class}\n\n", ConsoleColor.DarkGreen);
                Text(" LVL:             ");
                Text($"{player.Lvl}\n", ConsoleColor.Green);
                Text(" EXP:             ");
                Text($"{player.Exp}\n", ConsoleColor.Green);
                Text(" GOLD:            ");
                Text($"{player.Gold}\n", ConsoleColor.DarkYellow);
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
            Text($@"{"\t"} _______ _________ _______  _______  _       __________________         {"\n"}", ConsoleColor.Cyan, false, 2);
            Text($@"{"\t"}(  ____ \\__   __/(  ____ \(  ____ )( (    /|\__   __/\__   __/|\     /|{"\n"}", ConsoleColor.DarkCyan, false, 2);
            Text($@"{"\t"}| (    \/   ) (   | (    \/| (    )||  \  ( |   ) (      ) (   ( \   / ){"\n"}", ConsoleColor.Blue, false, 2);
            Text($@"{"\t"}| (__       | |   | (__    | (____)||   \ | |   | |      | |    \ (_) / {"\n"}", ConsoleColor.DarkBlue, false, 2);
            Text($@"{"\t"}|  __)      | |   |  __)   |     __)| (\ \) |   | |      | |     \   /  {"\n"}", ConsoleColor.DarkMagenta, false, 2);
            Text($@"{"\t"}| (         | |   | (      | (\ (   | | \   |   | |      | |      ) (   {"\n"}", ConsoleColor.DarkBlue, false, 2);
            Text($@"{"\t"}| (____/\   | |   | (____/\| ) \ \__| )  \  |___) (___   | |      | |   {"\n"}", ConsoleColor.Blue, false, 2);
            Text($@"{"\t"}(_______/   )_(   (_______/|/   \__/|/    )_)\_______/   )_(      \_/   {"\n\n"}", ConsoleColor.Cyan, false, 2);
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

        public static string EntryBattlePhrase(Character enemy)
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
            Text("\n");
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
            Text("|\n", ConsoleColor.DarkMagenta, slowText: true);
        }

        public static void PressEnter()
        {
            Thread.Sleep(1500);
            Text("Press Enter to continue");
            Console.ReadLine();
        }

        public static void PlayerStatistics(Player player, Item[] inventory)
        {
            //if you didn't buy any weapon from the shop
            if (!inventory[3].WeaponIsBought && !inventory[4].WeaponIsBought)
            {
                Text("\n");
                Text("".PadLeft(39, '>') + "\n", ConsoleColor.Magenta);
                MainStats();
                Text("".PadLeft(39, '<') + "\n\n", ConsoleColor.Magenta);
            }

            //if you have bought any weapon from the shop
            if (inventory[3].WeaponIsBought || inventory[4].WeaponIsBought)
            {
                Text("\n");
                Text("".PadLeft(39, '>') + "\n", ConsoleColor.Magenta);
                MainStats();

                if (inventory[3].WeaponIsBought)
                {
                    Text(" weapon:   ");
                    Text($"{inventory[3].Title}\n", ConsoleColor.DarkRed);
                }
                if (inventory[4].WeaponIsBought)
                {
                    Text(" weapon:   ");
                    Text($"{inventory[4].Title}\n", ConsoleColor.DarkRed);
                }

                Text("".PadLeft(39, '<') + "\n\n", ConsoleColor.Magenta);
            }

            void MainStats()
            {
                Text($" {player.Name}", ConsoleColor.DarkCyan);
                Text(" / ");
                Text($"{player.Gender}", ConsoleColor.DarkGray);
                Text(" / ");
                Text($"{player.Class}\n\n", ConsoleColor.DarkGreen);
                Text(" LVL:      ");
                Text($"{player.Lvl}\n", ConsoleColor.Green);
                Text(" HP:       ");
                Text($"{player.HP}\t\t".PadLeft(1, ' '), ConsoleColor.Green);
                Text("/ ");
                Text($"max {player.MaxHP}\n", ConsoleColor.DarkCyan);
                Text(" EXP:      ");
                Text($"{player.Exp}\t\t", ConsoleColor.Green);
                Text("/ ");
                Text($"lvl {player.NextLvl}\n", ConsoleColor.DarkCyan);
                Text(" GOLD:     ");
                Text($"{player.Gold}\n", ConsoleColor.DarkYellow);
            }
        }
    }
}
