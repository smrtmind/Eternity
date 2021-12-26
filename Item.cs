namespace EternityRPG
{
    public abstract class Item
    {
        public int HealingPower { get; set; }
        public string Title { get; set; }
        public int Cost { get; set; }
        public int Amount { get; set; } = 0;
        public bool WeaponIsBought { get; set; } = false;
        public int Damage { get; set; }
        public bool BuffIsActive { get; set; } = false;
        public int MaxDurationOfEffect { get; set; }
        public int CurrentDurationOfEffect { get; set; }
        public int BuffPower { get; set; }

        public abstract void Buy(Player player, Item[] inventory, int choice);

        public abstract void Use(Player player, Item[] inventory, int choice);
    }
}
