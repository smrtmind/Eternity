using System;

namespace EternityRPG
{
    public abstract class Character
    {
        public Random random = new Random();
        public string NormalAttackPhrase { get; set; }
        public string SpecialAttackPhrase { get; set; }
        public string Name { get; set; }
        public double Health { get; set; }
        public double CurrentHealth { get; set; }
        public double Damage { get; set; }
        public double MinDamage { get; set; }
        public double MaxDamage { get; set; }
        public int CritChance { get; set; } = 5;
        public int Exp { get; set; }
        public int Gold { get; set; }


        public double GenerateDamage() => Damage = random.Next((int) MinDamage, (int) MaxDamage);

        public virtual void Attack(Player player, Enemy enemy, double damage) { }

        public virtual void SpecialAttack(Player player, Enemy enemy, double damage) { }
    }
}
