namespace EternityRPG
{
    public class MedicineBag
    {
        public string Name { get; set; }
        public int HealingPower { get; set; }
        public int SmallAmount { get; set; }
        public int MediumAmount { get; set; }
        public int BigAmount { get; set; }
        public int SmallCost { get; set; } = 30;
        public int MediumCost { get; set; } = 90;
        public int BigCost { get; set; } = 150;
        public int Amount { get; set; }

        public MedicineBag() { }

        public void AddPotion(int potionType)
        {
            switch (potionType)
            {
                case 1:
                    SmallAmount++;
                    break;

                case 2:
                    MediumAmount++;
                    break;

                case 3:
                    BigAmount++;
                    break;
            }
        }

        public int UsePotion(int potionType)
        {
            switch (potionType)
            {
                case 1:
                    Name = "small healing potion";
                    HealingPower = 90;

                    if (SmallAmount > 0) Amount = SmallAmount--;
                    else
                    {
                        SmallAmount = 0;
                        Amount = 0;
                    }
                   
                    break;

                case 2:
                    Name = "medium healing potion";
                    HealingPower = 180;

                    if (MediumAmount > 0) Amount = MediumAmount--;
                    else
                    {
                        MediumAmount = 0;
                        Amount = 0;
                    }

                    break;

                case 3:
                    Name = "big healing potion";                 
                    HealingPower = 350;

                    if (BigAmount > 0) Amount = BigAmount--;
                    else
                    {
                        BigAmount = 0;
                        Amount = 0;
                    }

                    break;
            }

            return Amount;
        }
    }
}
