using System;

namespace EternityRPG
{
    public class Biome
    {
        Random random = new Random();
        public string LocationInfo { get; set; }
        public string ShortTitle { get; set; }
        public int FirstMob { get; set; }
        public int LastMob { get; set; }

        public Biome(int biomeType) => CreateLocation(biomeType);

        private void CreateLocation(int biomeType)
        {
            switch (biomeType)
            {
                case 1:
                    LocationInfo = "You are stepped forward to a deep dark forest. Prepare to defend yourself.\n";
                    ShortTitle = "Dark forest";
                    FirstMob = 1;
                    LastMob = 4;
                    break;

                case 2:
                    LocationInfo = "You see a large system of tangled caves in front of you. It's time to go.\n";
                    ShortTitle = "Mysterious caves";
                    FirstMob = 4;
                    LastMob = 7;
                    break;

                case 3:
                    LocationInfo = "The heat from volcanic rocks burns your body, you need to move forward, it is dangerous to stand still.\n";
                    ShortTitle = "Ancient volcano";
                    FirstMob = 7;
                    LastMob = 10;
                    break;

                case 4:
                    LocationInfo = "It is the last fight. You see a lot of bloody corps in the area, but it is not going to stop you. You came here to kill this monster.\n";
                    ShortTitle = "Lair of true evil";
                    break;
            }
        }

        public Enemy CreateEnemy() => new Mob(random.Next(FirstMob, LastMob));
    }
}
