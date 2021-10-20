using System;

namespace EternityRPG
{
    public abstract class Character
    {
        public Random random = new Random();
        public string NormalAttackPhrase { get; protected set; }
        public string CriticalAttackPhrase { get; protected set; }
        public string Name { get; protected set; }
        public double Health { get; protected set; }
        public double CurrentHealth { get; set; }
        public double Damage { get; protected set; }
        public double MinDamage { get; protected set; }
        public double MaxDamage { get; protected set; }
        public int CritChance { get; set; } = 5;
        public int Exp { get; set; }
        public int Gold { get; set; }


        public double GenerateDamage() => Damage = random.Next((int) MinDamage, (int) MaxDamage);

        public abstract void Attack(Player player, Enemy enemy, double damage);

        public abstract void CriticalAttack(Player player, Enemy enemy, double damage);
    }
}
