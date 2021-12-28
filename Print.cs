using System;
using System.Threading;

namespace EternityRPG
{
    public static class Print
    {
        public static void ChangeDirection()//options to choose between shop, locations
        {
            Console.Clear();

            Text(@"   ___        /           _             _         _______________ " + "\n", ConsoleColor.Blue);
            Text(@"  |___|      /           |\     /|\     /|       |               |" + "\n", ConsoleColor.Blue);
            Text(@"  _| |_     / /\           \     |     /         |  CLASS .....  |" + "\n", ConsoleColor.Blue);
            Text(@" |     |   / | |            \    |    /          |  EXP   .....  |" + "\n", ConsoleColor.Blue);
            Text(@" | HP  |  /  | |                                 |  GOLD  .....  |" + "\n", ConsoleColor.Blue);
            Text(@" |_____| /   | |              \  O               |_______________|" + "\n", ConsoleColor.Blue);
            Text("        /  __|_|__             \\/\u25A0\\ _                   | |       " + "\n", ConsoleColor.Blue);
            Text("       /      \u25A0                  \u25A0 |_|                  | |       " + "\n", ConsoleColor.Blue);
            Text("      /       \u25A0                 / \\                     |_|       " + "\n\n", ConsoleColor.Blue);

            for (int i = 0; i < Game.directions.Count; i++)
            {
                if (i == 0)
                    Text($"\t[{i + 1}] ", ConsoleColor.Cyan);
                else
                    Text($"\t\t[{i + 1}] ", ConsoleColor.Cyan);

                Text($"{Game.directions[i + 1]}");
            }
            Text("\n\n");
        }

        public static void GenderOptions()//selection of player's gender
        {
            Text("\nChoose your character's gender:");

            for (int i = 0; i < Game.genders.Count; i++)
            {
                if (i == 0)
                    Text($" [{i + 1}] ", ConsoleColor.Green);
                else
                    Text($" [{i + 1}] ".PadLeft(36, ' '), ConsoleColor.Green);

                Text($"{Game.genders[i + 1]}\n");
            }
            Text("\n");
        }

        public static void PlayerClassOptions()//selection of the player class before start of the game
        {
            Text("\nChoose your character's class: ");

            for (int i = 0; i < Game.classes.Count; i++)
            {
                if (i == 0)
                    Text($" [{i + 1}] ", ConsoleColor.Green);
                else
                    Text($" [{i + 1}] ".PadLeft(36, ' '), ConsoleColor.Green);

                Text($"{Game.classes[i + 1]}\n");
            }
            Text("\n");
        }

        public static void PlayerShortInfo(Player player)//card of player before start of the game
        {
            Console.Clear();

            Text("".PadLeft(45, '>') + "\n", ConsoleColor.Magenta);
            Text(" Your character\n\n", ConsoleColor.DarkYellow);
            Text(" name:\t\t");

            if (player.Name == "Ash")
            {
                Text($"{player.Name} ", ConsoleColor.DarkCyan);
                Text("(default)\n");
            }
            else
                Text($"{player.Name}\n", ConsoleColor.DarkCyan);

            Text(" gender:\t");
            Text($"{player.Gender}\n", ConsoleColor.DarkGray);
            Text(" class:\t\t");
            Text($"{player.Class}\n", ConsoleColor.DarkGreen);
            Text(" HP:\t\t");
            Text($"{player.MaxHP}\n", ConsoleColor.Green);
            Text(" DMG:\t\t");
            Text($"{player.MinDamage}", ConsoleColor.DarkGreen);
            Text(" - ");
            Text($"{player.MaxDamage}\n", ConsoleColor.DarkGreen);
            Text(" CRIT:\t\t");
            Text($"{player.CritChance}\n", ConsoleColor.Green);
            Text(" LUCK:\t\t");
            Text($"{player.Luck}\n", ConsoleColor.DarkGreen);
            Text("".PadLeft(45, '<') + "\n\n", ConsoleColor.Magenta);
        }

