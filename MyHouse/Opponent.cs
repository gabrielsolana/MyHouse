using System;

namespace MyHouse
{
    public class Opponent
    {
        private Location myLocation;
        private Random random;

        public Opponent(Location startingLocation)
        {
            this.myLocation = startingLocation;
            random = new Random();
        }

        public void Move()
        {
            if (myLocation is IHasExteriorDoor)
            {
                var location = myLocation as IHasExteriorDoor;
                if (random.Next(2) == 1)
                    myLocation = location.DoorLocation;
            }

            myLocation = myLocation.Exits[random.Next(myLocation.Exits.Length - 1)];
            if (myLocation is IHidingPlace)
                return;
            else
                Move();
        }

        public bool Check(Location location)
        {
            return myLocation == location;
        }
    }
}