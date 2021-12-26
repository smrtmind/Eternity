using System;
using System.Collections.Generic;

namespace EternityRPG
{
    public class Game
    {
        public static int DefeatedEnemiesToFightTheBoss { get; set; }
        public static int DefeatedEnemiesOverall { get; set; }
        public static int DefeatedBossesOverall { get; set; }

        public static Random random = new Random();
        public static Player player = new Player();
        public static Enemy enemy;
        public static Enemy[] bosses;
        public static Biome[] biomes;
        public static Item[] inventory;

        public static Dictionary<int, string> genders = new Dictionary<int, string>
        {
            { 1, "male" },
            { 2, "female" }
        };

        public static Dictionary<int, string> classes = new Dictionary<int, string>
        {
            { 1, "warrior" },
            { 2, "archer" },
            { 3, "mage" }
        };

        public static Dictionary<int, string> directions = new Dictionary<int, string>
        {
            { 1, "shop" },
            { 2, "locations" },
            { 3, "stats" }
        };

        public static Dictionary<int, string> battleOptions = new Dictionary<int, string>
        {
            { 1, "attack" },
            { 2, "auto attack" },
            { 3, "healing items" },
            { 4, "power elixirs" },
            { 5, "run away" }
        };

        public static void CreatePlayer()
        {
            //creating player according to the chosen name/gender/class
            switch (player.Class)
            {
                case "warrior":
                    player = new Warrior(player.Name, player.Gender, player.Class);
                    break;

                case "archer":
                    player = new Archer(player.Name, player.Gender, player.Class);
                    break;

                case "mage":
                    player = new Mage(player.Name, player.Gender, player.Class);
                    break;
            }
        }

        public static void InitializeWorld(int worldSize = 4)
        {
            bosses = new Enemy[worldSize];
            biomes = new Biome[worldSize];

            for (int i = 0; i < worldSize; i++)
            {
                bosses[i] = new Boss(bossType: i + 1);
                biomes[i] = new Biome(biomeType: i + 1);
            }

            inventory = new Item[]
            {
                new Potion(potionType: 1),
                new Potion(potionType: 2),
                new Potion(potionType: 3),
                new Buff(buffType: 1),
                new Buff(buffType: 2),
                new Buff(buffType: 3),
                new Weapon(player.Class, weaponType: 1),
                new Weapon(player.Class, weaponType: 2)
            };
        }
    }
}
