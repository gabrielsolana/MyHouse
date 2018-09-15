using System;

namespace MyHouse
{
    public class Opponent
    {
        public Opponent(Location startingLocation)
        {
            this.myLocation = startingLocation;
            random = new Random();
        }

        private Location myLocation;
        private Random random;

        public void Move()
        {
            bool hidden = false;

            while (!hidden)
            {
                if (myLocation is IHasExteriorDoor)
                {
                    var locationWithDoor = myLocation as IHasExteriorDoor;
                    if (random.Next(2) == 1)
                        myLocation = locationWithDoor.DoorLocation;
                }

                int randomExit = random.Next(myLocation.Exits.Length - 1);
                myLocation = myLocation.Exits[randomExit];

                if (myLocation is IHidingPlace)
                    hidden = true;
            }
           
        }

        public bool Check(Location locationToCheck)
        {
            return myLocation == locationToCheck;
        }
    }
}