        public static void ShopOptions(Player player, Item[] inventory)
        {
            Console.Clear();

            Text(@" ___   _  _    ___    ___ " + "\n", ConsoleColor.DarkYellow);
            Text(@"/ __| | || |  / _ \  | _ \" + "\n", ConsoleColor.Red);
            Text(@"\__ \ | __ | | (_) | |  _/" + "\n", ConsoleColor.DarkRed);
            Text(@"|___/ |_||_|  \___/  |_|  " + "\n\n", ConsoleColor.DarkMagenta);

            Text("What do you want to buy?");

            Text("Healing equipment".PadLeft(23, ' ') + "\n", ConsoleColor.DarkGreen);
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] is Potion)
                {
                    Text($" [{i + 1}] ".PadLeft(30, ' '), ConsoleColor.DarkGreen);
                    Text($"{inventory[i].Title}\t");
                    Text($"+{inventory[i].HealingPower} HP \t", ConsoleColor.DarkGray);

                    if (inventory[i].Cost.ToString().Length <= 2)
                        Text($"{inventory[i].Cost} gold ", ConsoleColor.DarkYellow);
                    else
                        Text($"{inventory[i].Cost} gold", ConsoleColor.DarkYellow);

                    Text($" / ");
                    Text($"you have {inventory[i].Amount}\n", ConsoleColor.Cyan);
                }
            }
            Text("\n");

