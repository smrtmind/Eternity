using System;

namespace EternityRPG
{
    public class Enemy : Character
    {
        public int TypeOfEnemy { get; set; }
        public string AttackPhrase { get; set; }

        public Enemy(int typeOfEnemy)
        {
            TypeOfEnemy = typeOfEnemy;
            CreateEnemy();
        }

        private void CreateEnemy()
        {
            switch (TypeOfEnemy)
            {
                case 1:
                    Name = "Stinky rat";
                    Health = 20;
                    CurrentHealth = Health;
                    MinDamage = 4;
                    MaxDamage = 9;
                    Gold = 10;
                    Exp = 25;
                    ChanceToInterruptTheEscape = 10;
                    AttackPhrase = "shoots claws";
                    break;

                case 2:
                    Name = "Sticky frog";
                    Health = 40;
                    CurrentHealth = Health;
                    MinDamage = 8;
                    MaxDamage = 13;
                    Gold = 20;
                    Exp = 45;
                    ChanceToInterruptTheEscape = 13;
                    AttackPhrase = "attacks with a vile tongue";
                    break;

                case 3:
                    Name = "Poison ivy";
                    Health = 70;
                    CurrentHealth = Health;
                    MinDamage = 12;
                    MaxDamage = 17;
                    Gold = 35;
                    Exp = 60;
                    ChanceToInterruptTheEscape = 16;
                    AttackPhrase = "sprinkles with poisonous mucus";
                    break;

                case 4:
                    Name = "Bloody bat";
                    Health = 100;
                    CurrentHealth = Health;
                    MinDamage = 16;
                    MaxDamage = 21;
                    Gold = 50;
                    Exp = 80;
                    ChanceToInterruptTheEscape = 20;
                    AttackPhrase = "bites the body with its teeth";
                    break;

                case 5:
                    Name = "Dark whisperer";
                    Health = 130;
                    CurrentHealth = Health;
                    MinDamage = 20;
                    MaxDamage = 25;
                    Gold = 70;
                    Exp = 100;
                    ChanceToInterruptTheEscape = 23;
                    AttackPhrase = "releases a psychedelic wave";
                    break;

                case 6:
                    Name = "Goblin";
                    Health = 160;
                    CurrentHealth = Health;
                    MinDamage = 24;
                    MaxDamage = 29;
                    Gold = 85;
                    Exp = 135;
                    ChanceToInterruptTheEscape = 26;
                    AttackPhrase = "hits with a terrifying mace";
                    break;

                case 7:
                    Name = "Fire thorn";
                    Health = 250;
                    CurrentHealth = Health;
                    MinDamage = 28;
                    MaxDamage = 33;
                    Gold = 100;
                    Exp = 150;
                    ChanceToInterruptTheEscape = 30;
                    AttackPhrase = "shoots many spikes";
                    break;

                case 8:
                    Name = "Ork warrior";
                    Health = 300;
                    CurrentHealth = Health;
                    MinDamage = 32;
                    MaxDamage = 37;
                    Gold = 120;
                    Exp = 180;
                    ChanceToInterruptTheEscape = 33;
                    AttackPhrase = "attacks with spear and shield";
                    break;

                case 9:
                    Name = "Mutant";
                    Health = 340;
                    CurrentHealth = Health;
                    MinDamage = 36;
                    MaxDamage = 41;
                    Gold = 140;
                    Exp = 230;
                    ChanceToInterruptTheEscape = 36;
                    AttackPhrase = "hits with claws from the ground";
                    break;
            }
        }

        public override void Turn(Character player, Character[] enemy, double enemyDamage, int index)
        {
            if (player.CurrentHealth <= 0)
            {
                Print.Text($"\t{enemy[index].Name} ", ConsoleColor.DarkMagenta);
                Print.Text($"{AttackPhrase} deals ");
                Print.Text($"{enemyDamage} DMG", ConsoleColor.DarkRed);
                Print.Text(", ");
                Print.Text($"{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text("died\n");
            }

            else
            {
                Print.Text($"\t{enemy[index].Name} ", ConsoleColor.DarkMagenta);
                Print.Text($"{AttackPhrase} deals ");
                Print.Text($"{enemyDamage} DMG", ConsoleColor.DarkRed);
                Print.Text(", ");
                Print.Text($"{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text("have ");
                Print.Text($"{player.CurrentHealth} HP\n\n", ConsoleColor.DarkGreen);
            }
        }
    }
}
