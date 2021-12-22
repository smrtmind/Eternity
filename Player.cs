using System;

namespace EternityRPG
{
    public class Player : Character
    {
        public int Luck { get; protected set; }
        public string Gender { get; protected set; }
        public string Class { get; protected set; }
        public int Lvl { get; private set; } = 1;
        public double NextLvl { get; private set; } = 150;

        public Player() { }

        public void SetName(string name)
        {
            if (name.Length > 0)
                Name = name;
            else Name = "Ash";
        }

        public void SetGender(int choice) => Gender = Game.genders[choice];

        public void SetClass(int choice) => Class = Game.classes[choice];

        public void LevelUp(int exp)
        {
            if (exp >= NextLvl)
            {
                if (Lvl > 0 && Lvl <= 10)
                    NextLvl = (int)(((NextLvl / 100) * 50) + NextLvl);
                else
                    NextLvl = (int)(((NextLvl / 100) * 30) + NextLvl);

                Lvl++;
                CritChance++;
                Luck++;
                MaxHP = (int)(((MaxHP / 100) * 10) + MaxHP);
                MinDamage = (int)(((MinDamage / 100) * 10) + MinDamage);
                MaxDamage = (int)(((MaxDamage / 100) * 10) + MaxDamage);

                Print.Text($"\tYou have promoted to level {Lvl}\n", ConsoleColor.DarkGreen);
                Print.Text("\tHP+");
                Print.Text(" | ", ConsoleColor.DarkGray);
                Print.Text("DMG+");
                Print.Text(" | ", ConsoleColor.DarkGray);
                Print.Text("CRIT+");
                Print.Text(" | ", ConsoleColor.DarkGray);
                Print.Text("LUCK+\n");
            }
        }

        //20 is a low level of HP in percentage
        public double DangerousLevelOfHealth() => (int)((MaxHP / 100) * 20);

        public override void Attack(Player player, Enemy enemy, double playerDamage, bool crit = false)
        {
            Print.Text($"\n\t{player.Name} ", ConsoleColor.DarkCyan);
            if (!crit)
            {
                enemy.HP -= playerDamage;
                Print.Text($"{NormalAttackPhrase} deals ");
                Print.Text($"{playerDamage} DMG", ConsoleColor.DarkGreen);
            }
            else
            {
                enemy.HP -= playerDamage *= random.Next(2, 4);
                Print.Text($"{CriticalAttackPhrase} deals ");
                Print.Text($"CRITICAL {playerDamage} DMG", ConsoleColor.DarkGreen);
            }
            Print.Text(", ");
            Print.Text($"{enemy.Name} ", ConsoleColor.DarkMagenta);

            //if enemy died
            if (enemy.HP <= 0)
            {
                enemy.IsDead = true;
                Print.Text("died\n");

                //boss
                if (enemy is Boss)
                {
                    Print.BossVanquished();
                    Print.Text($"\n\t+{enemy.Gold} gold / +{enemy.Exp} exp\n", ConsoleColor.DarkYellow);
                }
                //common enemy
                else
                {
                    Print.Text($"\n\tVICTORY. +{enemy.Gold} gold / +{enemy.Exp} exp\n", ConsoleColor.DarkYellow);

                    //drop of items after victory, only regular mobs
                    if (random.Next(0, 100) <= player.Luck)
                    {
                        int typeOfPotion = random.Next(0, 3);

                        Game.inventory[typeOfPotion].Amount++;
                        Print.Text($"\t{enemy.Name} ", ConsoleColor.DarkMagenta);
                        Print.Text("has dropped ");
                        Print.Text($"{Game.inventory[typeOfPotion].Title} healing potion\n", ConsoleColor.DarkGreen);
                    }
                }
            }
            //otherwise continue    
            else
            {
                Print.Text("has ");
                Print.Text($"{enemy.HP} HP\n", ConsoleColor.DarkRed);
            }
        }
    }
}