            Text("Elixirs of strength".PadLeft(49, ' ') + "\n", ConsoleColor.DarkMagenta);
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] is Buff)
                {
                    Text($" [{i + 1}] ".PadLeft(30, ' '), ConsoleColor.DarkMagenta);
                    Text($"{inventory[i].Title}\t");

                    if (inventory[i].BuffPower.ToString().Length <= 2)
                        Text($"+{inventory[i].BuffPower}  DMG", ConsoleColor.DarkGray);
                    else
                        Text($"+{inventory[i].BuffPower} DMG", ConsoleColor.DarkGray);

                    Text(" / ");
                    Text($"{inventory[i].MaxDurationOfEffect} hits\t", ConsoleColor.DarkGray);
                    Text($"{inventory[i].Cost} gold", ConsoleColor.DarkYellow);
                    Text(" / ");
                    Text($"you have {inventory[i].Amount}\n", ConsoleColor.Cyan);
                }
            }
            Text("\n");

            //you can see weapon according to the selected class of player
            Text("Weapons".PadLeft(37, ' ') + "\n", ConsoleColor.DarkBlue);
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] is Weapon)
                {
                    Text($" [{i + 1}] ".PadLeft(30, ' '), ConsoleColor.DarkBlue);
                    Text($"{inventory[i].Title}\t");

                    if (inventory[i].Damage.ToString().Length <= 2)
                        Text($"+{inventory[i].Damage}  DMG\t", ConsoleColor.DarkGray);
                    else
                        Text($"+{inventory[i].Damage} DMG\t", ConsoleColor.DarkGray);

                    Text($"{inventory[i].Cost} gold\n", ConsoleColor.DarkYellow);
                }
            }
            Text("\n");

            //gold in your bag
            Text(" [<] ".PadLeft(30, ' '), ConsoleColor.DarkYellow);
            Text($"exit");
            Text($"\t\t\t\t{player.Gold} ", ConsoleColor.Green);
            Text("gold ", ConsoleColor.DarkYellow);
            Text("in your bag\n\n");
        }

        public static void SelectLocation(Enemy[] bosses, Biome[] biomes, int maxLocations)
        {
            Console.Clear();

            Text(@" _       ___     ___     _     _____   ___    ___    _  _   ___ " + "\n", ConsoleColor.DarkYellow);
            Text(@"| |     / _ \   / __|   /_\   |_   _| |_ _|  / _ \  | \| | / __|" + "\n", ConsoleColor.Red);
            Text(@"| |__  | (_) | | (__   /(_)\    | |    | |  | (_) | | .` | \__ \" + "\n", ConsoleColor.DarkRed);
            Text(@"|____|  \___/   \___| /_/ \_\   |_|   |___|  \___/  |_|\_| |___/" + "\n\n", ConsoleColor.DarkMagenta);

            Text("Where do you want to go? ");

            int index = default;
            int counterToLastLocation = maxLocations;

            if (maxLocations == biomes.Length)
                counterToLastLocation--;

            while (index < counterToLastLocation)
            {
                if (index == 0)
                    Text($" [{index + 1}] ", ConsoleColor.Green);
                else
                    Text($" [{index + 1}] ".PadLeft(30, ' '), ConsoleColor.Green);

                Text($"{biomes[index].ShortTitle}\t\t");

                if (bosses[index].IsDead)
                    Text("boss is defeated\n", ConsoleColor.DarkGreen);
                else
                    Text("boss is alive\n", ConsoleColor.DarkRed);

                index++;
            }
            //the last location will be lined out with red color and without boss state info
            if (maxLocations == biomes.Length)
            {
                Text($" [{index + 1}] ".PadLeft(30, ' '), ConsoleColor.Green);
                Text($"{biomes[index].ShortTitle}\n", ConsoleColor.DarkRed);
            }
            Text("\n");

            Text(" [<] ".PadLeft(30, ' '), ConsoleColor.Green);
            Text($"exit\n\n");
        }

        public static void BattleOptions()
        {
            Text("What are you going to do?");

            for (int i = 0; i < Game.battleOptions.Count; i++)
            {
                if (i == 0)
                    Text($" [{i + 1}] ", ConsoleColor.DarkGray);
                else
                    Text($" [{i + 1}] ".PadLeft(30, ' '), ConsoleColor.DarkGray);

                Text($"{Game.battleOptions[i + 1]}\n");
            }
            Text("\n");
        }

        public static void HealingOptions(Item[] inventory)//battle optins => healing options
        {
            Text("\n");
            Text("Choose an item to heal:".PadLeft(25, ' '));

            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] is Potion)
                {
                    if (i == 0)
                        Text($" [{i + 1}] ", ConsoleColor.DarkGreen);
                    else
                        Text($" [{i + 1}] ".PadLeft(30, ' '), ConsoleColor.DarkGreen);

                    Text($"{inventory[i].Title}\t");
                    Text($"{inventory[i].Amount}\n", ConsoleColor.DarkGreen);
                }
            }
            Text("\n");

            Text(" [<] ".PadLeft(30, ' '), ConsoleColor.DarkGreen);
            Text($"back\n\n");
        }

        public static void BuffOptions(Item[] inventory)//battle optins => buff options
        {
            Text("\n");
            Text("Choose an elixir:".PadLeft(25, ' '));

            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] is Buff)
                {
                    if (i == Potion.AmountOfPotions())
                        Text($" [{i - Potion.AmountOfPotions() + 1}] ", ConsoleColor.DarkMagenta);
                    else
                        Text($" [{i - Potion.AmountOfPotions() + 1}] ".PadLeft(30, ' '), ConsoleColor.DarkMagenta);

                    Text($"{inventory[i].Title}\t");
                    Text($"{inventory[i].Amount}\n", ConsoleColor.DarkMagenta);
                }
            }
            Text("\n");

            Text(" [<] ".PadLeft(30, ' '), ConsoleColor.DarkMagenta);
            Text($"back\n\n");
        }

        public static void BossFight()
        {
            Text($@"{"\t"} ___    ___    ___   ___       ___   ___    ___   _  _   _____ {"\n"}", ConsoleColor.DarkYellow, slow: true, line: true);
            Text($@"{"\t"}| _ )  / _ \  / __| / __|     | __| |_ _|  / __| | || | |_   _|{"\n"}", ConsoleColor.Red, slow: true, line: true);
            Text($@"{"\t"}| _ \ | (_) | \__ \ \__ \     | _|   | |  | (_ | | __ |   | |  {"\n"}", ConsoleColor.DarkRed, slow: true, line: true);
            Text($@"{"\t"}|___/  \___/  |___/ |___/     |_|   |___|  \___| |_||_|   |_|  {"\n\n"}", ConsoleColor.DarkMagenta, slow: true, line: true);
        }

        public static void YouDied()
        {
            Text($@"{"\t"}__   __   ___    _   _       ___    ___   ___   ___  {"\n"}", ConsoleColor.DarkYellow, slow: true, line: true);
            Text($@"{"\t"}\ \ / /  / _ \  | | | |     |   \  |_ _| | __| |   \ {"\n"}", ConsoleColor.Red, slow: true, line: true);
            Text($@"{"\t"} \ V /  | (_) | | |_| |     | |) |  | |  | _|  | |) |{"\n"}", ConsoleColor.DarkRed, slow: true, line: true);
            Text($@"{"\t"}  |_|    \___/   \___/      |___/  |___| |___| |___/ {"\n\n"}", ConsoleColor.DarkMagenta, slow: true, line: true);
            Text("your journey is over :(".PadLeft(45, ' '), ConsoleColor.Red, slow: true);

            Thread.Sleep(3000);
            Text("\n\nPress Enter to exit");
            Console.ReadLine();
        }

        public static void BossVanquished()
        {
            Text($@"{"\t"} ___    ___    ___   ___     __   __    _     _  _    ___    _   _   ___   ___   _  _   ___   ___  {"\n"}", ConsoleColor.Cyan, slow: true, line: true);
            Text($@"{"\t"}| _ )  / _ \  / __| / __|    \ \ / /   /_\   | \| |  / _ \  | | | | |_ _| / __| | || | | __| |   \ {"\n"}", ConsoleColor.DarkCyan, slow: true, line: true);
            Text($@"{"\t"}| _ \ | (_) | \__ \ \__ \     \ V /   / _ \  | .` | | (_) | | |_| |  | |  \__ \ | __ | | _|  | |) |{"\n"}", ConsoleColor.Blue, slow: true, line: true);
            Text($@"{"\t"}|___/  \___/  |___/ |___/      \_/   /_/ \_\ |_|\_|  \__\_\  \___/  |___| |___/ |_||_| |___| |___/ {"\n"}", ConsoleColor.DarkBlue, slow: true, line: true);
        }

        public static void AdventureBegins()
        {
            Text($@"{"\t"}   _     ___   __   __  ___   _  _   _____   _   _   ___   ___       ___   ___    ___   ___   _  _   ___ {"\n"}", ConsoleColor.Green, slow: true, line: true);
            Text($@"{"\t"}  /_\   |   \  \ \ / / | __| | \| | |_   _| | | | | | _ \ | __|     | _ ) | __|  / __| |_ _| | \| | / __|{"\n"}", ConsoleColor.DarkGreen, slow: true, line: true);
            Text($@"{"\t"} /(_)\  | |) |  \ V /  | _|  | .` |   | |   | |_| | |   / | _|      | _ \ | _|  | (_ |  | |  | .` | \__ \{"\n"}", ConsoleColor.Blue, slow: true, line: true);
            Text($@"{"\t"}/_/ \_\ |___/    \_/   |___| |_|\_|   |_|    \___/  |_|_\ |___|     |___/ |___|  \___| |___| |_|\_| |___/{"\n\n"}", ConsoleColor.DarkBlue, slow: true, line: true);
        }

        public static void TheEnd(Player player, Item[] inventory)
        {
            Console.Clear();

            Text($@"{"\t"} _________          _______      _______  _        ______  { "\n"}", ConsoleColor.Cyan, slow: true, line: true);
            Text($@"{"\t"} \__   __/|\     /|(  ____ \    (  ____ \( (    /|(  __  \ {"\n"}", ConsoleColor.DarkCyan, slow: true, line: true);
            Text($@"{"\t"}    ) (   | )   ( || (    \/    | (    \/|  \  ( || (  \  ){"\n"}", ConsoleColor.Blue, slow: true, line: true);
            Text($@"{"\t"}    | |   | (___) || (__        | (__    |   \ | || |   ) |{"\n"}", ConsoleColor.DarkBlue, slow: true, line: true);
            Text($@"{"\t"}    | |   |  ___  ||  __)       |  __)   | (\ \) || |   | |{ "\n"}", ConsoleColor.DarkMagenta, slow: true, line: true);
            Text($@"{"\t"}    | |   | (   ) || (          | (      | | \   || |   ) |{"\n"}", ConsoleColor.DarkBlue, slow: true, line: true);
            Text($@"{"\t"}    | |   | )   ( || (____/\    | (____/\| )  \  || (__/  ){"\n"}", ConsoleColor.Blue, slow: true, line: true);
            Text($@"{"\t"}    )_(   |/     \|(_______/    (_______/|/    )_)(______/ {"\n"}", ConsoleColor.Cyan, slow: true, line: true);

            Text("\n");
            Text("".PadLeft(45, '>') + "\n", ConsoleColor.Magenta);
            Text($" {player.Name}", ConsoleColor.DarkCyan);
            Text(" / ");
            Text($"{player.Gender}", ConsoleColor.DarkGray);
            Text(" / ");
            Text($"{player.Class}\n\n", ConsoleColor.DarkGreen);
            Text(" LVL:\t\t ");
            Text($"{player.Lvl}\n", ConsoleColor.DarkGreen);
            Text(" EXP:\t\t ");
            Text($"{player.Exp}\n", ConsoleColor.Green);
            Text($" GOLD:\t\t {player.Gold}\n", ConsoleColor.DarkYellow);
            Text(" enemies killed: ");
            Text($"{Game.DefeatedEnemiesOverall}\n", ConsoleColor.DarkGreen);
            Text(" bosses killed:\t ");
            Text($"{Game.DefeatedBossesOverall}\n", ConsoleColor.Green);

            //if you have bought any weapon
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i].WeaponIsBought)
                {
                    Text(" weapon:\t ");
                    Text($"{inventory[i].Title}\n", ConsoleColor.DarkCyan);
                    break;
                }
            }

            Text("".PadLeft(45, '<') + "\n\n", ConsoleColor.Magenta);

            Thread.Sleep(3000);
            Text("Press Enter to exit");
            Console.ReadLine();
        }

        public static void GameTitle()
        {
            Text($@"{"\t"} _______ _________ _______  _______  _       __________________         {"\n"}", ConsoleColor.Cyan, slow: true, line: true);
            Text($@"{"\t"}(  ____ \\__   __/(  ____ \(  ____ )( (    /|\__   __/\__   __/|\     /|{"\n"}", ConsoleColor.DarkCyan, slow: true, line: true);
            Text($@"{"\t"}| (    \/   ) (   | (    \/| (    )||  \  ( |   ) (      ) (   ( \   / ){"\n"}", ConsoleColor.Blue, slow: true, line: true);
            Text($@"{"\t"}| (__       | |   | (__    | (____)||   \ | |   | |      | |    \ (_) / {"\n"}", ConsoleColor.DarkBlue, slow: true, line: true);
            Text($@"{"\t"}|  __)      | |   |  __)   |     __)| (\ \) |   | |      | |     \   /  {"\n"}", ConsoleColor.DarkMagenta, slow: true, line: true);
            Text($@"{"\t"}| (         | |   | (      | (\ (   | | \   |   | |      | |      ) (   {"\n"}", ConsoleColor.DarkBlue, slow: true, line: true);
            Text($@"{"\t"}| (____/\   | |   | (____/\| ) \ \__| )  \  |___) (___   | |      | |   {"\n"}", ConsoleColor.Blue, slow: true, line: true);
            Text($@"{"\t"}(_______/   )_(   (_______/|/   \__/|/    )_)\_______/   )_(      \_/   {"\n\n"}", ConsoleColor.Cyan, slow: true, line: true);
        }

        public static void EntryBattlePhrase(Character enemy)
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

            Text($"{entryPhrase[random.Next(0, 10)]}");
        }

        public static void RainbowLoading(int length = 8, bool consoleClear = false)
        {
            Text("\n");
            for (int i = 0; i <= length; i++)
            {
                Text("|", ConsoleColor.Red, slow: true);
                Text("|", ConsoleColor.DarkYellow, slow: true);
                Text("|", ConsoleColor.Yellow, slow: true);
                Text("|", ConsoleColor.Green, slow: true);
                Text("|", ConsoleColor.Cyan, slow: true);
                Text("|", ConsoleColor.DarkBlue, slow: true);
                Text("|", ConsoleColor.DarkMagenta, slow: true);
                Text("|", ConsoleColor.DarkBlue, slow: true);
                Text("|", ConsoleColor.Cyan, slow: true);
                Text("|", ConsoleColor.Green, slow: true);
                Text("|", ConsoleColor.Yellow, slow: true);
                Text("|", ConsoleColor.DarkYellow, slow: true);
            }

            Text("|", ConsoleColor.Red, slow: true);
            Text("|", ConsoleColor.DarkYellow, slow: true);
            Text("|", ConsoleColor.Yellow, slow: true);
            Text("|", ConsoleColor.Green, slow: true);
            Text("|", ConsoleColor.Cyan, slow: true);
            Text("|", ConsoleColor.DarkBlue, slow: true);
            Text("|\n", ConsoleColor.DarkMagenta, slow: true);

            if (consoleClear) Console.Clear();
        }

        public static void PressEnter()
        {
            Thread.Sleep(1500);
            Text("Press Enter to continue");
            Console.ReadLine();
        }

        public static void PlayerStatistics(Player player, Item[] inventory)
        {
            double minDamage = player.MinDamage;
            double maxDamage = player.MaxDamage;

            Text("\n");
            Text("".PadLeft(45, '>') + "\n", ConsoleColor.Magenta);
            Text($" {player.Name}", ConsoleColor.DarkCyan);
            Text(" / ");
            Text($"{player.Gender}", ConsoleColor.DarkGray);
            Text(" / ");
            Text($"{player.Class}\n\n", ConsoleColor.DarkGreen);
            Text(" LVL:\t\t");
            Text($"{player.Lvl}\n", ConsoleColor.DarkGreen);
            Text(" EXP:\t\t");
            Text($"{player.Exp}\t", ConsoleColor.Green);
            Text("/ ");
            Text($"lvl {player.NextLvl}\n", ConsoleColor.DarkCyan);
            Text(" HP:\t\t");
            Text($"{player.HP}\t", ConsoleColor.DarkGreen);
            Text("/ ");
            Text($"max {player.MaxHP}\n", ConsoleColor.DarkCyan);
            Text(" DMG:\t\t");

            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i].WeaponIsBought)
                {
                    minDamage += inventory[i].Damage;
                    maxDamage += inventory[i].Damage;
                }

                if (inventory[i].BuffIsActive)
                {
                    minDamage += inventory[i].BuffPower;
                    maxDamage += inventory[i].BuffPower;
                }
            }

            Text($"{minDamage}", ConsoleColor.Green);
            Text(" - ");
            Text($"{maxDamage}\n", ConsoleColor.Green);

            Text(" CRIT:\t\t");
            Text($"{player.CritChance}\n", ConsoleColor.DarkGreen);
            Text(" LUCK:\t\t");
            Text($"{player.Luck}\n\n", ConsoleColor.Green);

            Text($" GOLD:\t\t{player.Gold}\n", ConsoleColor.DarkYellow);

            //if you have bought any weapon
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i].WeaponIsBought)
                {
                    Text(" WEAPON:\t");
                    Text($"{inventory[i].Title}  ", ConsoleColor.DarkCyan);
                    Text($"+{inventory[i].Damage} DMG\n", ConsoleColor.DarkRed);
                    break;
                }
            }

            //if you have active buff
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i].BuffIsActive)
                {
                    Text(" ELIXIR:\t");
                    Text($"{inventory[i].Title}  ", ConsoleColor.DarkCyan);
                    Text($"+{inventory[i].BuffPower} DMG", ConsoleColor.DarkRed);
                    Text($" / ");
                    Text($"{inventory[i].CurrentDurationOfEffect} hits left\n", ConsoleColor.DarkRed);
                    break;
                }
            }

            Text("".PadLeft(45, '<') + "\n\n", ConsoleColor.Magenta);
        }

        public static void Text(string text, ConsoleColor color = ConsoleColor.White, bool slow = false, bool line = false, int speed = 5, bool consoleClear = false)
        {
            if (consoleClear) Console.Clear();

            //slowly printing in the specified color
            if (slow)
            {
                Console.ForegroundColor = color;

                if (line)
                {
                    Console.Write(text);
                    Thread.Sleep(200);
                }

                else
                {
                    char[] letters = text.ToCharArray();

                    foreach (char element in letters)
                    {
                        Console.Write(element);
                        Thread.Sleep(speed);
                    }
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

        public static void Question(string text, ConsoleColor color = ConsoleColor.Green)
        {
            Text($"{text}");
            Text(" [y] ", color);
            Text("/");
            Text(" [n]", color);
            Text(": ");
        }
    }
}
