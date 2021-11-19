﻿using System;
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

        public static Dictionary<int, string> Genders = new Dictionary<int, string>
        {
            { 1, "male" },
            { 2, "female" }
        };

        public static Dictionary<int, string> Classes = new Dictionary<int, string>
        {
            { 1, "warrior" },
            { 2, "archer" },
            { 3, "mage" }
        };

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

        /*
        public static void InitializeWorld(bool hardMode)
        {
            int sizeOfWorld;
            HardMode = hardMode;

            if (HardMode) 
                sizeOfWorld = 6;
            else sizeOfWorld = 4;

            bosses = new Enemy[sizeOfWorld];
            for (int i = 0; i < bosses.Length; i++)
                bosses[i] = new Boss(bossType: i + 1);

            biomes = new Biome[sizeOfWorld];
            for (int i = 0; i < bosses.Length; i++)
                biomes[i] = new Biome(biomeType: i + 1);

            inventory = new Item[]
            {
                new Potion(potionType: 1),
                new Potion(potionType: 2),
                new Potion(potionType: 3),
                new Weapon(player.Class, weaponType: 1),
                new Weapon(player.Class, weaponType: 2)
            };
        }
         */

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
