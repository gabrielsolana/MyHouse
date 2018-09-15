namespace MyHouse
{
    public class RoomWithHidingPlace : Room, IHidingPlace
    {
        public RoomWithHidingPlace(string name, string decoration, string hidingPlace) : base(name, decoration)
        {
            HidingPlace = hidingPlace;
        }

        public string HidingPlace { get; }

        public override string Description
        {
            get
            {
                return base.Description + $". Alguien podría esconderse en {HidingPlace}";
            }
        }
       
        
    }
}