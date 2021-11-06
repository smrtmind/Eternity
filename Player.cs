using System;

namespace EternityRPG
{
    public class Player : Character
    {
        public string Gender { get; protected set; }
        public string Class { get; protected set; }
        public int Lvl { get; private set; } = 1;
        public double NextLvl { get; private set; } = 150;

        public Player() { }

        public void SetName(string keyBoardInput)
        {
            if (keyBoardInput.Length > 0)
                Name = keyBoardInput;
            else Name = "Ash";
        }

        public void SetGender(int choice)
        {
            if (choice == 1) Gender = "male";
            if (choice == 2) Gender = "female";
        }

        public void SetClass(int choice)
        {
            if (choice == 1) Class = "warrior";
            if (choice == 2) Class = "archer";
            if (choice == 3) Class = "mage";
        }

        public Player CreatePlayer()
        {
            if (Class == "warrior") return new Warrior(Name, Gender, Class);
            if (Class == "archer") return new Archer(Name, Gender, Class);
            else return new Mage(Name, Gender, Class);
        }

        public double GenerateDamage(Item[] weapon)
        {
            if (weapon[3].WeaponIsBought)
                Damage = random.Next((int)MinDamage, (int)MaxDamage) + weapon[3].Damage;

            if (weapon[4].WeaponIsBought)
                Damage = random.Next((int)MinDamage, (int)MaxDamage) + weapon[4].Damage;

            return Damage;
        }

        public void LevelUp(int exp)
        {
            if (exp >= NextLvl)
            {
                NextLvl = (int)(((NextLvl / 100) * 50) + NextLvl);

                Lvl++;
                MaxHP = (int)(((MaxHP / 100) * 10) + MaxHP);
                MinDamage = (int)(((MinDamage / 100) * 10) + MinDamage);
                MaxDamage = (int)(((MaxDamage / 100) * 10) + MaxDamage);

                Print.Text($"\tYou have promoted to level {Lvl} ", ConsoleColor.DarkGreen);
                Print.Text("HP+ / DMG+\n");
            }
        }

        public override void Attack(Player player, Enemy enemy, double playerDamage, bool crit = false)
        {
            if (!crit) enemy.HP -= playerDamage;
            else enemy.HP -= playerDamage *= random.Next(2, 4);

            Print.Text($"\n\t{player.Name} ", ConsoleColor.DarkCyan);
            if (!crit)
            {
                Print.Text($"{NormalAttackPhrase} deals ");
                Print.Text($"{playerDamage} DMG", ConsoleColor.DarkGreen);
            }
            else
            {
                Print.Text($"{CriticalAttackPhrase} deals ");
                Print.Text($"CRITICAL {playerDamage} DMG", ConsoleColor.DarkGreen);
            }
            Print.Text(", ");
            Print.Text($"{enemy.Name} ", ConsoleColor.DarkMagenta);

            if (enemy.HP <= 0)
            {
                Print.Text("died\n");

                if (enemy is Boss)
                {
                    enemy.IsDead = true;
                    Print.BossVanquished();
                    Print.Text($"\n\tYou have earned {enemy.Gold} gold and {enemy.Exp} exp\n", ConsoleColor.DarkYellow);
                }

                else
                    Print.Text($"\n\tVICTORY. +{enemy.Gold} gold / +{enemy.Exp} exp\n", ConsoleColor.DarkYellow);
            }
                
            else
            {
                Print.Text("has ");
                Print.Text($"{enemy.HP} HP\n", ConsoleColor.DarkRed);
            }
        }
    }
}
