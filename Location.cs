using System;

namespace EternityRPG
{
    public class Location
    {
        public string LocationInfo { get; set; }
        public string ShortTitle { get; set; }
        public int TypeOfLocation { get; set; }

        public Location(int typeOfLocation)
        {
            TypeOfLocation = typeOfLocation;
            CreateLocation();
        }

        private void CreateLocation()
        {
            switch (TypeOfLocation)
            {
                case 1:
                    LocationInfo = "You are stepped forward to a deep dark forest. Prepare to defend yourself.\n";
                    ShortTitle = "Dark forest";
                    break;

                case 2:
                    LocationInfo = "You see a large system of tangled caves in front of you. It's time to go.\n";
                    ShortTitle = "Caves";
                    break;

                case 3:
                    LocationInfo = "The heat from volcanic rocks burns your body, you need to move forward, it is dangerous to stand still.\n";
                    ShortTitle = "Volcano";
                    break;

                case 4:
                    LocationInfo = "It is the last fight. You see a lot of bloody corps in the area, but it is not going to stop you. You came here to kill this monster.\n";
                    ShortTitle = "Lair of true evil";
                    break;
            }
        }

        public Character CreateEnemy()
        {
            Random random = new Random();
            Character enemy = new Enemy();

            if (TypeOfLocation == 1) enemy = new Enemy(random.Next(1, 4));
            if (TypeOfLocation == 2) enemy = new Enemy(random.Next(4, 7));
            if (TypeOfLocation == 3) enemy = new Enemy(random.Next(7, 10));

            return enemy;
        }
    }
}
