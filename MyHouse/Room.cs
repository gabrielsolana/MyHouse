namespace MyHouse
{
    public class Room : Location
    {
        private string decoration;

        public Room(string name, string decoration) : base(name)
        {
            this.decoration = decoration;
        }

        public override string Description
        {
            get
            {
                var description = base.Description;
                description += $" Ves {this.decoration}.";

                return description;
            }
        }
    }
}