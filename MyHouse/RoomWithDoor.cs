namespace MyHouse
{
    public class RoomWithDoor: RoomWithHidingPlace, IHasExteriorDoor
    {
        public RoomWithDoor(string name, string decoration, string doorDescription, string hidingPlace) : base(name, decoration, hidingPlace)
        {
            DoorDescription = doorDescription;
        }

        public string DoorDescription { get; }

        public Location DoorLocation { get; set; }
    }
}