namespace MyHouse
{
    public class RoomWithHidingPlace : RoomWithDoor, IHidingPlace
    {
        public RoomWithHidingPlace(string name, string decoration, string doorDescription) : base(name, decoration, doorDescription)
        {
        }

        public string HidingPlace { get; }
    }
}