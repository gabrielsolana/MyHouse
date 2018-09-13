namespace MyHouse
{
    public class OutsideWithHidingPlace : Outside, IHidingPlace
    {
        public OutsideWithHidingPlace(string name, bool hot) : base(name, hot)
        {
        }

        public string HidingPlace { get; }
    }
}