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
                Health = (int)(((Health / 100) * 10) + Health);
                MinDamage = (int)(((MinDamage / 100) * 10) + MinDamage);
                MaxDamage = (int)(((MaxDamage / 100) * 10) + MaxDamage);

                Print.Text($"\tYou have promoted to level {Lvl}\n", ConsoleColor.DarkGreen);
            }
        }

        public override void Attack(Player player, Enemy enemy, double playerDamage)
        {
            enemy.CurrentHealth -= playerDamage;

            if (enemy.CurrentHealth <= 0)
            {
                Print.Text($"\n\t{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text($"{NormalAttackPhrase} deals ");
                Print.Text($"{playerDamage} DMG", ConsoleColor.DarkGreen);
                Print.Text(", ");
                Print.Text($"{enemy.Name} ", ConsoleColor.DarkMagenta);
                Print.Text("died\n");

                if (enemy.GetType() == typeof(boss1) ||
                    enemy.GetType() == typeof(boss2) ||
                    enemy.GetType() == typeof(boss3) ||
                    enemy.GetType() == typeof(boss4))
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
                Print.Text($"\n\t{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text($"{NormalAttackPhrase} deals ");
                Print.Text($"{playerDamage} DMG", ConsoleColor.DarkGreen);
                Print.Text(", ");
                Print.Text($"{enemy.Name} ", ConsoleColor.DarkMagenta);
                Print.Text("has ");
                Print.Text($"{enemy.CurrentHealth} HP\n", ConsoleColor.DarkRed);
            }
        }

        public override void SpecialAttack(Player player, Enemy enemy, double playerDamage)
        {
            enemy.CurrentHealth -= playerDamage *= random.Next(2, 4);

            if (enemy.CurrentHealth <= 0)
            {
                Print.Text($"\n\t{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text($"{SpecialAttackPhrase} deals ");
                Print.Text($"CRITICAL {playerDamage} DMG", ConsoleColor.DarkGreen);
                Print.Text(", ");
                Print.Text($"{enemy.Name} ", ConsoleColor.DarkMagenta);
                Print.Text("died\n");

                if (enemy.GetType() == typeof(boss1) ||
                    enemy.GetType() == typeof(boss2) ||
                    enemy.GetType() == typeof(boss3) ||
                    enemy.GetType() == typeof(boss4))
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
                Print.Text($"\n\t{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text($"{SpecialAttackPhrase} deals ");
                Print.Text($"CRITICAL {playerDamage} DMG", ConsoleColor.DarkGreen);
                Print.Text(", ");
                Print.Text($"{enemy.Name} ", ConsoleColor.DarkMagenta);
                Print.Text("has ");
                Print.Text($"{enemy.CurrentHealth} HP\n", ConsoleColor.DarkRed);
            }
        }
    }
}
