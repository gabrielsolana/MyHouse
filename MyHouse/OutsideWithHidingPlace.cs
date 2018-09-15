namespace MyHouse
{
    public class OutsideWithHidingPlace : Outside, IHidingPlace
    {
        public OutsideWithHidingPlace(string name, bool hot, string hidingPlace) : base(name, hot)
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