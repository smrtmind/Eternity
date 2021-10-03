namespace EternityRPG
{
    public class MedicineBag
    {
        //1. small, 2. medium, 3. high
        public int[] HealingPower = { 90, 180, 350 };
        public int[] Cost = { 30, 90, 150 };
        public int[] Amount = new int[3];
        public string[] Title =
        {
            "small healing potion",
            "medium healing potion",
            "big healing potion"
        };

        public MedicineBag() { }

        public void AddPotion(int potionType)
        {
            switch (potionType)
            {
                case 1:
                    Amount[0]++;
                    break;

                case 2:
                    Amount[1]++;
                    break;

                case 3:
                    Amount[2]++;
                    break;
            }
        }

        public int UsePotion(int potionType)
        {
            int amount = 0;

            switch (potionType)
            {
                case 1:
                    if (Amount[0] > 0) amount = Amount[0]--;
                    else
                    {
                        Amount[0] = 0;
                        amount = 0;
                    }
                   
                    break;

                case 2:
                    if (Amount[1] > 0) amount = Amount[1]--;
                    else
                    {
                        Amount[1] = 0;
                        amount = 0;
                    }

                    break;

                case 3:
                    if (Amount[2] > 0) amount = Amount[2]--;
                    else
                    {
                        Amount[2] = 0;
                        amount = 0;
                    }

                    break;
            }

            return amount;
        }
    }
}
