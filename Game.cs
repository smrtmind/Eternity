using System;

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

        public static void InitializeWorld()
        {
            bosses = new Enemy[]
            {
                new Boss(bossType: 1),
                new Boss(bossType: 2),
                new Boss(bossType: 3),
                new Boss(bossType: 4)
            };

            biomes = new Biome[]
            {
                new Biome(biomeType: 1),
                new Biome(biomeType: 2),
                new Biome(biomeType: 3),
                new Biome(biomeType: 4)
            };

            inventory = new Item[]
            {
                new Potion(potionType: 1),
                new Potion(potionType: 2),
                new Potion(potionType: 3),
                new Weapon(player.Class, weaponType: 1),
                new Weapon(player.Class, weaponType: 2)
            };
        }

        public static int AmountOfPotions()
        {
            int amountOfPotions = default;

            for (int i = 0; i < inventory.Length; i++)
                if (inventory[i] is Potion)
                    amountOfPotions++;

            return amountOfPotions;
        }
    }
}
